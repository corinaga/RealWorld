using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrixFinal2018.Matrix
{
    class Smith : Personage
    {
        private Image imgSmith = Image.FromFile("..\\..\\imgPersonage\\smith.png");
        public int infect;
        private readonly int MAX = 8;

        public Smith()
        {
            this.infect = getInfect();
            this.image = imageResize();


        }
        private Image imageResize()
        {
            int height = 100;
            int weight = 100;
            Bitmap bm = new Bitmap(this.imgSmith, height, weight);
            return (Image)bm;
        }

        public int getInfect()
        {
            return Useful.random_Number(1, this.MAX);
        }
      

    }
}
