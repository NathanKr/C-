using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTicTacToe
{
    class TicTacToe
    {
        public TicTacToe(Point topLeft)
        {
            m_board = new Board(topLeft);
            Point resultTopLeft = new Point(topLeft.x + m_board.Size + 5, topLeft.y);
            //resultTopLeft.x = topLeft.x + m_board.Size + 5;// 5 is margin;
            //resultTopLeft.y = topLeft.y;
            m_scoreStorage = new ScoreStorage("Storage.txt");
            m_result = new Result(resultTopLeft);
            m_player1 = new Player();
            m_player2 = new Player();
        }

        

        public void Start()
        {
            m_bPlayAgain = true;
            m_startedPlayer = m_player1;

            showScores();
            readPlayers();

            while (m_bPlayAgain)
            {
                resetGame();

                while (!m_bGameIsOver)
                {
                    m_board.Write();
                    getInputFromPlayer();
                    checkGameIsOver();
                    switchCurrentPlayer();
                }
                Console.WriteLine("Do you want to start a new game ? y\\n");
                m_bPlayAgain = char.Parse(Console.ReadLine()) == 'y';
            }
            m_result.Write("Game is over");
        }

        private void showScores()
        {
            bool bSeeAllScores;
            string msg = "Do you want to see all scores ? y\\n";
            //Console.WriteLine("Do you want to see all scores ? y\\n");
            // --- todo->done loop here
            //bSeeAllScores = char.Parse(Console.ReadLine()) == 'y';
            bSeeAllScores = Utils.ReadCharFromConsole(msg) == 'y';
            if (bSeeAllScores)
            {
                Console.WriteLine("scores history : ");
                List<string> scores = m_scoreStorage.Read();
                foreach (string score in scores)
                {
                    Console.WriteLine(score);
                }
            }
            Console.WriteLine("hit key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        private void switchCurrentPlayer()
        {
            m_currentPlayer = (m_currentPlayer == m_player1) ? m_player2 : m_player1;
        }

        
        void writeToConsoleAndFile(string text)
        {
            m_result.Write(text);
            m_scoreStorage.Write(text);
        }

        private void checkGameIsOver()
        {
            if (m_board.IsPlayerWin(getCurrentEPlayer()))
            {
                m_bGameIsOver = true;
                writeToConsoleAndFile("winner is : " + m_currentPlayer.Name);
            }
            else if (m_board.IsGameDraw())
            {
                m_bGameIsOver = true;
                writeToConsoleAndFile("Game is draw");
            }

        }

        private void getInputFromPlayer()
        {
            int nRow, nCol;
            bool bTaken;
            
            Console.WriteLine("Player : {0}",m_currentPlayer.Name);

            do
            {
                //todo->done handle wrong input , use do while and TryParse
                //nRow = int.Parse(Console.ReadLine());
                nRow = Utils.ReadIntFromConsole("insert row (first is 0)");

                //todo->done handle wrong input , use do while and TryParse
                //nCol = int.Parse(Console.ReadLine());
                nCol = Utils.ReadIntFromConsole("insert col (first is 0)");
                if (m_board.Get(nRow, nCol).HasValue)
                {
                    bTaken = true;
                    Console.WriteLine("Place is taken");
                }
                else
                {
                    bTaken = false;
                    m_board.Set(
                        nRow,
                        nCol,
                        m_currentPlayer == m_player1 ? EPlayer.Player1 : EPlayer.Player2);
                }
            } while (bTaken);
        }

        private void resetGame()
        {
            m_bGameIsOver = false;
            m_board.Reset();
            // todo->done : current should toggle players on resetGame
            m_currentPlayer = (m_startedPlayer == m_player1) ? m_player2 : m_player1;
            m_startedPlayer = m_currentPlayer;
        }

        private void readPlayers()
        {
            Console.WriteLine("Player1");
            m_player1.ReadFromConsole();

            Console.WriteLine("Player2");
            m_player2.ReadFromConsole();
        }

        private EPlayer getCurrentEPlayer()
        {
            return m_currentPlayer == m_player1 ? EPlayer.Player1 : EPlayer.Player2;
        }

        Board m_board;
        bool m_bGameIsOver, m_bPlayAgain;
        Player m_player1;
        Player m_player2;
        Player m_currentPlayer;
        Player m_startedPlayer;
        Result m_result;
        ScoreStorage m_scoreStorage;
    }
}
