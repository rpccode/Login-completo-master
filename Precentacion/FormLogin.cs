using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Precentacion;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
            }
                
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "") 
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void textpass_Enter(object sender, EventArgs e)
        {
            if(textpass.Text == "Pass")
            {
                textpass.Text = "";
                textpass.ForeColor = Color.White;
                textpass.UseSystemPasswordChar = true;
            }
        }

        private void textpass_Leave(object sender, EventArgs e)
        {
            if(textpass.Text == "")
            {
                textpass.Text = "Pass";
                textpass.ForeColor = Color.LightGray;
                textpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimixar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnaccess_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "Usuario")
            {
                if (textpass.Text != "pass") 
                {
                    UserModel user = new UserModel();
                    var validarLogin = user.LoginUser(txtUsuario.Text,textpass.Text);
                    if(validarLogin == true)
                    {
                        this.Hide();
                        FormBienvenidad welcome = new FormBienvenidad();
                        welcome.ShowDialog();

                        FormPrincipal MainMenu = new FormPrincipal();
                        MainMenu.Show();
                        MainMenu.FormClosed += logout;
                       
                    }
                    else
                    {
                        msgError("Usuario o Contraseña Incorrectas. \n Please try again.");
                        textpass.Text="Pass";
                        txtUsuario.Focus();  
                    }
                }
                else msgError("Por favor ingrese su Contraseña");

            }
            else msgError("Por favor ingrese su nombre de Usuario");
        }
        private void msgError(string msg)
        {
            lblErrrorMessage.Text = "    " + msg;
            lblErrrorMessage.Visible = true;
        }
        private void logout(object sender, FormClosedEventArgs e)
        {
            textpass.Text = "Pass";
            textpass.UseSystemPasswordChar = false;
            txtUsuario.Text = "Usuario";
            lblErrrorMessage.Visible = false;
            this.Show();
           //textpass.Focus();
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoveryPassword = new FormReoverPassword();
            recoveryPassword.ShowDialog();
        }
    }
}
