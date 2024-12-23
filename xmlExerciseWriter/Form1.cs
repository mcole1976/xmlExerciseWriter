﻿using ExerciseMethodShareDtNt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace xmlExerciseWriter
{
    public partial class Form1 : Form
    {
        private List<ExerciseMethodShareDtNt.WorkOut> wo = new List<ExerciseMethodShareDtNt.WorkOut>();
        private int counter = 0;
        private string xml = "";

        public Form1()
        {
            InitializeComponent();
            var source = new AutoCompleteStringCollection();
            List<string> s = CreateExercises.ExerciseDataFeed.MakeContainsList();
            string[] sa = s.ToArray();
            source.AddRange(sa);

            txtExercise.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtExercise.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtExercise.AutoCompleteCustomSource = source;


            txtAnchor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAnchor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtAnchor.AutoCompleteCustomSource = source;

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
                Dictionary<int, string> type = CreateExercises.ExerciseDataFeed.Exercise_Types_List();
                int EXType_ID = 0;
                string Exname = "";
                int exTime = 0;
                if (String.IsNullOrEmpty(txtRoutine.Text))
                {
                    lbErr.Text = lbErr.Text + "You have not entered an exercise Name";
                    err = false;
                    return;
                }
                if (String.IsNullOrEmpty(txtRoutine.Text))
                {
                    lbErr.Text = lbErr.Text + "You have not entered an numeric value for routine time";
                    err = false;
                    return;
                }

                Exname = txtRoutine.Text;
                bool exTtf = int.TryParse(txtRtneTme.Text, out exTime);

                if (chkABME.Checked)
                {
                    EXType_ID = (from t in type where t.Value == chkABME.Text select t.Key).FirstOrDefault();
                }
                else if (chkFBME.Checked)
                {
                    EXType_ID = (from t in type where t.Value == chkFBME.Text select t.Key).FirstOrDefault();
                }
                else if (chkLegsME.Checked)
                {
                    EXType_ID = (from t in type where t.Value == chkLegsME.Text select t.Key).FirstOrDefault();
                }
                else if (chkUBME.Checked)
                {
                    EXType_ID = (from t in type where t.Value == chkUBME.Text select t.Key).FirstOrDefault();
                }

                //string fileloc = @"C:\Users\marcu\Documents\Code\ExerciseXML\ReviewLoc\" + txtRoutine.Text + ".xml";

                if (EXType_ID == 0)
                {
                    lbErr.Text = lbErr.Text + "You have not Chosen an exercise Type";
                    err = false;
                    return;
                }

                fnwriteXML(EXType_ID, Exname, exTime, true);
                fnClearUpper();

            }
            else
            {
                int time = 0;
                if (String.IsNullOrEmpty(txtExercise.Text))
                {
                    lbErr.Text = lbErr.Text + "You have not entered an exercise Name";
                    err = false;
                }

                if (String.IsNullOrEmpty(txtExTime.Text))
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

                        if (!conv)
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
                        ExerciseMethodShareDtNt.WorkOut w = new ExerciseMethodShareDtNt.WorkOut();
                        w.Name = txtExercise.Text;
                        w.Id = counter++;
                        w.Time = time;

                        wo.Add(w);

                        txtExercise.Text = "";
                        txtExTime.Text = "";
                        grdExercises.Rows.Clear();
                        //grdExercises.Columns.Clear();

                        foreach (ExerciseMethodShareDtNt.WorkOut wk in wo)
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

        private void fnClearUpper()
        {
            chkComp.Checked = false;
            txtRtneTme.Text = "";
            txtRoutine.Text = "";
            chkComp.Checked = false;
            chkUBME.Checked = false;
            chkLegsME.Checked = false;
            chkFBME.Checked = false;
            chkABME.Checked = false;
            txtRoutine.Focus();

        }

        private void fnwriteXML(int ExType_ID, string name, int ExTme, bool noH)
        {
            lbErr.Text = "";

            CreateExercises.ExerciseDataFeed.Make_Exercise_Regiment(ExType_ID, name, ExTme);

            foreach (ExerciseMethodShareDtNt.WorkOut w in wo)
            {
                CreateExercises.ExerciseDataFeed.Make_Regiment_Record(0, w);
                if (noH)
                {
                    CreateExercises.ExerciseDataFeed.Make_Result_Base(w, ExType_ID, name);
                }
            }
            wo.Clear();
            counter = 0;
            lbErr.Text = txtRoutine.Text + " Completed and Made " + name;
            txtRoutine.Text = "";
        }

        private void btnRnd_Click(object sender, EventArgs e)
        {
            bool TenOn, FifteenOn, TwentyOn, ThirtyOn;
            int checkCount = 0;
            int chkCountEx = 0;
            int timetoRun = 0;
            KeyValuePair<int, string> exChosen = new KeyValuePair<int, string>();

            Dictionary<int, string> typeEx = CreateExercises.ExerciseDataFeed.Exercise_Types_List();

            //Validation Code for entered Text time and exercise type
            if (String.IsNullOrEmpty(txtRndRoutine.Text))
            {

                if (chkAnchor.Checked)
                {
                    if(string.IsNullOrWhiteSpace(txtAnchor.Text))
                    {
                        lbErr.Text = lbErr.Text = "Please Enter Your Anchor Exercise Name";
                        return;
                    }
                }
                else
                {
                    lbErr.Text = lbErr.Text = "Please Enter Your Routines Name";
                    return;
                }
            }
            if (Chk10.Checked == true)
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
                exChosen = (from et in typeEx where chkLegs.Text == et.Value select et).FirstOrDefault();
            }

            if (ChkUpper.Checked == true)
            {
                chkCountEx++;
                exChosen = (from et in typeEx where ChkUpper.Text == et.Value select et).FirstOrDefault();
            }

            if (chkAbs.Checked == true)
            {
                chkCountEx++;
                exChosen = (from et in typeEx where chkAbs.Text == et.Value select et).FirstOrDefault();
            }

            if (ckFullB.Checked)
            {
                chkCountEx++;
                exChosen = (from et in typeEx where ckFullB.Text == et.Value select et).FirstOrDefault();
            }

            if (chKNoBreak.Checked)
            {
                chkCountEx++;
                exChosen = (from et in typeEx where et.Value == "Full Body" select et).FirstOrDefault();
            }

            if (checkCount < 1)
            {
                lbErr.Text = lbErr.Text = "You need to Check a time frame";
                return;
            }
            else if (checkCount > 1)
            {
                lbErr.Text = lbErr.Text = "You need to Check only one time frame";
                return;
            }

            if (chkCountEx < 1)
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

            //no break and Full Body are the same exercise patterns but have different break structures

            List<int> breakInterval = new List<int>();
            if (exChosen.Value == "Full Body")
            {
                if (!chKNoBreak.Checked)
                {
                    fnSetTimeforFullBody(ref breakInterval, timetoRun);
                }
            }
            else
            {
                fnSetBreak(ref breakInterval, timetoRun);
            }
            // creatine the exercise routine
            fnCreateRoutine(timetoRun, breakInterval, ref wo, exChosen, false);
            fnClearLower();
        }

        private void fnClearLower()
        {
            txtAnchor.Text = "";
            txtRndRoutine.Text = "";
            chkAbs.Checked = false;
            chkLegs.Checked = false;
            chkAnchor.Checked = false;
            chKNoBreak.Checked = false;
            ckFullB.Checked = false;
            Chk10.Checked = false;
            chk15.Checked = false;
            chk20.Checked = false;
            Chk30.Checked = false;
            txtRndRoutine.Focus();

        }

        private void fnSetTimeforFullBody(ref List<int> breakInterval, int timetoRun)
        {
            int controlledRuntime = 0;
            int loopTime = 0;
            if (timetoRun == 30)
            {
                controlledRuntime = (timetoRun * 60) - 12;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 48;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 12;
                }
            }
            else if (timetoRun == 20)
            {
                controlledRuntime = (timetoRun * 60) - 12;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 48;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 12;
                }
            }
            else if (timetoRun == 15)
            {
                controlledRuntime = (timetoRun * 60) - 12;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 48;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 12;
                }
            }
            else if (timetoRun == 10)
            {
                controlledRuntime = (timetoRun * 60) - 12;

                while (loopTime < controlledRuntime)
                {
                    loopTime = loopTime + 48;
                    breakInterval.Add(loopTime);
                    loopTime = loopTime + 12;
                }
            }
        }

        private void fnCreateRoutine(int timetoRun, List<int> bi, ref List<ExerciseMethodShareDtNt.WorkOut> wo, KeyValuePair<int, string> exType, bool nohistory)
        {
            List<string> currExs = new List<string>();
            List<string> aiEx = new List<string>();
            //int listCount = 0;
            //int compiledTime = 0;
            //bool breakfound = false;

            

            // choose all available exercise
            List<ExerciseMethodShareDtNt.ResultBase> rb = CreateExercises.ExerciseDataFeed.ResultList();

            rb = (from r in rb where r.Exercise_Type == exType.Value select r).ToList();

            Dictionary<int, string> exNamesA = CreateExercises.ExerciseDataFeed.Routine_List(exType.Key);
            List<string> exercises = new List<string>();
            exercises = (from rs in rb select rs.Exercise_Name).Distinct().ToList();

            List<string> exNames = new List<string>();

            exNames = (from rEx in rb select rEx.Searched_exercise).Distinct().ToList();

            // divide exercises up

            // get a list of Exercises that match Chosen Exercise Type

            // get list of exercise routines to pick off exercises
            //string ExLoc = Properties.Resources.XMLLibrary.ToString();
            //ExLoc = ExLoc + @"\" ;
            List<WorkOut> workOutsMain = new List<WorkOut>();
            List<WorkOut> workOutsB = new List<WorkOut>();
            // loop over each exercise routine

            foreach (KeyValuePair<int, string> s in exNamesA)
            {
                List<WorkOut> wOUT = new List<WorkOut>();
                counter++;
                wOUT = CreateExercises.ExerciseDataFeed.WorkOut_Regiment(s.Key);
                //List<string> exercisess = new List<string>();
                //exercisess = (from r in wOutArr select r.Name).ToList();

                List<string> ExTypes = new List<string>();

                //ExTypes = (from m in rb where m.Searched_exercise == s.Value select m.Exercise_Type).Distinct().ToList();

                // breakdown each routine
                foreach (WorkOut wCheck in wOUT)
                {
                    string wNm = wCheck.Name;
                    int wCnt = 0;
                    wCnt = (from r in rb where r.Exercise_Name == wNm && r.Exercise_Type == exType.Value select r).Count();
                    if (wNm == "Rest" || wNm == "rest" || wNm == "Complete" || wNm == "complete" || wNm == "Break" || wNm == "cobra" || wNm == "Cobra" || wNm == "cobra" || wNm == "child pose" || wNm == "Child Pose")
                    {
                    }
                    else if (wNm.Contains("stretch") || wNm.Contains("Child Pose"))
                    {
                    }
                    else if (wCnt < 1)
                    {
                        wCheck.Id = 0;
                        //workOutsMain.Add(wCheck);
                        aiEx.Add(wCheck.Name);
                    }
                    else if (wCnt >= 1)
                    {
                        currExs.Add(wCheck.Name);
                    }
                }
                //workOutsMain.AddRange(wOUT);
            }

            // = (from etAI in exNamesA select etAI.Value).Distinct().ToList();
            //List<string> aiExA = aiEx.Except((List<string>)exercises).ToList();
            //aiEx = (from a in workOutsMain select a.Name).Distinct().ToList();

            currExs = currExs.Distinct().ToList();
            aiEx = aiEx.Distinct().ToList();

            // set exercises according to time
            if (timetoRun == 30)
            {
                if (chKNoBreak.Checked)
                {
                    int r = (timetoRun * 60) / 45;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
                else
                {
                    int r = timetoRun * 2;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
            }
            else if (timetoRun == 20)
            {
                if (chKNoBreak.Checked)
                {
                    int r = (timetoRun * 60) / 40;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
                else
                {
                    int r = timetoRun * 2;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
            }
            else if (timetoRun == 15)
            {
                if (chKNoBreak.Checked)
                {
                    int r = (timetoRun * 60) / 45;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
                else
                {
                    int r = timetoRun * 2;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
            }
            else if (timetoRun == 10)
            {
                if (chKNoBreak.Checked)
                {
                    int r = (timetoRun * 60) / 40;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
                else
                {
                    int r = timetoRun * 2;
                    fnSetExerciseDetails(r, bi, exType.Value, aiEx, currExs);
                }
            }

            //string fileloc = @"C:\Users\marcu\Documents\Code\ExerciseXML\" + txtRndRoutine.Text + ".xml";
            int typeID = 0;//wo.Count;

            if (typeID == 0)
            {
                lbErr.Text = "You have missed the exercise type selection";
            }
            fnwriteXML(exType.Key, txtRndRoutine.Text, timetoRun, nohistory);
            //int g = wo.Count;
        }

        // set the exercise out to each break and execise at a point in time
        private void fnSetExerciseDetails(int r, List<int> bi, string exRcs, List<string> ax, List<string> curr)
        {
            List<string> currExs = curr;
            int totalTime = r;
            bool newOld = true;
            bool breakfound = false;
            int c = 0;

            List<string> anchors = new List<string>();

            if (chkAnchor.Checked)
            {
                int anchorrun = r ;
                int runVal = 0;
                while (runVal <= anchorrun)
                {
                    anchors.Add(txtAnchor.Text);
                    int removeAnchor = curr.IndexOf(anchors[0]);
                    if (removeAnchor > 0)
                    {
                        currExs.RemoveAt(removeAnchor);
                    }
                    break;
                }
                ax = anchors;
            }




            if ((exRcs == "Full Body" || exRcs == "No Break") &(!chkAnchor.Checked) )
            {
                currExs.AddRange(ax);
                currExs.Distinct().ToList();
            }
            while (r > 0)
            {
                ExerciseMethodShareDtNt.WorkOut w = new ExerciseMethodShareDtNt.WorkOut();

                if ((exRcs == "Full Body" || exRcs == "No Break")& !(chkAnchor.Checked))
                {
                    newOld = false;
                }
                else
                {
                    if (!chkAnchor.Checked)
                    {
                        if (r % 2 == 0 && r != 0)
                        {
                            newOld = true;
                        }
                        else
                        {
                            newOld = false;
                        }
                    }
                    else
                    {
                        if((r % 4 == 0 && r != 0) && ckFullB.Checked)
                        {
                            newOld = false;
                        }
                        
                        else if(chKNoBreak.Checked & r % 2 == 0 && r != 0)
                        {
                            newOld = true;
                        }
                        else if( r % 2 == 0)
                        {
                            newOld = true;
                        }
                        else
                        {
                            newOld = false;
                        }
                    }
                }

                foreach (int t in bi)
                {
                    if (t == c)
                    {
                        breakfound = true;
                        w.Name = "Rest";
                        w.Id = totalTime - r;
                        if (exRcs == "Full Body")
                        {
                            w.Time = 12;
                        }
                        else
                        {
                            w.Time = 30;
                        }
                    }
                }

                bool directionFound = false;
                string directionName = "";
                ExerciseMethodShareDtNt.WorkOut w2 = new ExerciseMethodShareDtNt.WorkOut();

                if (breakfound == false)
                {
                    w.Name = fnSetWorkout(currExs, ax, newOld);
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
                        List<string> exB = ax;
                        if (newOld)
                        {
                            exB = currExs;
                        }
                        w2.Name = fnGetRIGHTLEFT(w.Name, directionName, exB);
                        w2.Id = (totalTime - r);
                    }
                    w.Id = totalTime - r;
                    if (exRcs == "Full Body")
                    {
                        if ((chk15.Checked || Chk30.Checked) && chKNoBreak.Checked)
                        {
                            w.Time = 45;
                            w2.Time = 45;
                        }
                        else
                        {
                            if (chKNoBreak.Checked)
                            {
                                w.Time = 40;
                                w2.Time = 40;
                            }
                            else
                            {
                                w.Time = 48;
                                w2.Time = 48;
                            }
                        }
                    }
                    else
                    {
                        w.Time = 30;
                        w2.Time = 30;
                    }
                }

                if (exRcs == "Full Body")
                {
                    if (breakfound)
                    {
                        c = c + 12;
                    }
                    else
                    {
                        if ((chk15.Checked || Chk30.Checked) && chKNoBreak.Checked)
                        {
                            c = c + 45;
                        }
                        else
                        {
                            if (chKNoBreak.Checked)
                            {
                                c = c + 40;
                            }
                            else
                            {
                                c = c + 48;
                            }
                        }
                    }
                }
                else
                {
                    if (!directionFound)
                    {
                        c = c + 30;
                    }
                }

                breakfound = false;

                if (directionFound)
                {
                    wo.Add(w);
                    if (exRcs == "Full Body")
                    {
                        WorkOut w3 = new WorkOut();
                        if (chKNoBreak.Checked)
                        {
                            w2.Id = (totalTime - r) + 1;
                            r = r - 2;
                            c = c + (w2.Time);
                            wo.Add(w2);
                        }
                        else//add the code for anchor
                        {
                            if (!chkAnchor.Checked)
                            {
                                w3.Name = "Rest";
                                w3.Id = (totalTime - r) + 1;
                                w2.Id = w3.Id + 1;
                                w3.Time = 12;
                                wo.Add(w3);
                                r = r - 3;
                                c = c + (w3.Time + w2.Time);
                                wo.Add(w2);
                            }
                            else
                            {
                                WorkOut w4 = new WorkOut();
                                WorkOut w5 = new WorkOut();
                                //WorkOut w6 = new WorkOut();
                                
                                w3.Name = "Rest";
                                w4.Name = txtAnchor.Text;
                                w4.Time = w2.Time;
                                w3.Id = (totalTime - r) + 1;
                                //w2.Id = w5.Id + 1;
                                //w6 = w2;
                                w4.Id = w3.Id + 1;
                                w5.Id = w4.Id + 1;
                                w3.Time = 12;
                                w2.Id = w5.Id + 1;
                                w5.Time = w3.Time;
                                w5.Name = w3.Name;
                                wo.Add(w3);//rest
                                r = r - 3;
                                r = r - 2;
                                c = c + (w3.Time + w2.Time);
                                c = c + (w4.Time + w5.Time);
                                wo.Add(w4);
                                wo.Add(w5);
                                wo.Add(w2);
                            }

                            //c = c + (w3.Time + w2.Time);
                        }
                    }
                    else
                    {
                        w2.Id = (totalTime - r) + 1;

                        r = r - 2;
                        c = c + (w.Time);

                        foreach (int t in bi)
                        {
                            if (c == t)
                            {
                                r = r - 1;
                                WorkOut wRest = new WorkOut();
                                wRest.Name = "Rest";
                                wRest.Id = w2.Id;
                                w2.Id = w2.Id + 1;
                                if (exRcs == "Full Body")
                                {
                                    wRest.Time = 12;
                                    c = c + 12;
                                }
                                else
                                {
                                    wRest.Time = 30;
                                    c = c + 30;
                                }
                                wo.Add(wRest);
                            }
                        }

                        c = c + w2.Time;

                        wo.Add(w2);
                    }
                }
                else
                {
                    r--;
                    if (r == 0 && (w.Name == "Rest" || w.Name == "break"))
                    {
                        WorkOut ext = new WorkOut();
                        ext.Name = fnSetWorkout(currExs, ax, newOld);
                        ext.Id = w.Id + 1;
                        bool rl = false;
                        while (rl == false)
                        {
                            if (ext.Name.Contains("right") || ext.Name.Contains("left") || ext.Name.Contains("Right") || ext.Name.Contains("Left"))
                            {
                                rl = true;
                                w.Name = fnSetWorkout(currExs, ax, newOld);
                                if (exRcs == "Full Body")
                                {
                                    ext.Time = 48;
                                }
                                else
                                {
                                    ext.Time = 30;
                                }
                            }
                            else
                            {
                                rl = true;
                                if (exRcs == "Full Body")
                                {
                                    ext.Time = 48;
                                }
                                else
                                {
                                    ext.Time = 30;
                                }
                            }
                        }
                        wo.Add(w);
                        wo.Add(ext);
                    }
                    else
                    {
                        wo.Add(w);
                    }
                }
            }
        }

        private string fnGetRIGHTLEFT(string name, string directionName, List<string> exs)
        {
            string directionToLookFor = "";
            string stringPart = "";
            int at = 0;
            string resPortion = "";
            string returnResult = "";

            if (directionName == "RIGHT")
            {
                directionToLookFor = "LEFT";
                name = name.ToUpper();
                at = name.IndexOf(directionToLookFor);
                resPortion = name.Substring(0, at).ToUpper();



                returnResult = (from r in exs where r.ToUpper() == resPortion + directionName select r).FirstOrDefault();
                if (string.IsNullOrEmpty(returnResult))
                {
                    //returnResult = (from r in exs where r.ToUpper().Contains(resPortion) && r.ToUpper().Contains(directionName) select r).FirstOrDefault();
                    returnResult = resPortion + directionName;
                    int removal = exs.FindIndex(q => q.StartsWith(returnResult));
                    if (removal >0 )
                    {
                        exs.RemoveAt(removal);
                    }
                }
                else
                {
                    int removal = exs.FindIndex(q => q.StartsWith(returnResult));
                    if (removal > 0)
                    {
                        exs.RemoveAt(removal);
                    }
                }
            }
            else if (directionName == "LEFT")
            {
                directionToLookFor = "RIGHT";
                name = name.ToUpper();
                at = name.IndexOf(directionToLookFor);
                resPortion = name.Substring(0, at).ToUpper();
                returnResult = (from r in exs where r.ToUpper() == resPortion + directionName select r).FirstOrDefault();

                if (string.IsNullOrEmpty(returnResult))
                {
                    //returnResult = (from r in exs where r.ToUpper().Contains(resPortion) && r.ToUpper().Contains(directionName) select r).FirstOrDefault();
                    returnResult = resPortion + directionName;
                    int removal = exs.FindIndex(q => q.StartsWith(returnResult));
                    if (removal > 0)
                    {
                        exs.RemoveAt(removal);
                    }
                }
                else
                {
                    int removal = exs.FindIndex(q => q.StartsWith(returnResult));
                    if (removal > 0)
                    {
                        exs.RemoveAt(removal);
                    }
                }
            }

            return returnResult;
        }

        private string fnSetWorkout(List<string> exercisesKnown, List<string> exercisesUnknown, bool k)
        {
            Random r = new Random();
            //workout res = new workout();
            int counter = 0;
            string resName = "";
            if (k)
            {
                counter = r.Next(0, exercisesKnown.Count);
                resName = exercisesKnown[counter];
                exercisesKnown.RemoveAt(counter);
            }
            else
            {
                if (!chkAnchor.Checked)
                {
                    counter = r.Next(0, exercisesUnknown.Count);
                    resName = exercisesUnknown[counter];
                    exercisesUnknown.RemoveAt(counter);
                }
                else
                {
                    resName = exercisesUnknown[0];
                }
            }

            if (resName == "Rest" || resName.Contains("Stretch") || resName == " Child Pose")
            {
                resName = fnSetWorkout(exercisesKnown, exercisesUnknown, true);
            }

            

            return resName;
        }

        private void fnSetBreak(ref List<int> breakInterval, int TotalTime)
        {
            if (TotalTime == 30)
            {
                breakInterval.Add(600);
                breakInterval.Add(1200);
            }
            else if (TotalTime == 20)
            {
                breakInterval.Add(600);
            }
            else if (TotalTime == 15)
            {
                breakInterval.Add(450);
            }
        }

        private void txtRtneTme_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= 96 && e.KeyValue <= 105) || (e.KeyValue >= 48 && e.KeyValue <= 57))
            {
                e.Handled = true;
            }
            else
            {
                lbErr.Text = "Please Enter a number";
            }
        }

        private void txtExercise_TextChanged(object sender, EventArgs e)
        {
        }
    }
}