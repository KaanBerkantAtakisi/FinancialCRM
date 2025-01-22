using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryId.Text);
            string categoryName = txtCategoryName.Text;

            Categories category = new Categories();
            category.CategoryId = categoryId;
            category.CategoryName = categoryName;

            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Yeni Kategori Başarılı Bir Şekilde Sisteme Eklendi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(txtCategoryId.Text);

            var removeValue = db.Categories.Find(categoryId);
            db.Categories.Remove(removeValue);
            db.SaveChanges();

            MessageBox.Show(" Kategori Başarılı Bir Şekilde Sistemden Silindi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            string categoryName = txtCategoryName.Text;

            var updatedValue =db.Categories.Find(id);

            updatedValue.CategoryName = categoryName;
            db.SaveChanges();

            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemde Güncellendi","Kategoriler",MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;

        }

        private void button2_Click(object sender, EventArgs e)
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
            FrmSpendings frm=new FrmSpendings();
            frm.Show();
            this.Hide();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        
    }
}
