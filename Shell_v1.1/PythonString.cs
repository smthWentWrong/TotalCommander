using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Shell_v1._02
{
    class PythonString
    {
        public string[] massiv;

        public string[] Append(string element)
        {
            if (massiv == null)
            {
                massiv = new string[1];
                massiv[0] = element;
            }
            else
            {
                if (element != null)
                {
                    int count = massiv.Count();
                    string[] massiv1 = new string[count + 1];
                    for (int i = 0; i < count; i++)
                    {
                        massiv1[i] = massiv[i];
                    }
                    massiv1[count] = element;
                    massiv = massiv1;
                }
            }
            return massiv;
        }
    }
}