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
using ePay.BussinessLayer;
using ePay.Functions;

namespace ePay.Components.Category.subItems
{
    public partial class ucCategoryItem : UserControl
    {
        private ucCategory _category;
        public ucCategoryItem(ucCategory ucCategory)
        {
            InitializeComponent();
            _category = ucCategory;
        }

        public string NameCategory
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public int Id
        {
            get => int.Parse(lblId.Text);
            set => lblId.Text = value.ToString();
        }

        public DateTime? Date
        {
            get => Convert.ToDateTime(lblDate.Text);
            set => lblDate.Text = value.ToString();
        }

        private void ucCategoryItem_Load(object sender, EventArgs e)
        {
            if (Id == 0) btnDelete.Visible = btnUpdate.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new fmCategoryCreate(new Entity.Category { 
                IdCategory = Id,
                CategoryName = NameCategory
            }, _category).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (
                MsShow.ShowMessage("Desejas eliminar esta \ncategoria?", "Questão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
            ) == DialogResult.Yes)
            {
                CategoryBL bussinessCategory = new CategoryBL();
                int response = bussinessCategory.Delete(Id);
                if(response > 0)
                {
                    MsShow.ShowMessage("Categoria eliminada com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _category.loadCategoryWithModal();
                }
                else
                    MsShow.ShowMessage("Erro! ao eliminar", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
