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
    public partial class pildoraAzul : Form
    {
        
        public pildoraAzul()
        {
            InitializeComponent();
            this.CenterToScreen();
            String video = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString() + "\\principal\\pildoraAzul.mp4";


            this.axWindowsMediaPlayer1.URL = video;
            
            
        }



        private void axWindowsMediaPlayer1_PlayStateChange_1(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Application.Exit();
            }
        }
    }


    //Undefined 1 = Stopped(by User) 2 = Paused 3 = Playing 4 = Scan Forward 5 = Scan Backwards 6 = Buffering 7 = Waiting 8 = Media Ended 9 = Transitioning 10 = Ready 11 = Reconnecting 12 = Last



}
