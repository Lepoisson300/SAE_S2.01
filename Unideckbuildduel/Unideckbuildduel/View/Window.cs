using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            foreach (Card c in cards)
            {
                cardViews.Add(new CardView(c, point, i++));
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
        }

        private void NextTurnButton_Click(object sender, EventArgs e)
        {
            Controller.GetControler.EndTurn();
        }

        private void PlaceAllButton_Click(object sender, EventArgs e)
        {
            Controller.GetControler.PlaceAllCards();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
