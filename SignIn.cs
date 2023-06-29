using System.Data.SqlClient;
using System.Threading;

namespace Register
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        Thread t1;

        SqlConnection sqlConnection = new SqlConnection(@"Data source=DESKTOP-U54SHGF\DBGUILHERME; Persist Security Info = False; User ID =sa; Password=sa.@2;Initial Catalog = Teste; TrustServerCertificate = true;");
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;

        User user = new User();

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            user.CheckUser(txt_Email.Text);
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(OpenWindow);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();

        }

        public void OpenWindow(Object obj)
        {
            Application.Run(new SignUp());

        }
    }
}