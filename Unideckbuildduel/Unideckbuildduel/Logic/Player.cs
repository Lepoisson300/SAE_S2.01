namespace Unideckbuildduel.Logic
{
    /// <summary>
    /// A class for both players
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The player's number (0-1).
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// The player's score.
        /// </summary>
        public int Points { get; set; } = 0;
        /// <summary>
        /// The number of cards the player have at maximum.
        /// </summary>
        public int HandSize { get; set; } = 5;

    }
}