using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace FileManager
{
    static class VirusScanner
    {
        public static int _IsInfected { get; set; }
        static VirusScanner()
        {
            string IsInfected = ConfigurationManager.AppSettings["MalwareSize"];
            _IsInfected = Convert.ToInt32(_IsInfected);
            
        }
       public static bool IsFileInfected(MyFile myFile)
        {
            if (myFile.FileSize == _IsInfected)
            {
                return true;
            }
            else
            {
                throw new InfectedFileDetectedException("File is Infected with Virus", myFile.FilePath);
                return false;
            }
        }
    }
}
