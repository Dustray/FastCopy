using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromDir = "abc";
            string toDir = "" + Environment.GetEnvironmentVariable("USERPROFILE")+"\\.configure";
            
            CopyDir(fromDir, toDir);
        }
        public static void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
            {
                return;
            }
            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }
            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(toDir, fileName);
                if (File.Exists(toFileName))
                {
                    continue;
                }
                    
                File.Copy(formFileName, toFileName);
            }
            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(toDir, dirName);
                CopyDir(fromDirName, toDirName);
            }
        }

        public static void MoveDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            CopyDir(fromDir, toDir);
            Directory.Delete(fromDir, true);
        }
    }
}
