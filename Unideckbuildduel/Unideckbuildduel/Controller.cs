﻿using System;
using System.Collections.Concurrent;
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
        public int CurrentPlayer { get { return Game.GetGame.CurrentPlayer; } }
        private string PlayerName(int num) => Game.GetGame.PlayerName(num);

        public static bool gameOver = true;

        public bool hasDrawnFromDeck = false;

        public bool hasDrawnFromDiscard = false;

        private Controller() {}
        /// <summary>
        /// Launches a new game
        /// </summary>
        public void StartEverything()
        {
            gameOver = false;
            string playerOneName = "First";
            string playerTwoName = "Second";
            StartupDialog sd = new StartupDialog();
            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NumbersOfTurnsToGo = sd.TurnLimit;
                playerOneName = sd.Player1Name;
                playerTwoName = sd.Player2Name;
            }
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
            if (Game.GetGame.listDict[CurrentPlayer][Effect.Substitute])
            {
                Game.GetGame.listDict[CurrentPlayer][Effect.Substitute] = false;
                Game.GetGame.substitutesList[CurrentPlayer].Clear();
            }

            Game.GetGame.Play();
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

            Produce();

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
            Window.GetWindow.nextButtonState = true;
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
                if (NumbersOfTurnsToGo<=Game.GetGame.Turn)
                {
                    Window.GetWindow.WriteLine("Game over");
                    if (Game.GetGame.PlayerScore(0) == Game.GetGame.PlayerScore(1))
                        Window.GetWindow.WriteLine("Egalité!");
                    if (Game.GetGame.PlayerScore(0) > Game.GetGame.PlayerScore(1))
                        Window.GetWindow.WriteLine("Le joueur " + PlayerName(0) + " a gagné!");
                    if (Game.GetGame.PlayerScore(0) < Game.GetGame.PlayerScore(1))
                        Window.GetWindow.WriteLine("Le joueur " + PlayerName(1) + " a gagné!");

                    Window.GetWindow.disableButton();
                    gameOver = true;
                }
            }
            else
                Window.GetWindow.WriteLine("Turn ended. It is now player " + PlayerName(currentPlayer)+"'s turn in turn number " + turn + ".");
        }
        /// <summary>
        /// Feedback : indicates that the play (cards) phase has started
        /// </summary>
        /// <param name="currentPlayer">The number of the player</param>
        public void PlayPhaseStart(int currentPlayer)
        {
            Window.GetWindow.WriteLine("Player " + PlayerName(currentPlayer) + ", please play your cards, change phase or end your turn");
            Window.GetWindow.nextButtonState = false;
            hasDrawnFromDeck = false;
            hasDrawnFromDiscard = false;

        }
        /// <summary>
        /// Displays the hand of the player in the window
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <param name="cards">The card in the player's hand</param>
        public void DisplayHand(int num, List<Card> cards)
        {
            //Window.GetWindow.WriteLine("Player " + PlayerName(num) + ", these are your cards:");
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

        public void Echange(string s)
        {
            Game g = Game.GetGame;
            bool exchange_done = false;
            foreach (Card ca in g.buildings[g.players[g.CurrentPlayer]])
            {
                if (ca.CardType.Effect == Effect.CanExchange && ca.CardType.EffectCard.Name == s && !exchange_done)
                {
                    Card c  = Game.GetGame.DrawOneCard(CurrentPlayer);
                    exchange_done = true;
                    Window.GetWindow.WriteLine("Traded: " + s + " for: " + c.CardType.Name);
                }
            }
        }

        public void Produce()
        {
            foreach (Card ca in Game.GetGame.buildings[Game.GetGame.players[Game.GetGame.CurrentPlayer]])
            {
                if (ca.CardType.Effect == Effect.ProducesOne)
                {
                    Card c = new Card
                    {
                        CardType = ca.CardType.EffectCard
                    };
                    Game.GetGame.cards[Game.GetGame.players[CurrentPlayer]].Add(c);
                    Window.GetWindow.WriteLine("Produced: " + c.CardType.Name);
                }
            }
        }

        public static bool IsTradable(Card ca)
        {
            bool res = false;
            Game g = Game.GetGame;
            foreach (Card c in g.buildings[g.players[g.CurrentPlayer]])
            {
                if (c.CardType.Effect == Effect.CanExchange && c.CardType.EffectCard.Name == ca.CardType.Name)
                {
                    res = true;
                }
            }
            return res;
        }

        public void WriteOneMoreCard()
        {
            Window.GetWindow.WriteLine(PlayerName(CurrentPlayer) + " can now hold one more card in his hand");
        }

        public void WritePlayAgain()
        {
            Window.GetWindow.WriteLine(PlayerName(CurrentPlayer) + " gets to play again");
        }

        public void WriteSubstitute(string s)
        {
            Window.GetWindow.WriteLine(s + " is substitued this turn for " + PlayerName(CurrentPlayer));
        }
    }
}
