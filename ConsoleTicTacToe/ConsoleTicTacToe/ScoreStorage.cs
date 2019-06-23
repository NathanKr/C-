using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTicTacToe
{
    class ScoreStorage
    {
        private string strFileName;

        // --- locally save
        public ScoreStorage(string strFileName)
        {
            this.strFileName = strFileName;
        }

        public void Write(string score)
        {
            bool bAppend = true;
            using (StreamWriter writer = new StreamWriter(strFileName, bAppend))
            {
                writer.WriteLine(score);
            }
        }

        // --- read all scores
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
                        if(strLine == null)
                        {
                            break;
                        }
                        list.Add(strLine);
                    } 
                }
            }
            return list;
        }
    }
}
