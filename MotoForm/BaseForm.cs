using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotoForm.App;

namespace MotoForm
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            var login = new Login();
            if(login.ShowDialog() != DialogResult.OK)
            {
                //this.
            }

            InitializeComponent();
        }
    }
}
