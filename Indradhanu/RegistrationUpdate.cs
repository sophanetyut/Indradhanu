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
    public partial class RegistrationUpdate : Form
    {
        public RegistrationUpdate(int SN)
        {
            InitializeComponent();
            Registration r = new Registration(SN);
            r.Dock = DockStyle.Fill;
            this.Controls.Add(r);
        }

        public RegistrationUpdate(int SN,int index)
        {
            InitializeComponent();
            this.MinimumSize = new Size(356, 90);
            this.MaximumSize = new Size(370, 120);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            NewDateAppointment n = new NewDateAppointment(SN);
            n.Dock = DockStyle.Fill;
            this.Controls.Add(n);


        }
        

    }
}
