using FinancialCrm.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {

            var ziratBalance = db.TblBanks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBalance = db.TblBanks.Where(x => x.BankTitle == "Vakıfbank").Select(y => y.BankBalance).FirstOrDefault();
            var IsBalance = db.TblBanks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();
             
            lbl_zirat_balance.Text = ziratBalance?.ToString() + " TL";
            lbl_vakif_balance.Text = vakifBalance?.ToString() + " TL";
            lbl_is_balance.Text = IsBalance?.ToString() + " TL";


            var bankProcess1 = db.TblBankProcess.OrderByDescending(x => x.BankProcessID).Take(1).FirstOrDefault();
            lbl_bank_process1.Text = bankProcess1.Description + " |  " + bankProcess1.Amount + "  |  " + bankProcess1.ProcessDate;

            var bankProcess2 = db.TblBankProcess.OrderByDescending(x => x.BankProcessID).Take(2).Skip(1).FirstOrDefault();
            lbl_bank_process2.Text = bankProcess2.Description + " |  " + bankProcess2.Amount + "  |  " + bankProcess2.ProcessDate;

            var bankProcess3 = db.TblBankProcess.OrderByDescending(x => x.BankProcessID).Take(3).Skip(2).FirstOrDefault();
            lbl_bank_process3.Text = bankProcess3.Description + " |  " + bankProcess3.Amount + "  |  " + bankProcess3.ProcessDate;

            var bankProcess4 = db.TblBankProcess.OrderByDescending(x => x.BankProcessID).Take(4).Skip(3).FirstOrDefault();
            lbl_bank_process4.Text = bankProcess4.Description + " |  " + bankProcess4.Amount + "  |  " + bankProcess4.ProcessDate;

            var bankProcess5 = db.TblBankProcess.OrderByDescending(x => x.BankProcessID).Take(5).Skip(4).FirstOrDefault();
            lbl_bank_process5.Text = bankProcess5.Description + " |  " + bankProcess5.Amount + "  |  " + bankProcess5.ProcessDate;

        }

        private void btn_bills_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
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
