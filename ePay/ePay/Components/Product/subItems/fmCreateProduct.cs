using ePay.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.BussinessLayer;
using ePay.Entity;

namespace ePay.Components.Product.subItems
{
    public partial class fmCreateProduct : Form
    {
        ProductBL bussinessProduct = new ProductBL();
        CategoryBL bussinessCategory = new CategoryBL();
        BrandBL bussinessBrand = new BrandBL();
        ConvertBlob ConvertBlob = new ConvertBlob();
        private ucProduct _ucProductGrid;
        private Auth _auth;
        private Entity.Product _product;
        public fmCreateProduct(ucProduct ucProduct, Auth auth, Entity.Product product)
        {
            InitializeComponent();
            _ucProductGrid = ucProduct;
            _auth = auth;
            _product = product;
        }
        void loadAction()
        {
            if (_product == null)
            {
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                txtCode.Text = _product.ProductCode.ToString();
                txtProductName.Text = _product.ProductName;
                cmbCategory.Text = _product.Category.CategoryName;
                cmbBrand.Text = _product.Brand.BrandName;
                txtPrice.Text = _product.Price.ToString();
                txtDesc.Text = _product.Description;
                picImage.Image = ConvertBlob.unBlob((byte[])_product.ProductImage);
            }
        }

        void loadCategotyIntoCmb()
        {
            cmbCategory.DataSource = bussinessCategory.Read();
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id_category";
        }
        void loadBrandIntoCmb()
        {
            cmbBrand.DataSource = bussinessBrand.Read();
            cmbBrand.DisplayMember = "name";
            cmbBrand.ValueMember = "id_brand";
        }
        private void btnloadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog upload = new OpenFileDialog();
            upload.Filter = "choose Image(*.jpg; *.png) | *.jpg; *.png";
            if (upload.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(upload.FileName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!picImage.Image.Equals(null)) picImage.Image = null;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {          
            if (
                txtCode.Text != "" || txtProductName.Text != "" ||
                txtPrice.Text != "" || picImage.Image != null
                )
            {

                DataTable table = bussinessProduct.FindByCode(code: int.Parse(txtCode.Text));
                if (table.Rows.Count > 0)
                {
                    MsShow.ShowMessage("Código do produto já existe!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    int response = bussinessProduct.Create(new Entity.Product
                    {
                        ProductCode = int.Parse(txtCode.Text.Trim()),
                        ProductName = txtProductName.Text.Trim(),
                        User = new Auth { User = new Employee { Id = _auth.User.Id } },
                        Category = new Entity.Category { IdCategory = (int)cmbCategory.SelectedValue },
                        Brand = new Entity.Brand { Id_brand = (int)cmbBrand.SelectedValue },
                        Price = float.Parse(txtPrice.Text.Trim()),
                        Description = txtDesc.Text.Trim(),
                        ProductImage = ConvertBlob.Blob(picImage)
                    });

                    if (response > 0)
                    {
                        MsShow.ShowMessage("Produto cadastrado com \nsucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _ucProductGrid.loadProductWithModal();
                    }
                    else
                        MsShow.ShowMessage("Erro!, verifique os \ndados inserido", "Aviso",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                    
            }
            else
                MsShow.ShowMessage("Preencha devidamente os campos!", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fmCreateProduct_Load(object sender, EventArgs e)
        {
            loadCategotyIntoCmb();
            loadBrandIntoCmb();
            loadAction();
        }

        private void fmCreateProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_product == null) btnCreate_Click(sender, e);
                else btnUpdate_Click(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtCode.Text.Length == 6) || !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 0) cleanCodeInput.Visible = true;
        }

        private void cleanCodeInput_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
        }
    }
}
