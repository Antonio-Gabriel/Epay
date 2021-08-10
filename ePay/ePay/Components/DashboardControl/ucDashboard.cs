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
using ePay.Components.DashboardControl.subItems;

namespace ePay.Components.DashboardControl
{
    public partial class ucDashboard : UserControl
    {
        private Auth _auth;
        public ucDashboard(Auth auth)
        {
            InitializeComponent();
            this._auth = auth;
        }

        void loadAction()
        {
            //lblName.Text = _auth.Username;
            lblDateTime.Text = DateTime.Now.ToLongTimeString();
            instanceComponent.instance(pnlInstance, new ucHome());
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            loadAction();
        }
    }
}
