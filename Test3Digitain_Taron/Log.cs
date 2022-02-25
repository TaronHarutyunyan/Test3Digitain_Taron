using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3Digitain_Taron
{
    internal class Log
    {
        private static Log _instance { get; set; } = null;
        private readonly string _fileAdress = @$"./Log.txt";
        private Log()
        {
        }
        public static Log GetInstance()
        {
            if (_instance == null) _instance = new Log();
            return _instance;
        }
        public void Write(string s)
        {
            using StreamWriter writer = new(new FileStream(_fileAdress, FileMode.Append, FileAccess.Write));
            writer.WriteLine(s + " " + DateTime.Now.ToString());
        }

    }
}
