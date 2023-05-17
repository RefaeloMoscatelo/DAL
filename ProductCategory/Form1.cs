using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductCategory
{
    public partial class Form1 : Form
    {
        ProductManager pm = new ProductManager();
        CategoryManager cm = new CategoryManager();
        List<Category> CategoryList = new List<Category>();
        List<Product>  ProductList = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            CategoryList = cm.GetAll().ToList();
            var cat = cm.GetAll().Select(x=>x.CategoryName).ToList();
            lstCategory.DataSource = cat;

            ProductList = pm.GetAll().ToList();
            var prod = pm.GetAll().Select(x => x.ProductName).ToList();
            lstProduct.DataSource = prod;

        }
        
        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  selectedCat = lstCategory.SelectedItem.ToString();
            Category ct = CategoryList.Where(x => x.CategoryName == selectedCat).Single();

            lstProduct.DataSource = pm.GetByCategoryID(ct.CategoryID).Select(x=>x.ProductName).ToList();

        }
    }
}
