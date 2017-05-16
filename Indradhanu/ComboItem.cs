using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indradhanu
{
    class ComboItem
    {
        public string text { get; set; }
        public object value { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return text;
        }
    }
}
