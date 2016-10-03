using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using GameExample.Core;

namespace GameExample
{
    public class GameHub : Hub
    {
        #region Connection management

        public override Task OnConnected()
        {
            // Reconnect player if already logged on
            if (!string.IsNullOrEmpty(Context.User.Identity.Name))
            {
                var player = GameManager.Instance.Players
                    .Where(x => x.Name == Context.User.Identity.Name)
                    .SingleOrDefault();

                if (player != null)
                {
                    player.ConnectionId = Context.ConnectionId;
                    Clients.Caller.updateSelf(player.Name);
                }
            }

            return base.OnConnected();
        }

        #endregion


        public void Deal(int gameId)
        {
            var game = GetGame(gameId);
            if (game != null && game.Player.ConnectionId == Context.ConnectionId)
            {
                // Can also put checking here to make sure input is applicable to game state?
                // But that makes its setup kind of pointless
                game.HandleInput(Input.DEAL);

                Clients.Caller.setHand(game.Player.Hand);
            }
            else
            {
                Clients.Caller.displayError("Game not found.");
            }
        }

        public void Hit(int gameId)
        {
            var game = GetGame(gameId);
            if (game != null && game.Player.ConnectionId == Context.ConnectionId)
            {
                game.HandleInput(Input.HIT);

                Clients.Caller.setHand(game.Player.Hand);
            }
            else
            {
                Clients.Caller.displayError("Game not found.");
            }
        }

        public void Pass(int gameId)
        {
            var game = GetGame(gameId);
            if (game != null && game.Player.ConnectionId == Context.ConnectionId)
            {
                game.HandleInput(Input.PASS);

                // Notify all clients in group of pass
                Clients.Group(game.GameId.ToString()).passed(game);
            }
            else
            {
                Clients.Caller.displayError("Game not found.");
            }
        }

        private Game GetGame(int gameId)
        {
            return GameManager.Instance.Games
                .Where(x => x.GameId == gameId)
                .SingleOrDefault();
        }

    }
}