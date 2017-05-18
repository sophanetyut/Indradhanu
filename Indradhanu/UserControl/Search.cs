using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Indradhanu
{
    public partial class Search : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
        SqlCommand com;
        public Search()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adt = new SqlDataAdapter();
            try
            {
                con.Open();
                if (radioButton1.Checked)
                {
                    adt = new SqlDataAdapter(CommandByOption("SN", textBox1.Text));
                }
                else if (radioButton2.Checked)
                {
                    adt = new SqlDataAdapter(CommandByOption("Name", textBox1.Text));
                }
                else if (radioButton3.Checked)
                {
                    adt = new SqlDataAdapter(CommandByOption("Phone", textBox1.Text));
                }

                DataTable ds = new DataTable();
                adt.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception)
            {
                LoadDefault();
            }
            finally
            {
                con.Close();
                
            }
        } 

        void LoadDefault()
        {
            SqlDataAdapter adt = new SqlDataAdapter();
            try
            {
                con.Open();
                adt = new SqlDataAdapter(CommandByOption("else", "s"));
                DataTable ds = new DataTable();
                adt.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
            finally
            {
                con.Close();
            }
        }
         
        private SqlCommand CommandByOption(string source, string id)
        {
            string s = "";
            switch (source)
            {
                case "SN":
                    com = new SqlCommand(@"SELECT TOP 30 SN, Name,(CASE Sex WHEN 0 THEN 'Male' WHEN 1 THEN 'Female' end) as Sex, Dob AS 'Date of birth', Age, DoR AS 'registration date', dbo.fn_Phone(Phone) as 'Phone', Complain, Diagnoses, 
                                        Treatment, ApointmentDate, MettingTime,(select Name from tbl_Alocated where Alocated=Alocated) AS 'Alocate' 
                                        FROM tbl_Registration WHERE SN >= @sn", con);
                    com.Parameters.Add("@sn", SqlDbType.Int).Value = int.Parse(id);
                    break;
                case "Name":
                    com = new SqlCommand(@"SELECT TOP 30 SN, Name,(CASE Sex WHEN 0 THEN 'Male' WHEN 1 THEN 'Female' end) as Sex, Dob AS 'Date of birth', Age, DoR AS 'registration date', dbo.fn_Phone(Phone) as 'Phone', Complain, Diagnoses, 
                                        Treatment, ApointmentDate, MettingTime,(select Name from tbl_Alocated where Alocated=Alocated) AS 'Alocate' 
                                        FROM tbl_Registration where Name LIKE @name+'%' ORDER BY [SN] DESC;", con);
                    com.Parameters.AddWithValue("@name", id);
                    break;
                case "Phone":
                    com = new SqlCommand(@"SELECT TOP 30 SN, Name,(CASE Sex WHEN 0 THEN 'Male' WHEN 1 THEN 'Female' end) as Sex, Dob AS 'Date of birth', Age, DoR AS 'registration date', dbo.fn_Phone(Phone) as 'Phone', Complain, Diagnoses, 
                                        Treatment, ApointmentDate, MettingTime,(select Name from tbl_Alocated where Alocated=Alocated) AS 'Alocate' 
                                        FROM tbl_Registration 
                                               WHERE [Phone] LIKE phone+'%' ORDER BY [SN] DESC;", con);
                    com.Parameters.Add("@phone", SqlDbType.VarChar).Value = id;
                    break;
                case "else":
                    com = new SqlCommand(@"SELECT TOP 30 SN, Name,(CASE Sex WHEN 0 THEN 'Male' WHEN 1 THEN 'Female' end) as Sex, Dob AS 'Date of birth', Age, DoR AS 'registration date', dbo.fn_Phone(Phone) as 'Phone', Complain, Diagnoses, 
                                        Treatment, ApointmentDate, MettingTime,(select Name from tbl_Alocated where Alocated=Alocated) AS 'Alocate' 
                                        FROM tbl_Registration", con);
                    break;
            }
            return com;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }
    }
}