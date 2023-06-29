using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Register
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        Thread t2;
        User user = new User();

        private void btn_ToBack_Click(object sender, EventArgs e)
        {
            this.Close();
            t2 = new Thread(OpenWindow);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            user.Name = txt_rName.Text;
            user.Email = txt_rEmail.Text;
            user.Password = txt_rPassword.Text;

            user.RegisterUser();
        }

        public void OpenWindow(Object obj)
        {
            Application.Run(new SignIn());
        }

    }
}
