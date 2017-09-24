namespace GameRating.Model
{
    public class Game
    {
        /// <summary>
        /// Gets or Sets the primary key of Game
        /// </summary>
        /// <value>
        /// the primary key of the Game
        /// </value>
        public int GameID { get; set; }

        /// <summary>
        /// Gets or sets the name of game
        /// </summary>
        /// <value>
        /// Name of the game
        /// </value>
        public string GameName { get; set;  }

        /// <summary>
        /// Gets or sets the description of the game
        /// </summary>
        /// <value>
        /// The description of the game
        /// </value>
        public string GameDescription { get; set; }

        /// <summary>
        /// Gets or sets the rating of the game
        /// </summary>
        /// <value>
        /// The rating of the game
        /// </value>
        public float GameRating { get; set; }
    }
}
