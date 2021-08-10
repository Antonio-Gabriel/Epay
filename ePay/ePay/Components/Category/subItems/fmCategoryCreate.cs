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
using ePay.Functions;

namespace ePay.Components.Category.subItems
{
    public partial class fmCategoryCreate : Form
    {
        private Entity.Category _category;
        private ucCategory _categoryGrid;
        CategoryBL bussinessCategory = new CategoryBL();
        public fmCategoryCreate(Entity.Category category, ucCategory categoryGrid)
        {
            InitializeComponent();
            _category = category;
            _categoryGrid = categoryGrid;
        }

        void loadAction()
        {
            if (_category == null)
            {
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                txtCategory.Text = _category.CategoryName;
            }
        }

        private void fmCategoryCreate_Load(object sender, EventArgs e)
        {
            loadAction();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!txtCategory.Text.Trim().Equals(""))
            {
                int response = bussinessCategory.Create(new Entity.Category {                     
                    CategoryName = txtCategory.Text
                });

                if(response > 0)
                {
                    txtCategory.Clear();
                    MsShow.ShowMessage("Categoria cadastrado com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _categoryGrid.loadCategoryWithModal();
                } else 
                    MsShow.ShowMessage("Erro!, verifique os \ndados inserido", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
                MsShow.ShowMessage("Acesso negato, verifique os \ndados", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fmCategoryCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (_category == null) btnCreate_Click(sender, e);
                else btnUpdate_Click(sender, e);                                
            };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtCategory.Text.Trim().Equals(""))
            {
                int response = bussinessCategory.Update(new Entity.Category
                {
                    IdCategory = _category.IdCategory,
                    CategoryName = txtCategory.Text
                });

                if (response > 0)
                {
                    txtCategory.Clear();
                    MsShow.ShowMessage("Categoria actualizada com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _categoryGrid.loadCategoryWithModal();
                    this.Close();
                }
                else
                    MsShow.ShowMessage("Erro!, verifique os \ndados inserido", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MsShow.ShowMessage("Acesso negato, verifique os \ndados", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
