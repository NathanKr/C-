using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBullsAndCows
{
    class BullsCowsGame
    {
	    public BullsCowsGame(int nMaxTries, int nWorldLength)
        {
            //todo implement
        }
        public void Reset()
        {
            //todo implement
        }

        public int GetMaxTries()
        {
            return m_nMaxTries;
        }

        public int GetCurrentTry()
        {
            return m_nCurrentTry;
        }

        public bool IsGameWon()
        {
            //todo implement
            return false; // change this !!!!!! it is only to remove compile error 
        }

        public GuessStatus CheckGuessValid(string strGuess)
        {
            //todo implement
            return GuessStatus.Wrong_Number_Of_Letters;// change this !!!!!! it is only to remove compile error 
        }

        public BullsCowsCount SubmitValidGuess(string strGuess)
        {
            //todo implement
            return new BullsCowsCount(2, 1);// change this !!!!!! it is only to remove compile error
        }

	    int m_nCurrentTry, m_nMaxTries;
        bool m_bGameWon;
        string m_strHiddenWord;
    }
}
