
namespace MotoForm.App
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using Autofac;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;
    using MotoForm.Model;

    public partial class AddRepairItem : Form
    {
        public AddRepairItem()
        {
            InitializeComponent();
            var categoryItems = Enum.GetNames(typeof(RepairCategory))
                .Select((value, index) => new ComboBoxItem() { Key = Applibs.ConfigHelper.GetRepairCategoryDisplayName((RepairCategory)index), Value = $"{index}" });
            this.cbCategory.Items.AddRange(categoryItems.ToArray());
            this.cbCategory.DisplayMember = "Key";
            this.cbCategory.ValueMember = "Value";
            this.cbCategory.SelectedIndex = 0;
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairItemRepository>();
                var result = repo.InsertOne(new RepairItem()
                {
                    ItemName = this.tbItemName.Text,
                    Category = (RepairCategory)Convert.ToInt32(((ComboBoxItem)this.cbCategory.SelectedItem).Value),
                    Price = Convert.ToInt32(string.IsNullOrEmpty(this.tbPrice.Text) ? "0" : this.tbPrice.Text)
                });

                if (result.Item1 != null)
                {
                    MessageBox.Show(result.Item1.Message);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
