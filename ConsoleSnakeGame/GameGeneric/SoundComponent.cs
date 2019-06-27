using System.Media;

namespace GameGeneric
{
    public class SoundComponent
    {
        public SoundComponent()
        {
            SoundPlayer = new SoundPlayer();
        }

        public SoundPlayer SoundPlayer { get; set; }
    }
}
