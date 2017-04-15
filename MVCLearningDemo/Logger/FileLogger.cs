using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCLearningDemo.Logger
{
    public class FileLogger
    {
        public void LogException(Exception exception)
        {
            File.WriteAllLines(
                AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt",
                new string[] {"错误信息：" + exception.Message, "StackTrace:" + exception.StackTrace});
        }
    }
}