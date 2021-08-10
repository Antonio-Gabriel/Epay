using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ePay.Functions
{
    public static class instanceComponent
    {

        private static Panel pnlInstance;

        [DllImport("User32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        public static void instance(Panel pnl, UserControl Control)
        {
            pnlInstance = pnl;
            if (pnlInstance.Controls.Count > 0)
                pnlInstance.Controls.RemoveAt(0);

            UserControl ucInstance = Control as UserControl;
            ucInstance.Dock = DockStyle.Fill;
            pnlInstance.Controls.Add(ucInstance);
            pnlInstance.Tag = ucInstance;
        }

    }
}
