using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameExample.Core
{
    public class Game
    {
        public int GameId { get; set; }
        public IGameState State { get; private set; }
        public Player Player { get; set; }
        public List<int> DealerHand { get; set; }
        public Random RandomGenerator = new Random();

        public void HandleInput(Input input)
        {
            IGameState newState = State.HandleInput(this, input);
            if (newState != null)
            {
                // TODO: destroy current State?
                State = newState;
                State.Initialize(this);
            }
        }

        public void InitializeState()
        {
            State.Initialize(this);
        }


    }
}