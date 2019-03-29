
namespace MotoForm
{
    using System;
    using System.Windows.Forms;
    using Autofac;
    using MotoForm.Domain.Repository;

    public partial class LobbyForm : Form
    {
        public LobbyForm()
        {
            InitializeComponent();
            this.BtnReport.Enabled = Applibs.ConfigHelper.CurrentUser.Weight > 1;
            this.GetTodayCount();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var key = btn.Name.Replace("Btn", string.Empty);

            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var form = scope.ResolveKeyed<Form>(key);
                form.ShowDialog();
                this.GetTodayCount();
            }
        }

        private void GetTodayCount()
        {
            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairRecordRepository>();
                var getResult = repo.GetTodayRepairCount();
                if (getResult.Item1 != null)
                {
                    MessageBox.Show(getResult.Item1.Message);
                    return;
                }

                this.LbTotalCount.Text = $"今日修車統計：{getResult.Item2}";
            }
        }
    }
}
