using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indradhanu
{
    public partial class Form1 : Form
    {
        public static Button[] butto;
        public static UserControl[] user;
        public static string i;
        public Form1()
        {
            InitializeComponent();
            butto =new Button[] { btnHome, btnRegister, btnSearch, btnSchedule, btnCaseRecord, btnReceipt, btnAlocate, btnSetting, btnAbout };
          //  user = new UserControl[] { registration1, search1, schedule1, receipt1, alocate1, setting1, about1 };
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void ChangeColor(Button buttonObj)
        {
            foreach (Button btnn in butto)
            {
                if (btnn.BackColor != Color.Transparent)
                {
                    btnn.BackColor = Color.Transparent;
                }
            }
            buttonObj.BackColor = Color.FromArgb(5, 110, 140);
        }

        public void ShowUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(userControl);
            userControl.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnHome);
            MainPanel.Controls.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnRegister);
            Registration r = new Registration();
            ShowUserControl(r);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnSearch);
            Search s = new Search();
            ShowUserControl(s);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnSchedule);
            MainPanel.Controls.Clear();
        }

        private void btnCaseRecord_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnCaseRecord);
            MainPanel.Controls.Clear();
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnReceipt);
            Receipt re = new Receipt();
            ShowUserControl(re);
        }

        private void btnAlocate_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnAlocate);
            Alocate al = new Alocate();
            ShowUserControl(al);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnSetting);
            Setting s = new Setting();
            ShowUserControl(s);
        }

        public void btnAbout_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnAbout);
            MainPanel.Controls.Clear();
        }
    }
}