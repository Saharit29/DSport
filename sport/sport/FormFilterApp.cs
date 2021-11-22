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
    public partial class FormFilterApp : Form
    {
        public FormFilterApp()
        {
            InitializeComponent();
        }
       
        OleDbDataAdapter da;
        string sSport, sMother, sFather, sOfficer;
        string stateGenter = "";
        DataSet dsFilter = new DataSet();
        DataSet sds = new DataSet();
        bool bCheck = false;
        bool bIsFind = false;
        public DataGridView pdgvPublic = new DataGridView();
        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //OleDbCommand FilterCMD = new OleDbCommand();
            string sFilter = " select * from tb_applicant where aplica_date Between " + 
                dtpFromDate.Value.ToString("#dd-MM-yyyy#") + " and " + 
                dtpToDate.Value.ToString("#dd-MM-yyyy#") + "";

            pdgvPublic = dgvAllApp;

            da = new OleDbDataAdapter(sFilter, AC.con);
            da.Fill(dsFilter, "tb_applicant");

            if (bCheck == true)
            {
                dsFilter.Tables["tb_applicant"].Clear();
            }

            if (dsFilter.Tables["tb_applicant"].Rows.Count != 0)
            {
                bCheck = true;
                dgvAllApp.ReadOnly = true;
                dgvAllApp.DataSource = dsFilter;
            }
            else
            {
                bCheck = false;
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            DataSet KDSearch = new DataSet();
            if (e.KeyValue == 13)
            {
                if (txtSearch.Text != "")
                {
                    string sSearch = "select * from tb_applicant where id_numberaplc+aplc_name+aplc_surname+aplc_gender+aplc_nationality+aplc_Email+aplc_phone+aplc_province+id_sport+id_nbmother+id_nbfather+id_officer like'" +
                        txtSearch.Text + "'";

                    da = new OleDbDataAdapter(sSearch, AC.con);
                    da.Fill(KDSearch, "tb_applicant");

                    if (bIsFind == true)
                    {
                        KDSearch.Tables["tb_applicant"].Clear();
                    }

                    if (KDSearch.Tables["tb_applicant"].Rows.Count != 0)
                    {
                        bIsFind = true;
                        dgvAllApp.ReadOnly = true;
                        dgvAllApp.DataSource = KDSearch.Tables["tb_applicant"];
                    }
                    else
                    {
                        bIsFind = false;
                    }

                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormAppReport Frm = new FormAppReport();
            Frm.ShowDialog();
        }

        private void btnSearchFlterApp_Click(object sender, EventArgs e)
        {
            DataSet dssSearch = new DataSet();
            string sSearch = "select * from tb_applicant where id_numberaplc='" + txtSearch.Text + "'";
            if (txtSearch.Text != "")
            {
                if (bCheck == true)
                {
                    dssSearch.Tables["tb_applicant"].Clear();
                }


                
                
               
                da = new OleDbDataAdapter(sSearch, AC.con);
                da.Fill(dssSearch, "tb_applicant");
             
                if (dssSearch.Tables["tb_applicant"].Rows.Count != 0)
                {
                    bCheck = true;
                    dgvAllApp.ReadOnly = true;
                    dgvAllApp.DataSource = dssSearch.Tables["tb_applicant"];
                }
                else
                {
                    bCheck = false;
                }

            }
        }
        //AC ocn = new AC();

        private void FormFilterApp_Load(object sender, EventArgs e)
        {
            prvShowAllApp();
            prvFormatDataGrid();
        }

        private void prvFormatDataGrid()
        {
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Font = new Font("Ms Sans Serif", 10, FontStyle.Regular);
            dgvAllApp.ColumnHeadersDefaultCellStyle = cs;
            dgvAllApp.Columns[0].HeaderText = "เลขประจำตัวประชาชน";
            dgvAllApp.Columns[1].HeaderText = "ชื่อ";
            dgvAllApp.Columns[2].HeaderText = "นามสกุล";
            dgvAllApp.Columns[3].HeaderText = "เพศ";
            dgvAllApp.Columns[4].HeaderText = "สัญชาติ";
            dgvAllApp.Columns[5].HeaderText = "Email";
            dgvAllApp.Columns[6].HeaderText = "เบอร์มือถือ";
            dgvAllApp.Columns[7].HeaderText = "บ้าานเลขที่";
            dgvAllApp.Columns[8].HeaderText = "หมู่";
            dgvAllApp.Columns[9].HeaderText = "อำเภอ";
            dgvAllApp.Columns[10].HeaderText = "ถนน";
            dgvAllApp.Columns[11].HeaderText = "จังหวัด";
            dgvAllApp.Columns[12].HeaderText = "ตำบล";
            dgvAllApp.Columns[13].HeaderText = "วัน เดือน ปี เกิด";
            dgvAllApp.Columns[14].HeaderText = "วันที่สมัคร";


            dgvAllApp.Columns[0].Width = 180;
            dgvAllApp.Columns[1].Width = 120;
            dgvAllApp.Columns[2].Width = 120;
            dgvAllApp.Columns[3].Width = 100;
            dgvAllApp.Columns[4].Width = 100;
            dgvAllApp.Columns[5].Width = 100;
            dgvAllApp.Columns[6].Width = 100;
            dgvAllApp.Columns[7].Width = 120;
            dgvAllApp.Columns[8].Width = 120;
            dgvAllApp.Columns[9].Width = 100;
            dgvAllApp.Columns[10].Width = 100;
            dgvAllApp.Columns[11].Width = 100;
            dgvAllApp.Columns[12].Width = 100;
            dgvAllApp.Columns[13].Width = 120;
            dgvAllApp.Columns[14].Width = 120;
        }

        private void prvShowAllApp()
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
                dgvAllApp.ReadOnly = true;
                dgvAllApp.DataSource = AC.ds.Tables["tb_applicant"];
                pdgvPublic = dgvAllApp;
            }
            else
            {
                AC.IsFind = false;
            }
        }

    }

}
