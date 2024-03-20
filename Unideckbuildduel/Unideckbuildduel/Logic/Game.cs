using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unideckbuildduel.Logic.GameData;

namespace Unideckbuildduel.Logic
{
    /// <summary>
    /// A class used for the game's logic. One single instance at a time.
    /// </summary>
    public class Game
    {
        private Stack<Card> commonDeck;
        private List<Player> players;
        private Dictionary<Player, List<Card>> cards;
        private Dictionary<Player, List<Card>> buildings;

        /// <summary>
        /// A reference to the single instance of this class
        /// </summary>
        public static Game GetGame { get; } = new Game();
        /// <summary>
        /// Turn number (from 0)
        /// </summary>
        public int Turn { get; set; }
        /// <summary>
        /// The current phase
        /// </summary>
        public GameStatus GameStatus {get; private set;}
        /// <summary>
        /// The current player (0-1)
        /// </summary>
        public int CurrentPlayer { get; private set; }
        private Game() {}
        /// <summary>
        /// Method used to launch a new game (at startup or after)
        /// </summary>
        public void NewGame(string playerOneName, string playerTwoName)
        {
            commonDeck = LoadData.GenStack();
            players = new List<Player> { new Player { Name = playerOneName }, new Player { Name = playerTwoName } };
            cards = new Dictionary<Player, List<Card>>();
            buildings = new Dictionary<Player, List<Card>>();
            foreach (Player p in players)
            {
                p.Number = players.IndexOf(p);
                cards.Add(p, new List<Card>());
                buildings.Add(p, new List<Card>());
            }
            GameStatus = GameStatus.TurnStart;
            CurrentPlayer = 0;
            Turn = 0;
        }
        /// <summary>
        /// Method called to end the discard phase
        /// </summary>
        public void DiscardPhaseEnded()
        {
            GameStatus = GameStatus.Ended;
        }
        /// <summary>
        /// Try to play a specific card.
        /// </summary>
        /// <param name="playerNum">The number of the player</param>
        /// <param name="cardNum">The number of the card</param>
        /// <returns>msg: a string containing a message, ok: true iff the card could be played</returns>
        public (string msg, bool ok) PlayCard(int playerNum, int cardNum)
        {
            Card card = cards[players[playerNum]][cardNum];
            return PlayCard(playerNum, card);
        }
        private (string msg, bool ok) PlayCard(int playerNum, Card card)
        {
            if (card == null) { return ("Card playing error", false); }
            switch (card.CardType.Kind)
            {
                case Kind.Building:
                    var reqBs = card.CardType.RequiredBuildings;
                    if (reqBs != null && reqBs.Count > 0)
                    {
                        bool reqBok = true;
                        foreach (CardType b in reqBs.Keys)
                        {
                            int presB = NumberOfCardsPresent(buildings[players[playerNum]], b);
                            if (presB < reqBs[b])
                            {
                                reqBok = false;
                            }
                        }
                        if (!reqBok)
                        {
                            return ("Not enough required buildings", false);
                        }
                    }
                    buildings[players[playerNum]].Add(card);
                    cards[players[playerNum]].Remove(card);
                    players[playerNum].Points += card.CardType.Points;
                    Controller.GetControler.NewBuilding(playerNum, card);
                    Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
                    return (null, true);
                default:
                    return ("Card type not handled yet", false);
            }
        }
        private static int NumberOfCardsPresent(List<Card> cards, CardType type)
        {
            if (cards == null || cards.Count == 0 || type == null)
            {
                return 0;
            }
            int res = 0;
            foreach (Card card in cards)
            {
                if (card.CardType.Equals(type))
                {
                    res++;
                }
            }
            return res;
        }
        /// <summary>
        /// Method called when the game should advance; sometimes recursive, sometimes not.
        /// </summary>
        public void Play()
        {
            switch (GameStatus)
            {
                case GameStatus.TurnStart:
                    GameStatus = GameStatus.Drawing;
                    Play();
                    break;
                case GameStatus.Drawing:
                    Controller.GetControler.DrawStart(CurrentPlayer);
                    break;
                case GameStatus.Playing:
                    Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
                    Controller.GetControler.PlayPhaseStart(CurrentPlayer);
                    break;
                case GameStatus.Discarding:
                    Controller.GetControler.DiscardStart(CurrentPlayer);
                    break;
                case GameStatus.Ended:
                    CurrentPlayer = (CurrentPlayer + 1) % players.Count;
                    if (CurrentPlayer == 0)
                    {
                        Turn++;
                    }
                    Controller.GetControler.TurnEnded(CurrentPlayer, Turn);
                    GameStatus = GameStatus.TurnStart;
                    Play();
                    break;
            }
        }
        /// <summary>
        /// Method called to discard a specific card.
        /// </summary>
        /// <param name="playerNum">The number of the player</param>
        /// <param name="cardNum">The number of the card</param>
        /// <returns>True iff the card was actually discarded</returns>
        public bool DiscardCard(int playerNum, int cardNum)
        {
            Card card = cards[players[playerNum]][cardNum];
            return DiscardCard(playerNum, card);
        }
        private bool DiscardCard(int playerNum, Card card)
        {
            if (card == null) { return false; }
            return cards[players[playerNum]].Remove(card);
        }
        /// <summary>
        /// Draw one card for a player from the deck
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <returns>A reference to the drawn card, also added to the player's hand</returns>
        public Card DrawOneCard(int num)
        {
            if (PlayerHandSize(num)<=PlayerCardCount(num)) { return null; }
            if (commonDeck.Count <= 0)
            {
                commonDeck = LoadData.GenStack(); // Deck reload!
            }
            Card c = commonDeck.Pop();
            cards[players[num]].Add(c);
            return c;
        }
        /// <summary>
        /// Method called to end the draw phase
        /// </summary>
        public void DrawPhaseEnded()
        {
            GameStatus = GameStatus.Playing;
        }
        /// <summary>
        /// Read-only access to the players' names
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <returns>The player's name</returns>
        public string PlayerName(int num) => players[num].Name;
        /// <summary>
        /// Read-only access to the players' scores
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <returns>The player's score</returns>
        public int PlayerScore(int num) => players[num].Points;
        /// <summary>
        /// Read-only access to the players' handsizes
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <returns>The player's hand's size</returns>
        public int PlayerHandSize(int num) => players[num].HandSize;
        /// <summary>
        /// Read-only access to the players' number of cards
        /// </summary>
        /// <param name="num">The number of the player</param>
        /// <returns>The player's number of cards</returns>
        public int PlayerCardCount(int num) => cards[players[num]].Count;

    }
}
