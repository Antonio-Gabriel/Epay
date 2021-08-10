using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.Lib.ScrollBar;

namespace ePay.Components.DashboardControl.subItems
{
    public partial class ucHome : UserControl
    {
        public ucHome()
        {
            InitializeComponent();
        }

        void loadAction()
        {
            new PanelScrollHelper(pnlCategory, vsScroll, false);
        }         

        private void ucHome_Load(object sender, EventArgs e)
        {
            loadAction();
        }
    }
}
