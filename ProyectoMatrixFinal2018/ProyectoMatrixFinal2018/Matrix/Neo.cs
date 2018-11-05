using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrixFinal2018.Matrix
{
    class Neo : Personage
    {
        //atributo propio de la imagen de neo
        private Image imgNeo = Image.FromFile("..\\..\\imgPersonage\\neo.png");
        public bool believed;

        public Neo()
        {

            this.believed = isBelieved();
            this.image = imageResize();
        }
        private Image imageResize()
        {
            int height = 100;
            int weight = 100;   
            Bitmap bm = new Bitmap(this.imgNeo, height, weight);
            return (Image)bm;
        }
        public bool isBelieved()
        {
            int num = Useful.random_Number(0, 2);

            if (num == 0)
            {
                this.believed = false;
            }
            else
            {
                this.believed = true;
            }

            return this.believed;
        }

        public bool getBelieved()
        {
            return this.believed;
        }


    }
}
