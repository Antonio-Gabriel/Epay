using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePay.Components.Product.subItems
{
    public partial class ucNotRow : UserControl
    {
        public ucNotRow()
        {
            InitializeComponent();
        }

        public int Id
        {
            get => int.Parse(lblId.Text);
            private set => lblId.Text = "0";
        }

        public string Message
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }
    }
}
