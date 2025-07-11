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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

  
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBilling_Load(object sender, EventArgs e)
        {
             var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btn_odeme_list_Click(object sender, EventArgs e)
        {
            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btn_yeni_odeme_Click(object sender, EventArgs e)
        {
            string title = txt_title.Text;
            decimal amount = decimal.Parse(txt_amount.Text);
            string period = txt_period.Text;

           TblBills bills = new TblBills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.TblBills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Sisteme Eklendi", "Ödemeler & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;




        }

        private void btn_delete_odeme_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txt_bill_ID.Text);
            var removeValue = db.TblBills.Find(ID);
            db.TblBills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Silindi", "Ödemeler & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btn_update_odeme_Click(object sender, EventArgs e)
        {
            string title = txt_title.Text;
            decimal amount = decimal.Parse(txt_amount.Text);
            string period = txt_period.Text;
            int ID = int.Parse(txt_bill_ID.Text);
            var Value = db.TblBills.Find(ID);

          
            Value.BillTitle = title;
            Value.BillAmount = amount;
            Value.BillPeriod = period;
            db.TblBills.Add(Value);
            db.SaveChanges();
            MessageBox.Show("Ödeme Güncelledni", "Ödemeler & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.TblBills.ToList();
            dataGridView1.DataSource = values2;

        }

        private void btn_bank_forms_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 fd = new Form1();
            fd.Show();
            this.Hide();
        }
    }
}
