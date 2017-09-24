using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameRating.Controllers
{
    public class GameRatingController : ApiController
    {
        /// <summary>
        /// Gets all games with avg. rating of each game
        /// </summary>
        /// <returns>List of games</returns>
        [HttpGet]
        [ActionName("GetAll")]
        public Task<IEnumerable<GameRating.Model.Game>> GetAllGames()
        {
            var gameService = new DataAccess.GameRatingService();
            return gameService.GetAll();
        }

        /// <summary>
        /// Gets games with avg. rating of each game
        /// </summary>
        /// <returns>List of games</returns>
        [HttpGet]
        [ActionName("GetById")]
        public Task<GameRating.Model.Game> GetById(int gameId)
        {
            var gameService = new DataAccess.GameRatingService();
            return gameService.GetById(gameId);
        }

        /// <summary>
        /// Update description of a game
        /// </summary>
        /// <param name="gameId">the game id</param>
        /// <param name="description">The description of the game</param>
        [HttpGet]
        [ActionName("UpdateDescription")]
        public void UpdateDescription(int gameId, string description)
        {
            var gameService = new DataAccess.GameRatingService();
            gameService.UpdateDesc(gameId, description);
        }

        /// <summary>
        /// Add new rating for the game
        /// </summary>
        /// <param name="gameId">The game id</param>
        /// <param name="rating">The rating of game</param>
        [HttpGet]
        [ActionName("AddRating")]
        public void AddRating(int gameId, int rating)
        {
            var gameService = new DataAccess.GameRatingService();
            gameService.AddRating(gameId, rating);
        }
    }
}
