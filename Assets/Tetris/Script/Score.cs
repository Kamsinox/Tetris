using System.Collections.Generic;
using UnityEngine;

namespace Tomino
{
    public class Score
    {
        public int Tetris;

        public int Value { get; private set; }

        private Dictionary<int, int> scoreForClearedRows = new Dictionary<int, int>()
        {
            {1, 100}, {2, 300}, {3, 500}, {4, 800}
        };

        public void RowsCleared(int count)
        {
            int valueIncrease = 0;
            scoreForClearedRows.TryGetValue(count, out valueIncrease);
            Value += valueIncrease;
            countTetris(count);
        }

        public void PieceFinishedFalling(int rowsCount) => Value += rowsCount * 2;

        public void PieceMovedDown() => Value++;

        public void saveScore()
        {
            if(PlayerPrefs.GetInt("maxscore") < Value)
            {
                PlayerPrefs.SetInt("maxscore",Value);
                Debug.Log("Zapisany wynik to: " + PlayerPrefs.GetInt("maxscore"));
                PlayerPrefs.Save();
            }
        }

        public void countTetris(int count)
        {
            if(count == 4)
            {
                Debug.Log("TETRIS");
                Tetris++;
            }
        }

        public void saveTetrisScore()
        {
            if(PlayerPrefs.GetInt("maxtetris") < Tetris)
            {
                PlayerPrefs.SetInt("maxtetris", Tetris);
                Debug.Log("Zapisany wynik tetrisów to: " + PlayerPrefs.GetInt("maxtetris"));
                PlayerPrefs.Save();
            }
        }
    }
}