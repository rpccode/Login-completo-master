using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Domain;

namespace Precentacion
{
    public partial class FormUserPerfil : Form
    {
        public FormUserPerfil()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FormUserPerfil_Load(object sender, EventArgs e)
        {
            loadUserProfile();
            initializePassEditControl();
        }
        private void loadUserProfile()
        {
            lblUserName.Text = UserLoginCache.LoginName;
            lblName.Text = UserLoginCache.FirsName ;
            lblLastName.Text = UserLoginCache.LastName;
            lblEmail.Text = UserLoginCache.Email;
            lblPosition.Text = UserLoginCache.Position;

            //edit panel
            txtUserName.Text = UserLoginCache.LoginName;
            txtName.Text = UserLoginCache.FirsName;
            txtLastName.Text = UserLoginCache.LastName;
            txtEmail.Text = UserLoginCache.Email;
            txtPassword.Text = UserLoginCache.Password;
            txtConfirmPass.Text = UserLoginCache.Password;
            txtCurrentPass.Text = "";

        }

        private void initializePassEditControl()
        {
            lblEdit.Text = "Editar";
            txtPassword.Enabled = false;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPass.Enabled = false;
            txtConfirmPass.UseSystemPasswordChar = true;
            txtCurrentPass.UseSystemPasswordChar = true;
        }

        private void Resect()
        {
            loadUserProfile();
            initializePassEditControl();
        }

        private void lblEditPerfiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            loadUserProfile();
        }

        private void lblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblEdit.Text == "Editar")
            {
                lblEdit.Text = "Cancelar";
                txtPassword.Enabled = true;
                txtPassword.Text = "";
                txtConfirmPass.Enabled = true;
                txtConfirmPass.Text = "";
            }
            if(lblEdit.Text == "Cancelar")
            {
                Resect();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= 5)
            {
                if (txtPassword.Text == txtConfirmPass.Text)
                {
                    if (txtCurrentPass.Text == UserLoginCache.Password)
                    {
                        var userModel = new UserModel(
                            idUser: UserLoginCache.IdUsuario,
                            loginName: txtUserName.Text,
                            password: txtPassword.Text,
                            firstName: txtName.Text,
                            lastName: txtLastName.Text,
                            position: null,
                            email: txtEmail.Text);
                        var result = userModel.edictPerfilUser();
                        MessageBox.Show(result);
                        Resect();
                        panel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("clave  actual incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Las claves no concuerdan");
                }
            }
            else
            {
                MessageBox.Show("la Clave deve tener un minimo de 5 caracteres");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Resect();
        }
    }
}
