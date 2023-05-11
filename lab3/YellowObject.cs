using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    class YellowObject
    {
        private Label [,] labelArr;
        private Label farRight;
        private Label farLeft;
        private Label farUp;
        private Label farDown;
        int sizeArr;


        public YellowObject(int sizeArrPlace)
        {
            labelArr = new Label[sizeArrPlace, sizeArrPlace];
            sizeArr = sizeArrPlace;
            InitByNull();
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
    }
}
