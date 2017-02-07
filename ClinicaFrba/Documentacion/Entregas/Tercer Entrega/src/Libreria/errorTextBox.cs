using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria
{
    public partial class errorTextBox : TextBox
    {
        public errorTextBox()
        {
            InitializeComponent();
        }
        public Boolean Validar
        {
            set;
            get;
        }
    }
}
