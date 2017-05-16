using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Indradhanu
{
    public partial class Registration : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
        SqlCommand com,com2;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            lbSN.Text ="SN : "+ (int.Parse( GetSN())+1);
            GetAlocate();
        }

        private string GetSN()
        {
            string s = "error";
            com = new SqlCommand("select IDENT_CURRENT('tbl_Registration')", con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    s = reader.GetValue(0).ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return s;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string s = dateDoB.Value.ToString("yyyy-MM-dd");
            com = new SqlCommand(@"INSERT INTO [tbl_Registration]
                                   ([Name]
                                   ,[Sex]
                                   ,[Dob]
                                   ,[Age]
                                   ,[DoR]
                                   ,[fName]
                                   ,[mName]
                                   ,[Phone]
                                   ,[Address]
                                   ,[Complain]
                                   ,[Diagnoses]
                                   ,[Treatment]
                                   ,[ApointmentDate]
                                   ,[MettingTime]
                                   ,[Alocated])
                             VALUES
                                   (@Name,
                                   @Sex,
                                   @Dob,
                                   @Age,
                                   @DoR,
                                   @fName,
                                   @mName,
                                   @Phone,
                                   @Address,
                                   @Complain,
                                   @Diagnoses,
                                   @Treatment,
                                   @ApointmentDate,
                                   @MeetingTime,
                                   @Alocated)", con);
            com.Parameters.AddWithValue("@Name", tbName.Text);
            com.Parameters.AddWithValue("@Sex", GetSex());
            com.Parameters.AddWithValue("@Dob", s);
            com.Parameters.AddWithValue("@Age", tbAge.Text);
            com.Parameters.AddWithValue("@DoR", s);
            com.Parameters.AddWithValue("@fName", tbFName.Text);
            com.Parameters.AddWithValue("@mName", tbMName.Text);
            com.Parameters.AddWithValue("@Phone", GetPhone());
            com.Parameters.AddWithValue("@Address", tbAddress.Text);
            com.Parameters.AddWithValue("@Complain", tbComplain.Text);
            com.Parameters.AddWithValue("@Diagnoses", tbDiagnosis.Text);
            com.Parameters.AddWithValue("@Treatment", tbTreatment.Text);
            com.Parameters.AddWithValue("@ApointmentDate", s);
            com.Parameters.AddWithValue("@MeetingTime", meetingTime.Value.ToString());
            com.Parameters.AddWithValue("@Alocated", comAlocated.SelectedItem==null?"":(comAlocated.SelectedItem as ComboItem).value);

            MessageBox.Show(s);
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Successful", "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }
        }

        private void GetAlocate()
        {
            com = new SqlCommand("select AlocateID, Name from tbl_Alocated", con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    ComboItem i = new ComboItem();
                    i.text = reader["Name"].ToString();
                    i.value = reader["AlocateID"].ToString();
                    comAlocated.Items.Add(i);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private int GetSex()
        {
            int x = 0; ;
            if (raMale.Checked)
            {
                x = 0;
            }
            else if (raFemale.Checked)
            {
                x = 1;
            }
            return x;
        }

        private string GetPhone()
        {
            String Phone = "";
            foreach (var item in listboxPhone.Items)
            {
                if (Phone != "")
                    Phone = Phone + "," + item.ToString();
            }
            return Phone;
        }

    }
}
