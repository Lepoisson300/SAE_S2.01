using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unideckbuildduel.Logic;
using Unideckbuildduel.View;

namespace Unideckbuildduel
{
    /// <summary>
    /// The controler (one single instance) handles the link between the game and the window.
    /// Decides whether to display messages, launch a new game, etc.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// A reference to the single instance of this class
        /// </summary>
        public static Controller GetControler { get; } = new Controller();
        /// <summary>
        /// A string displaying the number of the current turn gotten by the game
        /// </summary>
        public string NumberOfTurns { get { return "Turn# " + (Game.GetGame.Turn + 1); } }
        /// <summary>
        /// A string displaying the score of player one with their name, both from the game
        /// </summary>
        public string PlayerOneScore { get { return Game.GetGame.PlayerName(0) + " " + Game.GetGame.PlayerScore(0); } }
        /// A string displaying the score of player two with their name, both from the game
        public string PlayerTwoScore { get { return Game.GetGame.PlayerName(1) + " " + Game.GetGame.PlayerScore(1); } }
        /// The number of turns to go, -1 if irrelevant
        public int NumbersOfTurnsToGo { get; set; }
        private int CurrentPlayer { get { return Game.GetGame.CurrentPlayer; } }
        private string PlayerName(int num) => Game.GetGame.PlayerName(num);

        private Controller() {}
        /// <summary>
        /// Launches a new game
        /// </summary>
        public void StartEverything()
        {
            string playerOneName = "First";
            string playerTwoName = "Second";
            //StartupDialog sd = new StartupDialog();
            //if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    NumbersOfTurnsToGo = sd.TurnLimit;
            //}
            Window.GetWindow.WriteLine("Starting new game with " + NumbersOfTurnsToGo + " turns to go.");
            Game.GetGame.NewGame(playerOneName, playerTwoName);
            Game.GetGame.Play();
        }
        /// <summary>
        /// Used when the turn ends
        /// </summary>
        public void EndTurn()
        {
            Game.GetGame.DiscardPhaseEnded();
            Game.GetGame.Play();
        }
        /// <summary>
        /// Atempt to place all cards for the current player; only loops through the cards once
        /// </summary>
        public void PlaceAllCards()
        {
            int handSize = Game.GetGame.PlayerHandSize(CurrentPlayer);
            Window.GetWindow.WriteLine("Placing all possible cards for player "+ PlayerName(CurrentPlayer));
            for (int i=handSize-1; i>=0; i--)
            {
                PlayCard(CurrentPlayer, i, true);
            }
            EndTurn();
        }
        /// <summary>
        /// Play one card (place, for buildings).
        /// </summary>
        /// <param name="playerNum">The number of the player</param>
        /// <param name="cardNum">The number of the card</param>
        /// <param name="silent">False by default; call with true for no messages</param>
        public void PlayCard(int playerNum, int cardNum, bool silent=false) 
        {
            (string msg, bool ok) = Game.GetGame.PlayCard(playerNum, cardNum);
            if (!silent)
            {
                if (!ok)
                {
                    Window.GetWindow.WriteLine(msg);
                }
                else
                {
                    Window.GetWindow.WriteLine("Card " + cardNum + " played and removed from the hand of player " + PlayerName(playerNum));
                    Window.GetWindow.Refresh();
                }
            }
        }
        /// <summary>
        /// Feedback: displays a new building in the window
        /// </summary>
        /// <param name="playerNum">The number of the player</param>
        /// <param name="card">The number of the card</param>
        public void NewBuilding(int playerNum, Card card)
        {
            Window.GetWindow.AddNewBuilding(playerNum, card);
            Window.GetWindow.WriteLine("Adding building " + card.CardType.Name + " for player" + PlayerName(playerNum));
            Window.GetWindow.Refresh();
        }
        /// <summary>
        /// Automated draw phase: draw cards to complete the player's hand
        /// </summary>
        /// <param name="num">The number of the player</param>
        public void DrawStart(int num)
        {
            int toDraw = Game.GetGame.PlayerHandSize(num)-Game.GetGame.PlayerCardCount(num);
            if (toDraw > 0)
            {
                Window.GetWindow.WriteLine("Drawing " + toDraw + " cards for player " + PlayerName(num));
                for (int i=0; i<toDraw; i++)
                {
                    Card c = Game.GetGame.DrawOneCard(num);
                    Window.GetWindow.WriteLine("Draw: " + c.CardType.Name);
                }
            }
            Game.GetGame.DrawPhaseEnded();
            Game.GetGame.Play();
        }
        /// <summary>
        /// Feedback: indicates that the discard phase has started
        /// </summary>
        /// <param name="currentPlayer">The number of the player</param>
        public void DiscardStart(int currentPlayer)
        {
            Window.GetWindow.WriteLine("Player " + PlayerName(currentPlayer) + ", please discard your cards or finish your turn");
        }
        /// <summary>
        /// Feedback when the turn is ended for a player
        /// </summary>
        /// <param name="currentPlayer">The number of the player</param>
        /// <param name="turn">The number of the turn</param>
        public void TurnEnded(int currentPlayer, int turn)
        {
            if (NumbersOfTurnsToGo>0)
            {
                if (NumbersOfTurnsToGo<Game.GetGame.Turn)
                {
                    Window.GetWindow.WriteLine("Game over");
                }
            }
            Window.GetWindow.WriteLine("Turn ended. It is now player " + PlayerName(currentPlayer)+"'s turn in turn number " + turn + ".");
        }
        /// <summary>
        /// Feedback : indicates that the play (cards) phase has started
        /// </summary>
        /// <param name="currentPlayer">The number of the player</param>
        public void PlayPhaseStart(int currentPlayer)
        {
            Window.GetWindow.WriteLine("Player " + PlayerName(currentPlayer) + ", please play your cards or finish your turn");
        }
        /// <summary>
        /// Displays the hand of the player in the window
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <param name="cards">The card in the player's hand</param>
        public void DisplayHand(int num, List<Card> cards)
        {
            Window.GetWindow.WriteLine("Player " + PlayerName(num) + ", these are your cards:");
            Window.GetWindow.CardsForPlayer(num, cards);
        }
        /// <summary>
        /// Method called to discard one specific card
        /// </summary>
        /// <param name="playerNum">The number of the player</param>
        /// <param name="cardNum">The number of the card</param>
        public void DiscardCard(int playerNum, int cardNum)
        {
            bool ok = Game.GetGame.DiscardCard(playerNum, cardNum);
            if (ok)
            {
                Window.GetWindow.WriteLine("Card " + cardNum + " removed from the hand of player " + PlayerName(playerNum));
                Window.GetWindow.Refresh();
            }
            else
            {
                Window.GetWindow.WriteLine("Discard problem");
            }
        }
    }
}
