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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db= new FinancialCrmDbEntities();

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {

            string userName = txtUserName.Text;

            var updatedValue = db.Users.SingleOrDefault(x=>x.UserName==userName);
            if(updatedValue != null)
            {
                if (txtNewPassword.Text == txtNewPassword2.Text)
                {
                    updatedValue.Password = txtNewPassword2.Text;
                    db.SaveChanges();
                    MessageBox.Show("Şifreniz güncellendi");
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUsername2.Text;
            string Password = txtPassword.Text;

            var userDelete = db.Users.SingleOrDefault(x=>x.UserName == userName);

            if(userDelete != null)
            {
                if (userDelete.Password == Password)
                {
                    db.Users.Remove(userDelete);
                    db.SaveChanges();

                    MessageBox.Show("Hesap kalıcı olarak silindi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre girdiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Bu kullanıcı bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();

        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frm = new FrmBankProcesses();
            frm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }
    }
}
