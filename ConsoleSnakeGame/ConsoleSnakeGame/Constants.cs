using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    struct Constants
    {
        public static readonly string SOUND_DIR = "Sound";
        public static readonly string SOUND_EAT_FILE = "snack-crunch2.wav";
        public static readonly string SOUND_DEATH_FILE = "death-sound.wav";
        public static readonly string SOUND_WIN_FILE = "media.io_we-are-the-champions-copia.wav";
        public static readonly string BEST_RESULTS_FILE = "best-results.txt";
        public static readonly int INITIAL_SNAKE_BODY_COUNT = 4;
        public static readonly int GROW_PERCENT = 3;
        public static readonly int BOARD_WIDTH = 70;
        public static readonly int BOARD_HEIGHT = 30;

    }
}
