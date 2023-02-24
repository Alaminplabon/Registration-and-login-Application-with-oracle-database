using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LOGinFrom
{
    internal class dbcontrol
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Desktop\\cs\\LOGinFrom\\LOGinFrom\\dbtest.mdf;Integrated Security=True");
        SqlCommand cm;
        public SqlDataAdapter da;
        List<SqlParameter> param = new List<SqlParameter>();
        public DataTable dt;
        public int recordcount;
        public string exception;


        public void query(string name)
        {
            recordcount = 0;
            exception = null;
            try
            {
                cn.Open();
                cm = new SqlCommand(name, cn);
                param.ForEach(p => cm.Parameters.Add(p));
                param.Clear();
                dt = new DataTable();
                da = new SqlDataAdapter(cm);
                recordcount = da.Fill(dt);

            }
            catch (Exception e)
            {
                exception = "problem : " + e.Message;
            }
            finally
            {
                cn.Close();
            }
        }

        public void Paramss(string name, object value)
        {
            SqlParameter newparam = new SqlParameter(name, value);
            param.Add(newparam);
        }
        public bool Check4error(bool err = false)
        {
            if(string.IsNullOrEmpty(exception)) 
            {
                return false;
            }
            if (err==true)
            {
                MessageBox.Show(exception,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return true;
        }
    }
}
