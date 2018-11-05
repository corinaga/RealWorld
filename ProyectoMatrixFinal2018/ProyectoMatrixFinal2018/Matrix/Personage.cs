using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrixFinal2018.Matrix
{
    class Personage : Generic
    {
        private String name;
        private readonly String[] names = { "Michelle ", "Alexander", "James    ", "Caroline ", "Claire   ", "Jessica  ", "Erik     ", "Mike     " };
        protected Image image;
        private readonly Image[] images =
        {
                Image.FromFile("..\\..\\imgPersonage\\chica1.png"),
                Image.FromFile("..\\..\\imgPersonage\\chico1.png"),
                Image.FromFile("..\\..\\imgPersonage\\chico2.png"),
                Image.FromFile("..\\..\\imgPersonage\\chica2.png"),
                Image.FromFile("..\\..\\imgPersonage\\chica3.png"),
                Image.FromFile("..\\..\\imgPersonage\\chica4.png"),
                Image.FromFile("..\\..\\imgPersonage\\chico3.png"),
                Image.FromFile("..\\..\\imgPersonage\\chico4.png")
        };
        private int age;
        private int percentageDie;
        private Location location;



        public Personage()
        {
            int pj = Useful.random_Number(0, names.Count() - 1);
            this.name = names[pj];
            this.image = addImageResize(pj);
            this.age = Useful.random_Number(1, 100);
            this.percentageDie = Useful.random_Number(1, 101);
            this.location = new Location();
        }
        /**
         * Metodo para añadir una imagen redimensionada
         * */
        private Image addImageResize(int num)
        {
            int height = 100;
            int weight = 100;
            Image img = images[num];
            Bitmap bm = new Bitmap(img, height, weight);
            return (Image)bm;
        }

        internal class Location
        {
            private readonly String[] cities = { "Nueva York", "Boston", "Baltimore", "Atlanta", "Detroit", "Dallas", "Denver" };
            public int latitude;
            public int longitude;
            public String city;

            public Location()
            {
                this.city = cities[Useful.random_Number(0, 7)];
                this.latitude = Useful.random_Number(0, 91);
                this.longitude = Useful.random_Number(0, 360);
            }

        }

        public void generate()
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public void prompt()
        {
            throw new NotImplementedException();
        }

        public String getNombre()
        {
            return this.name;
        }

        public int getPercentageDie()
        {
            return this.percentageDie;
        }

        public void setPercentageDie(int per)
        {
            this.percentageDie = per;
        }

        public Image getImage()
        {
            return this.image;
        }

    }
}
