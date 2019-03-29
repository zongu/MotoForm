
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

    public partial class Sale : Form
    {
        private Moto currentMoto;

        public Sale()
        {
            InitializeComponent();
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
        }

        private void tabControllerChage(object sender, EventArgs e)
        {
            if (currentMoto == null && this.tabController.SelectedIndex != 0)
            {
                MessageBox.Show("請先載入機車資料!!");
                this.tabController.SelectedIndex = 0;
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

        private void tbExhaustVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            var vm = (TextBox)sender;
            var keyCode = (int)e.KeyChar;
            if (keyCode >= 48 && keyCode < 58)
            {
                vm.SelectedText = e.KeyChar.ToString();
            }
            else
            {
                vm.Text = vm.Text.Substring(0, vm.Text.Length);
            }

            e.Handled = true;
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
            this.cbLabel.SelectedIndex = Applibs.ConfigHelper.MotoLabel.Select((value, index) => new { Index = index, Value = value})
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

        public class ComboBoxItem
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}
