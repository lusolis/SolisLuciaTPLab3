using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolisLuciaTPLab3
{
    internal class CEspera : Form
    {
        public ProgressBar progressBar;

        public CEspera()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            progressBar = new ProgressBar();
            progressBar.Location = new System.Drawing.Point(20, 20);
            progressBar.Size = new System.Drawing.Size(250, 20);
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 20;

            this.ClientSize = new System.Drawing.Size(300, 80);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importando datos a la tabla Incendios...";
            this.Controls.Add(progressBar);
        }
    }
}
