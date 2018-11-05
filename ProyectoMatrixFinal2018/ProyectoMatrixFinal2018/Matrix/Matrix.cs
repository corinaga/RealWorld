using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatrixFinal2018.Matrix
{
    class Matrix
    {
        public Queue<Personage> queue;
        public Personage[,] board;
        private Smith smith;
        private Neo neo;
        private int dead;
        private bool believed;


        public Matrix()
        {
            neo = new Neo();
            smith = new Smith();
            this.dead = 0;

            this.board = new Personage[5, 5];
            this.queue = new Queue<Personage>();
            putNeoSmith();
            relQueue();
            putPg();

        }


        public void putNeoSmith()
        {
            int smF = Useful.random_Number(0, 5);
            int smC = Useful.random_Number(0, 5);
            int neoF = Useful.random_Number(0, 5);
            int neoC = Useful.random_Number(0, 5);



            this.board[neoF, neoC] = this.neo;

            bool put = false;

            while (!put)
            {
                if (this.board[smF, smC] == null)
                {
                    this.board[smF, smC] = this.smith;
                    put = true;

                }
                smF = Useful.random_Number(0, 5);
                smC = Useful.random_Number(0, 5);
            }


        }


        public Cell whereIsNeo()
        {
            int row, col, rowN = 0, colN = 0;

            for (int i = 0; i < 5 * 5; i++)
            {
                row = i / 5;
                col = i % 5;

                if (this.board[row, col] is Neo)
                {
                    rowN = row;
                    colN = col;
                }

            }
            Cell c = new Cell(rowN, colN);


            return c;

        }

        public Cell whereIsSmith()
        {
            int row, col, rowS = 0, colS = 0;

            for (int i = 0; i < 5 * 5; i++)
            {
                row = i / 5;
                col = i % 5;

                if (board[row, col] is Smith)
                {
                    rowS = row;
                    colS = col;
                }

            }
            Cell c = new Cell(rowS, colS);


            return c;

        }


        public void putPg()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.board[i, j] == null)
                    {

                        this.board[i, j] = queue.Dequeue();

                    }

                }
            }
        }

        public void relQueue()
        {

            for (int i = 0; i < 200; i++)
            {

                this.queue.Enqueue(new Personage());

            }
        }



        public void smithAction2()
        {
            Cell smith = whereIsSmith();

            Cell neo = whereIsNeo();
            List<Cell> path = new List<Cell>();
            List<Cell> pathOpt = new List<Cell>();
            bool[,] visited = new bool[5, 5];

            smithAction(smith, neo, path, ref pathOpt, visited);
            //Console.WriteLine(pathOpt.Count());
            /*foreach (Cell item in pathOpt)
            {
                Console.Write(item.getx());
                Console.Write("-");
                Console.Write(item.gety());
                Console.Write("  ");
            }
            */
            //Console.WriteLine();

            int infect = this.smith.getInfect();
            this.dead = 0;
            Console.WriteLine("Infect: " + infect);
            Console.WriteLine();

            for (int i = 0; i < pathOpt.Count() - 1 && i < infect; i++)
            {

                Cell c = pathOpt[i];
                if (this.board[c.getx(), c.gety()] != null)
                {
                    kill(c.getx(), c.gety());
                    this.dead++;
                }
                else
                {
                    infect++;
                }

            }

        }

        public void smithAction(Cell smith, Cell neo, List<Cell> path, ref List<Cell> pathOpt, bool[,] visited)
        {
            int i, j;

            if (smith.equals(neo))
            {
                if (pathOpt.Count() == 0 || path.Count() < pathOpt.Count())
                {
                    pathOpt = path.GetRange(0, path.Count());
                }
            }
            else
            {
                for (i = -1; i <= 1; i++)
                {
                    for (j = -1; j <= 1; j++)
                    {

                        if (Math.Abs(i) + Math.Abs(j) == 1)
                        {
                            Cell aux = new Cell(smith.getx() + i, smith.gety() + j);

                            if (isInside(aux))
                            {
                                if (!isVisited(aux, visited))
                                {
                                    path.Add(aux);
                                    visited[smith.getx(), smith.gety()] = true;
                                    smithAction(aux, neo, path, ref pathOpt, visited);

                                    visited[aux.getx(), aux.gety()] = false;
                                    path.RemoveAt(path.Count - 1);
                                }
                            }
                        }

                    }
                }
            }


        }


        public bool isVisited(Cell c, bool[,] visited)
        {
            return visited[c.getx(), c.gety()];

        }

        public bool isInside(Cell c)
        {
            bool inside = false;
            if ((c.getx() < 5 && c.getx() >= 0) && (c.gety() < 5 && c.gety() >= 0))
            {
                inside = true;
            }
            return inside;
        }



        public void actionNeo()
        {
            this.believed = this.neo.isBelieved();
            if (this.believed && (this.queue.Count() > 0))
            {
                Console.WriteLine("Neo is believed to be the one ");
                Cell n = whereIsNeo();
                for (int i = -1; i <= 1; i++)
                {

                    for (int j = -1; j <= 1; j++)
                    {
                        Cell aux = new Cell(n.getx() + i, n.gety() + j);
                        if (isInside(aux))
                        {
                            if (this.board[aux.getx(), aux.gety()] == null)
                            {

                                this.board[aux.getx(), aux.gety()] = this.queue.Dequeue();
                            }
                        }

                    }
                }


            }
            else
            {
                Console.WriteLine("Neo is not believed to be the one ");

            }
            Console.WriteLine();
            swapNeo();

        }

        public void swapNeo()
        {
            Cell n = whereIsNeo();
            int neX = n.getx();
            int neY = n.gety();

            int newX = Useful.random_Number(0, 5);
            int newY = Useful.random_Number(0, 5);

            if (this.board[newX, newY] != null)
            {
                if (this.board[newX, newY] is Smith)
                {
                    Smith aux = (Smith)this.board[newX, newY];
                    this.board[newX, newY] = this.neo;
                    this.board[neX, neY] = aux;

                }
                else
                {
                    Personage aux = this.board[newX, newY];
                    this.board[newX, newY] = this.neo;
                    this.board[neX, neY] = aux;
                }

            }
            else
            {
                this.board[newX, newY] = this.neo;
                this.board[neX, neY] = null;
            }
        }


        public void kill(int fila, int col)
        {
            this.board[fila, col] = null;
        }


        public void printMatrix()
        {


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.board[i, j] is Neo)
                    {
                        Console.Write("  N      ");
                    }
                    else
                    {
                        if (this.board[i, j] is Smith)
                        {
                            Console.Write("  S      ");
                        }
                        else
                        {
                            if (this.board[i, j] != null)
                            {
                                //Console.Write("P");
                                Console.Write(this.board[i, j].getNombre());
                            }
                            else
                            {
                                Console.Write("  X      ");
                            }

                        }
                    }

                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }


        public void actionPg()
        {
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!(this.board[i, j] is Neo) && !(this.board[i, j] is Smith))
                    {
                        if (this.board[i, j] != null)
                        {
                            Personage p = this.board[i, j];
                            int per = p.getPercentageDie();

                            if (per > 70)
                            {
                                if (this.queue.Count() > 0)
                                {
                                    this.board[i, j] = this.queue.Dequeue();

                                }
                                else
                                {
                                    this.board[i, j] = null;
                                }
                                cont++;

                            }
                            else
                            {
                                p.setPercentageDie(per + 10);
                            }
                        }


                    }

                }
            }

            Console.WriteLine("Kill: " + cont);
            Console.WriteLine();
        }

        public int getCountQueue()
        {
            return this.queue.Count();
        }

        public bool end()
        {
            bool finish = false;
            int cont = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (this.board[i, j] != null)
                    {
                        cont++;
                    }
                }
            }

            if (cont <= 2)
            {
                finish = true;
            }

            return finish;
        }

        public Personage[,] getBoard()
        {
            return this.board;
        }

        public Smith getSmith()
        {
            return this.smith;
        }

        public Neo getNeo()
        {
            return this.neo;
        }

        public int getDead()
        {
            return this.dead;
        }

        public bool getBelieved()
        {
            return this.believed;
        }
    }

   
    
}
