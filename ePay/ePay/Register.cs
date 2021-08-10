using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using ePay.BussinessLayer;
using ePay.Functions;
using ePay.Entity;
using ePay.WaitForm;

namespace ePay
{
    public partial class Register : Form
    {
        int state = 0;               
        public Register()
        {
            InitializeComponent();
        }

        void clean()
        {
            txtUser.Text = 
            txtPhone.Text = 
            txtUserName.Text = 
            txtPassword.Text = 
            txtConfirmPassword.Text = "";
            cleanPhoneInput.Visible = false;
            inadmin.Checked = false;            
        }

        private void back_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {            
            if(    txtUser.Text == ""  || txtUserName.Text == ""  
                || txtPhone.Text == "" || txtPassword.Text == "" 
                || txtConfirmPassword.Text == ""
             )            
                MsShow.ShowMessage("Preencha devidamente os \ncampos requeridos", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);                          
            else
            {
                if (txtPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
                {
                    try
                    {
                        EmployeeBL bussinesAuth = new EmployeeBL();
                        int state = bussinesAuth.EmployeeCreate(new Auth { 
                            User = new Employee
                            {
                                Name = txtUser.Text,
                                Phone = Convert.ToInt32(txtPhone.Text)
                            },
                            Username = txtUserName.Text.Trim(),
                            Password = Password_hash.Hash(txtPassword.Text.Trim()),
                            InAdmin = ((inadmin.Checked) ? 1 : 0)
                        });
                        if (state > 0)
                        {
                            MsShow.ShowMessage("Usuário cadastrado com \nsucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.clean();
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else 
                    MsShow.ShowMessage("As Senhas são diferentes", "Aviso",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filled_hide_pass_Click(object sender, EventArgs e)
        {            
            if (state == 0)
            {
                state += 1;
                txtPassword.UseSystemPasswordChar = false;
                filled_hide_pass.Image = Properties.Resources.visible_filled_20px;
            } else if(state != 0)
            {
                state -= 1;
                txtPassword.UseSystemPasswordChar = true;
                filled_hide_pass.Image = Properties.Resources.hide_filled_20px;                
            }
        }

        private void filled_hide_confirmPass_Click(object sender, EventArgs e)
        {
            if (state == 0)
            {
                state += 1;
                txtConfirmPassword.UseSystemPasswordChar = false;
                filled_hide_confirmPass.Image = Properties.Resources.visible_filled_20px;
            }
            else if (state != 0)
            {
                state -= 1;
                txtConfirmPassword.UseSystemPasswordChar = true;
                filled_hide_confirmPass.Image = Properties.Resources.hide_filled_20px;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtPhone.Text.Length == 9) || !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;            
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if(txtPhone.Text.Length > 0)
            {
                cleanPhoneInput.Visible = true;
            }
        }

        private void cleanPhoneInput_Click(object sender, EventArgs e)
        {
            txtPhone.Clear();
        }

        private void keyForm_event(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAuth_Click(sender, e);            
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if(!txtConfirmPassword.Text.Trim().Equals(txtPassword.Text.Trim()))            
               Transition.run(txtConfirmPassword, "ForeColor", Color.Red, new TransitionType_Deceleration(950));          
            else Transition.run(txtConfirmPassword, "ForeColor", Color.Green, new TransitionType_Deceleration(950));
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }
    }
}
