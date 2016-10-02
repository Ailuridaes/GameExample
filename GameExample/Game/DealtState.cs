using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameExample.Game
{
    public class DealtState : GameState
    {
        public int hitCounter { get; set; }
        public GameState HandleInput(Game game)
        {
            //if Input == whatever
            if (hitCounter > 1)
            {
                return new ResultsState();
            }
            return null;
        }

        public void Initialize(Game game)
        {
            game.Hand = new List<int>();
            game.Hand.Add(game.RandomGenerator.Next(1, 14));
            game.Hand.Add(game.RandomGenerator.Next(1, 14));
        }
    }
}