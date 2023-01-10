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

namespace Precentacion
{
    public partial class FormReoverPassword : Form
    {
        public FormReoverPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var user = new UserModel();
            var resultado = user.recoveryPassword(txtUserRequesting.Text);
            lblResultado.Text = resultado;
        }
    }
}
