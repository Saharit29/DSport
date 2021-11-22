using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using sport.Properties;


namespace sport
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

        }
        AC ocn = new AC();
        OleDbDataReader loginReader;
        //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;data source=D:/athletes/db_athletes.accdb";
        //public string sql;
        //OleDbConnection Conn = new OleDbConnection();
        //OleDbDataAdapter da;
        //bool IsFind = false;


        private void Formlogin_Load(object sender, EventArgs e)
        {
            //sport.Properties.AC.openConnection();
            //MessageBox.Show("the  connection is" + sport.Properties.AC.con.State.ToString(), "Test Connection",MessageBoxButtons.OK, MessageBoxIcon.Information);

            //sport.Properties.AC.closeConnection();
           //MessageBox.Show("the  connection is" + sport.Properties.AC.con.State.ToString(), "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void checkpassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkpassword.Checked == true)
            {
                txtpassword.PasswordChar = (char)0;
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void btncancal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "" && txtpassword.Text != "")
            {
                Check_login();
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัส", "Msg",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
            private void Check_login()
            {
                if ((string.IsNullOrEmpty(this.txtusername.Text.Trim())) || (string.IsNullOrEmpty(this.txtpassword.Text.Trim())))
                {
                    MessageBox.Show("Please is input your uaername and password.", "Data Entry Erorr", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    if (this.txtusername.CanSelect)
                    {
                        this.txtusername.Select();
                    }
                    return;
                }
                

                AC.sql = "SELECT * FROM tb_officer WHERE username = @us AND password = @pa";
                AC.cmd.Parameters.Clear();
                AC.cmd.CommandType = CommandType.Text;
                AC.cmd.CommandText = AC.sql;

                AC.cmd.Parameters.AddWithValue("@us", this.txtusername.Text.Trim().ToString());
                AC.cmd.Parameters.AddWithValue("@pa", this.txtpassword.Text.Trim().ToString());

                AC.openConnection();
                AC.rd = AC.cmd.ExecuteReader();
                if (AC.rd.HasRows)
                {
                while (AC.rd.Read())
                {
                    AC.currentusername = AC.rd[1].ToString();
                    AC.currentid = AC.rd[0].ToString();
                    

                    MessageBox.Show("Welcome " + AC.currentusername + "(^_^)", "login Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Formmain frm = new Formmain();
                    frm.Show();
                
                }
                    this.txtusername.Text = String.Empty;
                    this.txtpassword.Text = String.Empty;


                }
                else
                {
                    MessageBox.Show("sorry , Invaild username or password. try again");
                    if (this.txtusername.CanSelect)
                    {
                        this.txtusername.Select();
                    }
                    this.txtusername.Text = String.Empty;
                    this.txtpassword.Text = String.Empty;

                    AC.rd.Close();
                    AC.closeConnection();
                }
            }
        private void puvGetEmployee()
        {
            AC.openConnection();

            // get name
            string sSqlName = " SELECT * FROM tb_officer WHERE id_officer=@ofid";

            AC.cmd.Parameters.Clear();
            AC.cmd.Parameters.AddWithValue("@ofid", AC.currentid);
            AC.cmd.CommandType = CommandType.Text;
            AC.cmd.CommandText = sSqlName;
            loginReader = AC.cmd.ExecuteReader();

            if (loginReader.HasRows)
            {
                while (loginReader.Read())
                {
                    AC.currentname = loginReader["of_name"].ToString();
                    AC.currentsurname = loginReader["of_surname"].ToString();
                    AC.currentstatus = loginReader["status"].ToString();
                }
            }
        }
    
        



    }
}
