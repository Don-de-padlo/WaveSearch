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
            for (int i = 0; i < sizeArr; i++)
            {
                for (int j = 0; j < sizeArr; j++)
                {
                    labelArr[i, j] = null;
                }
            }
        }


        public void AddYellowLb(Label lb)
        {
            labelArr[lb.Name[0], lb.Name[2]] = lb;
        }
        public void DeleteYellowLb(Label lb)
        {
            labelArr[lb.Name[0], lb.Name[2]] = null;
        }
        public Label FindFarRightLb()
        {
            Label temp = null;
            for (int i=0; i< sizeArr; i++)
            {
                temp = null;
                for (int j = 0; j < sizeArr; j++)
                {
                    if (temp == null && labelArr[j,i] != null)
                    {
                        temp = labelArr[j, i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return temp;
        }
    }
}
