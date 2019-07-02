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

        public void Write(Result bestResult)
        {
            bool bAppend = false;
            using (StreamWriter writer = new StreamWriter(strFileName, bAppend))
            {
                writer.WriteLine($"{bestResult.PlayerName}{m_cSeperator}{bestResult.Score}");
            }
        }

        public List<Result> Read()
        {
            List<Result> list = new List<Result>();
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
                        string [] arLines = strLine.Split(m_cSeperator);
                        if(arLines.Length == 2)
                        {
                            list.Add(new Result {
                                PlayerName = arLines[0] ,
                                Score = int.Parse(arLines[1])
                            });
                        }
                    }
                }
            }
            return list;
        }

        private string strFileName;
        const char m_cSeperator = ',';
    }
}
