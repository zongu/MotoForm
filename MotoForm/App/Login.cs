
namespace MotoForm.App
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using Autofac;
    using MotoForm.Domain.Repository;

    public partial class Login : Form
    {
        delegate void TbHandler(TextBox tb, string text);

        delegate void BtnHandler(Button btn, bool enable);

        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string pwd = this.TbPwd.Text;
            if (!Applibs.ConfigHelper.Users.Any(p => p.PWD == pwd))
            {
                MessageBox.Show("無此密碼!!");
                return;
            }

            Applibs.ConfigHelper.CurrentUser = Applibs.ConfigHelper.Users.FirstOrDefault(p => p.PWD == pwd);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnUpdateDb_Click(object sender, EventArgs e)
        {
            this.TbMsg.Text = "更新資料庫....";
            this.BtnLogin.Enabled = false;
            this.BtnUpdateDb.Enabled = false;

            var th = new Thread(UpdateDb);
            th.Start();
        }

        private void UpdateDb()
        {
            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IMaintainRepository>();
                var result = repo.InstanceCheck();
                if(result.Item1 != null)
                {
                    CallTbHandler(this.TbMsg, result.Item1.Message);
                    CallBtnHandler(this.BtnLogin, true);
                    CallBtnHandler(this.BtnUpdateDb, true);
                    return;
                }

                CallTbHandler(this.TbMsg, "更新完成");
                CallBtnHandler(this.BtnLogin, true);
                CallBtnHandler(this.BtnUpdateDb, true);
            }
        }

        private static void CallTbHandler(TextBox tb, string text)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new TbHandler(CallTbHandler), tb, text);
            }
            else
            {
                tb.Text = text;
            }
        }

        private static void CallBtnHandler(Button btn, bool enable)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke(new BtnHandler(CallBtnHandler), btn, enable);
            }
            else
            {
                btn.Enabled = enable;
            }
        }
    }
}
