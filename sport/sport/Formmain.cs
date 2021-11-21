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
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
            customizeDesing();
        }
        
        FormLogin foLogin = new FormLogin();
        FormApcl foApcl = new FormApcl();
        AC ocn = new AC();

        private void customizeDesing()
        {
            panelMenu.Visible = false;
            
        }
        private void PsubMenu()
        {
            if(panelMenu.Visible == true)
                panelMenu.Visible = false;
            
        }
        private void showMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                PsubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            showMenu(panelMenu);
        }

        private void btnSportApl_Click(object sender, EventArgs e)
        {
            foApcl.ShowDialog();
            PsubMenu();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            PsubMenu();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            PsubMenu();
            if (ocn.CloseChildForm(this, "FromProfile") == false)
            {
                lbnameStatus.Dispose();
                
                FormProfile Frm = new FormProfile();
                
                Frm.Show();
            }
        }
    

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PsubMenu();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            PsubMenu();
        }

        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Formmain_load(object sender, EventArgs e)
        {
            AC.currentstatus = AC.rd[8].ToString();
            AC.currentname = AC.rd[1].ToString();
            lbnameStatus.Text = "| Welcome: " + AC.currentname + " " +
                              " Your Status is : " + AC.currentstatus + " |";

            
        }
    }
}
