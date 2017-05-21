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
        SqlCommand com;
        public Registration()
        {
            InitializeComponent();
        }

        public Registration(string[] DataForEdit)
        {
            InitializeComponent();

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            lbSN.Text =(int.Parse( GetSN())+1).ToString();
            GetAlocate();
            comboTime.SelectedIndex = 0;
        }

        private string GetSN()
        {
            string s = "0";
            com = new SqlCommand("SELECT TOP 1 SNK FROM tbl_Registration ORDER BY SN DESC", con);
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
            com = new SqlCommand(@"INSERT INTO [tbl_Registration]
                                   ([SNK]
                                   ,[Name]
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
                                   (@SNK,
                                   @Name,
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
            com.Parameters.AddWithValue("@SNK", lbSN.Text);
            com.Parameters.AddWithValue("@Name", tbName.Text);
            com.Parameters.AddWithValue("@Sex", GetSex());
            com.Parameters.AddWithValue("@Dob", dateDoB.Value.ToString("yyyy-MM-dd"));
            com.Parameters.AddWithValue("@Age", tbAge.Text);
            com.Parameters.AddWithValue("@DoR", DateTime.Now.ToString("yyyy-MM-dd"));
            com.Parameters.AddWithValue("@fName", tbFName.Text);
            com.Parameters.AddWithValue("@mName", tbMName.Text);
            com.Parameters.AddWithValue("@Phone", GetPhone());
            com.Parameters.AddWithValue("@Address", tbAddress.Text);
            com.Parameters.AddWithValue("@Complain", tbComplain.Text);
            com.Parameters.AddWithValue("@Diagnoses", tbDiagnosis.Text);
            com.Parameters.AddWithValue("@Treatment", tbTreatment.Text);
            com.Parameters.AddWithValue("@ApointmentDate", dateApointment.Value.ToString("yyyy-MM-dd"));
            com.Parameters.AddWithValue("@MeetingTime", comboTime.SelectedItem+":00");
            com.Parameters.AddWithValue("@Alocated", comAlocated.SelectedItem==null?DBNull.Value:(comAlocated.SelectedItem as ComboItem).value);

           
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Successful", "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch(SqlException ex)
            {
                if (ex.Number==2601)
                {
                    MessageBox.Show("Alocate was registered in same date and time.", "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(ex.Message, "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
                lbSN.Text = "" + (int.Parse(GetSN()) + 1);
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
            if (raFemale.Checked)
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
                else
                    Phone = item.ToString();
            }
            return Phone;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        
        private void tbPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            if (listboxPhone.Items.Count == 3)
                return;
            if (tbPhone.Text != "")
            {
                listboxPhone.Items.Add(tbPhone.Text.Trim());
                tbPhone.Clear();
                tbPhone.Focus();
            }
        }

        private void listboxPhone_DoubleClick(object sender, EventArgs e)
        {
            if (listboxPhone.SelectedItem == null)
                return;
            tbPhone.Text = listboxPhone.SelectedItem.ToString();
            listboxPhone.Items.Remove(listboxPhone.SelectedItem);
            tbPhone.Focus();
        }

        void Clear()
        {
            tbName.Clear();
            tbAge.Clear();
            tbMName.Clear();
            tbFName.Clear();
            tbPhone.Clear();
            listboxPhone.Items.Clear();
            tbAddress.Clear();
            tbComplain.Clear();
            tbDiagnosis.Clear();
            tbTreatment.Clear();
        }
    }
}
