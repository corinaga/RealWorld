using ProyectoMatrixFinal2018.Matrix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatrixFinal2018
{
    public partial class Principal : Form
    {
        private Matrix.Matrix m;
        private String [] whiteRabbit;
        private String [] neoDialogue;
        private String[] smithDialogue;
        private int infect;
        private Image dead;
        private Final final;
        private bool control;


        public Principal()
        {
            whiteRabbit = new String[] { "> Wake up, Neo…", "> The Matrix has you....", "> Follow the white rabbit.", "> Knock, knock, Neo.","    " };
            smithDialogue = new String[] { "Neo, be careful Smith is close to your position", "Neo, Smith is following you", "Run Neo, you're in danger", "Smith is acting" };
            neoDialogue = new String[] { "Neo, we believe in you","you are the Choosen One", "you have healed people close to you" };
            try
            {
                this.dead = (Image)new Bitmap(Image.FromFile("..\\..\\imgPersonage\\muerto.jpg"), 100, 100);
            }catch(Exception ex)
            {
                Console.WriteLine("directorio de imagen no encontrado");
            }

            control = false;
            
            InitializeComponent();
            this.CenterToScreen();
            Shown += new EventHandler(Principal_Shown);
            // To report progress from the background worker we need to set this property
            backgroundWorker1.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            // This event will be raised when we call ReportProgress
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);



        }

        void Principal_Shown(object sender, EventArgs e)
        {
            // Start the background worker
            backgroundWorker1.RunWorkerAsync();


        }
        // On worker thread so do our thing!


        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int cont = 0;
            while (cont <5)
            {
                
                System.Threading.Thread.Sleep(2000);
                backgroundWorker1.ReportProgress(cont);
                cont++;

            }
            int max_time = 20;
            int time = 1;

             m = new Matrix.Matrix();

           
            do
            {
                if (time % 1 == 0 && !m.end())
                {
                    //Accion del personaje
                    m.actionPg();


                }
                if (time % 2 == 0 && !m.end())
                {
                    //Accion de smith
                    m.smithAction2();
                    this.infect = m.getDead();


                }
                if (time % 5 == 0 && !m.end())
                 {
                    //Accion de neo
                    m.actionNeo();
                    

                }
                    backgroundWorker1.ReportProgress(time);
                System.Threading.Thread.Sleep(1500);
                time += 1;
                
               

            } while (time <= max_time && !m.end());
            
            


        }
        // Back on the 'UI' thread so we can update the progress bar
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            int cont = e.ProgressPercentage;
 
           
            if (cont <5 &&!this.control)
            {
                this.txtArea.AppendText(this.whiteRabbit[cont]+String.Format(Environment.NewLine));
                if (cont == 4)
                {
                    this.control = true;
                }

            }
            else{
                // The progress percentage is a property of e
                 progressBar1.Value = e.ProgressPercentage;

                if (e.ProgressPercentage % 2 == 0)
                {
                    txtArea.AppendText(String.Format(Environment.NewLine));
                    txtArea.AppendText(this.smithDialogue[Useful.random_Number(0,this.smithDialogue.GetLength(0))] + String.Format(Environment.NewLine));
                    if (this.infect > 0)
                    {
                        txtArea.AppendText("# Smith has killed " + this.infect + " people!!"+ String.Format(Environment.NewLine));
                    }else
                    {
                        txtArea.AppendText("# Good news, smith hasn't killed anyone!!" + String.Format(Environment.NewLine));
                    }
                    



                }
                if (e.ProgressPercentage % 5 == 0)
                {
                    txtArea.AppendText(String.Format(Environment.NewLine));
                    if (m.getBelieved())
                    {
                        txtArea.AppendText(this.neoDialogue[Useful.random_Number(0, this.neoDialogue.GetLength(0))] + String.Format(Environment.NewLine));
                    }
                    


                }


                
                printDataView();
                this.dataGridView1.ClearSelection();
                // Aqui actualizamos el datagridview con los datos, osea el m.print que haciamos por consola

                if (e.ProgressPercentage == 20)
                {
                    final = new Final();
                    final.Show();
                    Inicial ts = (Inicial)Application.OpenForms["Inicial"];
                    ts.Close();
                }
            }
            

        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void printDataView()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < m.getBoard().GetLength(0); i++)
            {
                //  Añadir filas
                dataGridView1.Rows.Add(new DataGridViewRow());
                for (int j = 0; j < m.getBoard().GetLength(1); j++)
                {
                    if (m.getBoard()[i, j] != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = m.getBoard()[i, j].getImage();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = this.dead;
                    }

                }
            }
        }

    }
}
