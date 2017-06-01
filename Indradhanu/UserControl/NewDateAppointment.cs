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

    public partial class NewDateAppointment : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
        SqlCommand com;
        int id;
        public NewDateAppointment(int SNK)
        {
            InitializeComponent();
            id = SNK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.Text);
            if (comboBox1.Text==string.Empty)
            {
                comboBox1.DroppedDown = true;
                return;
            }
            if (dateTimePicker1.Value<DateTime.Now.Date)
            {
                MessageBox.Show("Can't meet at the past.","Indradhanu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            com = new SqlCommand("UPDATE tbl_Registration SET ApointmentDate= @val, MettingTime = @mt WHERE SNK=@snk", con);
            com.Parameters.AddWithValue("@val", dateTimePicker1.Value);
            com.Parameters.AddWithValue("@mt", comboBox1.Text + ":00");
            com.Parameters.AddWithValue("@snk", id);
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Success", "Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Indradhanu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}