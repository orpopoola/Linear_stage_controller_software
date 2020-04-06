using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Ports;

namespace csharp
{
    public partial class Form1 : Form
    {
        //initialize global variables
        System.UInt16 posVal;
        System.Single[] resPos = new System.Single[4];
        System.Int32[] tstOutput = new System.Int32[4];
        
        System.Int32[] runSte = new System.Int32[1];
        Random rnd = new Random();
        int test_cycle = 100;
        SerialPort mySerialPort = new SerialPort("COM5");
        string indataNew, indataOld;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize motion control card using the port name
            if (0x01 == mMCcard.MoCtrCard_Initial("COM4"))
            {
                statStripText.Text = "Hardware initialization success";
                Debug.WriteLine("My text");
            }
            else
            {
                statStripText.Text = "Hardware initialization failed";
            }
            indataNew = " ";
            indataOld = "1";
            //Arduino serial port
            mySerialPort.BaudRate = 19200;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.Open();
            mySerialPort.Close();
        }
        private void xaxis_Click(object sender, EventArgs e)
        {
            //Initializations -variables and status
            statStripText.Text = "X-axis movement initiated";
            SByte x_dir = 1;
            float x_hold;
            float[] x_loc = new float[test_cycle+1];
            x_loc[0]=0;
            mySerialPort.Open();
            //Declaration of randomized movement loop
            for (int jj = 1; jj<=100; jj++)
            {
                xtext.Text = Convert.ToString(jj);
                int test_travel = rnd.Next(1,6)*rnd.Next(2, 7);
                mMCcard.MoCtrCard_SendPara(0, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(0, x_dir);
                runSte[0] = 1;  
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte);  }
                posVal = mMCcard.MoCtrCard_GetAxisPos(0, resPos);
                x_loc[jj] = resPos[0];
                if (x_loc[jj]!=x_loc[jj-1])
                { 
                    for(int i=0; i<100; i++)
                    {
                        indataNew = mySerialPort.ReadLine();
                    }
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        x_hold = ParseInputData(indataNew, ",", 1);
                        if (x_hold != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\xtxt.txt", true))
                            {
                                file.WriteLine("{0}, {1}", x_hold, x_loc[jj]);
                            }
                        }                        
                    }
                   // mySerialPort.Close();                    
                }                 
                //Flip direction
                x_dir = Convert.ToSByte(-1*Convert.ToInt32(x_dir));
            }
            //Write output to file            
        }

        private float ParseInputData(string data, string sep, int axs)
        {
           string[] splitData = data.Split(sep.ToCharArray());
            int arrayLength = splitData.Length;
            //Debug.LogFormat("array length: {0}", arrayLength);
            if (splitData[0] == "f")
            {
                //Debug.Log("input in expected format");
                switch (axs)
                {
                    case 1:
                        return float.Parse(splitData[1]);
                        break;
                    case 2:
                        return float.Parse(splitData[2]);
                        break;
                    case 3:
                        return float.Parse(splitData[3]);
                        break;
                    case 4:
                        return float.Parse(splitData[4]);
                        break;
                    case 5:
                        return float.Parse(splitData[5]);
                    case 6:
                        return float.Parse(splitData[6]);
                        break;
                    default:
                        return 999999;
                        break;
                }
            }
            else
            {
                return 999999;
            }
        }
        private float[] ParseInputData(string data, string sep, int axs, int axy)
        {
            string[] splitData = data.Split(sep.ToCharArray());
            int arrayLength = splitData.Length;
            float[] xy_ad = new float[2];
            //Debug.LogFormat("array length: {0}", arrayLength);
            if (splitData[0] == "g")
            {  
                xy_ad[0] = float.Parse(splitData[1]);
                xy_ad[1] = float.Parse(splitData[2]);
            }
            else
            {
                xy_ad[0] = 999999;
                xy_ad[1] = 999999;
            }
            return xy_ad;
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {            
            SerialPort sp = (SerialPort)sender;
        }

        private void yaxis_Click(object sender, EventArgs e)
        {
            //Initializations -variables and status
            statStripText.Text = "Y-axis movement initiated";
            SByte y_dir = 1;
            float y_hold;
            float[] y_loc = new float[test_cycle + 1];
            y_loc[0] = 0;
            //Declaration of randomized movement loop
            for (int j = 1; j <= 100; j++)
            {
                xtext.Text = Convert.ToString(j);
                int test_travel = rnd.Next(1, 6) * rnd.Next(2, 7);
                mMCcard.MoCtrCard_SendPara(1, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(1, y_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); Console.WriteLine("Still Here"); }
                posVal = mMCcard.MoCtrCard_GetAxisPos(1, resPos);
                y_loc[j] = resPos[0];
                if (y_loc[j] != y_loc[j - 1])
                {
                    ytext.Text = Convert.ToString(y_loc[j]);
                    mySerialPort.Open();
                    for (int i = 0; i < 100; i++)
                    {
                        indataNew = mySerialPort.ReadLine();
                    }
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        y_hold = ParseInputData(indataNew, ",", 2);
                        if (y_hold != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\ytxt.txt", true))
                            {
                                file.WriteLine("{0}, {1}", y_hold, y_loc[j]);
                            }
                        }
                    }
                    mySerialPort.Close();
                }
                //Flip direction
                y_dir = Convert.ToSByte(-1 * Convert.ToInt32(y_dir));
            }
            //Write output to file            
        }

        private void xyaxis_Click(object sender, EventArgs e)
        {
            //Initializations -variables and status
            statStripText.Text = "XY-axis movement initiated";
            SByte x_dir = 1; SByte y_dir = 1;
            float[] xy_hold = new float[2];
            float[] x_loc = new float[test_cycle + 1];
            float[] y_loc = new float[test_cycle + 1];
            x_loc[0] = 0; y_loc[0] = 0;
            //Declaration of randomized movement loop
            for (int j = 1; j <= 100; j++)
            {
                ztext.Text = Convert.ToString(j);
                int test_travelx = rnd.Next(1, 6) * rnd.Next(2, 7);
                int test_travely = rnd.Next(1, 6) * rnd.Next(2, 7);
                mMCcard.MoCtrCard_SendPara(0, 0, test_travelx);
                mMCcard.MoCtrCard_SendPara(1, 0, test_travely);
                mMCcard.MoCtrCard_MCrlAxisMove(0, x_dir);
                mMCcard.MoCtrCard_MCrlAxisMove(1, y_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); }
                posVal = mMCcard.MoCtrCard_GetAxisPos(255, resPos);
                x_loc[j] = resPos[0];
                y_loc[j] = resPos[1];
                if (x_loc[j] != x_loc[j - 1])
                {
                    xtext.Text = Convert.ToString(x_loc[j]);
                    ytext.Text = Convert.ToString(y_loc[j]);
                    mySerialPort.Open();
                    for (int i = 0; i < 100; i++)
                    {
                        indataNew = mySerialPort.ReadLine();
                    }
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        xy_hold = ParseInputData(indataNew, ",", 1,2);
                        if (xy_hold[0] != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\xytxt.txt", true))
                            {
                                file.WriteLine("{0}, {1}, {2}, {3}", xy_hold[0], x_loc[j], xy_hold[1], y_loc[j]);
                            }
                        }
                    }
                    mySerialPort.Close();
                }
                //Flip direction
                x_dir = Convert.ToSByte(-1 * Convert.ToInt32(x_dir));
                y_dir = Convert.ToSByte(-1 * Convert.ToInt32(y_dir));
            }
            //Write output to file     
        }
        private void xzaxis_Click(object sender, EventArgs e)
        {
            mMCcard.MoCtrCard_SendPara(0, 0, Convert.ToInt32(ptext.Text));
            mMCcard.MoCtrCard_MCrlAxisMove(0, -1);//1 is left
            mMCcard.MoCtrCard_SendPara(1, 0, Convert.ToInt32(yawtext.Text));
            mMCcard.MoCtrCard_MCrlAxisMove(1, 1); //-1 is up
            mMCcard.MoCtrCard_SendPara(2, 0, Convert.ToInt32(rtext.Text));
            mMCcard.MoCtrCard_MCrlAxisMove(2, - 1); //-1 is up
        }

        private void yzaxis_Click(object sender, EventArgs e)
        {
            //System.IO.File.WriteAllLines("scores.txt",x_loc.Select(tb => (double.Parse(tb.Text)).ToString()));
        }

        private void unload_Click(object sender, EventArgs e)
        {
            //Release resources
            mMCcard.MoCtrCard_Unload();
            mySerialPort.Close();
        }

        private void zaxis_Click(object sender, EventArgs e)
        {

        }

        private void stop_Click(object sender, EventArgs e)
        {
            //Close button
            //Closes the form
            this.Close(); ;
        }
        
        private void reset_Click(object sender, EventArgs e)
        {
            //Assuming position at zero, this function takes the position to 350,350
            //350,350 is approximately the middle position
            posVal = mMCcard.MoCtrCard_ResetCoordinate(255, 0);
            mMCcard.MoCtrCard_SendPara(0, 0, 350);
            mMCcard.MoCtrCard_SendPara(1, 0, 350);
            mMCcard.MoCtrCard_MCrlAxisMove(0, -1);
            mMCcard.MoCtrCard_MCrlAxisMove(1, -1);
           // posVal = mMCcard.MoCtrCard_ResetCoordinate(255, 0);
        }

        private void ptext_TextChanged(object sender, EventArgs e)
        {

        }

        private void yawtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void pitch_Click(object sender, EventArgs e)
        {   //Rotation around x-axis --(
            //Initializations -variables and status
            statStripText.Text = "X-axis rotation initiated";
            SByte x_dir = 1;
            float x_hold;
            float[] x_loc = new float[test_cycle + 1];
            x_loc[0] = 0;
            mySerialPort.Open();
            //Declaration of randomized movement loop
            for (int jj = 1; jj <= 100; jj++)
            {
                xtext.Text = Convert.ToString(jj);
                int test_travel = rnd.Next(1, 6) * rnd.Next(2, 7);
                mMCcard.MoCtrCard_SendPara(0, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(0, x_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); }
                posVal = mMCcard.MoCtrCard_GetAxisPos(0, resPos);
                x_loc[jj] = resPos[0];
                if (x_loc[jj] != x_loc[jj - 1])
                {
                    for (int i = 0; i < 100; i++)
                    {
                        indataNew = mySerialPort.ReadLine();
                    }
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        x_hold = ParseInputData(indataNew, ",", 4);
                        if (x_hold != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\rxtxt.txt", true))
                            {
                                file.WriteLine("{0}, {1}", x_hold, x_loc[jj]);
                            }
                        }
                    }
                    // mySerialPort.Close();                    
                }
                //Flip direction
                x_dir = Convert.ToSByte(-1 * Convert.ToInt32(x_dir));
            }
            //Write output to file         
        }

        private void yaw_Click(object sender, EventArgs e)
        {   //Rotation about y-axis |U
            //Initializations -variables and status
            statStripText.Text = "Y-axis rotation initiated";
            SByte y_dir = 1;
            float y_hold;
            float[] y_loc = new float[test_cycle + 1];
            y_loc[0] = 0;
            //Declaration of randomized movement loop
            for (int j = 1; j <= 100; j++)
            {
                xtext.Text = Convert.ToString(j);
                int test_travel = rnd.Next(1, 6) * rnd.Next(2, 7);
                mMCcard.MoCtrCard_SendPara(1, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(1, y_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); Console.WriteLine("Still Here"); }
                posVal = mMCcard.MoCtrCard_GetAxisPos(1, resPos);
                y_loc[j] = resPos[0];
                if (y_loc[j] != y_loc[j - 1])
                {
                    ytext.Text = Convert.ToString(y_loc[j]);
                    mySerialPort.Open();
                    for (int i = 0; i < 100; i++)
                    {
                        indataNew = mySerialPort.ReadLine();
                    }
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        y_hold = ParseInputData(indataNew, ",", 6);
                        if (y_hold != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\rytxt.txt", true))
                            {
                                file.WriteLine("{0}, {1}", y_hold, y_loc[j]);
                            }
                        }
                    }
                    mySerialPort.Close();
                }
                //Flip direction
                y_dir = Convert.ToSByte(-1 * Convert.ToInt32(y_dir));
            }
            //Write output to file  
        }

        private void roll_Click(object sender, EventArgs e)
        {   //Rotation about z-axis (.)
            //Initializations -variables and status
            statStripText.Text = "Z-axis rotation initiated";
            SByte x_dir = -1;
            float x_hold;
            float[] x_loc = new float[test_cycle + 1];
            x_loc[0] = 0;
            mySerialPort.Open();
            //Declaration of randomized movement loop
            for (int jj = 1; jj <= 100; jj++)
            {
                xtext.Text = Convert.ToString(jj);
                int test_travel = rnd.Next(1, 6) * rnd.Next(2, 7);
                mMCcard.MoCtrCard_SendPara(2, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(2, x_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); }
                posVal = mMCcard.MoCtrCard_GetAxisPos(0, resPos);
                x_loc[jj] = resPos[0];
                if (x_loc[jj] != x_loc[jj - 1])
                {
                    for (int i = 0; i < 100; i++)
                    {
                        indataNew = mySerialPort.ReadLine();
                    }
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        x_hold = ParseInputData(indataNew, ",", 4);
                        if (x_hold != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\rztxt.txt", true))
                            {
                                file.WriteLine("{0}, {1}", x_hold, x_loc[jj]);
                            }
                        }
                    }
                    // mySerialPort.Close();                    
                }
                //Flip direction
                x_dir = Convert.ToSByte(-1 * Convert.ToInt32(x_dir));
            }
            //Write output to file   
        }

        private void rpy_Click(object sender, EventArgs e)
        {
            //mMCcard.MoCtrCard_SeekZero(0); 
            //posVal = mMCcard.MoCtrCard_ResetCoordinate(255, 0);
            mMCcard.MoCtrCard_GetAxisPos(1, resPos);
            Console.WriteLine(resPos[0]);
        }

        
    }
}
