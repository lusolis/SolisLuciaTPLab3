using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;

namespace SolisLuciaTPLab3
{
    internal class CIncendios
    {
        private DataSet DS;
        OleDbDataAdapter daI;
        public string cadena = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Incendios.mdb";
        CExcepciones errores = new CExcepciones();
        CEspera espera = new CEspera();
        public CIncendios() 
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
                cmdInc.CommandText = "incendios";

                daI = new OleDbDataAdapter(cmdInc);
                daI.Fill(DS, "incendios");
                // se agrega la clave primaria
                DataColumn[] dcI = new DataColumn[2];
                dcI[0] = DS.Tables["incendios"].Columns["anio"];
                dcI[1] = DS.Tables["incendios"].Columns["provincia"];
                DS.Tables["incendios"].PrimaryKey = dcI;
                OleDbCommandBuilder cbI = new OleDbCommandBuilder(daI);

                cnn.Close();
            }
            catch (Exception ex)
            {
                errores.RegistrarError(ex);
            }
        }
        public void insertar(int anio, string prov, int negli, int inten, int nat, int desc)
        {
            try
            {
                object[] clave = new object[2];
                clave[0] = anio;
                clave[1] = prov;
                DataRow d = DS.Tables["incendios"].Rows.Find(clave);
                int total = negli + inten + nat + desc;
                
                if (d != null)
                {
                    d.BeginEdit();
                    d["total_numero"] = total;
                    d["negligencia_numero"] = negli;
                    d["intencional_numero"] = inten;
                    d["natural_numero"] = nat;
                    d["desconocida_numero"] = desc;
                    d.EndEdit();
                }
                else
                {
                    DataRow dr = DS.Tables["incendios"].NewRow();
                    dr["anio"] = anio;
                    dr["provincia"] = prov;
                    dr["total_numero"] = total;
                    dr["negligencia_numero"] = negli;
                    dr["intencional_numero"] = inten;
                    dr["natural_numero"] = nat;
                    dr["desconocida_numero"] = desc;
                    DS.Tables["incendios"].Rows.Add(dr);
                }
                daI.Update(DS, "incendios");
                MessageBox.Show("Los datos se importaron correctamente a la tabla de Access.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                errores.RegistrarError(ex);
            }
        }
        public void eliminarRegistros()
        {
            string deleteQuery = "DELETE * FROM incendios";

            try
            {
                OleDbConnection cnn = new OleDbConnection(cadena);
                cnn.Open();
                OleDbCommand cmdBorrar = new OleDbCommand(deleteQuery, cnn);
                cmdBorrar.ExecuteNonQuery();
                cnn.Close();
                daI.Update(DS, "incendios");
                DS.Tables["incendios"].Clear();
            }
            catch (Exception ex)
            {
                errores.RegistrarError(ex);
            }
        }
        public void excelInc(string ruta)
        {
            int cantidad = 0;
            try
            {
                espera.Show();
                Application.DoEvents();
                if (DS.Tables["incendios"].Rows.Count > 0)
                {
                    eliminarRegistros();
                }
                // Cadena de conexión para el archivo de Excel
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties='Excel 8.0;HDR=YES;'";

                // Consulta SQL para seleccionar los datos de la hoja de Excel
                string selectQuery = "SELECT * FROM [incendios-cantidad-causas-provi$]";


                // Crear una conexión OleDb con la cadena de conexión
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Crear un adaptador OleDb y asignar la consulta y la conexión
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectQuery, connection))
                    {
                        // Crear un DataTable para almacenar los datos de Excel
                        DataTable dt = new DataTable();

                        // Llenar el DataTable con los datos del adaptador
                        adapter.Fill(dt);

                        connection.Close();
                        espera.progressBar.Maximum = dt.Rows.Count;
                        espera.progressBar.Value = 0; // Reiniciar el progreso
                        foreach (DataRow drE in dt.Rows) //filas en tabla de datos de excel
                        {
                            string provincia = drE["incendio_provincia"].ToString();

                            if (int.Parse(drE["incendio_total_numero"].ToString()) > 0 && ExisteProvincia(provincia))
                            {
                                DataRow d = DS.Tables["incendios"].NewRow();
                                d["anio"] = drE["incendio_anio"];
                                d["provincia"] = drE["incendio_provincia"];
                                d["total_numero"] = drE["incendio_total_numero"];
                                d["negligencia_numero"] = drE["incendio_negligencia_numero"];
                                d["intencional_numero"] = drE["incendio_intencional_numero"];
                                d["natural_numero"] = drE["incendio_natural_numero"];
                                d["desconocida_numero"] = drE["incendio_desconocida_numero"];
                                DS.Tables["incendios"].Rows.Add(d);
                                cantidad++;
                                
                            }
                            espera.progressBar.Value = cantidad;
                        }

                        daI.Update(DS, "incendios");
                        espera.Close();
                        espera.Dispose();
                        MessageBox.Show("Se importaron " + cantidad.ToString() + " registros correctamente a la tabla INCENDIOS de la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                errores.RegistrarError(ex);
            }
        }
        public bool ExisteProvincia(string provincia)
        {
            string selectQuery = "SELECT COUNT(*) FROM Provincias WHERE provincia = @provincia";
            int count = 0;

            using (OleDbConnection connection = new OleDbConnection(cadena))
            {
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@provincia", provincia);
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }

            return count > 0;
        }
        public void GraficarPorAnio(int anio, DataGridView dgv, Chart cht, ComboBox cmb)
        {
            int tipo = cmb.SelectedIndex;
            // crea un gráfico para una determinada localidad
            cht.Series.Clear();
            // crear una tabla temporal
            DataTable inc = new DataTable();
            inc.Columns.Add("Año");
            inc.Columns.Add("Provincia");
            inc.Columns.Add("Total");
            inc.Columns.Add("Negligencia");
            inc.Columns.Add("Intencional");
            inc.Columns.Add("Natural");
            inc.Columns.Add("Desconocida");
            
            foreach (DataRow dr in DS.Tables["incendios"].Rows)
            {
                if (anio == int.Parse(dr["anio"].ToString()))
                {
                    // se agrega el registro nuevo a la tabla temporal
                    DataRow nuevo = inc.NewRow();
                    nuevo["Año"] = int.Parse(dr["anio"].ToString());
                    nuevo["Provincia"] = dr["provincia"];
                    nuevo["Total"] = int.Parse(dr["total_numero"].ToString());
                    nuevo["Negligencia"] = int.Parse(dr["negligencia_numero"].ToString());
                    nuevo["Intencional"] = int.Parse(dr["intencional_numero"].ToString());
                    nuevo["Natural"] = int.Parse(dr["natural_numero"].ToString());
                    nuevo["Desconocida"] = int.Parse(dr["desconocida_numero"].ToString());

                    inc.Rows.Add(nuevo);
                }
            }
            dgv.DataSource = inc;
            // Crear una nueva serie en el control Chart
            Series serie = cht.Series.Add(anio.ToString());
            if(tipo == 0)
            {
                serie.ChartType = SeriesChartType.Column;
            }
            else
            {
                serie.ChartType = SeriesChartType.Line;
            }
            
            serie.YValueMembers = "Total"; // Establecer los valores en el eje Y de la serie
            serie.XValueMember = "Provincia"; // Establecer los valores en el eje X de la serie
            cht.Series[0].IsValueShownAsLabel = true;
            // Enlazar la tabla temporal al control Chart
            cht.DataSource = inc.DefaultView;
        }
        public void GraficarProv(string provincia, DataGridView dgv, Chart cht, ComboBox cmb)
        {
            int tipo = cmb.SelectedIndex;

            cht.Series.Clear();
            // crear una tabla temporal
            DataTable inc = new DataTable();
            inc.Columns.Add("Año");
            inc.Columns.Add("Provincia");
            inc.Columns.Add("Total");
            inc.Columns.Add("Negligencia");
            inc.Columns.Add("Intencional");
            inc.Columns.Add("Natural");
            inc.Columns.Add("Desconocida");
            
            foreach (DataRow dr in DS.Tables["incendios"].Rows)
            {
                if (provincia == dr["provincia"].ToString())
                {
                    // se agrega el registro nuevo a la tabla temporal
                    DataRow nuevo = inc.NewRow();
                    nuevo["Año"] = int.Parse(dr["anio"].ToString());
                    nuevo["Provincia"] = dr["provincia"];
                    nuevo["Total"] = int.Parse(dr["total_numero"].ToString());
                    nuevo["Negligencia"] = int.Parse(dr["negligencia_numero"].ToString());
                    nuevo["Intencional"] = int.Parse(dr["intencional_numero"].ToString());
                    nuevo["Natural"] = int.Parse(dr["natural_numero"].ToString());
                    nuevo["Desconocida"] = int.Parse(dr["desconocida_numero"].ToString());

                    inc.Rows.Add(nuevo);
                }
            }
            dgv.DataSource = inc;
            // Crear una nueva serie en el control Chart
            Series serie = cht.Series.Add(provincia);
            if (tipo == 0)
            {
                serie.ChartType = SeriesChartType.Column;
            }
            else
            {
                serie.ChartType = SeriesChartType.Line;
            }
            
            serie.YValueMembers = "Total";// Establecer los valores en el eje Y de la serie
            serie.XValueMember = "Año"; // Establecer los valores en el eje X de la serie
            cht.Series[0].IsValueShownAsLabel = true;

            // Enlazar la tabla temporal al control Chart
            cht.DataSource = inc.DefaultView;
        }
        public void dispose()
        {
            DS.Dispose();
        }
    }
}
