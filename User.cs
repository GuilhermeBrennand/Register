using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Register
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int Old_Password { get; set; }

        public User()
        {

        }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data source=DESKTOP-U54SHGF\DBGUILHERME; Persist Security Info = False; User ID =sa; Password=sa.@2;Initial Catalog = Teste; TrustServerCertificate = true;");
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;

        public void CheckUser(string email)
        {
            Email = email;

            try
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $"select * from usuario where email='{Email}'";
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows){
                    MessageBox.Show("Email já cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Email não cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void RegisterUser()
        {
            sqlConnection.Open();
            string strSQL =  $"INSERT INTO usuario (name, email, password) VALUES (@name, @email, @password) ";
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = Name;
            sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;
            sqlCommand.CommandText = strSQL;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Usuário cadastrado com sucesso!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            sqlCommand.Parameters.Clear();

        }
    }
}
