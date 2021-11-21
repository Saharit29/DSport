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

namespace DreamSportApp
{
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;data source=D:/132/Dbdsport.accdb";
        public string sql;
        OleDbConnection Conn = new OleDbConnection();
        OleDbDataAdapter da;
        DataSet ds = new DataSet();
        bool IsFind = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();

            }
            Conn.ConnectionString = strConn;
            Conn.Open();
            ShowAllEm();
            FormatDataEm();
        }
        private void ShowAllEm()
        {
            string sqlStu = "select * from tb_Officer";
            if (IsFind == true)
            {
                ds.Tables["tb_Officer"].Clear();
            }
            da = new OleDbDataAdapter(sqlStu, Conn);
            da.Fill(ds, "tb_Officer");
            if (ds.Tables["tb_Officer"].Rows.Count != 0)
            {
                IsFind = true;
                dataGrid.ReadOnly = true;
                dataGrid.DataSource = ds.Tables["tb_Officer"];
            }
            else
            {
                IsFind = false;
            }
        }
        private void FormatDataEm()
        {
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Font = new Font("Ms Sans Serif", 10, FontStyle.Regular);
            dataGrid.ColumnHeadersDefaultCellStyle = cs;
            dataGrid.Columns[0].HeaderText = "รหัสเจ้าหน้าที่";
            dataGrid.Columns[1].HeaderText = "ชื่อ";
            dataGrid.Columns[2].HeaderText = "นามสกุล";
            dataGrid.Columns[3].HeaderText = "เพศ";
            dataGrid.Columns[4].HeaderText = "วัน เดือน ปี";
            dataGrid.Columns[5].HeaderText = "เบอร์มือถือ";
            dataGrid.Columns[6].HeaderText = "ชื่อผู้ใช้";
            dataGrid.Columns[7].HeaderText = "รหัสผ่าน";
            dataGrid.Columns[8].HeaderText = "สถานะ";

            dataGrid.Columns[0].Width = 80;
            dataGrid.Columns[1].Width = 120;
            dataGrid.Columns[2].Width = 120;
            dataGrid.Columns[3].Width = 100;
            dataGrid.Columns[4].Width = 120;
            dataGrid.Columns[5].Width = 120;
            dataGrid.Columns[6].Width = 100;
            dataGrid.Columns[7].Width = 120;
            dataGrid.Columns[8].Width = 120;
            





        }

        private void dataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == dataGrid.Rows.Count - 1)
            {
                return;
            }
            try
            {
                txtID.Text = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSurname.Text = dataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtgen.Text = dataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                Bdate.Value = Convert.ToDateTime(dataGrid.Rows[e.RowIndex].Cells[4].Value);
                txtphone.Text = dataGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUsername.Text = dataGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPassword.Text = dataGrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtStatus.Text = dataGrid.Rows[e.RowIndex].Cells[8].Value.ToString();
            }

            catch
            {
                MessageBox.Show("ผิดพลาด");
            }
        }
        private void ClearAllEm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtgen.Text = "";
            Bdate.Value = DateTime.Now;
            txtphone.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtStatus.Text = "";
            txtID.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAllEm();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให่", "ผิดพลาด");
                txtID.Focus();
                return;
            }
            string sqlAdd = "";
            OleDbCommand comAdd = new OleDbCommand();
            try
            {
                if (MessageBox.Show("คุณต้องอยากเพิ่งข้อมูล ใช่หรือไม่", "คำเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlAdd = "INSERT INTO tb_Officer(id_Of, name_Of, surname_Of, gender_Of, Bdate_Of, Phone_Of, Username, Password, Status)values('" + txtID.Text + "','" + txtName.Text + "','" + txtSurname.Text + "','" + txtgen.Text + "','" + Bdate.Value + "','" + txtphone.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtStatus.Text + "')";
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                    }
                    Conn.ConnectionString = strConn;
                    Conn.Open();

                    comAdd.CommandType = CommandType.Text;
                    comAdd.CommandText = sqlAdd;
                    comAdd.Connection = Conn;
                    comAdd.ExecuteNonQuery();

                    MessageBox.Show("ได้บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการดำเนินการ");
                    ClearAllEm();
                    ShowAllEm();
                }
            }
            catch
            {
                MessageBox.Show("ไม่สามารถติดต่อข้อมูลได้", "ผิดพลาด");
            }
        }
    }
}
