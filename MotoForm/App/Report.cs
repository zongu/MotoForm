
namespace MotoForm.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Autofac;
    using ClosedXML.Excel;
    using MotoForm.Domain.Repository;
    using MotoForm.Model;

    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.cbQueryCategory.Items.AddRange(ReportQueryCategoryLibs.ReportQueryCategoryComboBoxItems().ToArray());
            this.cbQueryCategory.DisplayMember = "Key";
            this.cbQueryCategory.ValueMember = "Value";
            this.cbQueryCategory.SelectedIndex = 0;

            this.dtpStartDateTime.Value = DateTime.Parse($"{DateTime.Today.ToString("yyyy-MM-dd")} 00:00:00");
            this.dtpEndDateTime.Value = DateTime.Parse($"{DateTime.Today.ToString("yyyy-MM-dd")} 23:59:59");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.dtpEndDateTime.Value < this.dtpStartDateTime.Value)
            {
                MessageBox.Show("請檢察查詢時間!!");
                return;
            }

            var queryCategory = (ReportQueryCategory)Convert.ToInt32(((ComboBoxItem)this.cbQueryCategory.SelectedItem).Value);
            using (var scope = Applibs.AutoFacConfig.Container.BeginLifetimeScope())
            {
                var repo = scope.Resolve<IRepairRecordRepository>();
                var queryResult = repo.QueryByDateTime(this.dtpStartDateTime.Value, this.dtpEndDateTime.Value);
                if (queryResult.Item1 != null)
                {
                    MessageBox.Show(queryResult.Item1.Message);
                    return;
                }

                var records = queryResult.Item2.Select(p => new CustomRepairRecord()
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
                    CreateDateTime = new DateTime(p.CreateDateTimeStamp)
                });

                IEnumerable<ReportModel> reports = new List<ReportModel>();

                switch (queryCategory)
                {
                    case ReportQueryCategory.Day:
                        reports = records.GroupBy(
                            key => new
                            {
                                Year = key.CreateDateTime.Year,
                                Value = CultureInfo.CurrentCulture.Calendar.GetDayOfYear(key.CreateDateTime)
                            },
                            (g, data) => new ReportModel()
                            {
                                CategoryGroupName = $"{g.Year}-第{g.Value}天",
                                RecordCount = data.Count(),
                                TotalActualHarvestAmount = data.Sum(p => p.ActualHarvestAmount),
                                TotalReceivableAmount = data.Sum(p => p.ReceivableAmount)
                            });
                        break;
                    case ReportQueryCategory.Week:
                        reports = records.GroupBy(
                            key => new
                            {
                                Year = key.CreateDateTime.Year,
                                Value = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                    key.CreateDateTime,
                                    CalendarWeekRule.FirstFourDayWeek,
                                    DayOfWeek.Sunday)
                            },
                            (g, data) => new ReportModel()
                            {
                                CategoryGroupName = $"{g.Year}-第{g.Value}週",
                                RecordCount = data.Count(),
                                TotalActualHarvestAmount = data.Sum(p => p.ActualHarvestAmount),
                                TotalReceivableAmount = data.Sum(p => p.ReceivableAmount)
                            });
                        break;
                    case ReportQueryCategory.Month:
                        reports = records.GroupBy(
                            key => new
                            {
                                Year = key.CreateDateTime.Year,
                                Value = CultureInfo.CurrentCulture.Calendar.GetMonth(key.CreateDateTime)
                            },
                            (g, data) => new ReportModel()
                            {
                                CategoryGroupName = $"{g.Year}-第{g.Value}月",
                                RecordCount = data.Count(),
                                TotalActualHarvestAmount = data.Sum(p => p.ActualHarvestAmount),
                                TotalReceivableAmount = data.Sum(p => p.ReceivableAmount)
                            });
                        break;
                    default:
                        break;
                }

                this.gvReportData.DataSource = new BindingSource(reports, null);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dialogResult = new FolderBrowserDialog();
            if(dialogResult.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var path = dialogResult.SelectedPath;

            var records = new List<ReportModel>();
            foreach (DataGridViewRow row in this.gvReportData.Rows)
            {
                records.Add(new ReportModel()
                {
                    CategoryGroupName = row.Cells["CategoryGroupName"].Value.ToString(),
                    RecordCount = Convert.ToInt32(row.Cells["RecordCount"].Value),
                    TotalActualHarvestAmount = Convert.ToInt32(row.Cells["TotalActualHarvestAmount"].Value),
                    TotalReceivableAmount = Convert.ToInt32(row.Cells["TotalReceivableAmount"].Value)
                });
            }

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Report");
            ws.Cell(1, 1).Value = "查詢分類";
            ws.Cell(1, 2).Value = "維修筆數";
            ws.Cell(1, 3).Value = "應收";
            ws.Cell(1, 4).Value = "實收";

            int index = 2;
            records.ForEach(record =>
            {
                ws.Cell(index, 1).Value = record.CategoryGroupName;
                ws.Cell(index, 2).Value = $"{record.RecordCount}";
                ws.Cell(index, 3).Value = $"{record.TotalReceivableAmount}";
                ws.Cell(index, 4).Value = $"{record.TotalActualHarvestAmount}";
                index++;
            });

            wb.SaveAs($"{path}\\Report{DateTime.Now.ToString("yyyyMMddhhmmss")}.xlsx");
        }
    }
}
