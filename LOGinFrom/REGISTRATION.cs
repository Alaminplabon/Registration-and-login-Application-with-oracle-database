using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LOGinFrom
{
    public partial class REGISTRATION : Form
    {
        public REGISTRATION()
        {
            InitializeComponent();
        }
        dbcontrol sql = new dbcontrol();
        void register()
        {
        
            sql.Paramss("@usr", txtuser.Text);
            sql.Paramss("@pwd", txtpass.Text);
            sql.Paramss("@fname", txtfname.Text);
            sql.Paramss("@mn", txtmn.Text);
            sql.Paramss("@lname", txtlname.Text);

            // Execute the query
            sql.query("insert into tbluser (usr, pwd, fname, mn, lname) values (@usr, @pwd, @fname, @mn, @lname)");

            // Check for errors
            if (sql.Check4error(true))
            {
                return;
            }

            // Show success message
            MessageBox.Show("Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void REGISTRATION_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form1)
                {
                    frm.Show();
                }
            }
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            register();
        }
    }
}
