
namespace MotoForm.App
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Autofac;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;
    using MotoForm.Model;
    using Newtonsoft.Json;

    public partial class EditRepairRecord : Form
    {
        private CustomRepairRecord currentRecoerd;

        public EditRepairRecord(CustomRepairRecord recoerd)
        {
            InitializeComponent();
            this.currentRecoerd = recoerd;
            var items = JsonConvert.DeserializeObject<IEnumerable<CustomRepairItem>>(this.currentRecoerd.ContainString);
            this.gvRepairItems.DataSource = new BindingSource(items, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var items = new List<CustomRepairItem>();
            foreach (DataGridViewRow row in this.gvRepairItems.Rows)
            {
                items.Add(new CustomRepairItem()
                {
                    RepairItemId = Convert.ToInt32(row.Cells["RepairItemId"].Value),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Category = (RepairCategory)Convert.ToInt32(row.Cells["Category"].Value),
                    Price = Convert.ToInt32(row.Cells["Price"].Value),
                    CategoryDisplayName = row.Cells["CategoryDisplayName"].Value.ToString(),
                    Qty = Convert.ToInt32(row.Cells["Qty"].Value)
                });
            }

            this.currentRecoerd.ContainString = JsonConvert.SerializeObject(items);

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairRecordRepository>();
                var updateResult = repo.Update(this.currentRecoerd);
                if(updateResult.Item1 != null)
                {
                    MessageBox.Show(updateResult.Item1.Message);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
