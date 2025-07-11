using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        int count = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            var totalBalance = db.TblBanks.Sum(x => x.BankBalance);
            lbl_total_balance.Text = totalBalance.ToString() + " TL" ;

            var lastBankProcessAmount = db.TblBankProcess.OrderByDescending(x=>x.BankProcessID).
            Take(1).Select(y=>y.Amount).FirstOrDefault();

            lbl_last_bankProcessAmount.Text = lastBankProcessAmount.ToString() + " TL";

            //Grafiklerin kodları

            var bankData = db.TblBanks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance); 
            }

            //var billData = db.TblBills.Select(x => new
            //{
            //    x.BillTitle,
            //    x.BillAmount
            //}).ToList();
            //chart2.Series.Clear();
            //var series2 = chart2.Series.Add("Faturalar");
            //series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //foreach (var item in billData)
            //{
            //    series.Points.AddXY(item.BillTitle, item.BillAmount);
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if(count % 3 == 1)
            {
               var ElektrikFaturasi= db.TblBills.Where(x=>x.BillTitle=="Elektrik Faturası")
                    .Select(y=>y.BillAmount).FirstOrDefault();
                lbl_billTitle.Text = "Elektrik Faturası";
                lbl_billAmount.Text = ElektrikFaturasi.ToString() + " TL" ;
            }
            if (count % 3 == 2)
            {
                var DogalgazFaturasi = db.TblBills.Where(x => x.BillTitle == "Doğalgaz Faturası")
                     .Select(y => y.BillAmount).FirstOrDefault();
                lbl_billTitle.Text = "Doğal Gaz Faturası";
                lbl_billAmount.Text = DogalgazFaturasi.ToString() + " TL";
            }
            if (count % 3 == 0)
            {
                var SuFaturasi = db.TblBills.Where(x => x.BillTitle == "Su Faturası")
                     .Select(y => y.BillAmount).FirstOrDefault();
                lbl_billTitle.Text = "Su Faturası";
                lbl_billAmount.Text = SuFaturasi.ToString() + " TL";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            
            frm.Show();
            this.Hide();
        }

        private void btn_bills_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }
    }
}
