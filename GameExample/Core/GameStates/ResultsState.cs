using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static GameExample.Core.Input;

namespace GameExample.Core
{
    public class ResultsState : IGameState
    {
        public IGameState HandleInput(Game game, Input input)
        {
            if (input == DEAL)
            {
                return new DealtState();
            } else
            {
                return null;
            }
        }

        public void Initialize(Game game)
        {
            // Handle dealer hand, scoring
            throw new NotImplementedException();
        }
    }
}