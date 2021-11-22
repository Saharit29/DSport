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
        DataSet dsSport = new DataSet();
        DataSet dsFather = new DataSet();
        DataSet dsMother = new DataSet();
        string sSport, sMother, sFather, sOfficer;
        string stateGen = "";
        

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
                
                txtAppID.Text = TbApcldata.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAppName.Text = TbApcldata.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAppSurname.Text = TbApcldata.Rows[e.RowIndex].Cells[2].Value.ToString();
                stateGen = TbApcldata.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (rdbMale.Checked == true)
                {
                    stateGen = "ชาย";
                }
                else
                {
                    stateGen = "หญิง";
                }

                txtAppNationality.Text = TbApcldata.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAppEmail.Text = TbApcldata.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAppPhone.Text = TbApcldata.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtAppHomeNumber.Text = TbApcldata.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtAppMoo.Text = TbApcldata.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAppDistrict.Text = TbApcldata.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtAppStreet.Text = TbApcldata.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtAppProvince.Text = TbApcldata.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtAppSubDistrict.Text = TbApcldata.Rows[e.RowIndex].Cells[12].Value.ToString();
                Apclb_date.Value = Convert.ToDateTime(TbApcldata.Rows[e.RowIndex].Cells[13].Value);
                Apcldate.Value = Convert.ToDateTime(TbApcldata.Rows[e.RowIndex].Cells[14].Value);

                

                sSport = TbApcldata.Rows[e.RowIndex].Cells[15].Value.ToString();
                sMother = TbApcldata.Rows[e.RowIndex].Cells[16].Value.ToString();
                sFather = TbApcldata.Rows[e.RowIndex].Cells[17].Value.ToString();
                if (sSport != "")
                {
                    DataSet sport = new DataSet();
                    string sSql = "select * from tb_sport";
                    OleDbCommand scmd = new OleDbCommand();
                    OleDbDataAdapter sda;
                    sda = new OleDbDataAdapter(sSql, AC.con);
                    sda.Fill(sport, "tb_sport");

                    if (sport.Tables["tb_sport"].Rows.Count != 0)
                    {
                        cobIDsport.Text = sSport;
                        cobSportname.Text = sport.Tables["tb_sport"].Rows[0]["sp_name"].ToString(); 
                        cobSporttype.Text = sport.Tables["tb_sport"].Rows[0]["sp_type"].ToString();
                        
                        
                    }

                }
                if (sMother != "")
                {
                    DataSet mother = new DataSet();
                    string sSql = "select * from tb_mother";
                    OleDbCommand scmd = new OleDbCommand();
                    OleDbDataAdapter sda;
                    sda = new OleDbDataAdapter(sSql, AC.con);
                    sda.Fill(mother, "tb_mother");

                    if (mother.Tables["tb_mother"].Rows.Count != 0)
                    {
                        txtMotherID.Text = mother.Tables["tb_mother"].Rows[0]["id_nbmother"].ToString();
                        txtMotherName.Text = mother.Tables["tb_mother"].Rows[0]["mo_name"].ToString();
                        txtMotherSurname.Text = mother.Tables["tb_mother"].Rows[0]["mo_surname"].ToString();
                        txtMotherNationality.Text = mother.Tables["tb_mother"].Rows[0]["mo_ntionty"].ToString();
                        dtpBirthDateMother.Value = Convert.ToDateTime(mother.Tables["tb_mother"].Rows[0]["mo_b_date"].ToString());
                        txtMotherEmail.Text = mother.Tables["tb_mother"].Rows[0]["mo_email"].ToString();
                        txtMotherPhone.Text = mother.Tables["tb_mother"].Rows[0]["mo_phone"].ToString();
                        txtMotherHomeNumber.Text = mother.Tables["tb_mother"].Rows[0]["mo_honum"].ToString();
                        txtMotherMoo.Text = mother.Tables["tb_mother"].Rows[0]["mo_swine"].ToString();
                        txtMotherDistrict.Text = mother.Tables["tb_mother"].Rows[0]["mo_district"].ToString();
                        txtMotherStreet.Text = mother.Tables["tb_mother"].Rows[0]["mo_street"].ToString();
                        txtMotherProvince.Text = mother.Tables["tb_mother"].Rows[0]["mo_province"].ToString();
                        txtMotherSubDistrict.Text = mother.Tables["tb_mother"].Rows[0]["mo_sub_district"].ToString();

                    }
                }
                if (sFather != "")
                {
                     DataSet father = new DataSet();
                    string sSql = "select * from tb_father";
                    OleDbCommand scmd = new OleDbCommand();
                    OleDbDataAdapter sda;
                    sda = new OleDbDataAdapter(sSql, AC.con);
                    sda.Fill(father, "tb_father");

                    if (father.Tables["tb_father"].Rows.Count != 0)
                    {
                        txtFatherID.Text = father.Tables["tb_father"].Rows[0]["id_nbfather"].ToString();
                        txtFatherName.Text = father.Tables["tb_father"].Rows[0]["ft_name"].ToString();
                        txtFatherSurname.Text = father.Tables["tb_father"].Rows[0]["ft_surname"].ToString();
                        txtFatherNationality.Text = father.Tables["tb_father"].Rows[0]["ft_ntionty"].ToString();
                        dtpBirthDateMother.Value = Convert.ToDateTime(father.Tables["tb_father"].Rows[0]["ftb_date"].ToString());
                        txtFatherEmail.Text = father.Tables["tb_father"].Rows[0]["ft_email"].ToString();
                        txtFatherPhone.Text = father.Tables["tb_father"].Rows[0]["ft_phone"].ToString();
                        txtFatherHomeNumber.Text = father.Tables["tb_father"].Rows[0]["ft_honum"].ToString();
                        txtFatherMoo.Text = father.Tables["tb_father"].Rows[0]["ft_swine"].ToString();
                        txtFatherDistrict.Text = father.Tables["tb_father"].Rows[0]["ft_district"].ToString();
                        txtFatherStreet.Text = father.Tables["tb_father"].Rows[0]["ft_street"].ToString();
                        txtFatherProvince.Text = father.Tables["tb_father"].Rows[0]["ft_province"].ToString();
                        txtFatherSubDistrict.Text = father.Tables["tb_father"].Rows[0]["ft_sub_district"].ToString();
                    }
                }
                //sOfficer = TbApcldata.Rows[e.RowIndex].Cells[18].Value.ToString();


            }
            catch
            {
                MessageBox.Show("ผิดพลาด");
            }
        }
            private void ClearAllApcl()
            {
                txtAppID.Text = "";
                txtAppName.Text = "";
                txtAppSurname.Text = "";
                rdbMale.Checked = false;
                rdbFemale.Checked = false;
                txtAppNationality.Text = "";
                txtAppEmail.Text = "";
                txtAppPhone.Text = "";
                txtAppHomeNumber.Text = "";
                txtAppMoo.Text = "";
                txtAppDistrict.Text = "";
                txtAppStreet.Text = "";
                txtAppProvince.Text = "";
                txtAppSubDistrict.Text = "";
                Apclb_date.Value = DateTime.Now;
                Apcldate.Value = DateTime.Now;
                Apclimg.Image = null;
                txtAppID.Focus();

                txtMotherID.Text = "";
                txtMotherName.Text = "";
                txtMotherSurname.Text = "";
                txtMotherNationality.Text = "";
                dtpBirthDateMother.Value = DateTime.Now;
                txtMotherEmail.Text = "";
                txtMotherPhone.Text = "";
                txtMotherHomeNumber.Text = "";
                txtMotherMoo.Text = "";
                txtMotherDistrict.Text = "";
                txtMotherStreet.Text = "";
                txtMotherProvince.Text = "";
                txtMotherSubDistrict.Text = "";

                txtFatherID.Text = "";
                txtFatherName.Text  = "";
                txtFatherSurname.Text  = "";
                txtFatherNationality.Text  = "";
                dtpBirthDateMother.Value = DateTime.Now;
                txtFatherEmail.Text  = "";
                txtFatherPhone.Text  = "";
                txtFatherHomeNumber.Text  = "";
                txtFatherMoo.Text  = "";
                txtFatherDistrict.Text  = "";
                txtFatherStreet.Text  = "";
                txtFatherProvince.Text  = "";
                txtFatherSubDistrict.Text  = "";

                cobIDsport.Text = "";
                cobSportname.Text = "";
                cobSporttype.Text = "";
                

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            ClearAllApcl();
            
        }
        private void prvCheckStateGender()
        {
            if (rdbMale.Checked == true)
            {
                stateGen = "ชาย";
            }
            else
            {
                stateGen = "หญิง";
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            prvCheckStateGender();
            string sqlEdit;
            OleDbCommand comEdit = new OleDbCommand();
            try
            {
                if (MessageBox.Show("คุณต้องอยากเพิ่งข้อมูล ใช่หรือไม่", "ยืนยีน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sqlEdit = "update tb_applicant set aplc_name = '" + txtAppName.Text + 
                        "',aplc_surname = '" + txtAppSurname.Text +
                        "',aplc_gender = '" + stateGen +
                        "',aplc_nationality = '" + txtAppNationality.Text + 
                        "',aplc_Email = '" + txtAppEmail.Text + 
                        "',aplc_phone = '" + txtAppPhone.Text +
                        "',aplc_honum = '" + txtAppHomeNumber.Text +
                        "',aplc_swine = '" + txtAppMoo.Text +
                        "',aplc_district = '" + txtAppDistrict.Text +
                        "',aplc_street = '" + txtAppStreet.Text +
                        "',aplc_province = '" + txtAppProvince.Text +
                        "',aplc_sub_district = '" + txtAppSubDistrict.Text +
                        "',aplcb_date = '" + Apclb_date.Value.ToString() +
                        "',aplica_date = '" + Apcldate.Value.ToString() +
                        "',id_sport = '" + cobIDsport.Text +
                        "',id_nbmother = '" + txtMotherID.Text +
                        "',id_nbfather = '" + txtFatherID.Text +
                        "',id_officer= '" + AC.currentid +
                        "'where id_numberaplc = '" + txtAppID.Text + "'";

                    AC.closeConnection();
                    AC.openConnection();

                    comEdit.CommandType = CommandType.Text;
                    comEdit.CommandText = sqlEdit;
                    comEdit.Connection = AC.con;
                    comEdit.ExecuteNonQuery();


                    sqlEdit = "update tb_mother set mo_name = '" + txtMotherName.Text +
                        "',mo_surname = '" + txtMotherSurname.Text +
                        "',mo_ntionty = '" + txtMotherNationality.Text +
                        "',mo_b_date = '" + dtpBirthDateMother.Value.ToString() +
                        "',mo_email = '" + txtMotherEmail.Text +
                        "',mo_phone = '" + txtMotherPhone.Text +
                        "',mo_honum = '" + txtMotherHomeNumber.Text +
                        "',mo_swine = '" + txtMotherMoo.Text +
                        "',mo_district = '" + txtMotherDistrict.Text +
                        "',mo_street = '" + txtMotherStreet.Text +
                        "',mo_province = '" + txtMotherProvince.Text +
                        "',mo_sub_district = '" + txtMotherSubDistrict.Text +
                        "' where id_nbmother = '" + txtMotherID.Text + "'";

                    AC.closeConnection();
                    AC.openConnection();
                    OleDbCommand mcmd = new OleDbCommand();

                    mcmd.CommandType = CommandType.Text;
                    mcmd.CommandText = sqlEdit;
                    mcmd.Connection = AC.con;
                    mcmd.ExecuteNonQuery();


                    sqlEdit = "update tb_father set ft_name='" + txtFatherName.Text +
                        "',ft_surname='" + txtFatherSurname.Text +
                        "',ft_ntionty='" + txtFatherNationality.Text +
                        "',ftb_date='" + dtpBirthDateFather.Value.ToString() +
                        "',ft_email = '" + txtFatherEmail.Text +
                        "',ft_phone = '" + txtFatherPhone.Text +
                        "',ft_honum = '" + txtFatherHomeNumber.Text +
                        "',ft_swine = '" + txtFatherMoo.Text +
                        "',ft_district = '" + txtFatherDistrict.Text +
                        "',ft_street = '" + txtFatherStreet.Text +
                        "',ft_province = '" + txtFatherProvince.Text +
                        "',ft_sub_district = '" + txtFatherSubDistrict.Text +
                        "' where id_nbfather = '" + txtFatherID.Text + "'";

                    AC.closeConnection();
                    AC.openConnection();
                    OleDbCommand fcmd = new OleDbCommand();

                    fcmd.CommandType = CommandType.Text;
                    fcmd.CommandText = sqlEdit;
                    fcmd.Connection = AC.con;
                    fcmd.ExecuteNonQuery();

                    MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
                    ClearAllApcl();
                    ShowAllApcl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อมูลผิดพลาด"+ex.Message);
            }
        }



        private void btnSelect_Click(object sender, EventArgs e)
        {   

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            prvCheckStateGender();
            string sqlAddApcl = "";
            try
            {
                AC.closeConnection();
                AC.openConnection();

                if (MessageBox.Show("เพิ่มข้อมูลใช่หรือไม่", "เพิ่มข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    DataSet dsCheck = new DataSet();

                    string sSql = "select * from tb_applicant where id_numberaplc='" + txtAppID.Text + "'";

                    dsCheck = ocn.pudsLoadData(sSql, "tb_applicant", dsCheck);

                    if (dsCheck.Tables["tb_applicant"].Rows.Count != 0)
                    {
                        MessageBox.Show("กรุณากรอกข้อมูลรหัสผู้สมัครที่ไม่ซ้ำกับผู้อื่น", "ซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    sqlAddApcl = " INSERT INTO tb_applicant(id_numberaplc,aplc_name,aplc_surname,aplc_gender,aplc_nationality" +
                        ",aplc_Email,aplc_phone,aplc_honum,aplc_swine,aplc_district,aplc_street,aplc_province,aplc_sub_district" +
                        ",aplcb_date,aplica_date,id_sport, id_nbmother, id_nbfather, id_officer) VALUES('"
                        + txtAppID.Text + "','"
                        + txtAppName.Text + "','"
                        + txtAppSurname.Text + "','"
                        + stateGen + "','"
                        + txtAppNationality.Text + "','"
                        + txtAppEmail.Text + "','"
                        + txtAppPhone.Text + "','"
                        + txtAppHomeNumber.Text + "','"
                        + txtAppMoo.Text + "','"
                        + txtMotherDistrict.Text + "','"
                        + txtAppStreet.Text + "','"
                        + txtAppProvince.Text + "','"
                        + txtAppSubDistrict.Text + "','"
                        + Apclb_date.Value.ToString() + "','"
                        + Apcldate.Value.ToString() + "','"
                        + cobIDsport.Text + "','"
                        + txtMotherID.Text + "','"
                        + txtFatherID.Text + "','"
                        + AC.currentid
                        + "')";

                    OleDbCommand acmd = new OleDbCommand();
                    acmd.CommandType = CommandType.Text;
                    acmd.CommandText = sqlAddApcl;
                    acmd.Connection = AC.con;
                    acmd.ExecuteNonQuery();

                    AC.closeConnection();
                    AC.openConnection();



                    DataSet dsCheck2 = new DataSet();

                    string sSql2 = "select * from tb_mother where id_nbmother='" + txtMotherID.Text + "'";

                    dsCheck2 = ocn.pudsLoadData(sSql2, "tb_mother", dsCheck2);

                    if (dsCheck2.Tables["tb_mother"].Rows.Count == 0)
                    {
                        // ======================================== mother ==========================
                        AC.closeConnection();
                        AC.openConnection();

                        sqlAddApcl = " INSERT INTO tb_mother(id_nbmother,mo_name,mo_surname, mo_ntionty,mo_b_date, mo_email,mo_phone,mo_honum,mo_swine,mo_district,mo_street,mo_province,mo_sub_district) values('"
                            + txtMotherID.Text + "','"
                            + txtMotherName.Text + "','"
                            + txtMotherSurname.Text + "','"
                            + txtMotherNationality.Text + "','"
                            + dtpBirthDateMother.Value.ToString() + "','"
                            + txtMotherEmail.Text + "','"
                            + txtMotherPhone.Text + "','"
                            + txtMotherHomeNumber.Text + "','"
                            + txtMotherMoo.Text + "','"
                            + txtMotherDistrict.Text + "','"
                            + txtMotherStreet.Text + "','"
                            + txtMotherProvince.Text + "','"
                            + txtMotherSubDistrict.Text
                            + "')";

                        OleDbCommand mcmd = new OleDbCommand();
                        mcmd.CommandType = CommandType.Text;
                        mcmd.CommandText = sqlAddApcl;
                        mcmd.Connection = AC.con;
                        mcmd.ExecuteNonQuery();
                    }

                    DataSet dsCheck3 = new DataSet();

                    string sSql3 = "select * from tb_father where id_nbfather='" + txtFatherID.Text + "'";

                    dsCheck3 = ocn.pudsLoadData(sSql3, "tb_father", dsCheck3);

                    if (dsCheck3.Tables["tb_father"].Rows.Count == 0)
                    {
                        // ============================================== Father =============================================
                        AC.closeConnection();
                        AC.openConnection();

                        sqlAddApcl = " INSERT INTO tb_tb_father(id_nbfater,ft_name,ft_surname, ft_ntionty,ftb_date, ft_email,ft_phone,ft_honum,ft_swine,ft_district,ft_street,ft_province,ft_sub_district) values('"
                            + txtFatherID.Text + "','"
                            + txtFatherName.Text + "','"
                            + txtFatherSurname.Text + "','"
                            + txtFatherNationality.Text + "','"
                            + dtpBirthDateMother.Value.ToString() + "','"
                            + txtFatherEmail.Text + "','"
                            + txtFatherPhone.Text + "','"
                            + txtFatherHomeNumber.Text + "','"
                            + txtFatherMoo.Text + "','"
                            + txtFatherDistrict.Text + "','"
                            + txtFatherStreet.Text + "','"
                            + txtFatherProvince.Text + "','"
                            + txtAppSubDistrict
                            + "')";

                        OleDbCommand fcmd = new OleDbCommand();
                        fcmd.CommandType = CommandType.Text;
                        fcmd.CommandText = sqlAddApcl;
                        fcmd.Connection = AC.con;
                        fcmd.ExecuteNonQuery();
                    }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAppID.Text == "")
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลที่จะลบ", "ผิดพลาด");
                    return;
                }
                String sqlDel = "delete from tb_applicant where id_numberaplc = '" + txtAppID.Text + "'";
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
