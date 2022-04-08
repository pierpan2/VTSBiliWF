
using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;  //需要添加这个名词空间，调用DataReceivedEventArg 
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VTSBiliWF
{
    public class LoadPython
    {

        public string info = null;

        public int room_id = 14917277; // 夸！

        private string sArguments;
        // private string AppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private string AssetsPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public string temp = "";
        Process p = new Process();

        public Sender sender;

        public LoadPython(Sender s)
        {
            sender = s;
        }

        public void StartPy(int newID)
        {
            if (newID != 0) room_id = newID;
            info = $"连接直播间{room_id}";
            Debug.WriteLine(info);
            ThreadStart childRef = new ThreadStart(ThreadTest1);
            Thread childThread = new Thread(childRef);
            childThread.Start();
        }

        public void EndPy()
        {
            p.Close();
            info = $"停止连接房间{room_id}";
        }

        public void ThreadTest1()
        {
            // sArguments = @"/blivedm.py " + room_id.ToString();
            sArguments = room_id.ToString();
            Debug.WriteLine("ThreadTest1 is working");
            RunPythonScript(sArguments, "-u");
        }
        public void RunPythonScript(string sArgName, string args = "")
        {
            // string path = AssetsPath + sArgName;
            // string sArguments = path;

            // p.StartInfo.FileName = AppData + @"\Programs\Python\Python39\python.exe";
            p.StartInfo.FileName = AssetsPath + @"\py\blivedm\blivedm.exe";
            // UnityEngine.Debug.Log(path);
            // UnityEngine.Debug.Log(p.StartInfo.FileName);
            p.StartInfo.UseShellExecute = false;
            // p.StartInfo.Arguments = sArguments;
            p.StartInfo.Arguments = sArgName;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(Out_RecvData);
            Console.ReadLine();
            p.WaitForExit();

        }
        void Out_RecvData(object sender, DataReceivedEventArgs e)
        {
            if (temp != e.Data)
            {
                temp = e.Data;
                if (temp != "" && temp != null)
                {
                    Debug.WriteLine(temp);
                    // mainScript.receiveDanmu(temp);
                }

            }
        }
        public void Close()
        {
            p.Close();
        }

    }
}