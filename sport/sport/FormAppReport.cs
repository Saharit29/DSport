using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sport
{
    public partial class FormAppReport : Form
    {
        public FormAppReport()
        {
            InitializeComponent();
        }

        cryAppReport rptCryApp = new cryAppReport();
        private void FormAppReport_Load(object sender, EventArgs e)
        {
            FormFilterApp Frm = new FormFilterApp();

            cryViewer.ReportSource = rptCryApp;
            
        }
    }
}
