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
using System.Drawing.Text;

using System.Collections;

namespace ProyectoMatrixFinal2018
{
    public partial class Final : Form
    {
        private pildoraAzul pildoraAzul;
        private pildoraRoja pildoraRoja;
        public Final()
        {
            
            InitializeComponent();
            this.CenterToScreen();
            String cancion = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString() + "\\principal\\corazon.mp3";

            //para poner canciones en bucle
            axWindowsMediaPlayer1.settings.setMode("Loop", true);
            this.axWindowsMediaPlayer1.URL = cancion;

            }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click_1(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.close();
            this.pildoraRoja = new pildoraRoja();
            this.pildoraRoja.Show();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.close();
            this.pildoraAzul = new pildoraAzul();
            this.pildoraAzul.Show();
            
        }

        private void Final_Load(object sender, EventArgs e)
        {

        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
