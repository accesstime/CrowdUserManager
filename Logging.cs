using System;
using System.IO;

namespace CrowdUserManager
{
    class Logging
    {

        public void addLog(string logText)
        {
           string fileName= Environment.CurrentDirectory + "\\logging\\log01.log";
            File.AppendAllText (fileName,DateTime.Now + ": " + logText+"\r\n");

        }



    }
}
