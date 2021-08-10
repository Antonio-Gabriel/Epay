using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePay.WaitForm
{
    public partial class WaitProgress : Form
    {
        public Action _worKer { get; set; }
        public WaitProgress(Action worker)
        {
            InitializeComponent();
            _worKer = worker;
        }        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(_worKer).ContinueWith(
                    t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext()
                );
        }
    }
}
