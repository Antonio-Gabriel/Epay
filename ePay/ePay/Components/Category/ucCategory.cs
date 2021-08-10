using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.Components.Category.subItems;
using ePay.Functions;
using MySql.Data.MySqlClient;
using Guna.UI.Lib.ScrollBar;
using ePay.BussinessLayer;
using ePay.Entity;

namespace ePay.Components.Category
{
    public partial class ucCategory : UserControl
    {
        CategoryBL bussinessCategory = new CategoryBL();
        public ucCategory()
        {
            InitializeComponent();
        }

        private void changeDataFromCategoryEntity(int id, string name, DateTime? date)
        {
            ucCategoryItem categoryItem = new ucCategoryItem(this)
            {
                Id = id,
                NameCategory = name,
                Date = date
            };
            gridView.Controls.Add(categoryItem);
            categoryItem.Dock = DockStyle.Top;
        }

        internal void loadCategoryWithModal()
        {            
            DataTable table = bussinessCategory.Read();
            if (table.Rows.Count > 0)
            {
                gridView.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    changeDataFromCategoryEntity(
                            id: ((int)table.Rows[i][0]),
                            name: ((string)table.Rows[i][1]),
                            date: Convert.ToDateTime(table.Rows[i][2])
                        );
                }
            }                
            else { changeDataFromCategoryEntity(0, "Sem registro", null); }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            new fmCategoryCreate(null, this).ShowDialog();
        }    

        private void ucCategory_Load(object sender, EventArgs e)
        {
            loadCategoryWithModal();
            new PanelScrollHelper(gridView, vsScrollBar, true);            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = bussinessCategory.Search(name: txtSearch.Text.Trim());            
            
            if (table.Rows.Count > 0)
            {
                gridView.Controls.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    changeDataFromCategoryEntity(
                            id: ((int)table.Rows[i][0]),
                            name: ((string)table.Rows[i][1]),
                            date: Convert.ToDateTime(table.Rows[i][2])
                        );
                }
            }               
            else {
                gridView.Controls.Clear();
                changeDataFromCategoryEntity(0, "Sem registro", null); 
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
    }
}
