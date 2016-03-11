using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Level
    {
        byte minLevel;
        byte currentLevel;
        byte maxLevel;

        public byte CurrentLevel
        {
            get 
            { 
                return currentLevel; 
            }
            set
            {
                if (value < minLevel || value > maxLevel)
                    throw new ArgumentOutOfRangeException("CurrentLevel");
            }
        }

        public Level()
        {
            this.minLevel = 0;
            this.maxLevel = 255;
            this.currentLevel = minLevel;
        }

        public Level(byte minLevel, byte maxLevel)
        {
            this.minLevel = minLevel;
            this.maxLevel = maxLevel;
            this.currentLevel = minLevel;
        }

        public void LevelUp()
        {
            if (currentLevel < maxLevel)
                currentLevel++;
        }
    }
}
