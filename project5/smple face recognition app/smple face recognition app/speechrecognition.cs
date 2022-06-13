using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;
namespace smple_face_recognition_app
{
    public partial class speechrecognition : System.Windows.Forms.Form
    {

        //form declaration.....
        SpeechSynthesizer ss = new SpeechSynthesizer();///ewfer ah wsol ela wazaeef moharek al kalam al mothabat
        PromptBuilder pd = new PromptBuilder();///eqom b enshaa kaeen moagah fareg wa ewafer torok l edafat al mohttwa wa ekhtear al aswat wa al tahakom fe semat al sot wa estakhdam aedan l atahakom fe notk al kalemah al mantokah
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();///ewafer wsaeel  al wsool ela tasgel al kalam athnaa malagateh wa edarateh
        Choices clist = new Choices();//ewmathel majmoaa mn al badaeel fe qewd tasgel al kalam
        private SerialPort myport;

        public speechrecognition()
        {
            InitializeComponent();
            init();
        }

        private void speechrecognition_Load(object sender, EventArgs e)
        {

        }
        private void txtContents_Click(object sender, EventArgs e)
        {
            //start button 
            btnstart.Enabled = false;
            btnStop.Enabled = true;
            clist.Add(new string[] { "how are you", "what is the current time", "go to front", "go to back", "go to right", "go to left", "stop", "start chrome" });
            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {

                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "error");



            }

        }
        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {


                case "how are you":
                    ss.SpeakAsync("i am good how about you");
                    break;
                case "what is the current time":
                    ss.SpeakAsync("current time is" + DateTime.Now.ToLongTimeString());
                    break;

                case "go to front":
                    myport.WriteLine("a");
                    ss.SpeakAsync("yes sir");

                    break;
                case "go to back":
                    myport.WriteLine("b");
                    ss.SpeakAsync("yes sir");

                    break;

                case "go to right":
                    myport.WriteLine("d");
                    ss.SpeakAsync("yes sir");

                    break;
                case "go to left":
                    myport.WriteLine("c");
                    ss.SpeakAsync("yes sir");

                    break;
                case "stop":
                    myport.WriteLine("e");
                    ss.SpeakAsync("yes sir");

                    break;
                case "start chrome":
                    Process.Start("chrome");
                    ss.SpeakAsync("yes sir ");

                    break;










            }
            txtContents.Text += e.Result.Text.ToString() + Environment.NewLine;

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            btnstart.Enabled = true;
            btnStop.Enabled = false;
        }
        private void init()
        {
            try
            {
                myport = new SerialPort();
                myport.BaudRate = 9600;
                myport.PortName = "COM1";
                myport.Open();

            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }


        }
    }
}
