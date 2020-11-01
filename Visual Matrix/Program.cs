using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetProcessing;
using System.Text;
namespace Visual_Matrix
{
    class Program : NetProcessing.Sketch
    {
        public const int PS = 32;
        public const int PSD = 2;
        static public bool[] mat = new bool[64]; //={true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
        public static Thread drawT = new Thread(drawThread);
        public static Thread FindT = new Thread(findThread);
        public static int mx, my,pmx,pmy;
        public static string tmp;
        
        private static ulong ArrayToUInt64(bool[] arr)
        {
            if (arr.Length < 64)
                throw new ArgumentException("Wrong array length", nameof(arr));
            ulong result = 0;
            ulong j = 1;
            for (int i = 0; i < 64; i++)
            {
                if (arr[i])
                    result |= j;
                j *= 2;
            }
            return result;
        }
        public static string Reverse(string str)
        {
            string s = string.Empty;
            for (int i = str.Length - 1; i >= 0; --i)
                s += str[i];
            return s;
        }
        public static void Find()
        {
            ulong r = ArrayToUInt64(mat);
            tmp = r.ToString("X").PadLeft(16,'0');
            System.Threading.Thread.Sleep(10);
            tmp = "{" + "0x" + tmp.Substring(14, 2) + ",0x" + tmp.Substring(12, 2) + ",0x" + tmp.Substring(10, 2) + ",0x" + tmp.Substring(8, 2) + ",0x" + tmp.Substring(6, 2) + ",0x" + tmp.Substring(4, 2) + ",0x" + tmp.Substring(2, 2) + ",0x" + tmp.Substring(0, 2) + "}";
            Debug.WriteLine(tmp + " " + Convert.ToString(r));
            Form1.setText(tmp);
            //NetProcessing.Sketch.Text(tmp, 20, 20);
            //return tmp;
        }
        public static void drawThread()
        {
            new Program().Start();
        }
        public static void findThread()
        {
            while (true)
            {
                Find();
                System.Threading.Thread.Sleep(100);
            }
        }
        [STAThreadAttribute]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public override void Setup()
        {
            Size(256, 256);
            NoStroke();
            Fill(255,0,0);
            EllipseMode(CORNER);
            FrameRate(60);
        }
        public override void Draw()
        {
            
            mx = MouseX / PS;
            my = MouseY / PS;
            pmx = PMouseX / PS;
            pmy = PMouseY / PS;
            Background(0);
            Text(mx + " " + my, 10, 10);
            for(int i=0;i<8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(mat[j * 8 + 7-i])
                    {
                        Ellipse(i * PS + PSD, j * PS + PSD, PS - PSD, PS - PSD);
                    }
                }
            }
            if(IsMousePressed)
            {
                if (MouseButton == LEFT)
                {
                    mat[(my * 8) + 7-mx] = true;
                }
                if (MouseButton == RIGHT)
                {
                    mat[(my * 8) + 7-mx] = false;
                }
            }
            try
            {

            }
            catch
            {

            }
        }
    }
}
//textBox1.Text = Convert.ToString(Convert.ToByte(mat))
