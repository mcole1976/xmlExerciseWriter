using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace xmlExerciseWriter
{
    public partial class Form1 : Form
    {
        List<workout> wo = new List<workout>();
        int counter = 0;
        string xml = "";
        public Form1()
        {
            InitializeComponent();
            grdExercises.Columns.Add("WorkOut", "WorkOut");
            grdExercises.Columns.Add("Time", "Time");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool err = true;
            if (chkComp.Checked)
            {
                if (String.IsNullOrEmpty(txtExercise.Text))
                {
                    lbErr.Text = lbErr.Text + "You have not entered an exercise Name";
                    err = false;
                }

                string fileloc = @"C:\Users\marcu\Documents\Code\ExerciseXML\" + txtRoutine.Text + ".xml";

                fnwriteXML(fileloc);


            }
            else
            {
                
                int time = 0;
                if(String.IsNullOrEmpty(txtExercise.Text))
                {
                    lbErr.Text = lbErr.Text + "You have not entered an exercise Name";
                    err = false;
                }

                if(String.IsNullOrEmpty(txtExTime.Text))
                {

                    lbErr.Text = lbErr.Text + "You have not entered an exercise Time";
                    err = false;
                    return;
                }
                else
                {
                    if (err == false)
                    {
                        bool conv = Int32.TryParse(txtExTime.Text, out time);

                        if(!conv)
                        {
                            lbErr.Text = lbErr.Text + "You have not entered a numeric value for exercise Time";
                            err = false;
                            return;
                        }
                        
                    }
                    else
                    {
                        err = Int32.TryParse(txtExTime.Text, out time);
                       
                    }
                }

                if (err)
                {
                    if (time > 0 && time < 121)
                    {
                        workout w = new workout();
                        w.Name = txtExercise.Text;
                        w.Id = counter++;
                        w.Time = time;

                        wo.Add(w);

                        txtExercise.Text = "";
                        txtExTime.Text = "";
                        grdExercises.Rows.Clear();
                        //grdExercises.Columns.Clear();
                        
                        foreach (workout wk in wo)
                        {
                            grdExercises.Rows.Add(wk.Name, wk.Time);
                        }
                        txtExercise.Focus();
                    }
                    else
                    {
                        lbErr.Text = lbErr.Text + " Please Enter a time unter 120 seconds";
                    }
                }
            }
        }

        private void fnwriteXML(string fileloc)
        {
            string rootBgn = "<routine>";
            string rootEnd = "</routine>";
            string exBgn = "<exercise>";
            string exEnd = "</exercise>";
            string orderBgn = "<order>";
            string orderEnd = "</order>";
            string nameBgn = "<name>";
            string nameEnd = "</name>";
            string timeBgn = "<time>";
            string timeEnd = "</time>";

            using (StreamWriter sw = File.CreateText(fileloc))
            {
                sw.WriteLine(rootBgn);

            }

            foreach (workout w in wo)
            {
                using (StreamWriter sw = File.AppendText(fileloc))
                {
                    sw.WriteLine(exBgn);
                    sw.WriteLine(orderBgn + w.Id.ToString() + orderEnd);
                    sw.WriteLine(nameBgn + w.Name + nameEnd);
                    sw.WriteLine(timeBgn + w.Time.ToString() + timeEnd);
                    sw.WriteLine(exEnd);
                }
            }
            wo.Clear();
            counter = 0;
            lbErr.Text = txtRoutine.Text + " Completed and Made";
            txtRoutine.Text = "";
            using (StreamWriter sw = File.AppendText(fileloc))
            {
                sw.WriteLine(rootEnd);

            }
        }

        private void btnRnd_Click(object sender, EventArgs e)
        {
            bool TenOn, FifteenOn, TwentyOn, ThirtyOn;
            int checkCount = 0;
            int timetoRun = 0;

            if(String.IsNullOrEmpty(txtRndRoutine.Text))
            {
                lbErr.Text = lbErr.Text = "Please Enter Your Routines Name";
                return;
            }
            if ( Chk10.Checked == true)
            {
                TenOn = true;
                timetoRun = 10;
                checkCount++;
            }

            if (chk15.Checked == true)
            {
                FifteenOn = true;
                timetoRun = 15;
                checkCount++;
            }

            if (chk20.Checked == true)
            {
                TwentyOn = true;
                timetoRun = 20;
                checkCount++;
            }

            if (Chk30.Checked == true)
            {
                ThirtyOn = true;
                timetoRun = 30;
                checkCount++;
            }

            if (checkCount < 1)
            {
                lbErr.Text = lbErr.Text = "You need to Check a time frame";
                return;
            }
            else if(checkCount >1)
            {
                lbErr.Text = lbErr.Text = "You need to Check only one time frame";
                return;
            }

            List<int> intervals = new List<int>();

            if (timetoRun >= 30)
            {
                intervals.Add(30);
                intervals.Add(45);
                intervals.Add(60);
                intervals.Add(90);
                intervals.Add(120);
            }
            else
            {
                intervals.Add(10);
                intervals.Add(15);
                intervals.Add(20);
                intervals.Add(30);
                intervals.Add(45);
                intervals.Add(60);

            }

            List<string> exercises = new List<string>();

            DirectoryInfo d = new DirectoryInfo(@"C:\Users\marcu\Pictures\exercises\");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.jpg"); //Getting Text files
            string str = "";


            foreach (FileInfo file in Files)
            {
                str = (file.Name);
                int fileExtPos = str.LastIndexOf(".");

                if (fileExtPos >= 0)
                    str = str.Substring(0, fileExtPos);

                exercises.Add(str);
            }

            int x = 45;

            List<int> breakInterval = new List<int>();
            fnSetBreak(ref breakInterval, timetoRun );
            
            fnCreateRoutine(timetoRun, exercises, breakInterval, ref wo);

        }

        private void fnCreateRoutine(int timetoRun, List<string> exercises, List<int> bi, ref List<workout> wo)
        {
            //int listCount = 0;
            int compiledTime = 0;
            bool breakfound = false;
            if (timetoRun == 30)
            {
                int r = timetoRun * 2;
                workout w = new workout();
                while (r > 0)
                {
                    
                    foreach(int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = r;
                            w.Time = 30;
                        }
                    }
                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(exercises);
                        w.Id = r;
                        w.Time = 30;
                    }
                    breakfound = false;
                    wo.Add(w);
                    compiledTime = compiledTime + 30;
                    r--;
                }
            
            }
            else if(timetoRun == 20)
            {
                int r = timetoRun * 2;
                workout w = new workout();
                while (r > 0)
                {

                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = r;
                            w.Time = 30;
                        }
                    }
                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(exercises);
                        w.Id = r;
                        w.Time = 30;
                    }
                    breakfound = false;
                    wo.Add(w);
                    compiledTime = compiledTime + 30;
                    r--;
                }

            }
            else if (timetoRun == 15)
            {
                int r = timetoRun * 2;
                workout w = new workout();
                while (r > 0)
                {

                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = r;
                            w.Time = 30;
                        }
                    }
                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(exercises);
                        w.Id = r;
                        w.Time = 30;
                    }
                    breakfound = false;
                    wo.Add(w);
                    compiledTime = compiledTime + 30;
                    r--;
                }
            }
            else if (timetoRun == 10)
            {
                int r = timetoRun * 2;
                workout w = new workout();
                while (r > 0)
                {

                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = r;
                            w.Time = 30;
                        }
                    }
                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(exercises);
                        w.Id = r;
                        w.Time = 30;
                    }
                    breakfound = false;
                    wo.Add(w);
                    compiledTime = compiledTime + 30;
                    r--;
                }

            }

            string fileloc = @"C:\Users\marcu\Documents\Code\ExerciseXML\" + txtRndRoutine.Text + ".xml";

            fnwriteXML(fileloc);

        }

        private string fnSetWorkout(List<string> exercises)
        {
            Random r = new Random();
            //workout res = new workout();
            int counter = 0;
            counter = r.Next(0, exercises.Count);
            string resName = exercises[counter];
            if (resName == "Rest")
            {
                resName = fnSetWorkout(exercises);
            }

            return resName;
        }

        private void fnSetBreak(ref List<int> breakInterval, int TotalTime)
        {
            if (TotalTime == 30)
            {
                breakInterval.Add(450);
                breakInterval.Add(900);
                breakInterval.Add(1350);
            }else if (TotalTime == 20)
            {
                breakInterval.Add(420);
                breakInterval.Add(810);
            }
            else if (TotalTime == 15)
            {
                breakInterval.Add(300);
                breakInterval.Add(600);
            }
            else  if (TotalTime == 10)
            {
                breakInterval.Add(300);
                
            }
        }
    }
}
