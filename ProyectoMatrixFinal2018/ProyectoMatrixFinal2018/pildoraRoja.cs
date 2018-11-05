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
    public partial class pildoraRoja : Form
    {
        public pildoraRoja()
        {
            InitializeComponent();

            this.CenterToScreen();
            String video = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString() + "\\principal\\pildoraRoja.mp4";


            this.axWindowsMediaPlayer1.URL = video;
            
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Application.Exit();
            }
        }
    }
}
