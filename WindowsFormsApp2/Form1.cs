using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private const string LOGIN_PARAMETER="@login";
        private const string PASSWORD_PARAMETER="@password";
        public Form1()
        {
            InitializeComponent();
            mySqlCommand1.Parameters.Add(LOGIN_PARAMETER, MySqlConnector.MySqlDbType.VarChar);
            mySqlCommand1.Parameters.Add(PASSWORD_PARAMETER, MySqlConnector.MySqlDbType.VarChar);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection1.Open();

                mySqlCommand1.Parameters[LOGIN_PARAMETER].Value = txtBoxLogin.Text;
                mySqlCommand1.Parameters[PASSWORD_PARAMETER].Value = txtBoxPassword.Text;

                int result=Convert.ToInt32(mySqlCommand1.ExecuteScalar());

                if(result >0)
                {
                    MessageBox.Show("WSZYSCY ŚLĄZACY ŁĄCZIE SIĘ");
                }
                else
                {
                    MessageBox.Show("J***** KOMUNIZM");

                }

                mySqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
