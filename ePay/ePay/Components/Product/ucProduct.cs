using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.Components.Product.subItems;
using ePay.BussinessLayer;
using ePay.Entity;
using ePay.Functions;
using Guna.UI.Lib.ScrollBar;

namespace ePay.Components.Product
{
    public partial class ucProduct : UserControl
    {
        ProductBL bussinessProduct = new ProductBL();
        private Auth _auth;
        public ucProduct(Auth auth)
        {
            InitializeComponent();
            _auth = auth;
        }
        private void changeDataFromProductEntity(
                int idProduct, 
                string user, 
                string category,
                string brand,
                string name,
                float price,
                Image productImage,
                string description,
                int productCode,
                DateTime? date
            )
        {
            ucProductItem productItem = new ucProductItem(this) { 
                IdProduct = idProduct,
                User = user,
                CategoryName = category,
                BrandName = brand,
                ProdutName = name,
                Price = price,
                ProductImage = productImage,
                Description = description,
                CodeProduct = productCode,
                Date = date
            };
            gridView.Controls.Add(productItem);
            productItem.Dock = DockStyle.Top;
        }

        public void changeEmptyRowFromProduct(string name) {
            ucNotRow notRow = new ucNotRow() { Message = name };
            gridView.Controls.Add(notRow);
            notRow.Dock = DockStyle.Top;
        }

        internal void loadProductWithModal()
        {            
            DataTable table = bussinessProduct.Read();
            if (table.Rows.Count > 0)
            {
                gridView.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    changeDataFromProductEntity(
                          idProduct: (int)table.Rows[i][0],
                          user: (string)table.Rows[i][1],
                          category: (string)table.Rows[i][2],
                          brand: (string)table.Rows[i][3],
                          name: (string)table.Rows[i][4],
                          price: (float)table.Rows[i][5],
                          productImage: new ConvertBlob().unBlob((byte[])table.Rows[i][7]),
                          description: (string)table.Rows[i][8],
                          productCode: (int)table.Rows[i][6],
                          date: Convert.ToDateTime(table.Rows[i][9])
                        );
                }
            }
            else { changeEmptyRowFromProduct("Sem registro"); }
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {
            loadProductWithModal();
            new PanelScrollHelper.VScrollBarPanelHelper(gridView, vsScrollBar, true);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new fmCreateProduct(this, _auth, null).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = bussinessProduct.Search(txtSearch.Text.Trim());
            if (table.Rows.Count > 0)
            {
                gridView.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    changeDataFromProductEntity(
                          idProduct: (int)table.Rows[i][0],
                          user: (string)table.Rows[i][1],
                          category: (string)table.Rows[i][1],
                          brand: (string)table.Rows[i][3],
                          name: (string)table.Rows[i][4],
                          price: (float)table.Rows[i][5],
                          productImage: new ConvertBlob().unBlob((byte[])table.Rows[i][7]),
                          description: (string)table.Rows[i][8],
                          productCode: (int)table.Rows[i][6],
                          date: Convert.ToDateTime(table.Rows[i][9])
                        );
                }
            }
            else {
                gridView.Controls.Clear();
                changeEmptyRowFromProduct("Sem registro"); 
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
    }
}
