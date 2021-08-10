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
using ePay.Functions;

namespace ePay.Components.Brand.subItems
{
    public partial class fmBrandCreate : Form
    {
        private ucBrand _ucBrandGrid;
        private Entity.Brand _brand;
        BrandBL bussinessBrand = new BrandBL();
        public fmBrandCreate(Entity.Brand brand, ucBrand ucBrand)
        {
            InitializeComponent();
            _ucBrandGrid = ucBrand;
            _brand = brand;
        }

        void loadAction()
        {
            if (_brand == null)
            {
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                txtBrand.Text = _brand.BrandName;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!txtBrand.Text.Trim().Equals(""))
            {
                int response = bussinessBrand.Create(new Entity.Brand { 
                    BrandName = txtBrand.Text.Trim()
                });

                if (response > 0)
                {
                    txtBrand.Clear();
                    MsShow.ShowMessage("Marca cadastrado com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ucBrandGrid.loadBrandWithModal();
                }
                else
                    MsShow.ShowMessage("Erro!, verifique os \ndados inserido", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MsShow.ShowMessage("Acesso negato, verifique os \ndados", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fmBrandCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_brand == null) btnCreate_Click(sender, e);
                else btnUpdate_Click(sender, e);
            };
        }

        private void fmBrandCreate_Load(object sender, EventArgs e)
        {
            loadAction();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtBrand.Text.Trim().Equals(""))
            {
                int response = bussinessBrand.Update(new Entity.Brand
                {
                    Id_brand = _brand.Id_brand,
                    BrandName = txtBrand.Text
                });

                if (response > 0)
                {
                    txtBrand.Clear();
                    MsShow.ShowMessage("Marca actualizada com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ucBrandGrid.loadBrandWithModal();
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
