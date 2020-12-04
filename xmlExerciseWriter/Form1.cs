using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using ExerciseMethodShare;

namespace xmlExerciseWriter
{
    public partial class Form1 : Form
    {
        List<ExerciseMethodShare.WorkOut> wo = new List<ExerciseMethodShare.WorkOut>();
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

                string fileloc = @"C:\Users\marcu\Documents\Code\ExerciseXML\ReviewLoc\" + txtRoutine.Text + ".xml";

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
                        ExerciseMethodShare.WorkOut w = new ExerciseMethodShare.WorkOut();
                        w.Name = txtExercise.Text;
                        w.Id = counter++;
                        w.Time = time;

                        wo.Add(w);

                        txtExercise.Text = "";
                        txtExTime.Text = "";
                        grdExercises.Rows.Clear();
                        //grdExercises.Columns.Clear();
                        
                        foreach (ExerciseMethodShare.WorkOut wk in wo)
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

            lbErr.Text = "";

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

            foreach (ExerciseMethodShare.WorkOut w in wo)
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
            int chkCountEx = 0;
            int timetoRun = 0;
            string[] exChosen = new string[1];
            

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

            if (chkLegs.Checked == true)
            {
                chkCountEx++;
                exChosen = new string[1]{  "Legs"};
            }

            if (ChkUpper.Checked == true)
            {
                chkCountEx++;
                exChosen = new string[1]  { "Upper Body"};
            }

            if (chkAbs.Checked == true)
            {
                chkCountEx++;
                exChosen = new string[1] { "Abs" };
            }

            if (ckFullB.Checked)
            {
                chkCountEx++;
                exChosen = new string[1] { "Full Body" };
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

            if(chkCountEx < 1 )
            {
                lbErr.Text = lbErr.Text = "You need to Check an Exercise Type";
                return;
            }

            if (chkCountEx > 1)
            {
                lbErr.Text = lbErr.Text = "You need to Check only one Exercise Type";
                return;
            }

            List<int> intervals = new List<int>();

            List<string> exercises = ExercisePatterns.exerciseStringList();


            List<int> breakInterval = new List<int>();
            if (exChosen[0] == "Full Body")
            {
                fnSetTimeforFullBody(ref breakInterval, timetoRun);
            }
            else
            {
                fnSetBreak(ref breakInterval, timetoRun);
            }

            fnCreateRoutine(timetoRun, breakInterval, ref wo, exChosen[0]);

        }

