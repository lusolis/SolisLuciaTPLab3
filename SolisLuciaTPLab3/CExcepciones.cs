using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolisLuciaTPLab3
{
    public class CExcepciones
    {
        public class ActualizacionException : Exception
        {
            public ActualizacionException() : base() { }

            public ActualizacionException(string message) : base(message) { }

            public ActualizacionException(string message, Exception inner) : base(message, inner) { }
        }
        string archivo = "LogErrores.txt";
        public void RegistrarError(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(archivo, true)) //la instrucción using asegurará que el archivo se
                                                                      //cierre correctamente y se liberen los recursos 
            {
                sw.WriteLine(ex.GetType().Name + "," + ex.ToString());
            }               

        }
    }
}
