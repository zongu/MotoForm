
namespace MotoForm.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Autofac;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;
    using MotoForm.Model;
    using Newtonsoft.Json;

    public partial class Sale : Form
    {
        private Moto currentMoto;

        public Sale()
        {
            InitializeComponent();
            #region 機車資料
            this.cbLabel.Items.AddRange(Applibs.ConfigHelper.MotoLabel.Select(p => new ComboBoxItem { Key = p, Value = p }).ToArray());
            this.cbLabel.DisplayMember = "Key";
            this.cbLabel.ValueMember = "Value";
            this.cbLabel.SelectedIndex = 0;

            var powerSource = Enum.GetNames(typeof(MotoPowerSource))
                .Select((name, index) => new ComboBoxItem { Key = Applibs.ConfigHelper.GetPowerSourceDisplayName((MotoPowerSource)index), Value = $"{index}" });
            this.cbPowerSource.Items.AddRange(powerSource.ToArray());
            this.cbPowerSource.DisplayMember = "Key";
            this.cbPowerSource.ValueMember = "Value";
            this.cbPowerSource.SelectedIndex = 0;

            var gender = Enum.GetNames(typeof(GenderType))
                .Select((name, index) => new ComboBoxItem { Key = Applibs.ConfigHelper.GetGenderTypeDisplayName((GenderType)index), Value = $"{index}" });
            this.cbGender.Items.AddRange(gender.ToArray());
            this.cbGender.DisplayMember = "Key";
            this.cbGender.ValueMember = "Value";
            this.cbGender.SelectedIndex = 0;
            #endregion

            #region 維修資料
            var categoryNames = Enum.GetNames(typeof(RepairCategory))
                .Select((value, index) => new ComboBoxItem() { Key = Applibs.ConfigHelper.GetRepairCategoryDisplayName((RepairCategory)index), Value = $"{index}" });
            this.cbRepairCategory.Items.AddRange(categoryNames.ToArray());
            this.cbRepairCategory.DisplayMember = "Key";
            this.cbRepairCategory.ValueMember = "Value";
            this.cbRepairCategory.SelectedIndex = 0;

            var prinpalNames = Applibs.ConfigHelper.Users.Select(p => new ComboBoxItem() { Key = p.UserName, Value = p.UserName });
            this.cbPrincipal.Items.AddRange(prinpalNames.ToArray());
            this.cbPrincipal.DisplayMember = "Key";
            this.cbPrincipal.ValueMember = "Value";
            this.cbPrincipal.SelectedIndex = 0;
            #endregion
        }

        private void tabControllerChage(object sender, EventArgs e)
        {
            if (currentMoto == null && this.tabController.SelectedIndex != 0)
            {
                MessageBox.Show("請先載入機車資料!!");
                this.tabController.SelectedIndex = 0;
            }
            else if (this.tabController.SelectedIndex == 1)
            {
                this.cbRepairCategory.SelectedIndex = 0;
                this.dtpDateTime.Value = DateTime.Now;
                this.bindRepairCategoryItems();
                this.tbLastMaintainceMileage.Text = $"{this.getRepairRecords().FirstOrDefault()?.LastMaintainceMileage ?? 0}";
                this.tbMaintainceMileage.Text = $"{this.getRepairRecords().FirstOrDefault()?.LastMaintainceMileage ?? 0}";
            }
            else if(this.tabController.SelectedIndex == 2)
            {
                var record = this.getRepairRecords();
                if(record.Count() > 0)
                {
                    this.gvRepairReCords.DataSource = new BindingSource(record, null);
                    this.gvRepairReCords.Rows[0].Selected = true;
                    this.displayRepairItem();
                }
            }
        }

        #region 機車資料
        private void btnQueryMoto_Click(object sender, EventArgs e)
        {
            var data = this.QueryMotoData();
            if (data.Count() == 0)
            {
                MessageBox.Show("查無資料!!");
                return;
            }

            if (data.Count() > 1)
            {
                var motoDataSelect = new MotoDataListSelect(data);
                if (motoDataSelect.ShowDialog() == DialogResult.OK && motoDataSelect.motoId != -1)
                {
                    this.currentMoto = data.FirstOrDefault(p => p.MotoId == motoDataSelect.motoId);
                }
            }
            else
            {
                this.currentMoto = data.FirstOrDefault();
            }

            this.BindMotoDataToView();
        }

        private void btnAddMotoData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbMotoNumber.Text) || string.IsNullOrEmpty(this.tbOwnerName.Text) || string.IsNullOrEmpty(this.tbTelPhone.Text))
            {
                MessageBox.Show("車牌號碼、車主姓名、手機號碼為必填項目");
                return;
            }

            this.BindMotoDataToCurrentMoto();

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IMotoRepository>();
                var result = repo.InsertOne(this.currentMoto);
                if (result.Item1 != null)
                {
                    MessageBox.Show(result.Item1.Message);
                    this.currentMoto = null;
                    this.lbMotoNumber.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("新增機車資料完成!!");
                    this.BindMotoDataToView();
                }
            }
        }

        private void btnUpdateMotoData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lbMotoNumber.Text))
            {
                MessageBox.Show("尚未建立該資料!!");
                return;
            }

            if (string.IsNullOrEmpty(this.tbMotoNumber.Text) || string.IsNullOrEmpty(this.tbOwnerName.Text) || string.IsNullOrEmpty(this.tbTelPhone.Text))
            {
                MessageBox.Show("車牌號碼、車主姓名、手機號碼為必填項目");
                return;
            }

            this.BindMotoDataToCurrentMoto();

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IMotoRepository>();
                var result = repo.UpdateOne(this.currentMoto);
                if (result.Item1 != null)
                {
                    MessageBox.Show(result.Item1.Message);
                    this.currentMoto = null;
                    this.lbMotoNumber.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("更新機車資料完成!!");
                }
            }
        }

        private void btnDeleteMotoData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lbMotoNumber.Text))
            {
                MessageBox.Show("尚未建立該資料!!");
                return;
            }

            if (MessageBox.Show("確定刪除該資料?", "Warring", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IMotoRepository>();
                var result = repo.Disable(this.currentMoto.MotoId);
                if (result.Item1 != null)
                {
                    MessageBox.Show(result.Item1.Message);
                }

                this.currentMoto = null;
                this.lbMotoNumber.Text = string.Empty;
                this.tbAddress.Text = string.Empty;
                this.tbColor.Text = string.Empty;
                this.tbEngineNumber.Text = string.Empty;
                this.tbLine.Text = string.Empty;
                this.tbMotoNumber.Text = string.Empty;
                this.tbOwnerName.Text = string.Empty;
                this.tbTel.Text = string.Empty;
                this.tbTelPhone.Text = string.Empty;
                this.tbType.Text = string.Empty;
                this.tbExhaustVolume.Text = string.Empty;
                this.cbGender.SelectedIndex = 0;
                this.cbLabel.SelectedIndex = 0;
                this.cbPowerSource.SelectedIndex = 0;
            }
        }

        private IEnumerable<Moto> QueryMotoData()
        {
            try
            {
                using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
                {
                    var repo = scope.Resolve<IMotoRepository>();

                    if (!string.IsNullOrEmpty(this.tbMotoNumber.Text))
                    {
                        var result = repo.FindByMotoNumber(this.tbMotoNumber.Text);
                        if (result.Item1 != null)
                        {
                            throw result.Item1;
                        }

                        return new List<Moto>() { result.Item2 };
                    }

                    if (!string.IsNullOrEmpty(this.tbTelPhone.Text))
                    {
                        var result = repo.QueryByTelPhone(this.tbTelPhone.Text);
                        if (result.Item1 != null)
                        {
                            throw result.Item1;
                        }

                        return result.Item2;
                    }

                    if (!string.IsNullOrEmpty(this.tbOwnerName.Text))
                    {
                        var result = repo.FuzzyQueryByOwnerName(this.tbOwnerName.Text);
                        if (result.Item1 != null)
                        {
                            throw result.Item1;
                        }

                        return result.Item2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new List<Moto>();
        }

        private void BindMotoDataToView()
        {
            if (this.currentMoto == null)
            {
                return;
            }

            this.tbAddress.Text = this.currentMoto.Address;
            this.tbColor.Text = this.currentMoto.Color;
            this.tbEngineNumber.Text = this.currentMoto.EngineNumber;
            this.tbLine.Text = this.currentMoto.Line;
            this.tbMotoNumber.Text = this.currentMoto.MotoNumber;
            this.tbOwnerName.Text = this.currentMoto.OwnerName;
            this.tbTel.Text = this.currentMoto.Tel;
            this.tbTelPhone.Text = this.currentMoto.TelPhone;
            this.tbType.Text = this.currentMoto.Type;
            this.tbExhaustVolume.Text = $"{this.currentMoto.ExhaustVolume}";
            this.cbGender.SelectedIndex = (int)this.currentMoto.Gender;
            this.cbLabel.SelectedIndex = Applibs.ConfigHelper.MotoLabel.Select((value, index) => new { Index = index, Value = value })
                .FirstOrDefault(p => p.Value == this.currentMoto.Label).Index;
            this.cbPowerSource.SelectedIndex = (int)this.currentMoto.PowerSource;
            this.lbMotoNumber.Text = $"車牌號碼：{this.currentMoto.MotoNumber}";
        }

        private void BindMotoDataToCurrentMoto()
        {
            int id = this.currentMoto?.MotoId ?? -1;

            this.currentMoto = new Moto()
            {
                MotoId = id,
                Address = this.tbAddress.Text,
                Color = this.tbColor.Text,
                EngineNumber = this.tbEngineNumber.Text,
                Line = this.tbLine.Text,
                MotoNumber = this.tbMotoNumber.Text,
                OwnerName = this.tbOwnerName.Text,
                Tel = this.tbTel.Text,
                TelPhone = this.tbTelPhone.Text,
                Type = this.tbType.Text,
                ExhaustVolume = Convert.ToInt32(this.tbExhaustVolume.Text == string.Empty ? "0" : this.tbExhaustVolume.Text),
                Gender = (GenderType)Convert.ToInt32(((ComboBoxItem)this.cbGender.SelectedItem).Value),
                Label = ((ComboBoxItem)this.cbLabel.SelectedItem).Value,
                PowerSource = (MotoPowerSource)Convert.ToInt32(((ComboBoxItem)this.cbPowerSource.SelectedItem).Value)
            };
        }
        #endregion

        #region 維修資料
        private void gvCellContentClice(object sender, DataGridViewCellEventArgs e)
        {
            var gvCloumn = ((DataGridView)sender).Columns[e.ColumnIndex];
            if (e.RowIndex >= 0 && gvCloumn is DataGridViewButtonColumn)
            {
                var gvRow = ((DataGridView)sender).Rows[e.RowIndex];
                if (!int.TryParse(gvRow.Cells["Qty"].Value.ToString(), out var qty))
                {
                    qty = 0;
                }

                if (gvCloumn.Name == "btnAdd")
                {
                    qty++;
                }
                else if (gvCloumn.Name == "btnSub" && qty > 0)
                {
                    qty--;
                }

                gvRow.Cells["Qty"].Value = qty;
            }
        }

        private void cbRepairCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bindRepairCategoryItems();
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            this.bindRepairItemsFromItemChoice();
        }

        private void gvSaleRepairItem_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var saleItems = new List<CustomRepairItem>();
            foreach (DataGridViewRow row in this.gvSaleRepairItem.Rows)
            {
                saleItems.Add(new CustomRepairItem()
                {
                    RepairItemId = Convert.ToInt32(row.Cells["SaleRepairItemId"].Value),
                    ItemName = row.Cells["SaleItemName"].Value.ToString(),
                    Category = (RepairCategory)Convert.ToInt32(row.Cells["SaleCategory"].Value),
                    Price = Convert.ToInt32(row.Cells["SalePrice"].Value),
                    CategoryDisplayName = row.Cells["SaleCategoryDisplayName"].Value.ToString(),
                    Qty = Convert.ToInt32(row.Cells["SaleQty"].Value)
                });
            }

            this.tbReceivable.Text = $"{saleItems.Sum(p => p.Qty * p.Price)}";
            this.tbActualHarvest.Text = $"{saleItems.Sum(p => p.Qty * p.Price)}";
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定儲存資料!?", "Info", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var saleItems = new List<CustomRepairItem>();
                foreach (DataGridViewRow row in this.gvSaleRepairItem.Rows)
                {
                    saleItems.Add(new CustomRepairItem()
                    {
                        RepairItemId = Convert.ToInt32(row.Cells["SaleRepairItemId"].Value),
                        ItemName = row.Cells["SaleItemName"].Value.ToString(),
                        Category = (RepairCategory)Convert.ToInt32(row.Cells["SaleCategory"].Value),
                        Price = Convert.ToInt32(row.Cells["SalePrice"].Value),
                        CategoryDisplayName = row.Cells["SaleCategoryDisplayName"].Value.ToString(),
                        Qty = Convert.ToInt32(row.Cells["SaleQty"].Value)
                    });
                }

                var record = new RepairRecord()
                {
                    MotoId = this.currentMoto.MotoId,
                    Principal = ((ComboBoxItem)this.cbPrincipal.SelectedItem).Value,
                    LastMaintainceMileage = long.TryParse(this.tbMaintainceMileage.Text, out var mileage) ? mileage : 0,
                    Memo = this.tbMemo.Text,
                    ReceivableAmount = int.TryParse(this.tbReceivable.Text, out var receivable) ? receivable : 0,
                    ActualHarvestAmount = int.TryParse(this.tbActualHarvest.Text, out var actualHarvest) ? actualHarvest : 0,
                    CreateDateTimeStamp = this.dtpDateTime.Value.Ticks,
                    ContainString = JsonConvert.SerializeObject(saleItems)
                };

                using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
                {
                    var repo = scope.Resolve<IRepairRecordRepository>();
                    var insertResult = repo.Insert(record);
                    if(insertResult.Item1 != null)
                    {
                        MessageBox.Show(insertResult.Item1.Message);
                        return;
                    }

                    MessageBox.Show("儲存成功!!");
                    this.cbRepairCategory.SelectedIndex = 0;
                    this.dtpDateTime.Value = DateTime.Now;
                    this.bindRepairCategoryItems();
                    this.tbReceivable.Text = string.Empty;
                    this.tbActualHarvest.Text = string.Empty;
                    this.tbMemo.Text = string.Empty;
                    this.gvSaleRepairItem.DataSource = new BindingSource(new List<CustomRepairItem>(), null);
                    this.tbLastMaintainceMileage.Text = $"{this.getRepairRecords().FirstOrDefault()?.LastMaintainceMileage ?? 0}";
                }
            }
        }

        private void bindRepairCategoryItems()
        {
            var choiceCategory = (RepairCategory)Convert.ToInt32(((ComboBoxItem)this.cbRepairCategory.SelectedItem).Value);
            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairItemRepository>();
                var queryResult = repo.GetAll();
                if (queryResult.Item1 != null)
                {
                    MessageBox.Show(queryResult.Item1.Message);
                    return;
                }

                var items = queryResult.Item2.Where(p => p.Category == choiceCategory)
                    .Select(p => new CustomRepairItem()
                    {
                        RepairItemId = p.RepairItemId,
                        ItemName = p.ItemName,
                        Category = p.Category,
                        Price = p.Price,
                        Enable = p.Enable,
                        CategoryDisplayName = Applibs.ConfigHelper.GetRepairCategoryDisplayName(p.Category),
                        Qty = 0
                    });

                this.gvRepairChoice.DataSource = new BindingSource(items, null);
            }
        }

        private void bindRepairItemsFromItemChoice()
        {
            var choiceItems = new List<CustomRepairItem>();
            foreach (DataGridViewRow row in this.gvSaleRepairItem.Rows)
            {
                choiceItems.Add(new CustomRepairItem()
                {
                    RepairItemId = Convert.ToInt32(row.Cells["SaleRepairItemId"].Value),
                    ItemName = row.Cells["SaleItemName"].Value.ToString(),
                    Category = (RepairCategory)Convert.ToInt32(row.Cells["SaleCategory"].Value),
                    Price = Convert.ToInt32(row.Cells["SalePrice"].Value),
                    CategoryDisplayName = row.Cells["SaleCategoryDisplayName"].Value.ToString(),
                    Qty = Convert.ToInt32(row.Cells["SaleQty"].Value)
                });
            }

            foreach (DataGridViewRow row in this.gvRepairChoice.Rows)
            {
                if (int.TryParse(row.Cells["Qty"].Value.ToString(), out var qty) && qty > 0)
                {
                    choiceItems.Add(new CustomRepairItem()
                    {
                        RepairItemId = Convert.ToInt32(row.Cells["RepairItemId"].Value),
                        ItemName = row.Cells["ItemName"].Value.ToString(),
                        Category = (RepairCategory)Convert.ToInt32(row.Cells["Category"].Value),
                        Price = Convert.ToInt32(row.Cells["Price"].Value),
                        CategoryDisplayName = row.Cells["CategoryDisplayName"].Value.ToString(),
                        Qty = Convert.ToInt32(row.Cells["Qty"].Value)
                    });
                }
            }

            this.tbReceivable.Text = $"{choiceItems.Sum(p => p.Qty * p.Price)}";
            this.tbActualHarvest.Text = $"{choiceItems.Sum(p => p.Qty * p.Price)}";
            this.gvSaleRepairItem.DataSource = new BindingSource(choiceItems, null);
        }
        #endregion

        #region 維修紀錄
        private void gvRepairReCords_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            this.displayRepairItem();
        }

        private void btnEditRepairItem_Click(object sender, EventArgs e)
        {
            if (this.gvRepairReCords.SelectedRows.Count == 0)
            {
                return;
            }

            var selectRowCells = this.gvRepairReCords.SelectedRows[0].Cells;
            var record = new CustomRepairRecord()
            {
                RepairRecordId = Convert.ToInt32(selectRowCells["RepairRecordId"].Value),
                MotoId = Convert.ToInt32(selectRowCells["MotoId"].Value),
                Principal = selectRowCells["Principal"].Value.ToString(),
                LastMaintainceMileage = Convert.ToInt64(selectRowCells["LastMaintainceMileage"].Value),
                Memo = selectRowCells["Memo"].Value.ToString(),
                ReceivableAmount = Convert.ToInt32(selectRowCells["ReceivableAmount"].Value),
                ActualHarvestAmount = Convert.ToInt32(selectRowCells["ActualHarvestAmount"].Value),
                CreateDateTimeStamp = Convert.ToInt64(selectRowCells["CreateDateTimeStamp"].Value),
                ContainString = selectRowCells["ContainString"].Value.ToString(),
                DateTimeString = selectRowCells["DateTimeString"].Value.ToString()
            };

            if(new EditRepairRecord(record).ShowDialog() == DialogResult.OK)
            {
                var records = this.getRepairRecords();
                if (records.Count() > 0)
                {
                    this.gvRepairReCords.DataSource = new BindingSource(records, null);
                    this.gvRepairReCords.Rows[0].Selected = true;
                    this.displayRepairItem();
                }
            }
        }

        private void displayRepairItem()
        {
            if(this.gvRepairReCords.SelectedRows.Count == 0)
            {
                return;
            }

            var containString = this.gvRepairReCords.SelectedRows[0].Cells["ContainString"].Value.ToString();
            var repairItems = JsonConvert.DeserializeObject<IEnumerable<CustomRepairItem>>(containString);
            var repairItemFormat = repairItems.Select(p => $"類別:{p.CategoryDisplayName}, 項目:{p.ItemName}, 數量:{p.Qty}, 價錢:{p.Price}");
            this.tbRepairItemDisplay.Text = string.Join("\r\n", repairItemFormat);
        }
        #endregion


        private void tbNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            var vm = (TextBox)sender;
            var keyCode = (int)e.KeyChar;
            if ((keyCode >= 48 && keyCode < 58) || keyCode == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private IEnumerable<CustomRepairRecord> getRepairRecords()
        {
            if (this.currentMoto == null)
            {
                return new List<CustomRepairRecord>();
            }

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairRecordRepository>();
                var queryResult = repo.QueryByMotoId(this.currentMoto.MotoId);
                if (queryResult.Item1 != null)
                {
                    MessageBox.Show(queryResult.Item1.Message);
                    return new List<CustomRepairRecord>();
                }

                return queryResult.Item2.Select(p => new CustomRepairRecord()
                {
                    RepairRecordId = p.RepairRecordId,
                    MotoId = p.MotoId,
                    Principal = p.Principal,
                    LastMaintainceMileage = p.LastMaintainceMileage,
                    Memo = p.Memo,
                    ReceivableAmount = p.ReceivableAmount,
                    ActualHarvestAmount = p.ActualHarvestAmount,
                    CreateDateTimeStamp = p.CreateDateTimeStamp,
                    ContainString = p.ContainString,
                    DateTimeString = new DateTime(p.CreateDateTimeStamp).ToString("yyyy-MM-dd hh:mm:ss")
                });
            }
        }

        
    }
}
