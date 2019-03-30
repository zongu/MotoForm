
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

    public partial class EditRepairItem : Form
    {
        private RepairItem currentRepairItem;

        public EditRepairItem(RepairItem currentRepairItem)
        {
            InitializeComponent();
            this.currentRepairItem = currentRepairItem;
            var categoryItems = Enum.GetNames(typeof(RepairCategory))
                .Select((value, index) => new ComboBoxItem() { Key = Applibs.ConfigHelper.GetRepairCategoryDisplayName((RepairCategory)index), Value = $"{index}" });
            this.cbCategory.Items.AddRange(categoryItems.ToArray());
            this.cbCategory.DisplayMember = "Key";
            this.cbCategory.ValueMember = "Value";

            this.tbItemName.Text = this.currentRepairItem.ItemName;
            this.cbCategory.SelectedIndex = (int)this.currentRepairItem.Category;
            this.tbPrice.Text = $"{this.currentRepairItem.Price}";
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.currentRepairItem.ItemName = this.tbItemName.Text;
            this.currentRepairItem.Category = (RepairCategory)Convert.ToInt32(((ComboBoxItem)this.cbCategory.SelectedItem).Value);
            this.currentRepairItem.Price = Convert.ToInt32(string.IsNullOrEmpty(this.tbPrice.Text) ? "0" : this.tbPrice.Text);

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairItemRepository>();
                var result = repo.UpdateOne(this.currentRepairItem);
                if(result.Item1 != null)
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
