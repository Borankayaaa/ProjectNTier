using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WinFormUI.WiewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUI
{
    public partial class Form2 : Form
    {
        ProductRepository _propRep;
        CategoryRepository _catRep;
        public Form2()
        {
            InitializeComponent();
            _propRep = new ProductRepository();
            _catRep = new CategoryRepository();
        }
        void ListCategories()
        {
            cmbcategories.DataSource = _catRep.Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
               Description = x.Description
            }).ToList();
            cmbcategories.DisplayMember = "CategoryName";
            cmbcategories.ValueMember = "ID";
        }
        void ListProducts()
        {
            lstProducts.DataSource = _propRep.Select(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category == null ? "Kategori Yok" : x.Category.CategoryName,
                CategoryID = x.CategoryID,
            }).ToList();
        }
        ProductVM _selected;
        private void Form2_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProducts();
        }

        private void lstProducts_Click(object sender, EventArgs e)
        {
            if(lstProducts.SelectedIndex > -1) 
            {
                _selected = lstProducts.SelectedItem as ProductVM;
                txtName.Text = _selected.ProductName;
                txtPrice.Text = _selected.UnitPrice.ToString();
                cmbcategories.SelectedValue = _selected.CategoryID != null ?
                    _selected.CategoryID.Value : -1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                if(cmbcategories.SelectedIndex > -1) 
                    p.CategoryID = Convert.ToInt32(cmbcategories.SelectedValue);
                    
                _propRep.Add(p);
                ListProducts();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(_selected != null)
            {
                Product toBeDeleted = _propRep.Find(_selected.ID);
                _propRep.Delete(toBeDeleted);
                ListProducts();
                _selected = null;
                txtName.Text = txtPrice.Text = null;
                cmbcategories.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seciniz");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(_selected != null)
                {
                    Product toBeUpdate = _propRep.Find(_selected.ID);
                    toBeUpdate.ProductName = txtName.Text;
                    toBeUpdate.UnitPrice =Convert.ToDecimal(txtPrice.Text);
                    if (cmbcategories.SelectedIndex > -1) toBeUpdate.CategoryID = Convert.ToInt32(cmbcategories.SelectedValue);
                    _propRep.Update(toBeUpdate);
                    ListProducts();
                    _selected = null;
                    txtName.Text=txtPrice.Text = null;
                    cmbcategories.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
