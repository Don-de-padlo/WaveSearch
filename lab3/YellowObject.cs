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
            for (int i = 0; i < sizeArr - 1; i++)
            {
                for (int j = 0; j < sizeArr - 1; j++)
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
        public void SlideRight()
        {
            InitMatrixLabel();
            Label temp = null;
            for (int i = 0; i < sizeArr; i++)
            {
                
                for (int j = 0; j < sizeArr; j++)
                {
                    if (MLb[i , j].label != null && !MLb[i, j].visited )
                    {
                        temp = labelArr[i, j];
                        if(i < sizeArr - 1) labelArr[i+1, j ] = temp;
                        MLb[i, j].visited = true;
                    }

                }
                
            }
            
        }

        public void SlideDown()
        {
            InitMatrixLabel();
            Label temp = null;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                    if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        temp = labelArr[i, j];
                        if (j < sizeArr - 1) labelArr[i , j+1] = temp;
                        MLb[i, j].visited = true;
                    }

                }

            }

        }
        public void SlideBisector()
        {
            InitMatrixLabel();
            Label temp = null;
            for (int i = 0; i < sizeArr; i++)
            {

                for (int j = 0; j < sizeArr; j++)
                {
                    if (MLb[i, j].label != null && !MLb[i, j].visited)
                    {
                        temp = labelArr[i, j];
                        if (i < sizeArr - 1 && j < sizeArr - 1) labelArr[i + 1 , j + 1] = temp;
                        MLb[i, j].visited = true;
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
    }
}
