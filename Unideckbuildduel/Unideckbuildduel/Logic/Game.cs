using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unideckbuildduel.Logic.GameData;

namespace Unideckbuildduel.Logic
{
    /// <summary>
    /// A class used for the game's logic. One single instance at a time.
    /// </summary>
    public class Game
    {
        public Stack<Card> commonDeck;
        public Stack<Card> discardStack;
        public List<Player> players;
        public Dictionary<Player, List<Card>> cards;
        public Dictionary<Player, List<Card>> buildings;

        public List<HashSet<Card>> substitutesList;

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

        public List<Dictionary<Effect?, bool>> listDict = new List<Dictionary<Effect?, bool>>();

        public Dictionary<Effect?, bool> effectDictP1 = new Dictionary<Effect?, bool>();

        public Dictionary<Effect?, bool> effectDictP2 = new Dictionary<Effect?, bool>();

        private Game() {}
        /// <summary>
        /// Method used to launch a new game (at startup or after)
        /// </summary>
        public void NewGame(string playerOneName, string playerTwoName)
        {
            commonDeck = LoadData.GenStack();
            discardStack = new Stack<Card>();
            players = new List<Player> { new Player { Name = playerOneName }, new Player { Name = playerTwoName } };
            cards = new Dictionary<Player, List<Card>>();
            buildings = new Dictionary<Player, List<Card>>();

            substitutesList = new List<HashSet<Card>>();
            substitutesList.Add(new HashSet<Card>());
            substitutesList.Add(new HashSet<Card>());

            initialiseDict();
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

        public void initialiseDict()
        {
            listDict.Add(effectDictP1);
            listDict.Add(effectDictP2);
            foreach(Dictionary<Effect?, bool> d in listDict)
            {
                foreach (Effect? e in Effect.GetValues(typeof(Effect)))
                {
                    d[e] = false;
                }
            }
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
                    var reqRs = card.CardType.RequiredRessources;

                    bool reqBok = true;
                    bool reqRok = true;
                    if (reqBs != null && reqBs.Count > 0)
                    {
                        foreach (CardType b in reqBs.Keys)
                        {
                            int presB = NumberOfCardsPresent(buildings[players[playerNum]], b);
                            if (presB < reqBs[b])
                            {
                                reqBok = false;
                            }
                        }

                    }
                    if (reqRs != null && reqRs.Count > 0)
                    {
                        foreach (CardType r in reqRs.Keys)
                        {
                            int presR = NumberOfCardsPresent(cards[players[playerNum]], r);
                            if (presR < reqRs[r] && !IsSubstitued(r))
                            {
                                reqRok = false;
                            }
                        }
                    }
                    if (!reqBok)
                    {
                        return ("Not enough required buildings", false);
                    }
                    else if (!reqRok)
                    {
                        return ("Not enough required ressources", false);
                    }

                    if (reqRs != null && reqRs.Count > 0)
                    {
                        foreach(CardType r in reqRs.Keys)
                        {
                            if (!IsSubstitued(r))
                            {
                                int num = 0;
                                int i = 0;
                                while (i < cards[players[playerNum]].Count && num < reqRs[r])
                                {
                                    if (cards[players[playerNum]][i].CardType.Equals(r))
                                    {
                                        discardStack.Push(cards[players[playerNum]][i]);
                                        cards[players[playerNum]].Remove(cards[players[playerNum]][i]);
                                        num++;
                                    }
                                    i++;
                                }
                            }
                        }
                    }

                    if (commonDeck.Count == 0 && discardStack.Count != 0)
                    {
                        discardStack = Shuffle(discardStack);
                        while(discardStack.Count > 0)
                        {
                            Card c = discardStack.Pop();
                            commonDeck.Push(c);
                        }
                    }

                    if (card.CardType.Effect != null)
                        newEffect(card.CardType.Effect, card);

                    buildings[players[playerNum]].Add(card);
                    cards[players[playerNum]].Remove(card);
                    players[playerNum].Points += card.CardType.Points;
                    Controller.GetControler.NewBuilding(playerNum, card);
                    Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
                    return (null, true);
                    
                case Kind.Action:
                    discardStack.Push(card);
                    cards[players[playerNum]].Remove(card);
                    if (card.CardType.Effect != null)
                        newEffect(card.CardType.Effect, card);
                    Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
                    return (null, true);
                case Kind.Ressource:
                    return ("Ressource card cannot be played", false);
                default:
                    return ("Card type not handled yet", false);
            }
        }

        public void newEffect(Effect? e, Card c)
        {
            listDict[CurrentPlayer][e] = true;
            useEffect(e, c);
        }

        public void useEffect(Effect? effect, Card c)
        {
            switch (effect)
            { 
                case Effect.OneMoreCard:
                    {
                        if (players[CurrentPlayer].HandSize != 6)
                        {
                            players[CurrentPlayer].HandSize++;
                            Controller.GetControler.WriteOneMoreCard();
                        }
                        break;
                    }
                case Effect.PlayAgain:
                    {
                        Controller.GetControler.WritePlayAgain();
                        GameStatus = GameStatus.Drawing;
                        Play();
                        listDict[CurrentPlayer][effect] = false;
                        break;
                    }
                case Effect.Substitute:
                    {
                        Controller.GetControler.WriteSubstitute(c.CardType.EffectCard.Name);
                        substitutesList[CurrentPlayer].Add(c);
                        break;
                    }
                default:
                    break;
            }
        }

        public static Stack<Card> Shuffle(Stack<Card> stack)
        {
            Random rng = new Random();
            var values = stack.ToArray();
            stack.Clear();
            foreach (var value in values.OrderBy(x => rng.Next()))
                stack.Push(value);
            return stack;
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
                    if (!Controller.gameOver)
                        Play();
                    break;
            }
        }

        public void NextPhase()
        {
            if (GameStatus == GameStatus.Playing)
                GameStatus = GameStatus.Discarding;
            Play();
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
            discardStack.Push(card);
            bool res =  cards[players[playerNum]].Remove(card);
            Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
            return res;
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
            Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
            return c;
        }

        public Card drawFromDeck(string s)
        {
            bool res = true;
            int i = 0;
            Card ca = null;
            while (i < commonDeck.Count && res)
            {
                if (commonDeck.ElementAt(i).CardType.Name == s)
                {
                    ca = commonDeck.ElementAt(i);
                    cards[players[CurrentPlayer]].Add(commonDeck.ElementAt(i));
                    res = false;
                }
                i++;
            }
            Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
            return ca;
        }

        public Card drawFromDiscard(string s)
        {
            bool res = true;
            int i = 0;
            Card ca = null;
            while (i < discardStack.Count && res)
            {
                if (discardStack.ElementAt(i).CardType.Name == s)
                {
                    ca = discardStack.ElementAt(i);
                    cards[players[CurrentPlayer]].Add(discardStack.ElementAt(i));
                    res = false;
                }
                i++;
            }
            Controller.GetControler.DisplayHand(CurrentPlayer, cards[players[CurrentPlayer]]);
            return ca;
        }

        public bool IsSubstitued(CardType ct)
        {
            bool res = false;
            foreach (Card ca in substitutesList[CurrentPlayer])
            {
                if (ca.CardType.EffectCard == ct)
                {
                    res = true;
                    break;
                }
            }
            return res;
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
