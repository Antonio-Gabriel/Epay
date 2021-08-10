using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePay
{
    public partial class MsgBoxOk : Form
    {
        public MsgBoxOk()
        {
            InitializeComponent();
        }
        public Image IllustrationIcon
        {
            get => messageIcon.Image;
            set => messageIcon.Image = value;
        }

        public string Message
        {
            get => lblMessage.Text;
            set => lblMessage.Text = value;
        }
    }
}
