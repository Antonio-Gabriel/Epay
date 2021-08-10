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
using ePay.Components.DashboardControl;
using ePay.Components.Category;
using ePay.Components.Brand;
using ePay.Components.Product;

namespace ePay
{
    public partial class Dashboard : Form
    {
        private Auth datas;
        public Dashboard(Auth data)
        {
            InitializeComponent();
            this.datas = data;
        }

        void loadAction()
        {
            instanceComponent.instance(
                pnlInstance, new ucDashboard(datas)
                );                        
        }
                

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadAction();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlDrag.Height = btnHome.Height;
            pnlDrag.Top = btnHome.Top;
            instanceComponent.instance(
                pnlInstance, new ucDashboard(datas)
                );
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            pnlDrag.Height = btnBrand.Height;
            pnlDrag.Top = btnBrand.Top;
            instanceComponent.instance(
                    pnlInstance, new ucBrand()
                );
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            pnlDrag.Height = btnCategory.Height;
            pnlDrag.Top = btnCategory.Top;
            instanceComponent.instance(
                    pnlInstance, new ucCategory()
                );
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            pnlDrag.Height = btnProduct.Height;
            pnlDrag.Top = btnProduct.Top;
            instanceComponent.instance(
                    pnlInstance, new ucProduct(datas)
                );
        }
    }
}
