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
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            decimal value = decimal.Parse(db.Spendings.Sum(x => x.SpendingAmount).ToString());
            lblTotalSpendingAmount.Text = value.ToString();
        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSpendingAdd_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime date = DateTime.Parse(mskSpendingDate.Text);
            int category = int.Parse(txtSpendingCategory.Text);

            Spendings spend = new Spendings();
            spend.SpendingTitle= spendingTitle;
            spend.SpendingAmount= spendingAmount;
            spend.SpendingDate= date;
            spend.CategoryId= category;
            db.Spendings.Add(spend);
            db.SaveChanges();
            MessageBox.Show("Yeni Harcama Başarılı Bir Şekilde Sisteme Eklendi", "Giderler & Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnSpendingDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı Bir Şekilde Sistemden Silindi", "Giderler & Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSpendingUpdate_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            DateTime date = DateTime.Parse(mskSpendingDate.Text);
            int category = int.Parse(txtSpendingCategory.Text);
            int id = int.Parse(txtSpendingId.Text);

            var updatedValues= db.Spendings.Find(id);

            updatedValues.SpendingTitle = spendingTitle;
            updatedValues.SpendingAmount = spendingAmount;
            updatedValues.SpendingDate = date;
            updatedValues.CategoryId = category;

            db.SaveChanges();
            MessageBox.Show("Harcama Başarılı Bir Şekilde Sistemde Güncellendi", "Giderler & Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Spendings.ToList() ;
            dataGridView1.DataSource = values;

         

        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillings_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnSpendings_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcesses_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses();
            frm.Show();
            this.Hide();
        }
    }
}
