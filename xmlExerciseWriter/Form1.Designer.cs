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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.ChkUpper = new System.Windows.Forms.CheckBox();
            this.chkAbs = new System.Windows.Forms.CheckBox();
            this.chkLegs = new System.Windows.Forms.CheckBox();
            this.ckFullB = new System.Windows.Forms.CheckBox();
            this.chKNoBreak = new System.Windows.Forms.CheckBox();
            this.chkFBME = new System.Windows.Forms.CheckBox();
            this.chkLegsME = new System.Windows.Forms.CheckBox();
            this.chkABME = new System.Windows.Forms.CheckBox();
            this.chkUBME = new System.Windows.Forms.CheckBox();
            this.lbRoutineTime = new System.Windows.Forms.Label();
            this.txtRtneTme = new System.Windows.Forms.TextBox();
            this.chkAnchor = new System.Windows.Forms.CheckBox();
            this.txtAnchor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdExercises)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExercise
            // 
            this.txtExercise.AutoCompleteCustomSource.AddRange(new string[] {
            "Sit Up",
            "Push Up",
            "Run in Place",
            "High Knees"});
            this.txtExercise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtExercise.Location = new System.Drawing.Point(370, 182);
            this.txtExercise.Margin = new System.Windows.Forms.Padding(6);
            this.txtExercise.Name = "txtExercise";
            this.txtExercise.Size = new System.Drawing.Size(409, 47);
            this.txtExercise.TabIndex = 0;
            this.txtExercise.TextChanged += new System.EventHandler(this.txtExercise_TextChanged);
            // 
            // txtExTime
            // 
            this.txtExTime.Location = new System.Drawing.Point(370, 295);
            this.txtExTime.Margin = new System.Windows.Forms.Padding(6);
            this.txtExTime.Name = "txtExTime";
            this.txtExTime.Size = new System.Drawing.Size(409, 47);
            this.txtExTime.TabIndex = 1;
            // 
            // lbExName
            // 
            this.lbExName.AutoSize = true;
            this.lbExName.Location = new System.Drawing.Point(100, 197);
            this.lbExName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbExName.Name = "lbExName";
            this.lbExName.Size = new System.Drawing.Size(217, 41);
            this.lbExName.TabIndex = 2;
            this.lbExName.Text = "Exercise Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exercise Time:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(824, 480);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 59);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkComp
            // 
            this.chkComp.AutoSize = true;
            this.chkComp.Location = new System.Drawing.Point(824, 423);
            this.chkComp.Margin = new System.Windows.Forms.Padding(6);
            this.chkComp.Name = "chkComp";
            this.chkComp.Size = new System.Drawing.Size(299, 45);
            this.chkComp.TabIndex = 5;
            this.chkComp.Text = "Complete Exercise";
            this.chkComp.UseVisualStyleBackColor = true;
            this.chkComp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbRoutine
            // 
            this.lbRoutine.AutoSize = true;
            this.lbRoutine.Location = new System.Drawing.Point(198, 94);
            this.lbRoutine.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbRoutine.Name = "lbRoutine";
            this.lbRoutine.Size = new System.Drawing.Size(127, 41);
            this.lbRoutine.TabIndex = 6;
            this.lbRoutine.Text = "Routine:";
            // 
            // txtRoutine
            // 
            this.txtRoutine.Location = new System.Drawing.Point(370, 80);
            this.txtRoutine.Margin = new System.Windows.Forms.Padding(6);
            this.txtRoutine.Name = "txtRoutine";
            this.txtRoutine.Size = new System.Drawing.Size(409, 47);
            this.txtRoutine.TabIndex = 7;
            // 
            // lbErr
            // 
            this.lbErr.AutoSize = true;
            this.lbErr.Location = new System.Drawing.Point(300, 900);
            this.lbErr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbErr.MinimumSize = new System.Drawing.Size(425, 164);
            this.lbErr.Name = "lbErr";
            this.lbErr.Size = new System.Drawing.Size(425, 164);
            this.lbErr.TabIndex = 8;
            this.lbErr.Text = "   ";
            // 
            // grdExercises
            // 
            this.grdExercises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExercises.Location = new System.Drawing.Point(1156, 80);
            this.grdExercises.Margin = new System.Windows.Forms.Padding(6);
            this.grdExercises.Name = "grdExercises";
            this.grdExercises.RowHeadersWidth = 51;
            this.grdExercises.Size = new System.Drawing.Size(497, 797);
            this.grdExercises.TabIndex = 9;
            this.grdExercises.Text = "dataGridView1";
            // 
            // btnRnd
            // 
            this.btnRnd.Location = new System.Drawing.Point(51, 564);
            this.btnRnd.Margin = new System.Windows.Forms.Padding(6);
            this.btnRnd.Name = "btnRnd";
            this.btnRnd.Size = new System.Drawing.Size(200, 156);
            this.btnRnd.TabIndex = 10;
            this.btnRnd.Text = "Make Work Out";
            this.btnRnd.UseVisualStyleBackColor = true;
            this.btnRnd.Click += new System.EventHandler(this.btnRnd_Click);
            // 
            // Chk10
            // 
            this.Chk10.AutoSize = true;
            this.Chk10.Location = new System.Drawing.Point(336, 564);
            this.Chk10.Margin = new System.Windows.Forms.Padding(6);
            this.Chk10.Name = "Chk10";
            this.Chk10.Size = new System.Drawing.Size(203, 45);
            this.Chk10.TabIndex = 11;
            this.Chk10.Text = "10 Minutes";
            this.Chk10.UseVisualStyleBackColor = true;
            // 
            // chk20
            // 
            this.chk20.AutoSize = true;
            this.chk20.Location = new System.Drawing.Point(336, 650);
            this.chk20.Margin = new System.Windows.Forms.Padding(6);
            this.chk20.Name = "chk20";
            this.chk20.Size = new System.Drawing.Size(203, 45);
            this.chk20.TabIndex = 12;
            this.chk20.Text = "20 Minutes";
            this.chk20.UseVisualStyleBackColor = true;
            // 
            // chk15
            // 
            this.chk15.AutoSize = true;
            this.chk15.Location = new System.Drawing.Point(595, 564);
            this.chk15.Margin = new System.Windows.Forms.Padding(6);
            this.chk15.Name = "chk15";
            this.chk15.Size = new System.Drawing.Size(203, 45);
            this.chk15.TabIndex = 13;
            this.chk15.Text = "15 Minutes";
            this.chk15.UseVisualStyleBackColor = true;
            // 
            // Chk30
            // 
            this.Chk30.AutoSize = true;
            this.Chk30.Location = new System.Drawing.Point(595, 650);
            this.Chk30.Margin = new System.Windows.Forms.Padding(6);
            this.Chk30.Name = "Chk30";
            this.Chk30.Size = new System.Drawing.Size(203, 45);
            this.Chk30.TabIndex = 14;
            this.Chk30.Text = "30 Minutes";
            this.Chk30.UseVisualStyleBackColor = true;
            // 
            // txtRndRoutine
            // 
            this.txtRndRoutine.Location = new System.Drawing.Point(336, 746);
            this.txtRndRoutine.Margin = new System.Windows.Forms.Padding(6);
            this.txtRndRoutine.Name = "txtRndRoutine";
            this.txtRndRoutine.Size = new System.Drawing.Size(261, 47);
            this.txtRndRoutine.TabIndex = 15;
            // 
            // lbRndName
            // 
            this.lbRndName.AutoSize = true;
            this.lbRndName.Location = new System.Drawing.Point(57, 746);
            this.lbRndName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbRndName.Name = "lbRndName";
            this.lbRndName.Size = new System.Drawing.Size(181, 41);
            this.lbRndName.TabIndex = 16;
            this.lbRndName.Text = "Name to Be:";
            // 
            // ChkUpper
            // 
            this.ChkUpper.AutoSize = true;
            this.ChkUpper.Location = new System.Drawing.Point(870, 565);
            this.ChkUpper.Name = "ChkUpper";
            this.ChkUpper.Size = new System.Drawing.Size(215, 45);
            this.ChkUpper.TabIndex = 17;
            this.ChkUpper.Text = "Upper Body";
            this.ChkUpper.UseVisualStyleBackColor = true;
            // 
            // chkAbs
            // 
            this.chkAbs.AutoSize = true;
            this.chkAbs.Location = new System.Drawing.Point(870, 650);
            this.chkAbs.Name = "chkAbs";
            this.chkAbs.Size = new System.Drawing.Size(106, 45);
            this.chkAbs.TabIndex = 18;
            this.chkAbs.Text = "Abs";
            this.chkAbs.UseVisualStyleBackColor = true;
            // 
            // chkLegs
            // 
            this.chkLegs.AutoSize = true;
            this.chkLegs.Location = new System.Drawing.Point(870, 735);
            this.chkLegs.Name = "chkLegs";
            this.chkLegs.Size = new System.Drawing.Size(117, 45);
            this.chkLegs.TabIndex = 19;
            this.chkLegs.Text = "Legs";
            this.chkLegs.UseVisualStyleBackColor = true;
            // 
            // ckFullB
            // 
            this.ckFullB.AutoSize = true;
            this.ckFullB.Location = new System.Drawing.Point(870, 815);
            this.ckFullB.Name = "ckFullB";
            this.ckFullB.Size = new System.Drawing.Size(178, 45);
            this.ckFullB.TabIndex = 19;
            this.ckFullB.Text = "Full Body";
            this.ckFullB.UseVisualStyleBackColor = true;
            // 
            // chKNoBreak
            // 
            this.chKNoBreak.AutoSize = true;
            this.chKNoBreak.Location = new System.Drawing.Point(870, 900);
            this.chKNoBreak.Name = "chKNoBreak";
            this.chKNoBreak.Size = new System.Drawing.Size(177, 45);
            this.chKNoBreak.TabIndex = 20;
            this.chKNoBreak.Text = "No Break";
            this.chKNoBreak.UseVisualStyleBackColor = true;
            // 
            // chkFBME
            // 
            this.chkFBME.AutoSize = true;
            this.chkFBME.Location = new System.Drawing.Point(848, 349);
            this.chkFBME.Name = "chkFBME";
            this.chkFBME.Size = new System.Drawing.Size(178, 45);
            this.chkFBME.TabIndex = 23;
            this.chkFBME.Text = "Full Body";
            this.chkFBME.UseVisualStyleBackColor = true;
            // 
            // chkLegsME
            // 
            this.chkLegsME.AutoSize = true;
            this.chkLegsME.Location = new System.Drawing.Point(848, 269);
            this.chkLegsME.Name = "chkLegsME";
            this.chkLegsME.Size = new System.Drawing.Size(117, 45);
            this.chkLegsME.TabIndex = 24;
            this.chkLegsME.Text = "Legs";
            this.chkLegsME.UseVisualStyleBackColor = true;
            // 
            // chkABME
            // 
            this.chkABME.AutoSize = true;
            this.chkABME.Location = new System.Drawing.Point(848, 184);
            this.chkABME.Name = "chkABME";
            this.chkABME.Size = new System.Drawing.Size(106, 45);
            this.chkABME.TabIndex = 22;
            this.chkABME.Text = "Abs";
            this.chkABME.UseVisualStyleBackColor = true;
            // 
            // chkUBME
            // 
            this.chkUBME.AutoSize = true;
            this.chkUBME.Location = new System.Drawing.Point(848, 99);
            this.chkUBME.Name = "chkUBME";
            this.chkUBME.Size = new System.Drawing.Size(215, 45);
            this.chkUBME.TabIndex = 21;
            this.chkUBME.Text = "Upper Body";
            this.chkUBME.UseVisualStyleBackColor = true;
            // 
            // lbRoutineTime
            // 
            this.lbRoutineTime.AutoSize = true;
            this.lbRoutineTime.Location = new System.Drawing.Point(114, 406);
            this.lbRoutineTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbRoutineTime.Name = "lbRoutineTime";
            this.lbRoutineTime.Size = new System.Drawing.Size(200, 41);
            this.lbRoutineTime.TabIndex = 26;
            this.lbRoutineTime.Text = "Routine Time:";
            // 
            // txtRtneTme
            // 
            this.txtRtneTme.Location = new System.Drawing.Point(369, 391);
            this.txtRtneTme.Margin = new System.Windows.Forms.Padding(6);
            this.txtRtneTme.Name = "txtRtneTme";
            this.txtRtneTme.Size = new System.Drawing.Size(410, 47);
            this.txtRtneTme.TabIndex = 25;
            this.txtRtneTme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRtneTme_KeyDown);
            // 
            // chkAnchor
            // 
            this.chkAnchor.AutoSize = true;
            this.chkAnchor.Location = new System.Drawing.Point(866, 1075);
            this.chkAnchor.Name = "chkAnchor";
            this.chkAnchor.Size = new System.Drawing.Size(298, 45);
            this.chkAnchor.TabIndex = 27;
            this.chkAnchor.Text = "Anchored Exercise";
            this.chkAnchor.UseVisualStyleBackColor = true;
            // 
            // txtAnchor
            // 
            this.txtAnchor.Location = new System.Drawing.Point(914, 1164);
            this.txtAnchor.Name = "txtAnchor";
            this.txtAnchor.Size = new System.Drawing.Size(250, 47);
            this.txtAnchor.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1770, 1415);
            this.Controls.Add(this.txtAnchor);
            this.Controls.Add(this.chkAnchor);
            this.Controls.Add(this.lbRoutineTime);
            this.Controls.Add(this.txtRtneTme);
            this.Controls.Add(this.chkFBME);
            this.Controls.Add(this.chkLegsME);
            this.Controls.Add(this.chkABME);
            this.Controls.Add(this.chkUBME);
            this.Controls.Add(this.chKNoBreak);
            this.Controls.Add(this.ckFullB);
            this.Controls.Add(this.chkLegs);
            this.Controls.Add(this.chkAbs);
            this.Controls.Add(this.ChkUpper);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private System.Windows.Forms.CheckBox ChkUpper;
        private System.Windows.Forms.CheckBox chkAbs;
        private System.Windows.Forms.CheckBox chkLegs;
        private System.Windows.Forms.CheckBox ckFullB;
        private System.Windows.Forms.CheckBox chKNoBreak;
        private System.Windows.Forms.CheckBox chkFBME;
        private System.Windows.Forms.CheckBox chkLegsME;
        private System.Windows.Forms.CheckBox chkABME;
        private System.Windows.Forms.CheckBox chkUBME;
        private System.Windows.Forms.Label lbRoutineTime;
        private System.Windows.Forms.TextBox txtRtneTme;
        private System.Windows.Forms.CheckBox chkAnchor;
        private System.Windows.Forms.TextBox txtAnchor;
    }
}

