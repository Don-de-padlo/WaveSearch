using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public struct MatrixLabel
    {
        public MatrixLabel(Label lb , bool visited)
        {
            this.label = lb;
            this.visited = visited;
        }
        public Label label { get; set; }
        public bool visited { get; set; }
    }
    class YellowObject
    {
        private Label [,] labelArr;
        private Label farRight;
        private Label farLeft;
        private Label farUp;
        private Label farDown;
        private Label destination;
        private Label start;
        private MatrixLabel[,] MLb;
        int sizeArr;


        public YellowObject(int sizeArrPlace)
        {
            labelArr = new Label[sizeArrPlace, sizeArrPlace];
            MLb = new MatrixLabel[sizeArrPlace, sizeArrPlace];
            sizeArr = sizeArrPlace;
            InitByNull();
        }
        private void InitMatrixLabel()
        {
            for (int i = 0; i < sizeArr ; i++)
            {
                for (int j = 0; j < sizeArr ; j++)
                {
                    MLb[i, j] = new MatrixLabel(labelArr[i,j] , false);
                }
            }
        }
        private void InitByNull()
        {
            for (int i = 0; i < sizeArr-1; i++)
            {
                for (int j = 0; j < sizeArr-1; j++)
                {
                    labelArr[i, j] = null;
                }
            }
        }

        public void AddDestinationLb(Label lb)
        {
            destination = lb;
        }
        public void AddStartLb(Label lb)
        {
            start = lb;
        }
        public void AddYellowLb(Label lb)
        {
            int x =Int32.Parse(lb.Name.Substring(0 , lb.Name.IndexOf('_')));
            int y = Int32.Parse(lb.Name.Substring(lb.Name.IndexOf('_')+1));
            labelArr[x, y] = lb;
        }
        public void DeleteYellowLb(Label lb)
        {
            int x = Int32.Parse(lb.Name.Substring(0, lb.Name.IndexOf('_')));
            int y = Int32.Parse(lb.Name.Substring(lb.Name.IndexOf('_') + 1));
            labelArr[x, y] = null;
        }
        public void DeleteDestinationLb(Label lb)
        {
            destination = null;
        }
        public void DeleteStartLb(Label lb)
        {
            start = null;
        }
        public Label FindFarRightLb()
        {
            Label temp = null;
            for (int i=0; i< sizeArr ; i++)
            {
                //temp = null;
                for (int j = 0; j < sizeArr; j++)
                {
                    if ( labelArr[i,j] != null)
                    {
                        temp = labelArr[i, j];
                    }
                    
                }
                
            }
            return temp;
        }
        public Label FindFarLefttLb()
        {
            Label temp = null;
            for (int i = sizeArr - 1; i >= 0; i--)
            {
                //temp = null;
                for (int j = sizeArr - 1; j >= 0; j--)
                {
                    if (labelArr[i, j] != null)
                    {
                        temp = labelArr[i, j];
                    }
                    
                }
            }
            return temp;
        }

        public Label FindFarDownLb()
        {
            Label temp = null;
            for (int i = 0; i < sizeArr; i++)
            {
                //temp = null;
                for (int j = 0; j < sizeArr; j++)
                {
                    if (labelArr[j, i] != null)
                    {
                        temp = labelArr[j, i];
                    }
                    
                }
            }
            return temp;
        }
        public Label FindFarUpLb()
        {
            Label temp = null;
            for (int i = sizeArr - 1; i >= 0; i--)
            {
                
                for (int j = sizeArr - 1; j >= 0; j--)
                {
                    if (labelArr[j, i] != null)
                    {
                        temp = labelArr[j, i];
                    }
                    
                }
            }
            return temp;
        }
        public Label FindOrangeLb(Label [,]Lbarr)
        {
            for (int i = 0; i < sizeArr;i++)
            {
                for (int j = 0; j < sizeArr; j++)
                {
                    if (Lbarr[i , j].BackColor == Color.DarkOrange)
                    {
                        return Lbarr[i, j];
                    }
                }
            }
            return null;
        }
        public void SlideRight( ref Label [,] larr)
        {
            //InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {
                
                for (int j = 0; j < sizeArr; j++)
                {
                    /*if (MLb[i , j].label != null && !MLb[i, j].visited )
                    {
                        temp = labelArr[i, j];
                        if(i < sizeArr - 1) labelArr[i+1, j ] = temp;
                        MLb[i, j].visited = true;
                    }*/

                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (i < sizeArr - 1) larr[i + 1, j].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }
                
            }
            
        }
        public void SlideLeft(ref Label[,] larr)
        {
            InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        temp = labelArr[i, j];
                        if (i > 0) labelArr[i - 1 , j] = temp;
                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (i > 0) larr[i - 1, j].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }

            }
            

        }
        public void SlideDown(ref Label[,] larr)
        {
            InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        temp = labelArr[i, j];
                        if (j < sizeArr - 1) labelArr[i , j+1] = temp;
                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (j < sizeArr - 1) larr[i, j + 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }

                }

            }

        }
        public void SlideUp(ref Label[,] larr)
        {
            //InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        temp = labelArr[i, j];
                        if (j > 0) labelArr[i, j - 1] = temp;
                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (j > 0) larr[i, j - 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }

            }

        }
        public void SlideBisector(ref Label[,] larr)
        {
            //InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        temp = labelArr[i, j];
                        if (i < sizeArr - 1 && j < sizeArr - 1) labelArr[i + 1 , j + 1] = temp;
                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (i < sizeArr - 1 && j < sizeArr - 1) larr[i + 1, j + 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }

            }

        }
        public void SlideBisectorRDToLUp(ref Label[,] larr)
        {
            //InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                   
                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        
                        temp = labelArr[i, j];
                        if (i > 0 && j > 0) labelArr[i - 1, j - 1] = temp;
                        
                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (i > 0 && j > 0) larr[i - 1, j - 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }

                }

            }

        }
        public void SlideBisectorLDToRUp(ref Label[,] larr)
        {
            //InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {

                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {

                        temp = labelArr[i, j];
                        if (i < sizeArr - 1 && j > 0) labelArr[i + 1, j - 1] = temp;

                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (i < sizeArr - 1 && j > 0) larr[i + 1, j - 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }

                }

            }

        }
        public void SlideBisectorRUpToLDown(ref Label[,] larr)
        {
            //InitMatrixLabel();
            Label temp = null;
            bool moved = false;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {

                    /*if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {

                        temp = labelArr[i, j];
                        if (i > 0  && j < sizeArr - 1) labelArr[i - 1, j + 1] = temp;

                        MLb[i, j].visited = true;
                    }*/
                    if (larr[i, j].BackColor == Color.DarkOrange && moved == false)
                    {
                        //AddYellowLb(larr[i, j]);
                        larr[i, j].BackColor = Color.Yellow;
                        if (i > 0 && j < sizeArr - 1) larr[i - 1, j + 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }

            }

        }
        public void SynchrLb(Label[,] synch)
        {
           
            for (int i = 0; i < sizeArr; i++)
            {
                
                for (int j = 0; j < sizeArr; j++)
                {
                    if (synch[i , j].BackColor  == Color.Yellow && labelArr[i , j] == null)
                    {
                        synch[i, j].BackColor = Color.Aqua;
                    }
                    if (synch[i, j].BackColor == Color.Aqua && labelArr[i, j] != null)
                    {
                        synch[i, j].BackColor = Color.Yellow;
                    }
                }

            }
        }
        public void SearchLeftRight(ref Label[,] larr)
        {
            int x_d = Int32.Parse(destination.Name.Substring(0, destination.Name.IndexOf('_')));
            //int y_d = Int32.Parse(destination.Name.Substring(destination.Name.IndexOf('_') + 1));

            int x_s = Int32.Parse(start.Name.Substring(0, start.Name.IndexOf('_')));
            //int y_s = Int32.Parse(start.Name.Substring(start.Name.IndexOf('_') + 1));
            //Label temp = null;
            while(x_s != x_d)
            {
                
                if (x_s > x_d)
                {
                    SlideLeft(ref larr);
                    x_s--;

                    //temp.BackColor = Color.Yellow;
                }
                if (x_s < x_d)
                {
                    x_s++;
                    SlideRight(ref larr);
                }
            }
            

        }

        public void SearchUpDown(ref Label[,] larr)
        {
            //int x_d = Int32.Parse(destination.Name.Substring(0, destination.Name.IndexOf('_')));
            int y_d = Int32.Parse(destination.Name.Substring(destination.Name.IndexOf('_') + 1));

            //int x_s = Int32.Parse(start.Name.Substring(0, start.Name.IndexOf('_')));
            int y_s = Int32.Parse(start.Name.Substring(start.Name.IndexOf('_') + 1));
            //Label temp = null;
            while (y_s != y_d)
            {
                
                if (y_s > y_d)
                {
                    SlideUp(ref larr);
                    y_s--;

                    //temp.BackColor = Color.Yellow;
                }
                if (y_s < y_d)
                {
                    y_s++;
                    SlideDown(ref larr);
                }
                
            }


        }
        public void SearchUpDownLeftRight(ref Label[,] larr)
        {
            start = FindOrangeLb(larr);
            int x_d = Int32.Parse(destination.Name.Substring(0, destination.Name.IndexOf('_')));
            int y_d = Int32.Parse(destination.Name.Substring(destination.Name.IndexOf('_') + 1));

            int x_s = Int32.Parse(start.Name.Substring(0, start.Name.IndexOf('_')));
            int y_s = Int32.Parse(start.Name.Substring(start.Name.IndexOf('_') + 1));
            Label temp = null;
            /*if (Math.Abs(x_s - x_d) >= Math.Abs(y_s - y_d))
            {
                SearchUpDown(ref larr);
                start = FindOrangeLb(larr);
                x_s = Int32.Parse(start.Name.Substring(0, start.Name.IndexOf('_')));
                y_s = Int32.Parse(start.Name.Substring(start.Name.IndexOf('_') + 1));
            }else
            if (Math.Abs(x_s - x_d) <= Math.Abs(y_s - y_d))
            {
                SearchLeftRight(ref larr);
                start = FindOrangeLb(larr);
                x_s = Int32.Parse(start.Name.Substring(0, start.Name.IndexOf('_')));
                y_s = Int32.Parse(start.Name.Substring(start.Name.IndexOf('_') + 1));
            }*/
            
            SearchLeftRight(ref larr);
            SearchUpDown(ref larr);




        }
    }
}
