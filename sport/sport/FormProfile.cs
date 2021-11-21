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
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }
        OleDbDataAdapter da;
        string sSql;
        string stateGenter = "";
        
        string stateStatus;
        AC ocn = new AC();

        private void FormProfile_Load(object sender, EventArgs e)
        {
            if (AC.currentstatus == "User")
            {
                ShowForUserLogin();
                
                tbDateOf.Hide();
                tbDateOf.Hide();
                
                
            }
            // ================================== Admin ================================== //
            else
            {

                lbStatus.Hide();
                
                prvShowAllMember();
                prvFormatDataEmployee();

                

                tbDateOf.ReadOnly = true;
            }
        }
        private void prvShowAllMember()
        {
            string sSqlOf = "select * from tb_officer";
            

            /*if (AC.IsFind == true)
            {
                AC.ds.Tables["tb_officer"].Clear();
            }

            da = new OleDbDataAdapter(sSqlOf, AC.con);
            da.Fill(AC.ds, "tb_officer");
            if (AC.ds.Tables["tb_officer"].Rows.Count != 0)
            {
                AC.IsFind = true;
                tbDateOf.ReadOnly = true;
                tbDateOf.DataSource = AC.ds.Tables["td_officer"];
            }
            else
            {
                AC.IsFind = false;
            }*/

            // ------------------------------------------------------- //
            DataSet dsAdmin = new DataSet();
            OleDbDataAdapter daAdmin = new OleDbDataAdapter(sSqlOf, AC.con);
            bool bCheck = false;

            if (bCheck == true)
            {
                dsAdmin.Tables["tb_officer"].Clear();
            }

            //daLogin = new OleDbDataAdapter();
            daAdmin.Fill(dsAdmin, "tb_officer");

            if (dsAdmin.Tables["tb_officer"].Rows.Count != 0)
            {
                bCheck = true;
                tbDateOf.ReadOnly = true;
                tbDateOf.DataSource = dsAdmin.Tables["tb_officer"];
            }
            else
            {
                bCheck = false;
            }


        }
        private void ShowForUserLogin()
        {
            try
            {

                //AC ocn = new AC();

                DataSet dsAdmin = new DataSet();

                sSql = "";
                sSql = " SELECT * FROM tb_officer WHERE username ='" + AC.currentusername + "'";
                dsAdmin = ocn.pudsLoadData(sSql, "tb_officer", dsAdmin);

                if (dsAdmin.Tables["tb_officer"].Rows.Count != 0)
                {
                    txtNameOf.Text = dsAdmin.Tables["tb_officer"].Rows[0]["of_name"].ToString();
                    txtsurNameOf.Text = dsAdmin.Tables["tb_officer"].Rows[0]["of_surname"].ToString();
                    txtPhoneOf.Text = dsAdmin.Tables["tb_officer"].Rows[0]["of_phone"].ToString();
                    BdateTime.Value = Convert.ToDateTime( dsAdmin.Tables["tb_officer"].Rows[0]["of_b_date"]);
                    txtUsernameOf.Text = dsAdmin.Tables["tb_officer"].Rows[0]["username"].ToString();
                    txtPasswordOf.Text = dsAdmin.Tables["tb_officer"].Rows[0]["password"].ToString();
                    lbStatus.Text = dsAdmin.Tables["tb_officer"].Rows[0]["status"].ToString();
                    txtIDOf.Text = dsAdmin.Tables["tb_officer"].Rows[0]["id_officer"].ToString();



                }
            
                // ======================================== End  it is fill all data from tb_login to dataGridView ================================================== //


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on private void fillofficerData(string id_officer): " + ex.Message, "mesg");
            }

        }

        private void tbDateOf_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == tbDateOf.Rows.Count)
            {
                return;
            }
            try
            {
                txtIDOf.Text = tbDateOf.Rows[e.RowIndex].Cells[0].Value.ToString();

                 

                txtNameOf.Text = tbDateOf.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtsurNameOf.Text = tbDateOf.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhoneOf.Text = tbDateOf.Rows[e.RowIndex].Cells[3].Value.ToString();
                BdateTime.Value = Convert.ToDateTime(tbDateOf.Rows[e.RowIndex].Cells[4].Value);
                stateGenter = tbDateOf.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (stateGenter == "ชาย")
                {
                    radiomaleOf.Checked = true;
                }
                else
                {
                    radiofemaleOf.Checked = true;
                }
                txtUsernameOf.Text = tbDateOf.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPasswordOf.Text = tbDateOf.Rows[e.RowIndex].Cells[7].Value.ToString();
                stateStatus = tbDateOf.Rows[e.RowIndex].Cells[8].Value.ToString();
                if (stateGenter == "User")
                {
                    radioUser.Checked = true;
                }
                else
                {
                    radioAdmin.Checked = true;
                }

                //dtpBirthDate.CustomFormat = "dd.MMM-yyyy";







            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error krub",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void prvClearAll()
        {
            txtIDOf.Text = "";
            txtNameOf.Text = "";
            txtsurNameOf.Text = "";
            txtPasswordOf.Text = "";
            txtPhoneOf.Text = "";
            txtUsernameOf.Text = "";
            radioUser.Checked = true;
            radioAdmin.Checked = false;
        }
   
        public Boolean CloseChildForm(Form _FrmCtrls, string _sFrmName)
        {
            foreach (Form Frm in _FrmCtrls.MdiChildren)
            {
                if (Frm.Name == _sFrmName)
                {
                    Frm.Focus();
                    return true;
                }
            }

            return false;
        }
        private void btnAddEm_Click(object sender, EventArgs e)
        {
            if (txtNameOf.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่จะแก้ไขให้ครบ", "ผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNameOf.Focus();
                return;
            }

            //OleDbCommand comEdit = new OleDbCommand();
            try
            {
                
                

                if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลใช่หรือไม่", "ยืนยัน",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (AC.currentstatus == "User")
                    {
                        EditFunction();
                    }
                    else
                    {
                        EditFunction();
                        prvClearAll();
                        prvShowAllMember();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อมูลผิดพลาด:" + ex.Message, "ผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            
            

            try
            {
                
                if (MessageBox.Show("เพิ่มข้อมูลใช่หรือไม่", "เพิ่มข้อมูล",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlAddEmp = "";

                    AC.openConnection();

                    sqlAddEmp = " INSERT INTO tb_officer(id_officer,of_name,of_surname,of_phone,of_b_date,of_gender,uesrname,password,status) VALUES(@id,@name,@surname,@gender,@bdate,@gender,@username,@password,@status)";

                    AC.cmd.Parameters.Clear();

                    AC.cmd.Parameters.AddWithValue("@id", txtIDOf.Text.Trim().ToString());
                    AC.cmd.Parameters.AddWithValue("@name", txtNameOf.Text.Trim().ToString());
                    AC.cmd.Parameters.AddWithValue("@lastname", txtsurNameOf.Text.Trim().ToString());
                    AC.cmd.Parameters.AddWithValue("@phone", txtPhoneOf.Text.Trim().ToString());
                    AC.cmd.Parameters.AddWithValue("@bdate", BdateTime.Value.GetDateTimeFormats('d')[0]);
                    AC.cmd.Parameters.AddWithValue("@gender", stateGenter);
                    AC.cmd.Parameters.AddWithValue("@username", txtUsernameOf.Text.Trim().ToString());
                    AC.cmd.Parameters.AddWithValue("@password", txtPasswordOf.Text.Trim().ToString());
                    AC.cmd.Parameters.AddWithValue("@status", stateStatus);

                    AC.cmd.CommandType = CommandType.Text;
                    AC.cmd.CommandText = sqlAddEmp;
                    AC.cmd.Connection = AC.con;
                    AC.cmd.ExecuteNonQuery();

                    // ========================================  Insert Data Into tb_login ==================================== //
           
                    MessageBox.Show("ได้บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการดำเนินการ");


                    prvClearAll();
                    prvShowAllMember();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูลได้:" + ex.Message, "โปรดลองอีกครั้ง",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void prvFormatDataEmployee()
        {
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Font = new Font("Ms Sans Serif", 10, FontStyle.Regular);
            tbDateOf.ColumnHeadersDefaultCellStyle = cs;
            tbDateOf.Columns[0].HeaderText = "รหัสพนักงาน";
            tbDateOf.Columns[1].HeaderText = "ชื่อ";
            tbDateOf.Columns[2].HeaderText = "นามสกุล";
            tbDateOf.Columns[3].HeaderText = "เบอร์โทร";
            tbDateOf.Columns[4].HeaderText = "วันเดือนปีเกิด";
            tbDateOf.Columns[5].HeaderText = "เพศ";
            tbDateOf.Columns[6].HeaderText = "ชื่อผู้ใช้";
            tbDateOf.Columns[7].HeaderText = "รหัสผ่าน";
            tbDateOf.Columns[8].HeaderText = "สถานะ";

            tbDateOf.Columns[0].Width = 120;
            tbDateOf.Columns[1].Width = 220;
            tbDateOf.Columns[2].Width = 220;
            tbDateOf.Columns[3].Width = 60;
            tbDateOf.Columns[4].Width = 160;
            tbDateOf.Columns[5].Width = 160;
            tbDateOf.Columns[6].Width = 60;
            tbDateOf.Columns[7].Width = 160;
            tbDateOf.Columns[8].Width = 160;
        }

        private void btnDeleteEm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDOf.Text == "")
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลที่จะลบ", "ผิดพลาด");
                    return;
                }
           
                string stateOfID = "";
                stateOfID = txtIDOf.Text;
                String sqlDelOf = "DELETE FROM tb_officer WHERE id_officer='" + stateOfID + "'";
                
                AC.openConnection();

                OleDbCommand comDelOf = new OleDbCommand(stateOfID, AC.con);
                

                if (MessageBox.Show("คุณต้องการลบข้อมูลนี้ใช่หรือไม่", "ยืนยัน",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    comDelOf.ExecuteNonQuery();
                    
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ผลการดำเนินการ");
                    prvClearAll();
                    prvShowAllMember();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString(), "โปรดลองอีกครั้ง",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditEm_Click(object sender, EventArgs e)
        {
            if (txtNameOf.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่จะแก้ไขให้ครบ", "ผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNameOf.Focus();
                return;
            }

            //OleDbCommand comEdit = new OleDbCommand();
            try
            {
                

                if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลใช่หรือไม่", "ยืนยัน",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (AC.currentstatus == "user")
                    {
                        EditFunction();
                    }
                    else
                    {
                        EditFunction();
                        prvClearAll();
                        prvShowAllMember();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อมูลผิดพลาด:" + ex.Message, "ผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditFunction()
        {
            if (radioAdmin.Checked == true)
            {
                stateStatus = "Admin";
            }
            else
            {
                stateStatus = "User";
            }


            string sqlEdit;
            

             
            sqlEdit = " UPDATE tb_officer SET of_name='" + txtNameOf.Text
                + "',of_surname='" + txtsurNameOf.Text
                + "',of_phone='" + txtPhoneOf.Text
                + "',of_b_date='" + BdateTime.Value
                + "',of_gender='" + stateGenter
                + "',username='" + txtUsernameOf.Text
                + "',password='" + txtPasswordOf.Text
                + "',status='" + stateStatus
                + "'WHERE id_officer= '"+ txtIDOf + "'";

        

            AC.openConnection();

            AC.cmd.CommandType = CommandType.Text;
            AC.cmd.CommandText = sqlEdit;
            AC.cmd.Connection = AC.con;
            AC.cmd.ExecuteNonQuery();

   




        }
        private void ShowAllOf()
        {

            string SqlApcl = "SELECT * from tb_officer";
            if (AC.IsFind == true)
            {
                AC.ds.Tables["tb_officer"].Clear();
            }
            da = new OleDbDataAdapter(SqlApcl, AC.con);
            da.Fill(AC.ds, "tb_officer");
            if (AC.ds.Tables["tb_officer"].Rows.Count != 0)
            {
                AC.IsFind = true;
                tbDateOf.ReadOnly = true;
                tbDateOf.DataSource = AC.ds.Tables["tb_officer"];
            }
            else
            {
                AC.IsFind = false;
            }
        }
        private void btnSearchOf_Click(object sender, EventArgs e)
        {
            string sqlStu = "select * from tb_officer where id_officer = '" + txtSearchOf.Text + "'";
            {
                AC.ds.Tables["tb_officer"].Clear();
            }
            AC.da = new OleDbDataAdapter(sqlStu, AC.con);
            AC.da.Fill(AC.ds, "tb_officer");
            if (AC.ds.Tables["tb_officer"].Rows.Count != 0)
            {
                AC.IsFind = true;
                tbDateOf.ReadOnly = true;
                tbDateOf.DataSource = AC.ds.Tables["tb_officer"];
                txtSearchOf.Text = " ";
            }
            else
            {
                AC.IsFind = false;
                
            }
            
        }

        private void btnSearchAllOf_Click(object sender, EventArgs e)
        {
            ShowAllOf();
        }

       
    }
    
    
}
