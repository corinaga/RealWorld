using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatrixFinal2018
{
    public partial class Inicial : Form
    {

        private Principal principal;
        public Inicial()
        {
            principal = new Principal();

            InitializeComponent();
            pbFondo.ImageLocation = "..\\..\\principal\\fondo.gif";
            this.CenterToScreen();
            String cancion = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString() +"\\principal\\musica.mp3";
            
            awp1.URL = cancion;


        }

        private void pbFondo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Hide();
        }

        private void Inicial_Load(object sender, EventArgs e)
        {

        }


    }
}
