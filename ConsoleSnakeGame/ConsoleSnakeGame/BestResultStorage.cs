using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class BestResultStorage
    {
        public BestResultStorage(string strFileName)
        {
            this.strFileName = strFileName;
        }

        public void Write(int bestResult)
        {
            bool bAppend = false;
            using (StreamWriter writer = new StreamWriter(strFileName, bAppend))
            {
                writer.WriteLine(bestResult);
            }
        }

        public List<string> Read()
        {
            List<string> list = new List<string>();
            string strLine;
            if (File.Exists(strFileName))
            {
                using (StreamReader reader = new StreamReader(strFileName))
                {
                    while (true)
                    {
                        strLine = reader.ReadLine();
                        if (strLine == null)
                        {
                            break;
                        }
                        list.Add(strLine);
                    }
                }
            }
            return list;
        }

        private string strFileName;
    }
}
