using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameExample.Game
{
    public interface GameState
    {
        GameState HandleInput(Game game);
        void Initialize(Game game);
    }

}