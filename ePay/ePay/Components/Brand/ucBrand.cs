using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.Components.Brand.subItems;
using ePay.BussinessLayer;
using Guna.UI.Lib.ScrollBar;

namespace ePay.Components.Brand
{
    public partial class ucBrand : UserControl
    {
        BrandBL bussinessBrand = new BrandBL();
        public ucBrand()
        {
            InitializeComponent();
        }
        private void changeDataFromBrandEntity(int id, string name, DateTime? date)
        {
            ucBrandItem categoryItem = new ucBrandItem(this)
            {
                Id = id,
                NameBrand = name,
                Date = date
            };
            gridView.Controls.Add(categoryItem);
            categoryItem.Dock = DockStyle.Top;
        }

        internal void loadBrandWithModal()
        {
            DataTable table = bussinessBrand.Read();
            if (table.Rows.Count > 0)
            {
                gridView.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    changeDataFromBrandEntity(
                            id: ((int)table.Rows[i][0]),
                            name: ((string)table.Rows[i][1]),
                            date: Convert.ToDateTime(table.Rows[i][2])
                        );
                }
            }
            else { changeDataFromBrandEntity(0, "Sem registro", null); }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            new fmBrandCreate(null, this).ShowDialog();
        }

        private void ucBrand_Load(object sender, EventArgs e)
        {
            loadBrandWithModal();
            new PanelScrollHelper(gridView, vsScrollBar, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = bussinessBrand.Search(name: txtSearch.Text.Trim());

            if (table.Rows.Count > 0)
            {
                gridView.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    changeDataFromBrandEntity(
                            id: ((int)table.Rows[i][0]),
                            name: ((string)table.Rows[i][1]),
                            date: Convert.ToDateTime(table.Rows[i][2])
                        );
                }
            }
            else
            {
                gridView.Controls.Clear();
                changeDataFromBrandEntity(0, "Sem registro", null);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
    }
}
