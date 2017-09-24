using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using GameRating.Model;

namespace GameRating.DataAccess
{
    public class GameRatingService
    {
        public GameRatingService()
        {

        }

        /// <summary>
        /// Get all game with avg. rating in descending order of rating.
        /// </summary>
        /// <returns>
        /// List of games with avg. rating of each game.
        /// </returns>
        public async Task<IEnumerable<Game>> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(GameRating.Base.ConfigSetting.DBConnStr))
            {
               return await conn.QueryAsync<Game>("Proc_GetAllGames");
            }
        }

        /// <summary>
        /// Get game with avg. rating in descending order of rating.
        /// </summary>
        /// <returns>
        /// List of games with avg. rating of each game.
        /// </returns>
        public async Task<Game> GetById(int gameId)
        {
            using (IDbConnection conn = new SqlConnection(GameRating.Base.ConfigSetting.DBConnStr))
            {
                return await conn.QueryFirstAsync<Game>("Proc_GetById", new  { gameId });
            }
        }

        /// <summary>
        /// Update description of a game.
        /// </summary>
        /// <param name="gameId">The game id</param>
        /// <param name="gameDescription">Description of the game</param>
        public void UpdateDesc(int gameId, string gameDescription)
        {
            using (IDbConnection conn = new SqlConnection(GameRating.Base.ConfigSetting.DBConnStr))
            {
                conn.ExecuteAsync("Proc_UpdateDesciption", 
                        new { gameId, gameDescription }, 
                            null,
                            null,
                            CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Add a new rating to the game
        /// </summary>
        /// <param name="gameId">The game id</param>
        /// <param name="rating">The rating  for the game.</param>
        public void AddRating(int gameId, int rating)
        {
            using (IDbConnection conn = new SqlConnection(GameRating.Base.ConfigSetting.DBConnStr))
            {
                conn.ExecuteAsync("Proc_AddRating",
                        new { gameId, rating },
                            null,
                            null,
                            CommandType.StoredProcedure);
            }
        }
    }
}
