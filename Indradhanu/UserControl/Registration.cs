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
            lbSN.Text = (int.Parse(GetSN()) + 1).ToString();
        }

        int RID;
        public Registration(int SN)
        {
            InitializeComponent();
            btnSave.Text = "Update";
            RID = SN;
            com = new SqlCommand(@"SELECT SNK, Name, Sex, Dob, Age, DoR, fName, mName, Phone, [Address],
                                Complain, Diagnoses, Treatment, ApointmentDate, MettingTime, Alocated FROM tbl_Registration WHERE SNK=@SN", con);
            com.Parameters.AddWithValue("@SN", SN);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    lbSN.Text = reader["SNK"].ToString();
                    tbName.Text = reader["Name"].ToString();
                    if (int.Parse(reader["Sex"].ToString()) == 1)
                        raFemale.Checked = true;
                    else
                        raMale.Checked = true;
                    dateDoB.Text = reader["Dob"].ToString();
                    tbAge.Text = reader["Age"].ToString();
                    tbFName.Text = reader["fName"].ToString();
                    tbMName.Text = reader["mName"].ToString();
                    FillListBoxPhoneFromdatabase(reader["Phone"]);
                    tbAddress.Text = reader["Address"].ToString();
                    tbComplain.Text = reader["Complain"].ToString();
                    tbDiagnosis.Text = reader["Diagnoses"].ToString();
                    tbTreatment.Text = reader["Treatment"].ToString();
                    dateApointment.Text = reader["ApointmentDate"].ToString();
                    comboTime.SelectedItem =int.Parse( reader["MettingTime"].ToString().Substring(0,2));
                    comAlocated.SelectedItem = reader["Alocated"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void FillListBoxPhoneFromdatabase( object phone)
        {
            string text = phone.ToString();
            if (text.Contains(','))
            {
                foreach (var item in text)
                {
                    if (item == ',')
                    {
                        string aPhone = text.Substring(0, text.IndexOf(item, 1));
                        text = text.Remove(0, text.IndexOf(item, 1) + 1);
                        listboxPhone.Items.Add(aPhone);
                        if (text != "" && text.Contains(",") == false)
                        {
                            listboxPhone.Items.Add(text);
                        }
                    }
                }
            }
            else
                listboxPhone.Items.Add(text);
        }


        private void Registration_Load(object sender, EventArgs e)
        {
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
            if (btnSave.Text== "Update")
            {
                com = new SqlCommand(@"UPDATE tbl_Registration
                                    SET
                                   [SNK] =@SNK
                                  ,[Name] = @Name
                                  ,[Sex] =  @Sex
                                  ,[Dob] =  @Dob
                                  ,[Age] =  @Age
                                  ,[DoR] = @DoR
                                  ,[fName] =  @fName
                                  ,[mName] = @mName
                                  ,[Phone] =  @Phone
                                  ,[Address] =  @Address
                                  ,[Complain] = @Complain
                                  ,[Diagnoses] = @Diagnoses
                                  ,[Treatment] = @Treatment
                                  ,[ApointmentDate] = @ApointmentDate
                                  ,[MettingTime] = @MeetingTime
                                  ,[Alocated] = @Alocated
                             WHERE SNK=@sn ", con);
                com.Parameters.AddWithValue("@sn", RID);
            }
            else if (btnSave.Text=="Save")
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
            }
            else
            {
                return;
            }
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
            com.Parameters.AddWithValue("@MeetingTime", comboTime.SelectedItem + ":00");
            com.Parameters.AddWithValue("@Alocated", comAlocated.SelectedItem == null ? DBNull.Value : (comAlocated.SelectedItem as ComboItem).value);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Successful", "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
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
