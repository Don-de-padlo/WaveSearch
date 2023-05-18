using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
        public bool SlideRight( ref Label [,] larr)
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
                        if (i < sizeArr - 1 && larr[i + 1, j].BackColor == Color.Black)
                        {
                            larr[i, j].BackColor = Color.DarkOrange;
                            return true;
                        }
                        if (i < sizeArr - 1) larr[i + 1, j].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }
                
            }
            return false;
        }
        public bool SlideLeft(ref Label[,] larr)
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
                        if (i > 0 && larr[i - 1, j].BackColor == Color.Black)
                        {
                            larr[i, j].BackColor = Color.DarkOrange;
                            return true;
                        }
                        if (i > 0) larr[i - 1, j].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }

            }
            return false;

        }
        public bool SlideDown(ref Label[,] larr)
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
                        if (j < sizeArr - 1 && larr[i, j + 1].BackColor == Color.Black)
                        {
                            larr[i, j].BackColor = Color.DarkOrange;
                            return true;
                        }
                        if (j < sizeArr - 1) larr[i, j + 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }

                }

            }
            return false;
        }
        public bool SlideUp(ref Label[,] larr)
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
                        if (j > 0 && larr[i, j - 1].BackColor == Color.Black)
                        {
                            larr[i, j].BackColor = Color.DarkOrange;
                            return true;
                        }
                        if (j > 0) larr[i, j - 1].BackColor = Color.DarkOrange;
                        moved = true;
                    }
                }

            }
            return false;

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
        public bool SearchLeftRight(ref Label[,] larr)
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
                    if(SlideLeft(ref larr)) return true;
                    x_s--;

                    //temp.BackColor = Color.Yellow;
                }
                if (x_s < x_d)
                {
                    x_s++;
                    if(SlideRight(ref larr)) return true;
                }
            }

            return false;
        }

        public bool SearchUpDown(ref Label[,] larr)
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
                    if(SlideUp(ref larr)) return true;
                    y_s--;

                    //temp.BackColor = Color.Yellow;
                }
                if (y_s < y_d)
                {
                    y_s++;
                    if(SlideDown(ref larr)) return true;
                }
                
            }

            return false;
        }
        public void GoAroundObstacle(ref Label[,] larr)
        {

        }
        public bool SearchUpDownLeftRight(ref Label[,] larr)
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
            
            if(SearchLeftRight(ref larr)) return true;
            if(SearchUpDown(ref larr)) return true;



            return false;
        }
        private List<Label> InitAllLbNeighbor(ref Label[,] larr, ref int count, Label curent)
        {
            List<Label> LbList = new List<Label>();
            int x_cur = Int32.Parse(curent.Name.Substring(0, curent.Name.IndexOf('_')));
            int y_cur = Int32.Parse(curent.Name.Substring(curent.Name.IndexOf('_') + 1));
            
            //up
            if (y_cur > 0)
            {
                if (larr[x_cur, y_cur - 1].BackColor != Color.Black && larr[x_cur, y_cur - 1].Text =="")
                {
                    larr[x_cur, y_cur - 1].Text = count.ToString();
                    LbList.Add(larr[x_cur, y_cur - 1]);
                }

            }
            //right
            if (x_cur < sizeArr - 1)
            {
                if (larr[x_cur + 1, y_cur].BackColor != Color.Black && larr[x_cur + 1, y_cur ].Text == "")
                {
                    larr[x_cur + 1, y_cur].Text = count.ToString();
                    LbList.Add(larr[x_cur + 1, y_cur]);
                }

            }
            //left
            if (x_cur > 0 )
            {
                if (larr[x_cur - 1, y_cur].BackColor != Color.Black && larr[x_cur - 1, y_cur].Text == "")
                {
                    larr[x_cur - 1, y_cur].Text = count.ToString();
                    LbList.Add(larr[x_cur - 1, y_cur]);
                }

            }
            //down
            if (y_cur < sizeArr - 1)
            {
                if (larr[x_cur, y_cur + 1].BackColor != Color.Black && larr[x_cur , y_cur + 1].Text == "")
                {
                    larr[x_cur, y_cur + 1].Text = count.ToString();
                    LbList.Add(larr[x_cur, y_cur + 1]);
                }

            }
            //count++;
            return LbList;
        }
        private Label MarkPath(ref Label[,] larr, Label curent)
        {

            Label temp = null;
            int x_cur = Int32.Parse(curent.Name.Substring(0, curent.Name.IndexOf('_')));
            int y_cur = Int32.Parse(curent.Name.Substring(curent.Name.IndexOf('_') + 1));

            int minValue = 999;
            //LUpToRdown
            if (x_cur < sizeArr - 1 && y_cur < sizeArr - 1)
            {
                if (larr[x_cur + 1, y_cur + 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur + 1, y_cur + 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur + 1, y_cur + 1].Text);
                        temp = larr[x_cur + 1, y_cur + 1];
                    }
                }

            }
            //RDToLUp
            if (x_cur > 0 && y_cur > 0)
            {
                if (larr[x_cur - 1, y_cur - 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur - 1, y_cur - 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur - 1, y_cur - 1].Text);
                        temp = larr[x_cur - 1, y_cur - 1];
                    }
                }

            }
            //LDToRUp
            if (x_cur < sizeArr - 1 && y_cur > 0)
            {
                if (larr[x_cur + 1, y_cur - 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur + 1, y_cur - 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur + 1, y_cur - 1].Text);
                        temp = larr[x_cur + 1, y_cur - 1];

                    }
                }

            }
            //RUpToLDown
            if (x_cur > 0 && y_cur < sizeArr - 1)
            {
                if (larr[x_cur - 1, y_cur + 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur - 1, y_cur + 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur - 1, y_cur + 1].Text);
                        temp = larr[x_cur - 1, y_cur + 1];
                    }
                }

            }
            //up
            if (y_cur > 0)
            {
                if (larr[x_cur, y_cur - 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur, y_cur - 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur, y_cur - 1].Text);
                        temp = larr[x_cur, y_cur - 1];
                    }
                }

            }
            //right
            if (x_cur < sizeArr - 1)
            {
                if (larr[x_cur + 1, y_cur].Text != "")
                {
                    if (Int32.Parse(larr[x_cur + 1, y_cur].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur + 1, y_cur].Text);
                        temp = larr[x_cur + 1, y_cur];
                    }
                }

            }
            //left
            if (x_cur > 0)
            {
                if (larr[x_cur - 1, y_cur].Text != "")
                {
                    if (Int32.Parse(larr[x_cur - 1, y_cur].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur - 1, y_cur].Text);
                        temp = larr[x_cur - 1, y_cur];
                    }
                }

            }
            //down
            if (y_cur < sizeArr - 1)
            {
                if (larr[x_cur, y_cur + 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur, y_cur + 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur, y_cur + 1].Text);
                        temp = larr[x_cur, y_cur + 1];
                    }
                }

            }


            temp.BackColor = Color.Red;
            return temp;
        }

        public void WaveSearchDestination(ref Label[,] larr)
        {
            start = FindOrangeLb(larr);
            List<Label> CurentLbList = new List<Label>();
            List<Label> NextLbList = new List<Label>();
            CurentLbList.Add(start);
            
            int count = 0;
            bool end = false;
            start.Text = count.ToString();
            count++;
            while (!end)
            {
                foreach (Label lb in CurentLbList)
                {
                    NextLbList.AddRange(InitAllLbNeighbor(ref larr, ref count, lb));
                    if (lb == destination)
                    {
                        end = true;
                        break;
                    }
                    
                }
                CurentLbList.Clear();
                CurentLbList.AddRange(NextLbList);
                NextLbList.Clear();
                count++;
            }
            end = false;
            Label curent = destination;
            int failSearch = 0;
            while (!end)
            {
                curent = MarkPath(ref larr , curent);
                if (curent == start || failSearch > 255)
                {
                    end = true;
                    break;
                }
                failSearch++;
            }
            
        }


        private Label MarkPathBisector(ref Label[,] larr, Label curent)
        {

            Label temp = null;
            int x_cur = Int32.Parse(curent.Name.Substring(0, curent.Name.IndexOf('_')));
            int y_cur = Int32.Parse(curent.Name.Substring(curent.Name.IndexOf('_') + 1));

            int minValue = 999;
            //LUpToRdown
            if (x_cur < sizeArr - 1 && y_cur < sizeArr - 1)
            {
                if (larr[x_cur + 1, y_cur + 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur + 1, y_cur + 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur + 1, y_cur + 1].Text);
                        temp = larr[x_cur + 1, y_cur + 1];
                    }
                }

            }
            //RDToLUp
            if (x_cur > 0 && y_cur > 0)
            {
                if (larr[x_cur - 1, y_cur - 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur - 1, y_cur - 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur - 1, y_cur - 1].Text);
                        temp = larr[x_cur - 1, y_cur - 1];
                    }
                }

            }
            //LDToRUp
            if (x_cur < sizeArr - 1 && y_cur > 0)
            {
                if (larr[x_cur + 1, y_cur - 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur + 1, y_cur - 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur + 1, y_cur - 1].Text);
                        temp = larr[x_cur + 1, y_cur - 1];

                    }
                }

            }
            //RUpToLDown
            if (x_cur > 0 && y_cur < sizeArr - 1)
            {
                if (larr[x_cur - 1, y_cur + 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur - 1, y_cur + 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur - 1, y_cur + 1].Text);
                        temp = larr[x_cur - 1, y_cur + 1];
                    }
                }

            }
            

            if(temp != null) temp.BackColor = Color.Red;
            return temp;
        }

        public void WaveSearchDestinationBisector(ref Label[,] larr)
        {
            start = FindOrangeLb(larr);
            List<Label> CurentLbList = new List<Label>();
            List<Label> NextLbList = new List<Label>();
            CurentLbList.Add(start);

            int count = 0;
            bool end = false;
            start.Text = count.ToString();
            count++;
            int failSearch = 0;
            while (!end )
            {
                foreach (Label lb in CurentLbList)
                {
                    NextLbList.AddRange(InitAllLbNeighbor(ref larr, ref count, lb));
                    if (lb == destination || failSearch == 55)
                    {
                        end = true;
                        break;
                    }

                }
                CurentLbList.Clear();
                CurentLbList.AddRange(NextLbList);
                NextLbList.Clear();
                count++;
                failSearch++;
            }
            end = false;
            Label curent = destination;
            failSearch = 0;
            while (!end)
            {
                curent = MarkPathBisector(ref larr, curent);
                if (curent == start || failSearch == 55)
                {
                    end = true;
                    break;
                }
                failSearch++;
            }

        }

        private Label MarkPathHorAndVert(ref Label[,] larr, Label curent)
        {

            Label temp = null;
            int x_cur = Int32.Parse(curent.Name.Substring(0, curent.Name.IndexOf('_')));
            int y_cur = Int32.Parse(curent.Name.Substring(curent.Name.IndexOf('_') + 1));

            int minValue = 999;
            
            //up
            if (y_cur > 0)
            {
                if (larr[x_cur, y_cur - 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur, y_cur - 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur, y_cur - 1].Text);
                        temp = larr[x_cur, y_cur - 1];
                    }
                }

            }
            //right
            if (x_cur < sizeArr - 1)
            {
                if (larr[x_cur + 1, y_cur].Text != "")
                {
                    if (Int32.Parse(larr[x_cur + 1, y_cur].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur + 1, y_cur].Text);
                        temp = larr[x_cur + 1, y_cur];
                    }
                }

            }
            //left
            if (x_cur > 0)
            {
                if (larr[x_cur - 1, y_cur].Text != "")
                {
                    if (Int32.Parse(larr[x_cur - 1, y_cur].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur - 1, y_cur].Text);
                        temp = larr[x_cur - 1, y_cur];
                    }
                }

            }
            //down
            if (y_cur < sizeArr - 1)
            {
                if (larr[x_cur, y_cur + 1].Text != "")
                {
                    if (Int32.Parse(larr[x_cur, y_cur + 1].Text) < minValue)
                    {
                        minValue = Int32.Parse(larr[x_cur, y_cur + 1].Text);
                        temp = larr[x_cur, y_cur + 1];
                    }
                }

            }


            temp.BackColor = Color.Red;
            return temp;
        }

        public void WaveSearchDestinationHorAndVert(ref Label[,] larr)
        {
            start = FindOrangeLb(larr);
            List<Label> CurentLbList = new List<Label>();
            List<Label> NextLbList = new List<Label>();
            CurentLbList.Add(start);

            int count = 0;
            bool end = false;
            start.Text = count.ToString();
            count++;
            while (!end)
            {
                foreach (Label lb in CurentLbList)
                {
                    NextLbList.AddRange(InitAllLbNeighbor(ref larr, ref count, lb));
                    if (lb == destination)
                    {
                        end = true;
                        break;
                    }

                }
                CurentLbList.Clear();
                CurentLbList.AddRange(NextLbList);
                NextLbList.Clear();
                count++;
            }
            end = false;
            Label curent = destination;
            int failSearch = 0;
            while (!end)
            {
                curent = MarkPathHorAndVert(ref larr, curent);
                if (curent == start || failSearch > 255)
                {
                    end = true;
                    break;
                }
                failSearch++;
            }

        }
    }
}
