namespace xmlExerciseWriter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtExercise = new System.Windows.Forms.TextBox();
            this.txtExTime = new System.Windows.Forms.TextBox();
            this.lbExName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkComp = new System.Windows.Forms.CheckBox();
            this.lbRoutine = new System.Windows.Forms.Label();
            this.txtRoutine = new System.Windows.Forms.TextBox();
            this.lbErr = new System.Windows.Forms.Label();
            this.grdExercises = new System.Windows.Forms.DataGridView();
            this.btnRnd = new System.Windows.Forms.Button();
            this.Chk10 = new System.Windows.Forms.CheckBox();
            this.chk20 = new System.Windows.Forms.CheckBox();
            this.chk15 = new System.Windows.Forms.CheckBox();
            this.Chk30 = new System.Windows.Forms.CheckBox();
            this.txtRndRoutine = new System.Windows.Forms.TextBox();
            this.lbRndName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdExercises)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExercise
            // 
            this.txtExercise.Location = new System.Drawing.Point(174, 89);
            this.txtExercise.Name = "txtExercise";
            this.txtExercise.Size = new System.Drawing.Size(125, 27);
            this.txtExercise.TabIndex = 0;
            // 
            // txtExTime
            // 
            this.txtExTime.Location = new System.Drawing.Point(174, 144);
            this.txtExTime.Name = "txtExTime";
            this.txtExTime.Size = new System.Drawing.Size(125, 27);
            this.txtExTime.TabIndex = 1;
            // 
            // lbExName
            // 
            this.lbExName.AutoSize = true;
            this.lbExName.Location = new System.Drawing.Point(47, 96);
            this.lbExName.Name = "lbExName";
            this.lbExName.Size = new System.Drawing.Size(109, 20);
            this.lbExName.TabIndex = 2;
            this.lbExName.Text = "Exercise Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exercise Time:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkComp
            // 
            this.chkComp.AutoSize = true;
            this.chkComp.Location = new System.Drawing.Point(337, 198);
            this.chkComp.Name = "chkComp";
            this.chkComp.Size = new System.Drawing.Size(153, 24);
            this.chkComp.TabIndex = 5;
            this.chkComp.Text = "Complete Exercise";
            this.chkComp.UseVisualStyleBackColor = true;
            this.chkComp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbRoutine
            // 
            this.lbRoutine.AutoSize = true;
            this.lbRoutine.Location = new System.Drawing.Point(93, 46);
            this.lbRoutine.Name = "lbRoutine";
            this.lbRoutine.Size = new System.Drawing.Size(63, 20);
            this.lbRoutine.TabIndex = 6;
            this.lbRoutine.Text = "Routine:";
            // 
            // txtRoutine
            // 
            this.txtRoutine.Location = new System.Drawing.Point(174, 39);
            this.txtRoutine.Name = "txtRoutine";
            this.txtRoutine.Size = new System.Drawing.Size(125, 27);
            this.txtRoutine.TabIndex = 7;
            // 
            // lbErr
            // 
            this.lbErr.AutoSize = true;
            this.lbErr.Location = new System.Drawing.Point(337, 39);
            this.lbErr.MinimumSize = new System.Drawing.Size(200, 80);
            this.lbErr.Name = "lbErr";
            this.lbErr.Size = new System.Drawing.Size(200, 80);
            this.lbErr.TabIndex = 8;
            this.lbErr.Text = "   ";
            // 
            // grdExercises
            // 
            this.grdExercises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExercises.Location = new System.Drawing.Point(544, 39);
            this.grdExercises.Name = "grdExercises";
            this.grdExercises.RowHeadersWidth = 51;
            this.grdExercises.Size = new System.Drawing.Size(234, 389);
            this.grdExercises.TabIndex = 9;
            this.grdExercises.Text = "dataGridView1";
            // 
            // btnRnd
            // 
            this.btnRnd.Location = new System.Drawing.Point(24, 275);
            this.btnRnd.Name = "btnRnd";
            this.btnRnd.Size = new System.Drawing.Size(94, 53);
            this.btnRnd.TabIndex = 10;
            this.btnRnd.Text = "Make Random Work Out";
            this.btnRnd.UseVisualStyleBackColor = true;
            this.btnRnd.Click += new System.EventHandler(this.btnRnd_Click);
            // 
            // Chk10
            // 
            this.Chk10.AutoSize = true;
            this.Chk10.Location = new System.Drawing.Point(158, 275);
            this.Chk10.Name = "Chk10";
            this.Chk10.Size = new System.Drawing.Size(103, 24);
            this.Chk10.TabIndex = 11;
            this.Chk10.Text = "10 Minutes";
            this.Chk10.UseVisualStyleBackColor = true;
            // 
            // chk20
            // 
            this.chk20.AutoSize = true;
            this.chk20.Location = new System.Drawing.Point(158, 317);
            this.chk20.Name = "chk20";
            this.chk20.Size = new System.Drawing.Size(103, 24);
            this.chk20.TabIndex = 12;
            this.chk20.Text = "20 Minutes";
            this.chk20.UseVisualStyleBackColor = true;
            // 
            // chk15
            // 
            this.chk15.AutoSize = true;
            this.chk15.Location = new System.Drawing.Point(280, 275);
            this.chk15.Name = "chk15";
            this.chk15.Size = new System.Drawing.Size(103, 24);
            this.chk15.TabIndex = 13;
            this.chk15.Text = "15 Minutes";
            this.chk15.UseVisualStyleBackColor = true;
            // 
            // Chk30
            // 
            this.Chk30.AutoSize = true;
            this.Chk30.Location = new System.Drawing.Point(280, 317);
            this.Chk30.Name = "Chk30";
            this.Chk30.Size = new System.Drawing.Size(103, 24);
            this.Chk30.TabIndex = 14;
            this.Chk30.Text = "30 Minutes";
            this.Chk30.UseVisualStyleBackColor = true;
            // 
            // txtRndRoutine
            // 
            this.txtRndRoutine.Location = new System.Drawing.Point(158, 364);
            this.txtRndRoutine.Name = "txtRndRoutine";
            this.txtRndRoutine.Size = new System.Drawing.Size(125, 27);
            this.txtRndRoutine.TabIndex = 15;
            // 
            // lbRndName
            // 
            this.lbRndName.AutoSize = true;
            this.lbRndName.Location = new System.Drawing.Point(27, 364);
            this.lbRndName.Name = "lbRndName";
            this.lbRndName.Size = new System.Drawing.Size(91, 20);
            this.lbRndName.TabIndex = 16;
            this.lbRndName.Text = "Name to Be:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRndName);
            this.Controls.Add(this.txtRndRoutine);
            this.Controls.Add(this.Chk30);
            this.Controls.Add(this.chk15);
            this.Controls.Add(this.chk20);
            this.Controls.Add(this.Chk10);
            this.Controls.Add(this.btnRnd);
            this.Controls.Add(this.grdExercises);
            this.Controls.Add(this.lbErr);
            this.Controls.Add(this.txtRoutine);
            this.Controls.Add(this.lbRoutine);
            this.Controls.Add(this.chkComp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbExName);
            this.Controls.Add(this.txtExTime);
            this.Controls.Add(this.txtExercise);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdExercises)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExercise;
        private System.Windows.Forms.TextBox txtExTime;
        private System.Windows.Forms.Label lbExName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkComp;
        private System.Windows.Forms.Label lbRoutine;
        private System.Windows.Forms.TextBox txtRoutine;
        private System.Windows.Forms.Label lbErr;
        private System.Windows.Forms.DataGridView grdExercises;
        private System.Windows.Forms.Button btnRnd;
        private System.Windows.Forms.CheckBox Chk10;
        private System.Windows.Forms.CheckBox chk20;
        private System.Windows.Forms.CheckBox chk15;
        private System.Windows.Forms.CheckBox Chk30;
        private System.Windows.Forms.TextBox txtRndRoutine;
        private System.Windows.Forms.Label lbRndName;
    }
}

