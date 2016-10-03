using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameExample.Core
{
    public interface IGameState
    {
        IGameState HandleInput(Game game, Input input);
        void Initialize(Game game);
    }

}