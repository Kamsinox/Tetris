using System;
using UnityEngine;

namespace Tomino
{
    public class Level
    {
        public int Number => Lines / 10 + 1;

        public float FallDelay => Math.Max(0.05f, 1.0f - ((Number - 1) * 0.1f));

        public int Lines { get; private set; }

        public void RowsCleared(int count) => Lines += count;

        public void saveLinesCount()
        {
            if(PlayerPrefs.GetInt("maxlines") < Lines)
            {
                PlayerPrefs.SetInt("maxlines", Lines);
                PlayerPrefs.Save();
            }
        }

        public void saveLevelCount()
        {
            if(PlayerPrefs.GetInt("maxlevel") < Number)
            {
                PlayerPrefs.SetInt("maxlevel", Number);
                PlayerPrefs.Save();
            }
        }
    }
}