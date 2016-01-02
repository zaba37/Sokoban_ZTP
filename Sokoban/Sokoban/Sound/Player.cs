using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Sokoban.Sound
{
    static class Player
    {
        private static SoundPlayer soundPlayer = null;

        public static SoundPlayer getSoundPlayerInstance()
        {
            if (soundPlayer == null)
            {
                soundPlayer = new SoundPlayer();
                return soundPlayer;
            }
            else
            {
                return soundPlayer;
            }
        }
    }
}
