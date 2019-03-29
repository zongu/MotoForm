
namespace MotoForm.App
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using MotoForm.Domain.Model;

    public partial class MotoDataListSelect : Form
    {
        public int motoId = -1;

        public MotoDataListSelect(IEnumerable<Moto> data)
        {
            InitializeComponent();
            this.gvMotoDataList.DataSource = new BindingSource(data, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.gvMotoDataList.SelectedRows.Count == 0)
            {
                MessageBox.Show("請選擇一筆資料!!");
                return;
            }

            motoId = Convert.ToInt32(this.gvMotoDataList.SelectedRows[0].Cells[0].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
