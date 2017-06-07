using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indradhanu
{
    class FormControl
    {
        
        public static void BtnReceipt(string id)
        {
            Form1.ChangeColor(Form1.butto[4]);
           // Form1.SwitchComponent(Form1.user[3]);
            Receipt.SetID(id);
        }
    }
}