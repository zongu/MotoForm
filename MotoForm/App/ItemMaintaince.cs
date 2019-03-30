
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

    public partial class ItemMaintaince : Form
    {
        const int btnCategoryLocationX = 100;
        const int btnCategoryLocationY = 15;
        const int btnCategoryLocationDistince = 85;

        private int currentCategoryIndex = -1;

        public ItemMaintaince()
        {
            InitializeComponent();
            Enum.GetNames(typeof(RepairCategory)).Select((value, index) => new { Key = index, Value = value }).ToList().ForEach(category =>
             {
                 var btn = new Button();
                 btn.Name = $"btnRepairCategory{category.Key}";
                 btn.Width = 80;
                 btn.Height = 40;
                 btn.Location = new Point(
                     btnCategoryLocationX + (btnCategoryLocationDistince * category.Key),
                     btnCategoryLocationY);
                 btn.Text = Applibs.ConfigHelper.GetRepairCategoryDisplayName((RepairCategory)category.Key);
                 btn.Font = this.btnRepairCategoryAll.Font;
                 btn.Click += new EventHandler(this.CategoryFilter);
                 this.splitContainer1.Panel1.Controls.Add(btn);
             });

            this.lbCategoryDisplayName.Text = "全部";
            this.UpdateRepairItem();
        }

        private void CategoryFilter(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var key = btn.Name.Replace("btnRepairCategory", string.Empty);
            var categoryName = string.Empty;
            if (key == "All")
            {
                this.currentCategoryIndex = -1;
                categoryName = "全部";
            }
            else
            {
                this.currentCategoryIndex = Convert.ToInt32(key);
                categoryName = Applibs.ConfigHelper.GetRepairCategoryDisplayName((RepairCategory)this.currentCategoryIndex);
            }

            this.lbCategoryDisplayName.Text = categoryName;
            this.UpdateRepairItem();
        }

        private void RepairItemOperation(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var key = btn.Name.Replace("btn", string.Empty);

            switch (key)
            {
                case "AddRepairItem":
                    if (new AddRepairItem().ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    break;
                case "DisableRepairItem":
                    if (this.gvRepairItem.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("請選擇一筆資料!!");
                        return;
                    }

                    var repairItemId = Convert.ToInt32(this.gvRepairItem.SelectedRows[0].Cells["RepairItemId"].Value);
                    using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
                    {
                        var repo = scope.Resolve<IRepairItemRepository>();
                        var result = repo.Disable(repairItemId);
                        if (result.Item1 != null)
                        {
                            MessageBox.Show(result.Item1.Message);
                            return;
                        }
                    }

                    break;
                case "EditRepairItem":
                    if (this.gvRepairItem.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("請選擇一筆資料!!");
                        return;
                    }

                    var repairItem = new RepairItem()
                    {
                        RepairItemId = Convert.ToInt32(this.gvRepairItem.SelectedRows[0].Cells["RepairItemId"].Value),
                        ItemName = this.gvRepairItem.SelectedRows[0].Cells["ItemName"].Value.ToString(),
                        Category = (RepairCategory)Convert.ToInt32(this.gvRepairItem.SelectedRows[0].Cells["Category"].Value),
                        Price = Convert.ToInt32(this.gvRepairItem.SelectedRows[0].Cells["Price"].Value)
                    };

                    if (new EditRepairItem(repairItem).ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    break;
                default:
                    return;
            }

            this.UpdateRepairItem();
        }

        private void UpdateRepairItem()
        {
            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairItemRepository>();
                var result = repo.GetAll();
                if (result.Item1 != null)
                {
                    MessageBox.Show(result.Item1.Message);
                    return;
                }

                var data = result.Item2.Where(p => this.currentCategoryIndex == -1 || p.Category == (RepairCategory)this.currentCategoryIndex)
                    .Select(p => new CustomRepairItem()
                    {
                        RepairItemId = p.RepairItemId,
                        ItemName = p.ItemName,
                        Category = p.Category,
                        CategoryDisplayName = Applibs.ConfigHelper.GetRepairCategoryDisplayName(p.Category),
                        Enable = p.Enable,
                        Price = p.Price
                    });

                this.gvRepairItem.DataSource = new BindingSource(data, null);
                this.lbItemTotalCount.Text = $"{data.Count()}";
            }
        }
    }
}
