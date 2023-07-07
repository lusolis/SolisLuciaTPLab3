using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolisLuciaTPLab3
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }
        CProvincias provi = new CProvincias();
        CIncendios incendios = new CIncendios();
        CExcepciones erroes = new CExcepciones();
        private void Registrar_Load(object sender, EventArgs e)
        {
            try
            {
                btnRegistrar.Enabled = false;
                btnImportar.Enabled = false;
                dtpAnio.Format = DateTimePickerFormat.Custom;
                dtpAnio.CustomFormat = "yyyy"; //muestra solo el año
                dtpAnio.MaxDate = DateTime.Parse("2023-01-01");
                groupBox1.Enabled = false;
                
            }
            catch (Exception ex)
            {
                erroes.RegistrarError(ex);
            }
        }
        private void verificarDatos()
        {
            if (cmbProvincia.SelectedItem != null && dtpAnio.Text != null && txtNegligencia.Text != "" &&
                txtIntencional.Text != "" && txtNatural.Text != "" && txtDesconocida.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtRuta.Text = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Archivo de Incendios";
            dlg.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            dlg.FilterIndex = 0;
            dlg.InitialDirectory = Application.StartupPath;
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = dlg.FileName;
                btnImportar.Enabled = true;
                Trace.WriteLine("Se seleccionó el archivo " + dlg.FileName);
                btnImportar.Enabled = true;
            }
            else
            {
                txtRuta.Text = "";
                btnImportar.Enabled = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int anio = int.Parse(dtpAnio.Text);
            string prov = cmbProvincia.Text;
            int negli = int.Parse(txtNegligencia.Text);
            int inten = int.Parse(txtIntencional.Text);
            int nat = int.Parse(txtNatural.Text);
            int desc = int.Parse(txtDesconocida.Text);
            incendios.insertar(anio, prov, negli, inten, nat, desc);
            cmbProvincia.SelectedIndex = 0;
            dtpAnio.Value = dtpAnio.MaxDate;
            txtNegligencia.Text = "";
            txtIntencional.Text = "";
            txtNatural.Text = "";
            txtDesconocida.Text = "";
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = txtRuta.Text;
                provi.excelProv(ruta);
                incendios.excelInc(ruta);
                txtRuta.Text = "";
                btnImportar.Enabled = false;
                groupBox1.Enabled = true;
                cmbProvincia.DisplayMember = "provincia";
                cmbProvincia.ValueMember = "numero";
                cmbProvincia.DataSource = provi.GetProvincias();
            }
            catch (Exception ex)
            {
                erroes.RegistrarError(ex);
            }
        }

        private void txtNegligencia_TextChanged(object sender, EventArgs e)
        {
            verificarDatos();
        }

        private void txtIntencional_TextChanged(object sender, EventArgs e)
        {
            verificarDatos();
        }

        private void txtNatural_TextChanged(object sender, EventArgs e)
        {
            verificarDatos();
        }

        private void txtDesconocida_TextChanged(object sender, EventArgs e)
        {
            verificarDatos();
        }
    }
}
