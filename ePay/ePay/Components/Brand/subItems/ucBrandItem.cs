using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.Entity;
using ePay.Functions;
using ePay.BussinessLayer;

namespace ePay.Components.Brand.subItems
{
    public partial class ucBrandItem : UserControl
    {
        private ucBrand _ucbrand;
        public ucBrandItem(ucBrand ucbrand)
        {
            InitializeComponent();
            _ucbrand = ucbrand;
        }
        public string NameBrand
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

        private void ucBrandItem_Load(object sender, EventArgs e)
        {
            if (Id == 0) btnDelete.Visible = btnUpdate.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new fmBrandCreate(new Entity.Brand
            {
                Id_brand = Id,
                BrandName = NameBrand
            }, _ucbrand).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (
                   MsShow.ShowMessage("Desejas eliminar esta \nmarca?", "Questão",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question
               ) == DialogResult.Yes)
            {
                BrandBL bussinessBrand = new BrandBL();
                int response = bussinessBrand.Delete(Id);
                if (response > 0)
                {
                    MsShow.ShowMessage("Marca eliminada com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ucbrand.loadBrandWithModal();
                }
                else
                    MsShow.ShowMessage("Erro! ao eliminar", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
