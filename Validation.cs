using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prakticheskaya_6
{
    class Validation
    {
        public bool Validation1(string text)
        {
            var input = text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с логином пустое!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Validation2(string text)
        {
            var input = text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с IP пустое!");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
