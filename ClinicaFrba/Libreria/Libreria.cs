using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria
{
    public class Utilidades
    {
    

    public static Boolean ValidarFormulario(Control Objeto,ErrorProvider ErrorProvider)
    {
        Boolean hayErrores = false;

        foreach(Control Item in Objeto.Controls)
        {

            if(Item is errorTextBox)
            {
                errorTextBox obj = (errorTextBox)Item;

                if(obj.Validar == true)
                {
                    if(String.IsNullOrEmpty(obj.Text.Trim()))
                    {
                        ErrorProvider.SetError(obj, "No puede estar vacio");
                        hayErrores = true;
                    } 
                } else
                {
                    ErrorProvider.SetError(obj, "");
                } 
            }
        } return hayErrores;
    }
   }
}
