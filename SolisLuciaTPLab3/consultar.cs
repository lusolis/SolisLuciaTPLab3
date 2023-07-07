using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SolisLuciaTPLab3
{
    public partial class consultar : Form
    {
        public consultar()
        {
            InitializeComponent();
        }
        CProvincias provi = new CProvincias();
        CIncendios incendios = new CIncendios();
        CExcepciones erroes = new CExcepciones();
        private void consultar_Load(object sender, EventArgs e)
        {

            dtpAnioConsulta.Format = DateTimePickerFormat.Custom;
            dtpAnioConsulta.CustomFormat = "yyyy"; //para ver solo el año
            dtpAnioConsulta.MinDate = DateTime.Parse("1993-01-01");
            dtpAnioConsulta.MaxDate = DateTime.Parse("2022-01-01");
            dtpAnioConsulta.Value = dtpAnioConsulta.MinDate;//para visualizar el menor año al abrir el form

            cmbProvinciaConsulta.DisplayMember = "provincia";
            cmbProvinciaConsulta.ValueMember = "numero";
            cmbProvinciaConsulta.DataSource = provi.GetProvincias();

            cmbGrafico.Items.Add("Gráfico de Columnas");
            cmbGrafico.Items.Add("Gráfico de Líneas");
            cmbGrafico.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int anio = dtpAnioConsulta.Value.Year;
            string prov = cmbProvinciaConsulta.Text;
            try
            {
                if (optAnio.Checked == true)
                {
                    incendios.GraficarPorAnio(anio, dgvConsulta, chtConsulta, cmbGrafico);
                }
                else
                {
                    incendios.GraficarProv(prov, dgvConsulta, chtConsulta, cmbGrafico);
                }
            }
            catch (Exception ex)
            {

                erroes.RegistrarError(ex); 
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
