using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unideckbuildduel.Logic;
using Unideckbuildduel.View;

namespace Unideckbuildduel.View
{
    /// <summary>
    /// A class for the main window for gameplay. One single instance.
    /// </summary>
    public partial class Window : Form
    {
        private readonly List<CardView> cardViews;
        private readonly List<List<BuildingView>> buildingViews;
        private Point playerOneCardStart;
        private Point playerTwoCardStart;
        private Point playerOneBuildingStart;
        private Point playerTwoBuildingStart;
        private Point playerOneBuildingCurrent;
        private Point playerTwoBuildingCurrent;
        public bool nextButtonState;

        /// <summary>
        /// A reference to the single instance of this class
        /// </summary>
        public static Window GetWindow { get; } = new Window();
        private Window()
        {
            InitializeComponent();
            ViewSettings.Rightmost = outputListBox.Left;
            cardViews = new List<CardView>();
            buildingViews = new List<List<BuildingView>>
            {
                new List<BuildingView>(),
                new List<BuildingView>()
            };
            playerOneCardStart = new Point(10, 10);
            playerTwoCardStart = new Point(10, 500);
            playerOneBuildingStart = new Point(25, 190);
            playerTwoBuildingStart = new Point(25, 370);
            playerOneBuildingCurrent=playerOneBuildingStart;
            playerTwoBuildingCurrent=playerTwoBuildingStart;
            nextButtonState = true;

        }
        /// <summary>
        /// Method called by the controler whenever some text should be displayed
        /// </summary>
        /// <param name="s"></param>
        public void WriteLine(string s)
        {
            List<string> strs = s.Split('\n').ToList();
            strs.ForEach(str => outputListBox.Items.Add(str));
            if (outputListBox.Items.Count > 0)
            {
                outputListBox.SelectedIndex = outputListBox.Items.Count - 1;
            }
            outputListBox.Refresh();
        }
        /// <summary>
        /// Method called to display a new building
        /// </summary>
        /// <param name="playerNumber">The number of the player</param>
        /// <param name="card">The card to base the building on</param>
        public void AddNewBuilding(int playerNumber, Card card)
        {
            Point point = playerNumber==0 ? playerOneBuildingCurrent : playerTwoBuildingCurrent;
            Point start = playerNumber == 0 ? playerOneBuildingStart : playerTwoBuildingStart;

            buildingViews[playerNumber].Add(BuildingView.MakeBuildingOrNull(card.CardType, point));
            point.Offset(ViewSettings.BuildSize.Width, 0);
            point.Offset(ViewSettings.Margin.Width, 0);
            if (point.X + ViewSettings.BuildSize.Width + ViewSettings.Margin.Width >= ViewSettings.Rightmost)
            {
                point.X = start.X;
                point.Y = point.Y + ViewSettings.BuildSize.Height + ViewSettings.Margin.Height;
            }

            if (playerNumber==0)
            {
                playerOneBuildingCurrent = point;
            } else
            {
                playerTwoBuildingCurrent = point;
            }
            Refresh();
        }
        /// <summary>
        /// Method called whenever the cards should be displayed
        /// </summary>
        /// <param name="playerNumber">The number of the player</param>
        /// <param name="cards">The cards to display for the player</param>
        public void CardsForPlayer(int playerNumber, List<Card> cards)
        {
            cardViews.Clear();
            Point point = playerNumber == 0 ? playerOneCardStart : playerTwoCardStart;
            int i = 0;
            Dictionary <CardType, int> cardsWithNumber = new Dictionary<CardType, int>();
            foreach (Card c in cards)
            {
                if (!cardsWithNumber.ContainsKey(c.CardType))
                {
                    cardsWithNumber.Add(c.CardType, 1);
                }
                else
                {
                    cardsWithNumber[c.CardType]++;
                }
            }
            foreach (CardType ct in cardsWithNumber.Keys)
            {
                Card ca = new Card
                {
                    CardType = ct,
                };
                cardViews.Add(new CardView(ca, point, i++, cardsWithNumber[ct]));
                point.Offset(ViewSettings.CardSize.Width, 0);
                point.Offset(ViewSettings.Margin.Width, 0);
            }
            Refresh();
        }
        #region Event handling
        private void Window_Paint(object sender, PaintEventArgs e)
        {
            foreach(CardView cv in cardViews) { cv.Draw(e.Graphics); }
            foreach (List<BuildingView> lbv in buildingViews)
            {
                foreach (BuildingView bv in lbv) { bv.Draw(e.Graphics); }
            }
            playerOneScoreLabel.Text = Controller.GetControler.NumberOfTurns;
            playerTwoScoreLabel.Text = Controller.GetControler.PlayerOneScore;
            turnLabel.Text = Controller.GetControler.PlayerTwoScore;
            DiscardSize.Text = "Taille de la défausse : " + Game.GetGame.discardStack.Count;
            DeckSize.Text = "Taille de la pioche : " + Game.GetGame.commonDeck.Count;
            if (nextButtonState)
                nextTurnButton.Text = "Next Turn";
            else
                nextTurnButton.Text = "Next Phase";
            if (Game.GetGame.listDict[Game.GetGame.CurrentPlayer][Effect.DrawOncePerTurn] && !Controller.GetControler.hasDrawnFromDeck)
            {
                drawOncePerTurn.Visible = true;
                drawOncePerTurn.Enabled = true;
                DeckSize.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                drawOncePerTurn.Visible = false;
                drawOncePerTurn.Enabled = false;
                DeckSize.BorderStyle = BorderStyle.None;
            }
            if (Game.GetGame.listDict[Game.GetGame.CurrentPlayer][Effect.DrawFromDiscardOncePerTurn] && !Controller.GetControler.hasDrawnFromDiscard)
            {
                DrawFromDiscardButton.Visible = true;
                DrawFromDiscardButton.Enabled = true;
                DiscardSize.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                DrawFromDiscardButton.Visible = false;
                DrawFromDiscardButton.Enabled = false;
                DiscardSize.BorderStyle = BorderStyle.None;
            }
            affichageEffect();
        }

