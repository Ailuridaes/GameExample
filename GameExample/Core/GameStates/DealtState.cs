using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static GameExample.Core.Input;

namespace GameExample.Core
{
    public class DealtState : IGameState
    {
        // hitCounter just to demo that a GameState can hold member variables/properties
        public int hitCounter { get; set; }

        public IGameState HandleInput(Game game, Input input)
        {
            switch (input)
            {
                case HIT:
                    {
                        game.Player.Hand.Add(game.RandomGenerator.Next(1, 14));
                        return null;
                    }
                case PASS:
                    {
                        return new ResultsState();
                    }
                default:
                    {
                        // input not valid
                        return null;
                    }
            }
        }

        public void Initialize(Game game)
        {
            game.Player.Hand = new List<int>();
            game.Player.Hand.Add(game.RandomGenerator.Next(1, 14));
            game.Player.Hand.Add(game.RandomGenerator.Next(1, 14));
        }
    }
}