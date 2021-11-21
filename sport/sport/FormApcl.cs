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
    public partial class FormApcl : Form
    {
        public FormApcl()
        {
            InitializeComponent();
        }
        OleDbDataAdapter da;
       
        string stateGenter = "";

        AC ocn = new AC();
        private void ShowAllApcl()
        {

            string SqlApcl = "SELECT * from tb_applicant";
            if (AC.IsFind == true)
            {
                AC.ds.Tables["tb_applicant"].Clear();
            }
            da = new OleDbDataAdapter(SqlApcl, AC.con);
            da.Fill(AC.ds, "tb_applicant");
            if (AC.ds.Tables["tb_applicant"].Rows.Count != 0)
            {
                AC.IsFind = true;
                TbApcldata.ReadOnly = true;
                TbApcldata.DataSource = AC.ds.Tables["tb_applicant"];
            }
            else
            {
                AC.IsFind = false;
            }
        }

        private void FormApcl_Load(object sender, EventArgs e)
        {
            
           
            if (AC.con.State == ConnectionState.Open)
            {
                AC.con.Close();

            }
            AC.con.ConnectionString = AC.getConnectionString();
            AC.con.Open();
            ShowAllApcl();
            FormatTbApcldata();
        }
        private void FormatTbApcldata()
        {
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Font = new Font("Ms Sans Serif", 10, FontStyle.Regular);
            TbApcldata.ColumnHeadersDefaultCellStyle = cs;
            TbApcldata.Columns[0].HeaderText = "เลขประจำตัวประชาชน";
            TbApcldata.Columns[1].HeaderText = "ชื่อ";
            TbApcldata.Columns[2].HeaderText = "นามสกุล";
            TbApcldata.Columns[3].HeaderText = "เพศ";
            TbApcldata.Columns[4].HeaderText = "สัญชาติ";
            TbApcldata.Columns[5].HeaderText = "Email";
            TbApcldata.Columns[6].HeaderText = "เบอร์มือถือ";
            TbApcldata.Columns[7].HeaderText = "บ้าานเลขที่";
            TbApcldata.Columns[8].HeaderText = "หมู่";
            TbApcldata.Columns[9].HeaderText = "อำเภอ";
            TbApcldata.Columns[10].HeaderText = "ถนน";
            TbApcldata.Columns[11].HeaderText = "จังหวัด";
            TbApcldata.Columns[12].HeaderText = "ตำบล";
            TbApcldata.Columns[13].HeaderText = "วัน เดือน ปี เกิด";
            TbApcldata.Columns[14].HeaderText = "วันที่สมัคร";
            
           


            TbApcldata.Columns[0].Width = 180;
            TbApcldata.Columns[1].Width = 120;
            TbApcldata.Columns[2].Width = 120;
            TbApcldata.Columns[3].Width = 100;
            TbApcldata.Columns[4].Width = 100;
            TbApcldata.Columns[5].Width = 100;
            TbApcldata.Columns[6].Width = 100;
            TbApcldata.Columns[7].Width = 120;
            TbApcldata.Columns[8].Width = 120;
            TbApcldata.Columns[9].Width = 100;
            TbApcldata.Columns[10].Width = 100;
            TbApcldata.Columns[11].Width = 100;
            TbApcldata.Columns[12].Width = 100;
            TbApcldata.Columns[13].Width = 120;
            TbApcldata.Columns[14].Width = 120;
            
            
            

        }

        private void TbApcldata_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == TbApcldata.Rows.Count - 1)
            {
                return;
            }
            try
            {
                txtApclidnumber.Text = TbApcldata.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtApclname.Text = TbApcldata.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtApclsurname.Text = TbApcldata.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtApclntointy.Text = TbApcldata.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtApclemail.Text = TbApcldata.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtApclphone.Text = TbApcldata.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtApclHonum.Text = TbApcldata.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtApclswine.Text = TbApcldata.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtApcldistrist.Text = TbApcldata.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtApclstreet.Text = TbApcldata.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtApclprovince.Text = TbApcldata.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtApclsub_dstrict.Text = TbApcldata.Rows[e.RowIndex].Cells[12].Value.ToString();
                Apclb_date.Value = Convert.ToDateTime(TbApcldata.Rows[e.RowIndex].Cells[13].Value);
                Apcldate.Value = Convert.ToDateTime(TbApcldata.Rows[e.RowIndex].Cells[14].Value);
                
                
            }
            catch
            {
                MessageBox.Show("ผิดพลาด");
            }
        }
            private void ClearAllApcl()
            {
                txtApclidnumber.Text = "";
                txtApclname.Text = "";
                txtApclsurname.Text = "";
                radioMale.Checked = false;
                radioFemale.Checked = false;
                txtApclntointy.Text = "";
                txtApclemail.Text = "";
                txtApclphone.Text = "";
                txtApclHonum.Text = "";
                txtApclswine.Text = "";
                txtApcldistrist.Text = "";
                txtApclstreet.Text = "";
                txtApclprovince.Text = "";
                txtApclsub_dstrict.Text = "";
                Apclb_date.Value = DateTime.Now;
                Apcldate.Value = DateTime.Now;
                Apclimg.Image = null;
                txtApclidnumber.Focus();
            }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            ClearAllApcl();
            
        }
        private void checkStateGender()
        {
            if (radioMale.Checked == true)
            {
                stateGenter = "ชาย";
            }
            else
            {
                stateGenter = "หญิง";
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            string sqlEdit;
            OleDbCommand comEdit = new OleDbCommand();
            try
            {
                if (MessageBox.Show("คุณต้องอยากเพิ่งข้อมูล ใช่หรือไม่", "ยืนยีน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlEdit = "update tb_applicant set aplc_name = '" + txtApclname.Text + 
                        "',aplc_surname = '" + txtApclsurname.Text +
                        "',aplc_gender = '" + stateGenter +
                        "' ,aplc_nationality = '" + txtApclntointy.Text + 
                        "',aplc_Email = '" + txtApclemail.Text + 
                        "',aplc_phone = '" + txtApclphone.Text +
                        "',aplc_honum = '" + txtApclHonum.Text +
                        "',aplc_swine = '" + txtApclswine.Text +
                        "',aplc_district = '" + txtApcldistrist.Text +
                        "',aplc_street = '" + txtApclstreet.Text +
                        "',aplc_province = '" + txtApclprovince.Text +
                        "',aplc_sub_district = '" + txtApclsub_dstrict.Text +
                        "',aplcb_date = '" + Apclb_date.Value +
                        "',aplica_date = '" + Apcldate.Value +
                        "', = '" + txtApclphone.Text +
                        "'where id_numberaplc = '" + txtApclidnumber.Text + "'";

                    if (AC.con.State == ConnectionState.Open)
                    {
                        AC.con.Close();
                    }
                    AC.openConnection();
                    AC.con.Open();

                    comEdit.CommandType = CommandType.Text;
                    comEdit.CommandText = sqlEdit;
                    comEdit.Connection = AC.con;
                    comEdit.ExecuteNonQuery();

                    MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                    ClearAllApcl();
                    ShowAllApcl();
                }
            }
            catch
            {
                MessageBox.Show("ข้อมูลผิดพลาด");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             
             string sqlAddApcl = "";
             try
             {
                 if (MessageBox.Show("เพิ่มข้อมูลใช่หรือไม่", "เพิ่มข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     sqlAddApcl = " INSERT INTO tb_applicant(id_numberaplc,aplc_name,aplc_surname,aplc_gender,aplc_nationality" +
                         ",aplc_Email,aplc_phone,aplc_honum,aplc_swine,aplc_district,aplc_street,aplc_province,aplc_sub_district" +
                         ",aplcb_date,aplica_date,aplc_img) VALUES('" + txtApclidnumber.Text + "','" + txtApclname.Text + "','" + txtApclsurname.Text + "'" +
                         ",'" + stateGenter + "','" + txtApclntointy.Text + "','" + txtApclemail.Text + "','" + txtApclphone.Text + "'," +
                         "'" + txtApclHonum.Text + "','" + txtApclswine.Text + "','" + txtFtdistrict.Text + "','" + txtApclstreet.Text + "'," +
                         "'" + txtApclprovince.Text + "','" + txtApclsub_dstrict.Text + "','" + Apclb_date.Value + "','" + Apcldate.Text + "')";

                    if (AC.con.State == ConnectionState.Open)
                    {
                        AC.con.Close();
                    }

                    AC.openConnection();
                    AC.con.Open();

                    
                    AC.cmd.CommandType = CommandType.Text;
                    AC.cmd.CommandText = sqlAddApcl;
                    AC.cmd.Connection = AC.con;
                    AC.cmd.ExecuteNonQuery();


                    MessageBox.Show("ได้บันทึกข้อมูลเรียบร้อยแล้ว", "ผลการดำเนินการ");


                    ClearAllApcl();
                    ShowAllApcl();

                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("ไม่สามารถติดต่อฐานข้อมูลได้:" + ex.Message, "ผิดพลาด");
             }
             
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {   

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtApclidnumber.Text == "")
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลที่จะลบ", "ผิดพลาด");
                    return;
                }
                String sqlDel = "delete from tb_applicant where id_numberaplc = '" + txtApclidnumber.Text + "'";
                if (AC.con.State == ConnectionState.Open)
                {
                    AC.con.Close();
                }

                AC.con.ConnectionString = AC.getConnectionString();
                AC.con.Open();

                OleDbCommand comDel = new OleDbCommand(sqlDel, AC.con);

                if (MessageBox.Show("คุณต้องการลบข้อมูลนี้ใช่หรือไม่", "ยืนยัน",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    comDel.ExecuteNonQuery();
                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ผลการดำเนินการ");
                    ClearAllApcl();
                    ShowAllApcl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlStu = "select * from tb_applicant where id_numberaplc = '" + txtSearch.Text + "'";
            {
                AC.ds.Tables["tb_applicant"].Clear();
            }
            da = new OleDbDataAdapter(sqlStu, AC.con);
            da.Fill(AC.ds, "tb_applicant");
            if (AC.ds.Tables["tb_applicant"].Rows.Count != 0)
            {
                AC.IsFind = true;
                TbApcldata.ReadOnly = true;
                TbApcldata.DataSource = AC.ds.Tables["tb_applicant"];
            }
            else
            {
                AC.IsFind = false;
            }
        }

        private void btnsearchAll_Click(object sender, EventArgs e)
        {
            ShowAllApcl();
        }

 
    }
    
}
