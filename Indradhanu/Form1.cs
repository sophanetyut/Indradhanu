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
        Button[] butto;
        UserControl[] user;
        public Form1()
        {
            InitializeComponent();
            butto =new Button[] { btnHome, btnRegister, btnSearch, btnSchedule, btnCaseRecord, btnReceipt, btnAlocate, btnSetting, btnAbout };
            user = new UserControl[] { registration1, search1, schedule1, receipt1, alocate1, setting1, about1 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void ChangeColor(Button buttonObj)
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

        void SwitchComponent(UserControl userControl)
        {
            foreach (UserControl item in user)
            {
                if (item == userControl)
                {
                    item.Show();
                }
                else
                    item.Hide();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnHome);
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnRegister);
            SwitchComponent(registration1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnSearch);
            SwitchComponent(search1);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnSchedule);
            SwitchComponent(schedule1);
        }

        private void btnCaseRecord_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnCaseRecord);
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnReceipt);
            SwitchComponent(receipt1);
        }

        private void btnAlocate_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnAlocate);
            SwitchComponent(alocate1);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnSetting);
            SwitchComponent(setting1);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ChangeColor(this.btnAbout);
            SwitchComponent(about1);
        }
    }
}