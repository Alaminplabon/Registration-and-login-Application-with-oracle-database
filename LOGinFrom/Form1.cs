namespace LOGinFrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbcontrol sql = new dbcontrol();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            REGISTRATION r= new REGISTRATION();
            Hide();
            r.ShowDialog();
        }

        bool Login()
        {
            sql.Paramss("@usr",txtuser.Text);
            sql.Paramss("@pwd",txtpass.Text);
            sql.query("select count(*) from tbluser where usr=@usr and pwd=@pwd");
            if ((int)sql.dt.Rows[0][0]==1)
            {
                return true;
            }
            MessageBox.Show("Invalid User or Password","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            return false;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (Login() == true)
            {
                mainFrom mf = new mainFrom();
                Hide();
                mf.ShowDialog();
            }
        }
    }
}