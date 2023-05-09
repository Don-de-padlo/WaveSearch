﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        private Label[,] labelArr = new Label[16, 16];

        private void InitLabelArr()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    labelArr[i, j] = new System.Windows.Forms.Label();

                    labelArr[i, j].AutoSize = false;
                    labelArr[i, j].Location = new System.Drawing.Point(i * 30 + 100, j * 30 + 100);
                    labelArr[i, j].Name = "" + i + "_" + j;
                    labelArr[i, j].Size = new System.Drawing.Size(25, 25);
                    labelArr[i, j].TabIndex = 0;
                    labelArr[i, j].Text = "" + i + "_" + j;
                    labelArr[i, j].BackColor = Color.Aqua;
                    labelArr[i, j].Click += new EventHandler(label1_Click);
                    this.Controls.Add(labelArr[i, j]);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            InitLabelArr();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            switch (((MouseEventArgs)e).Button)
            {
                case (MouseButtons.Left):
                    if (lb.BackColor == Color.Black)
                    {
                        lb.BackColor = Color.Aqua; ;
                    }
                    else
                    {
                        lb.BackColor = Color.Black;
                    }

                    break;


                case (MouseButtons.Right):
                    if (lb.BackColor == Color.Yellow)
                    {
                        lb.BackColor = Color.Aqua; ;
                    }
                    else
                    {
                        lb.BackColor = Color.Yellow;
                    }
                    break;
                default:
                    break;
            }
            
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void VerticalMove()
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {

        }
    }
}