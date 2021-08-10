using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ePay.Functions;
using ePay.BussinessLayer;
using ePay.Entity;

namespace ePay
{
    public partial class Login : Form
    {
        Authentication authentication = new Authentication();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUser.Focus();          
        }
  
        private void btnAuth_Click(object sender, EventArgs e)
        {
            if ( txtUser.Text == "" || txtPass.Text == "")
                MsShow.ShowMessage("Preencha devidamente os \ncampos requeridos", "Aviso",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    Auth data = authentication.VerifyAccess(txtUser.Text.Trim(),
                        Password_hash.Hash(txtPass.Text.Trim()));

                    if (data != null)
                    {
                        new Dashboard(data).Show();
                        this.Hide();                        
                    }
                    else
                        MsShow.ShowMessage("Acesso negato, verifique os \ndados", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void instanceRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void KeyForm_event(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAuth_Click(sender, e);            
        }
    }
}
