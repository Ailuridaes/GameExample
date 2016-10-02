using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameExample.Game
{
    public class Game
    {
        public GameState State { get; private set; }
        public List<int> Hand { get; set; }
        public Random RandomGenerator = new Random();

        public void HandleInput()
        {
            GameState newState = State.HandleInput(this);
            if (newState != null)
            {
                // TODO: destroy current State?
                State = newState;
            }
        }

        public void InitializeState()
        {
            State.Initialize(this);
        }


    }
}