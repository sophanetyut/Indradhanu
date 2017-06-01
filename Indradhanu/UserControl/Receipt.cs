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
    public partial class Receipt : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
        SqlCommand com,com2;
        public static void SetID(string id)
        {
            s.Text = id;
        }
        
        static Label s;
        public Receipt()
        {
            InitializeComponent();
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            s = lbID;
            GetAlocate();
        }
        #region btnAdd
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
                    comboAlocated.Items.Add(i);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbDescription.Text =="")
            {
                tbDescription.Focus();
                return;
            }
            if (tbAmount.Text == "")
            {
                tbAmount.Focus();
                return;
            }
            dataGridView1.Rows.Add(tbDescription.Text, tbAmount.Text);
            SumGrid();
            tbDescription.Clear();
            tbAmount.Clear();
            tbDescription.Focus();

        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            btnAdd_Click(sender, e);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(tbAmount_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(tbAmount_KeyPress);
                }
            }
           // SumGrid();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SumGrid();
        }

        private void tbExchange_TextChanged(object sender, EventArgs e)
        {
            SumGrid();
        }

        private void SumGrid()
        {
            double d=0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                d += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            lbTotalDolla.Text = d.ToString();
            lbTotalRiel.Text = (d * Double.Parse(tbExchange.Text)).ToString();
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            com = new SqlCommand("INSERT INTO DBO.tbl_Reciept(Date,RID,SN, ExRate, totalDollar, totalRiel) VALUES(GETDATE(), @RID, @SN, @Exc, @TDolla, @TRiel); SELECT SCOPE_IDENTITY()", con);
            com.Parameters.AddWithValue("@RID", 2);
            com.Parameters.AddWithValue("@SN", 79);
            com.Parameters.AddWithValue("@Exc", tbExchange.Text);
            com.Parameters.AddWithValue("@TDolla", lbTotalDolla.Text);
            com.Parameters.AddWithValue("@TRiel", lbTotalRiel.Text);

            com2 = new SqlCommand("INSERT INTO tbl_RecieptDetail(Description, AmountDollar, RID) VALUES(@de, @amd, @RID)", con);
            com2.Parameters.AddWithValue("@de", dataGridView1.Rows[0].Cells[0].Value);
            com2.Parameters.AddWithValue("@amd", dataGridView1.Rows[0].Cells[1].Value);

            try
            {
                con.Open();
                
                var x= com.ExecuteScalar();
                com2.Parameters.AddWithValue("@RID", x);
                MessageBox.Show(x.ToString());

                foreach (var item in dataGridView1.Rows)
                {
                    com2.ExecuteNonQuery();
                }
                dataGridView1.Rows.Clear();
                lbTotalDolla.Text = "0";
                lbTotalRiel.Text = "0";
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


    }
}
