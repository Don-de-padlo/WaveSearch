
namespace lab3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.right_leftRbn = new System.Windows.Forms.RadioButton();
            this.up_downRbn = new System.Windows.Forms.RadioButton();
            this.bisector_rightRbn = new System.Windows.Forms.RadioButton();
            this.bisector_leftRbn = new System.Windows.Forms.RadioButton();
            this.bisectorRbn = new System.Windows.Forms.RadioButton();
            this.h_vRbn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(1097, 36);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 36);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // right_leftRbn
            // 
            this.right_leftRbn.AutoSize = true;
            this.right_leftRbn.Location = new System.Drawing.Point(988, 112);
            this.right_leftRbn.Name = "right_leftRbn";
            this.right_leftRbn.Size = new System.Drawing.Size(112, 21);
            this.right_leftRbn.TabIndex = 2;
            this.right_leftRbn.TabStop = true;
            this.right_leftRbn.Text = "ВправоВліво";
            this.right_leftRbn.UseVisualStyleBackColor = true;
            this.right_leftRbn.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // up_downRbn
            // 
            this.up_downRbn.AutoSize = true;
            this.up_downRbn.Location = new System.Drawing.Point(988, 149);
            this.up_downRbn.Name = "up_downRbn";
            this.up_downRbn.Size = new System.Drawing.Size(92, 21);
            this.up_downRbn.TabIndex = 3;
            this.up_downRbn.TabStop = true;
            this.up_downRbn.Text = "ВерхВниз";
            this.up_downRbn.UseVisualStyleBackColor = true;
            // 
            // bisector_rightRbn
            // 
            this.bisector_rightRbn.AutoSize = true;
            this.bisector_rightRbn.Location = new System.Drawing.Point(988, 189);
            this.bisector_rightRbn.Name = "bisector_rightRbn";
            this.bisector_rightRbn.Size = new System.Drawing.Size(212, 21);
            this.bisector_rightRbn.TabIndex = 4;
            this.bisector_rightRbn.TabStop = true;
            this.bisector_rightRbn.Text = "ПоБісектрисі(нахил вправо)";
            this.bisector_rightRbn.UseVisualStyleBackColor = true;
            // 
            // bisector_leftRbn
            // 
            this.bisector_leftRbn.AutoSize = true;
            this.bisector_leftRbn.Location = new System.Drawing.Point(988, 229);
            this.bisector_leftRbn.Name = "bisector_leftRbn";
            this.bisector_leftRbn.Size = new System.Drawing.Size(199, 21);
            this.bisector_leftRbn.TabIndex = 5;
            this.bisector_leftRbn.TabStop = true;
            this.bisector_leftRbn.Text = "ПоБісектрисі(нахил вліво)";
            this.bisector_leftRbn.UseVisualStyleBackColor = true;
            // 
            // bisectorRbn
            // 
            this.bisectorRbn.AutoSize = true;
            this.bisectorRbn.Location = new System.Drawing.Point(988, 298);
            this.bisectorRbn.Name = "bisectorRbn";
            this.bisectorRbn.Size = new System.Drawing.Size(128, 21);
            this.bisectorRbn.TabIndex = 7;
            this.bisectorRbn.TabStop = true;
            this.bisectorRbn.Text = "ПоБісектрисам";
            this.bisectorRbn.UseVisualStyleBackColor = true;
            // 
            // h_vRbn
            // 
            this.h_vRbn.AutoSize = true;
            this.h_vRbn.Location = new System.Drawing.Point(988, 261);
            this.h_vRbn.Name = "h_vRbn";
            this.h_vRbn.Size = new System.Drawing.Size(179, 21);
            this.h_vRbn.TabIndex = 6;
            this.h_vRbn.TabStop = true;
            this.h_vRbn.Text = "ВправоВліво/ВерхВниз";
            this.h_vRbn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 834);
            this.Controls.Add(this.bisectorRbn);
            this.Controls.Add(this.h_vRbn);
            this.Controls.Add(this.bisector_leftRbn);
            this.Controls.Add(this.bisector_rightRbn);
            this.Controls.Add(this.up_downRbn);
            this.Controls.Add(this.right_leftRbn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.RadioButton right_leftRbn;
        private System.Windows.Forms.RadioButton up_downRbn;
        private System.Windows.Forms.RadioButton bisector_rightRbn;
        private System.Windows.Forms.RadioButton bisector_leftRbn;
        private System.Windows.Forms.RadioButton bisectorRbn;
        private System.Windows.Forms.RadioButton h_vRbn;
    }
}

