using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace SolisLuciaTPLab3
{
    internal class CProvincias
    {

        private DataSet DS;
        OleDbDataAdapter daP;
        public string cadena = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Incendios.mdb";
        CExcepciones errores = new CExcepciones();
        public CProvincias()
        {
            try
            {
                DS = new DataSet(); // creación del DataSet
                // conexión con la base de datos
                OleDbConnection cnn = new OleDbConnection();
                cnn.ConnectionString = cadena;
                cnn.Open();

                // Proceso de la tabla incendios
                OleDbCommand cmdInc = new OleDbCommand();
                cmdInc.Connection = cnn;
                cmdInc.CommandType = CommandType.TableDirect;
                cmdInc.CommandText = "Provincias";

                daP = new OleDbDataAdapter(cmdInc);
                daP.Fill(DS, "Provincias");
                // se agrega la clave primaria
                DataColumn[] dcP = new DataColumn[1];
                dcP[0] = DS.Tables["Provincias"].Columns["numero"];
                DS.Tables["Provincias"].PrimaryKey = dcP;
                OleDbCommandBuilder cbP = new OleDbCommandBuilder(daP);

                cnn.Close();
            }
            catch (Exception ex)
            {
                errores.RegistrarError(ex);
            }
        }
        public void eliminarRegistros()
        {
            string deleteQuery = "DELETE * FROM Provincias";

            try
            {
                OleDbConnection cnn = new OleDbConnection(cadena);
                cnn.Open();
                OleDbCommand cmdBorrar = new OleDbCommand(deleteQuery, cnn);
                cmdBorrar.ExecuteNonQuery();
                cnn.Close();
                daP.Update(DS, "Provincias");
                DS.Tables["Provincias"].Clear();
            }
            catch (Exception ex)
            {
                errores.RegistrarError(ex);
            }
        }
        public void excelProv(string ruta)
        {
			try
			{
                if (DS.Tables["Provincias"].Rows.Count > 0)
                {
                    eliminarRegistros();

                }
                // Cadena de conexión para el archivo de Excel
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties='Excel 8.0;HDR=YES;'";

                // Consulta SQL para seleccionar los datos de la hoja de Excel
                string selectQuery = "SELECT * FROM [Provincias$]";
                                
                // Crear una conexión OleDb con la cadena de conexión
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Crear un adaptador OleDb y asignar la consulta y la conexión
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, connection))
                    {
                        // Crear un DataTable para almacenar los datos de Excel
                        DataTable dataTable = new DataTable();

                        // Llenar el DataTable con los datos del adaptador
                        adapter.Fill(dataTable);
                        
                        // Cerrar la conexión
                        connection.Close();
                       
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (dr != null)
                            {
                                DataRow drP = DS.Tables["Provincias"].NewRow();
                                drP["numero"] = dr["numero"];
                                drP["provincia"] = dr["provincia"];
                                DS.Tables["Provincias"].Rows.Add(drP);
                            }
                        }
                        daP.Update(DS, "Provincias");
                        MessageBox.Show("Los datos se importaron correctamente a la tabla PROVINCIAS de la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
			catch (Exception ex)
			{
                errores.RegistrarError(ex);
            }
        }
        public DataTable GetProvincias()
        {
            if (DS.Tables.Count == 1)
            {
                return DS.Tables["Provincias"];
            }
            else
            {
                throw new Exception("La tabla no existe");
            }
        }
    }
}