        private void fnSetTimeforFullBody(ref List<int> breakInterval, int timetoRun)
        {
            int controlledRuntime = 0;
            int loopTime = 0;
            if (timetoRun == 30)
            {
                controlledRuntime = (timetoRun * 60) - 20 ;
                
                while (loopTime < controlledRuntime )
                {
                    loopTime = loopTime + 40;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 20;

                }
            }
            else if (timetoRun == 20)
            {
                controlledRuntime = (timetoRun * 60) - 20;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 40;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 20;

                }
            }
            else if (timetoRun == 15)
            {
                controlledRuntime = (timetoRun * 60) - 20;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 40;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 20;

                }
            }
            else if (timetoRun == 10)
            {
                controlledRuntime = (timetoRun * 60) - 20;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 40;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 20;

                }

            }
        }

        List<string> currExs = new List<string>();
        private void fnCreateRoutine(int timetoRun,  List<int> bi, ref List<ExerciseMethodShare.WorkOut> wo, string exType)
        {
            //int listCount = 0;
            int compiledTime = 0;
            bool breakfound = false;

            ExerciseMethodShare.ResultBase[] rbArr = ExercisePatterns.CreateResBaseList();

            List<ExerciseMethodShare.ResultBase> rb = rbArr.ToList();

            //rb = (from r in rb where r.Exercise_Type == exType select r).ToList();

            List<string> exNames = new List<string>();
            List<string> exercises = new List<string>();

            exercises = (from rs in rb select rs.Exercise_Name).Distinct().ToList();

            exNames = (from rEx in rb select rEx.Searched_exercise).Distinct().ToList();
            // divide exercises up

            // get a list of Exercises that match Chosen Exercise Type

            // get list of exercise routines to pick off exercises
            string ExLoc = Properties.Resources.XMLLibrary.ToString();
            ExLoc = ExLoc + @"\" ;
            List<WorkOut> workOutsMain = new List<WorkOut>();

            foreach(string s in exNames)
            {
                List<WorkOut> wOUT = new List<WorkOut>();

                WorkOut[] wOutArr = ExercisePatterns.readExercise(s);
                List<string> exercisess = new List<string>();
                exercisess = (from r in wOutArr select r.Name).ToList();

                List<string> types = new List<string>();

                types = (from m in rb where m.Searched_exercise == s select m.Exercise_Type).Distinct().ToList(); 

                

                foreach(WorkOut wCheck in wOutArr )
                {
                    if (types.Count == 1  && types[0] ==  exType && exType != "Full Body")
                    {
                        string wNm = wCheck.Name;
                        int wCnt = 0;
                        wCnt = (from r in rb where r.Exercise_Name == wNm && r.Exercise_Type == exType select r).Count();
                        if (wNm == "Rest" || wNm == "rest" || wNm == "Complete" || wNm == "complete" || wNm == "Break" ||wNm == "cobra" || wNm == "Cobra" || wNm == "cobra" || wNm == "child pose" || wNm == "Child Pose")
                        {

                        }
                        else if (wNm.Contains("stretch"))
                        {

                        }
                        else if (wCnt < 1)
                        {
                            wCheck.Id = 0;
                            workOutsMain.Add(wCheck);
                        }
                        else if (wCnt > 1)
                        {
                            currExs.Add(wCheck.Name);
                        }
                    }
                    else if (exType == "Full Body"  && types.Count >= 2)
                    {
                        string wNm = wCheck.Name;
                        int wCnt = 0;
                        wCnt = (from r in rb 
                                
                                where r.Exercise_Name == wNm && types.Contains(r.Exercise_Type ) select r).Count();
                        if (wNm == "Rest" || wNm == "rest" || wNm == "Complete" || wNm == "complete")
                        {

                        }
                        else if (wNm.Contains("stretch"))
                        {

                        }
                        else if (wCnt < 1)
                        {
                            wCheck.Id = 0;
                            workOutsMain.Add(wCheck);
                        }
                        else if (wCnt > 1)
                        {
                            currExs.Add(wCheck.Name);
                        }

                    }

                }
                workOutsMain.AddRange(wOUT);      
            }
            
            List<string> aiEx = new List<string>();
            aiEx = (from a in workOutsMain select a.Name).Distinct().ToList();
            
            currExs = currExs.Distinct().ToList();

            if (timetoRun == 30)
            {
                int r = timetoRun * 2;
                int totalTime = r;
                bool newOld = true;
                
                while (r > 0)
                {
                    ExerciseMethodShare.WorkOut w = new ExerciseMethodShare.WorkOut();
                    if (r % 2 == 0 && r != 0)
                    {
                        newOld = true;
                    }
                    else
                    {
                        newOld = false;
                    }

                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = totalTime - r;
                            if (exType == "Full Body")
                            {
                                w.Time = 20;
                            }
                            else
                            {
                                w.Time = 30;
                            }
                        }
                    }

                    bool directionFound = false;
                    string directionName = "";
                    ExerciseMethodShare.WorkOut w2 = new ExerciseMethodShare.WorkOut();


                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(currExs, aiEx, newOld);
                        if (w.Name.Contains(" Right") || w.Name.Contains("Left") || w.Name.Contains(" right") || w.Name.Contains("left"))
                        {
                            directionFound = true;
                            if (w.Name.Contains(" Right") || w.Name.Contains(" right"))
                            {
                                directionName = "Left".ToUpper();
                            }
                            else
                            {
                                directionName = "Right".ToUpper();
                            }
                            w2.Name = fnGetRIGHTLEFT(w.Name, directionName, currExs);
                            w2.Id = (totalTime - r) - 1;
                            w2.Time = 40;
                        }
                        w.Id = totalTime - r;
                        if (exType == "Full Body")
                        {
                            w.Time = 40;
                        }
                        else
                        {
                            w.Time = 30;
                        }
                        
                    }
                    if (exType == "Full Body")
                    {
                        if (breakfound)
                        {
                            compiledTime = compiledTime + 20;
                        }
                        else
                        {
                            compiledTime = compiledTime + 40;
                        }
                    }
                    else
                    {
                        compiledTime = compiledTime + 30;
                    }


                    breakfound = false;
                    

                    if (directionFound)
                    {
                        wo.Add(w);
                        wo.Add(w2);
                        r = r - 2;
                    }
                    else
                    {
                        wo.Add(w);
                        r--;
                    }
                }
            
            }
            else if(timetoRun == 20)
            {
                int r = timetoRun * 2;
                int totalTime = r;
                bool newOld = true;
                
                while (r > 0)
                {
                    ExerciseMethodShare.WorkOut w = new ExerciseMethodShare.WorkOut();
                    if (r % 2 == 0 && r != 0)
                    {
                        newOld = true;
                    }
                    else
                    {
                        newOld = false;
                    }
                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = totalTime - r;
                            if (exType == "Full Body")
                            {
                                w.Time = 20;
                            }
                            else
                            {
                                w.Time = 30;
                            }
                        }
                    }

                    bool directionFound = false;
                    string directionName = "";
                    ExerciseMethodShare.WorkOut w2 = new ExerciseMethodShare.WorkOut();

                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(currExs, aiEx, newOld);
                        if (w.Name.Contains(" Right") || w.Name.Contains("Left") || w.Name.Contains(" right") || w.Name.Contains("left"))
                        {
                            directionFound = true;
                            if (w.Name.Contains(" Right") || w.Name.Contains(" right"))
                            {
                                directionName = "Left".ToUpper();
                            }
                            else
                            {
                                directionName = "Right".ToUpper();
                            }
                            w2.Name = fnGetRIGHTLEFT(w.Name, directionName, currExs);
                            w2.Id = (totalTime - r) + 1;
                            w2.Time = 40;
                            if (exType == "Full Body")
                            {
                                w2.Time = 40;
                            }
                            else
                            {
                                w2.Time = 30;
                            }
                        }
                        w.Id = totalTime - r;
                        if (exType == "Full Body")
                        {
                            w.Time = 40;
                        }
                        else
                        {
                            w.Time = 30;
                        }
                    }

                    if (exType == "Full Body")
                    {
                        if (breakfound)
                        {
                            compiledTime = compiledTime + 20;
                        }
                        else
                        {
                            compiledTime = compiledTime + 40;
                        }
                    }
                    else
                    {
                        compiledTime = compiledTime + 30;
                    }

                    breakfound = false;
                    

                    if (directionFound)
                    {
                        wo.Add(w);
                        wo.Add(w2);
                        r = r - 2;
                    }
                    else
                    {
                        wo.Add(w);
                        r--;
                    }
                }

            }
            else if (timetoRun == 15)
            {
                int r = timetoRun * 2;
                int totalTime = r;
                bool newOld = true;
                
                while (r > 0)
                {
                    ExerciseMethodShare.WorkOut w = new ExerciseMethodShare.WorkOut();
                    if (r % 2 == 0 && r != 0)
                    {
                        newOld = true;
                    }
                    else
                    {
                        newOld = false;
                    }
                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {

                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = totalTime - r;
                            if (exType == "Full Body")
                            {
                                w.Time = 20;
                            }
                            else
                            {
                                w.Time = 30;
                            }
                        }
                    }

                    bool directionFound = false;
                    string directionName = "";
                    ExerciseMethodShare.WorkOut w2 = new ExerciseMethodShare.WorkOut();

                    if (breakfound == false)
                    {
                        w.Name = fnSetWorkout(currExs, aiEx, newOld);
                        if (w.Name.Contains(" Right") || w.Name.Contains("Left") || w.Name.Contains(" right") || w.Name.Contains("left"))
                        {
                            directionFound = true;
                            if (w.Name.Contains(" Right") || w.Name.Contains(" right"))
                            {
                                directionName = "Left".ToUpper();
                            }
                            else
                            {
                                directionName = "Right".ToUpper();
                            }
                            w2.Name = fnGetRIGHTLEFT(w.Name, directionName, currExs);
                            w2.Id = (totalTime - r) + 1;
                            w2.Time = 40;

                            if (exType == "Full Body")
                            {
                                w2.Time = 40;
                            }
                            else
                            {
                                w2.Time = 30;
                            }
                        }
                        w.Id = totalTime - r;
                        if (exType == "Full Body")
                        {
                            w.Time = 40;
                        }
                        else
                        {
                            w.Time = 30;
                        }

                    }

                    if (exType == "Full Body")
                    {
                        if (breakfound)
                        {
                            compiledTime = compiledTime + 20;
                        }
                        else
                        {
                            compiledTime = compiledTime + 40;
                        }
                    }
                    else
                    {
                        compiledTime = compiledTime + 30;
                    }

                    breakfound = false;

                    if (directionFound)
                    {
                        wo.Add(w);
                        wo.Add(w2);
                        r = r - 2;
                    }
                    else
                    {
                        wo.Add(w);
                        r--;
                    }
                }
            }
            else if (timetoRun == 10)
            {
                int r = timetoRun * 2;
                int totalTime = r;
                bool newOld = true;

                while (r > 0)
                {
                    ExerciseMethodShare.WorkOut w = new ExerciseMethodShare.WorkOut();
                    if (r % 2 == 0 && r != 0)
                    {
                        newOld = true;
                    }
                    else
                    {
                        newOld = false;
                    }

                    foreach (int t in bi)
                    {
                        if (t == compiledTime)
                        {
                            breakfound = true;
                            w.Name = "Rest";
                            w.Id = totalTime - r;
                            if (exType == "Full Body")
                            {
                                w.Time = 20;
                                //compiledTime = compiledTime + 20;
                            }
                            else
                            {
                                w.Time = 30;
                            }
                        }
                    }
                    bool directionFound = false;
                    string directionName = "";
                    ExerciseMethodShare.WorkOut w2 = new ExerciseMethodShare.WorkOut();
                    if (breakfound == false)
                    {

                        w.Name = fnSetWorkout(currExs, aiEx, newOld);
                        if (w.Name.Contains(" Right") || w.Name.Contains("Left") || w.Name.Contains(" right") || w.Name.Contains("left"))
                        {
                            directionFound = true;
                            if (w.Name.Contains(" Right") || w.Name.Contains(" right"))
                            {
                                directionName = "Left".ToUpper();
                            }
                            else
                            {
                                directionName = "Right".ToUpper();
                            }
                            w2.Name = fnGetRIGHTLEFT(w.Name, directionName, currExs);
                            w2.Id = (totalTime - r) - 1;
                            w2.Time = 40;
                            if (exType == "Full Body")
                            {
                                w2.Time = 40;
                            }
                            else
                            {
                                w2.Time = 30;
                            }

                        }
                        w.Id = totalTime - r;
                        if (exType == "Full Body")
                        {
                            w.Time = 40;
                        }
                        else
                        {
                            w.Time = 30;
                        }
                    }
                    
                    if (exType == "Full Body")
                    {
                        if (breakfound)
                        {
                            compiledTime = compiledTime + 20;
                        }
                        else
                        {
                            compiledTime = compiledTime + 40;
                        }
                    }
                    else
                    {
                        compiledTime = compiledTime + 30;
                    }

                    breakfound = false;
                     if (directionFound)
                    {
                        wo.Add(w);
                        wo.Add(w2);
                        r = r-2;
                    }
                    else
                    {
                        wo.Add(w);
                        r--;
                    }
                    
                }

            }

            string fileloc = @"C:\Users\marcu\Documents\Code\ExerciseXML\" + txtRndRoutine.Text + ".xml";
            int f = wo.Count;
            fnwriteXML(fileloc);

        }

        private string fnGetRIGHTLEFT(string name, string directionName, List <string> exs)
        {
            string directionToLookFor = "";
            string stringPart = "";
            int  at = 0;
            string resPortion = "";
            string returnResult = "";

            if (directionName == "RIGHT" )
            {
                directionToLookFor = "LEFT";
                name = name.ToUpper();
                at = name.IndexOf(directionToLookFor);
                resPortion = name.Substring(0, at).ToUpper();
                returnResult = (from r in exs where r.ToUpper().Contains(resPortion) && r.ToUpper().Contains(directionName) select r).FirstOrDefault();
                if (string.IsNullOrEmpty(returnResult))
                {
                    returnResult = resPortion + directionName;

                }
            }
            else if(directionName == "LEFT")
            {
                directionToLookFor = "RIGHT";
                name = name.ToUpper();
                at = name.IndexOf(directionToLookFor);
                resPortion = name.Substring(0, at).ToUpper();
                returnResult = (from r in exs where r.ToUpper().Contains(resPortion) && r.ToUpper().Contains(directionName) select r).FirstOrDefault();

                if (string.IsNullOrEmpty(returnResult))
                {
                    returnResult = resPortion + directionName;
                        
                }
            }

            return returnResult;
        }

        private string fnSetWorkout(List<string> exercisesKnown, List<string> exercisesUnknown , bool k)
        {
            Random r = new Random();
            //workout res = new workout();
            int counter = 0;
            string resName = "";
            if (k)
            {
                counter = r.Next(0, exercisesKnown.Count);
                resName = exercisesKnown[counter];
            }
            else
            {
                counter = r.Next(0, exercisesUnknown.Count);
                 resName = exercisesUnknown[counter];
            }
            
            if (resName == "Rest"  || resName.Contains("Stretch"))
            {
                resName = fnSetWorkout(exercisesKnown, exercisesUnknown, true);
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
