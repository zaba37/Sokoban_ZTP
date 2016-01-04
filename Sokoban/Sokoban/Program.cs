using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Windows;
using Sokoban.Sound;
using System.Media;
using Sokoban.Builder;
using Sokoban.GameMap;

namespace Sokoban
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            SoundPlayer typewriter = Player.getSoundPlayerInstance();
            typewriter.SoundLocation = @"Music\mainMusic.wav";
            typewriter.PlayLooping();

            Director director = new Director();
            ClassicMapBuilder classic = new ClassicMapBuilder();
            director.setMapBuilder(classic);
            director.constructMap(1);
            Map map = director.getMap();
            
            Application.Run(new GameMenu());
        }
    }
}
