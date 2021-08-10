using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.Functions;

namespace ePay.Components.Product.subItems
{
    public partial class ucProductItem : UserControl
    {
        private ucProduct _ucProduct;
        ConvertBlob ConvertBlob = new ConvertBlob();
        public ucProductItem(ucProduct ucProduct)
        {
            InitializeComponent();
            _ucProduct = ucProduct;
        }

        public int IdProduct
        {
            get => int.Parse(lblId.Text);
            set => lblId.Text = value.ToString();
        }

        public int CodeProduct
        {
            get => int.Parse(lblCodProduct.Text);
            set => lblCodProduct.Text = value.ToString();
        }
        public string ProdutName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public float Price
        {
            get => float.Parse(lblPrice.Text);
            set => lblPrice.Text = value.ToString();
        }

        public string CategoryName
        {
            get => lblCategory.Text;
            set => lblCategory.Text = value;
        }
        public string BrandName
        {
            get => lblBrand.Text;
            set => lblBrand.Text = value;
        }
        public Image ProductImage
        {
            get => picImage.Image;
            set => picImage.Image = value;
        }
        
        public string Description
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }
        
        public string User
        {
            get => lblUser.Text;
            set => lblUser.Text = value;
        }
        public DateTime? Date
        {
            get => Convert.ToDateTime(lblDate.Text);
            set => lblDate.Text = value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new fmCreateProduct(_ucProduct, null, new Entity.Product { 
                IdProduct = IdProduct,
                ProductCode = CodeProduct,
                Category = new Entity.Category { CategoryName = CategoryName},
                ProductName = ProdutName,
                Brand = new Entity.Brand { BrandName = BrandName},
                Price = Price,
                Description = Description,
                ProductImage = ConvertBlob.Blob(picImage),
            }).ShowDialog();
        }
    }
}