        private void affichageEffect()
        {
            ActiveEffectListBox.Items.Clear();
            ActiveEffectListBox.Items.Add("List des Effets actifs");
            Game g = Game.GetGame;
            foreach (Effect? e in g.listDict[g.CurrentPlayer].Keys)
            {
                if (g.listDict[g.CurrentPlayer][e])
                    ActiveEffectListBox.Items.Add(e.ToString());
            }
        }

        private void NextTurnButton_Click(object sender, EventArgs e)
        {
            if (nextButtonState)
            {
                string message = "Are you sure, that you want end turn?";
                string title = "End turn";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                    Controller.GetControler.EndTurn();
            }
            else
            {
                string message = "Are you sure, that you want end playing phase?";
                string title = "End phase";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                    Game.GetGame.NextPhase();
            }
            Refresh();
        }


        public void disableButton()
        {
            nextTurnButton.Enabled = false;
            replayButton.Enabled = true;
        }


        private void QuitButton_Click(object sender, EventArgs e)
        {
            string message = "Are you sure, that you want quit?";
            string title = "Quit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes) 
                Application.Exit();
        }
        #endregion

        private void replayButton_Click(object sender, EventArgs e)
        {
            Controller.GetControler.StartEverything();
            nextTurnButton.Enabled = true;
            replayButton.Enabled = false;
            buildingViews[0].Clear();
            buildingViews[1].Clear();

            playerOneCardStart = new Point(10, 10);
            playerTwoCardStart = new Point(10, 500);
            playerOneBuildingStart = new Point(25, 190);
            playerTwoBuildingStart = new Point(25, 370);
            playerOneBuildingCurrent = playerOneBuildingStart;
            playerTwoBuildingCurrent = playerTwoBuildingStart;

            Refresh();
        }

        public int SelectCard(Point loc)
        {
            int num = -1;
            Game g = Game.GetGame;
            foreach (CardView c in cardViews)
            {
                if (c.GetRectangle().Contains(loc))
                {
                    for (int i = 0; i < g.cards[g.players[g.CurrentPlayer]].Count; i++)
                    {
                        if (c.card.CardType.Name == g.cards[g.players[g.CurrentPlayer]][i].CardType.Name)
                            num = i;
                    }
                }
            }
            return num;
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            int num = SelectCard(e.Location);
            Controller c = Controller.GetControler;
            Game g = Game.GetGame;


            if (num != -1)
            {
                if (Game.GetGame.GameStatus == GameStatus.Playing)
                {
                    string s = g.cards[g.players[c.CurrentPlayer]][num].CardType.Name;
                    if (e.Button == MouseButtons.Left)
                        c.PlayCard(c.CurrentPlayer, num);
                    if (e.Button == MouseButtons.Right)
                    {
                        if (Controller.IsTradable(g.cards[g.players[c.CurrentPlayer]][num]))
                        {
                            c.DiscardCard(c.CurrentPlayer, num);
                            c.Echange(s);
                        }
                    }
                }
                else if (Game.GetGame.GameStatus == GameStatus.Discarding)
                {
                    c.DiscardCard(c.CurrentPlayer, num);
                }
            }
        }

        private void drawOncePerTurn_Click(object sender, EventArgs e)
        {
            Controller c = Controller.GetControler;
            c.hasDrawnFromDeck = true;
            Game g = Game.GetGame;
            foreach(Card ca in g.buildings[g.players[g.CurrentPlayer]])
            {
                if (ca.CardType.Effect == Effect.DrawOncePerTurn)
                {
                    WriteLine( g.PlayerName(c.CurrentPlayer) + " draws " + ca.CardType.EffectCard.Name + " from Deck");
                    Card card = Game.GetGame.drawFromDeck(ca.CardType.EffectCard.Name);
                }
            }
            Refresh();

        }


        private void DrawFromDiscardButton_Click(object sender, EventArgs e)
        {
            Controller c = Controller.GetControler;
            c.hasDrawnFromDiscard = true;
            Game g = Game.GetGame;
            foreach (Card ca in g.buildings[g.players[g.CurrentPlayer]])
            {
                if (ca.CardType.Effect == Effect.DrawFromDiscardOncePerTurn)
                {
                    WriteLine(g.PlayerName(c.CurrentPlayer) + " draws " + ca.CardType.EffectCard.Name + "from Discard");
                    Card card = Game.GetGame.drawFromDiscard(ca.CardType.EffectCard.Name);
                }
            }
            Refresh();
        }


        private void DeckSize_Click(object sender, EventArgs e)
        {
            if (Game.GetGame.listDict[Game.GetGame.CurrentPlayer][Effect.DrawOncePerTurn] && !Controller.GetControler.hasDrawnFromDeck)
            {
                Controller.GetControler.hasDrawnFromDeck = true;
                drawOncePerTurn_Click(sender, e);
                DeckSize.BorderStyle = BorderStyle.None;
            }
        }

        private void DiscardSize_Click(object sender, EventArgs e)
        {
            if (Game.GetGame.listDict[Game.GetGame.CurrentPlayer][Effect.DrawFromDiscardOncePerTurn] && !Controller.GetControler.hasDrawnFromDeck)
            {
                Controller.GetControler.hasDrawnFromDiscard = true;
                DrawFromDiscardButton_Click(sender, e);
                DiscardSize.BorderStyle = BorderStyle.None;
            }
        }
    }
}
