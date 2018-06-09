using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{
    class Game
    {
        Results m_results;
        readonly int m_nHorizonatalSpacing = 10 , m_nVerticalSpacing = 4;
        int m_nRows, m_nCols;
        private int m_nLevel;
        private int m_nGameEnds;
        private bool m_bGameHasFinished;

        public Game(int nRows, int nCols , int nLevel , int nGameEnds)
        {
            m_nRows = nRows;
            m_nCols = nCols;
            m_nLevel = nLevel;
            m_nGameEnds = nGameEnds;
            m_bGameHasFinished = false;
            m_results = new Results();
        }


        void TimerCallback(object state){
            Board board = (Board)state;
            board.HandleLogic(out m_bGameHasFinished);
            if (m_bGameHasFinished){
                showFinalResult();
                turnTimerOff();
            }
            else{
                board.Draw();
                scheduleNextTimerCycle();// --- this will prevent timer callback overlapping
            }
            showCurrentResult();
        }

        private bool scheduleNextTimerCycle()
        {
            return m_timer.Change(m_nSleepMs, int.MaxValue);
        }

        private bool turnTimerOff()
        {
            return m_timer.Change(int.MaxValue, int.MaxValue);
        }

        private void showFinalResult()
        {
            Console.SetCursorPosition(0, m_nRows + m_nVerticalSpacing);
            Console.WriteLine(m_results.ShowFinal());
        }

        void showCurrentResult(){
            Console.SetCursorPosition(m_nCols + m_nHorizonatalSpacing,  m_nRows / 2);
            Console.Write(m_results.ShowCurrent());
        }

        Timer m_timer;
        int m_nSleepMs;

        public void Start()
        {
            Console.CursorVisible = false;
            Board board = new Board(m_nRows, m_nCols, m_nGameEnds, m_results);
            m_nSleepMs = 1000/m_nLevel;
            m_timer = new Timer(TimerCallback, board, 0, m_nSleepMs);

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (board.HumanPlayer.AllowMoveDown()){
                            board.HumanPlayer.MoveDown();
                        }
                        
                        break;

                    case ConsoleKey.UpArrow:
                        if(board.HumanPlayer.AllowMoveUp()){
                            board.HumanPlayer.MoveUp();
                        }
                        break;
                }
            }
        }
    }
}
