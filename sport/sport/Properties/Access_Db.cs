using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace sport.Properties
{
    class AC
    {
        public static OleDbConnection con = new OleDbConnection();
        public static OleDbCommand cmd = new OleDbCommand("", con);
        public static OleDbDataReader rd;
        public static OleDbDataAdapter da;
        public static DataSet ds = new DataSet();

        public static string currentusername;
        public static string currentstatus;
        public static string currentname;
        public static string currentsurname;
        public static string currentid;
        public static string sql;
        
        public static bool IsFind = false;
        public static bool bCheckConnect = false;

        public static string getConnectionString()
        {
            // Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\athletes\db_athletes.accdb
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=D:/athletes/db_athletes.accdb;";

            return connectionString;
        }
        public static void openConnection()
        {
            try
            {
                
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = getConnectionString();
                    con.Open();
                }
                
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("ระบบไม่สามารถสร้างการเชื่อมต่อได้" + "\n" +
                    "รายละเอียด: " + ex.Message.ToString(), "ผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void closeConnection()
        {
            try
            {
                
                if (con.State == ConnectionState.Open)
                {

                    con.Close();
                }
                
            }
            catch
            {
                MessageBox.Show("Close Connection Failed");

            }

        }
        public Boolean CloseChildForm(Form _FormCtrls, string _sFormName)
        {
            foreach (Form Form in _FormCtrls.MdiChildren)
            {
                if (Form.Name == _sFormName)
                {
                    Form.Focus();
                    return true;
                }
            }

            return false;
        }
        public DataSet pudsLoadData(string _sSql, string _sNameTable, DataSet _ds)
        {
            DataSet ds = new DataSet();
            try
            {
                _ds.Clear();
                if (bCheckConnect == false)
                {
                    openConnection();
                }
                OleDbDataAdapter oleDA = new OleDbDataAdapter(_sSql, con);
                OleDbCommandBuilder oleCMDB = new OleDbCommandBuilder(oleDA);
                oleDA.Fill(_ds, _sNameTable);
                ds = _ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadData :" + ex.Message.ToString(), "Msg",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return ds;
        }
        public DataSet LoadData(string _sSql, string _sNameTable, DataSet _ds)
        {
            DataSet ds = new DataSet();
            try
            {
                _ds.Clear();
                if (bCheckConnect == false)
                {
                    openConnection();
                }
                OleDbDataAdapter oleDA = new OleDbDataAdapter(_sSql, con);
                OleDbCommandBuilder oleCMDB = new OleDbCommandBuilder(oleDA);
                oleDA.Fill(_ds, _sNameTable);
                ds = _ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadData :" + ex.Message.ToString(), "Msg",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return ds;
        }
    }
 }

