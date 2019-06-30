using System.Media;

namespace GameGeneric
{
    public class SoundComponent
    {
        public SoundPlayer CreateSoundPlayer()
        {
            return new SoundPlayer();
        }
    }
}
