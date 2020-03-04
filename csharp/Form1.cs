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
        System.UInt32 posValx, posValy;
        System.Single[] resPos = new System.Single[4];
        System.Int32[] tstOutput = new System.Int32[4];
        
        System.Int32[] runSte = new System.Int32[1];
        Random rnd = new Random();
        int test_cycle = 4;
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
            mySerialPort.BaudRate = 9600;
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
            //Declaration of randomized movement loop
            for (int j = 1; j<=test_cycle; j++)
            {
                int test_travel = 5*rnd.Next(1, 11);
                mMCcard.MoCtrCard_SendPara(0, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(0, x_dir);
                runSte[0] = 1;  
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte);  }
                posVal = mMCcard.MoCtrCard_GetAxisPos(0, resPos);
                x_loc[j] = resPos[0];
                if (x_loc[j]!=x_loc[j-1])
                { 
                    mySerialPort.Open();
                    indataNew = mySerialPort.ReadLine();
                    if (indataNew != indataOld)
                    {
                        indataOld = indataNew;
                        x_hold = ParseInputData(indataNew, ",", 1);
                        if (x_hold != 999999)
                        {
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\xtxt.txt", true))
                            {
                                file.Write("{0}, ", x_hold);
                            }

                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\xtxt.txt", true))
                            {
                                file.WriteLine("{0}", x_loc[j]);
                            }
                        }                        
                    }
                    mySerialPort.Close();                    
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
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {            
            SerialPort sp = (SerialPort)sender;
        }

        private void yaxis_Click(object sender, EventArgs e)
        {
            statStripText.Text = "Y-axis movement initiated";
            SByte y_dir = 1;
            float[] y_loc = new float[test_cycle];
            for (int j = 0; j < test_cycle; j++)
            {
                int test_travel = 5 * rnd.Next(1, 11);
                mMCcard.MoCtrCard_SendPara(1, 0, test_travel);
                mMCcard.MoCtrCard_MCrlAxisMove(1, y_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); }
                posVal = mMCcard.MoCtrCard_GetAdVal(1, tstOutput);
                Console.WriteLine(tstOutput[0]);
                y_loc[j] = resPos[0];
                y_dir = Convert.ToSByte(-1 * Convert.ToInt32(y_dir));
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\ytxt.txt", true))
            {
                for (int j = 0; j < test_cycle; j++)
                {
                    file.WriteLine("{0}, ", y_loc[j]);
                }
            }
        }

        private void xyaxis_Click(object sender, EventArgs e)
        {
            statStripText.Text = "Y-axis movement initiated";
            SByte y_dir = 1;
            SByte x_dir = 1;
            float[] y_loc = new float[test_cycle];
            float[] x_loc = new float[test_cycle];
            for (int j = 0; j < test_cycle; j++)
            {
                int test_travely = 5 * rnd.Next(1, 11);
                int test_travelx = 5 * rnd.Next(1, 11);
                mMCcard.MoCtrCard_SendPara(0, 0, test_travelx);
                mMCcard.MoCtrCard_SendPara(1, 0, test_travely);
                mMCcard.MoCtrCard_MCrlAxisMove(0, x_dir);
                mMCcard.MoCtrCard_MCrlAxisMove(1, y_dir);
                runSte[0] = 1;
                while (runSte[0] != 0) { mMCcard.MoCtrCard_GetRunState(runSte); }
                posVal = mMCcard.MoCtrCard_GetAxisPos(255, resPos);
                y_loc[j] = resPos[1];
                x_loc[j] = resPos[0];
                //Console.WriteLine("{0}", y_loc[j]);
                y_dir = Convert.ToSByte(-1 * Convert.ToInt32(y_dir));
                x_dir = Convert.ToSByte(-1 * Convert.ToInt32(x_dir));
                // Console.WriteLine("Out while");
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\olaol\Documents\Ola-git-projects\Linear_stage_control\xytxt.txt", true))
            {
                for (int j = 0; j < test_cycle; j++)
                {
                    file.Write("{0}, {1}, ", x_loc[j], y_loc[j]);
                }
                file.WriteLine();

            }

        }
        private void xzaxis_Click(object sender, EventArgs e)
        {

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
            this.Close(); ;
        }

        

        private void reset_Click(object sender, EventArgs e)
        {
            //Assuming position at zero, this function takes the position to 350,350
            posVal = mMCcard.MoCtrCard_ResetCoordinate(255, 0);
            mMCcard.MoCtrCard_SendPara(0, 0, 350);
            mMCcard.MoCtrCard_SendPara(1, 0, 350);
            mMCcard.MoCtrCard_MCrlAxisMove(0, -1);
            mMCcard.MoCtrCard_MCrlAxisMove(1, -1);
            posVal = mMCcard.MoCtrCard_ResetCoordinate(255, 0);
        }

        private void rpy_Click(object sender, EventArgs e)
        {
            //mMCcard.MoCtrCard_SeekZero(0); 
            posVal = mMCcard.MoCtrCard_ResetCoordinate(255, 0);

        }

        
    }
}
