using Dapper;
using Final_Project__True_Coders_.Models;
using System.Data;

namespace Final_Project__True_Coders_
{
    public class GameRepository : IGameRepository
    {

        private readonly IDbConnection _conn;

        public GameRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _conn.Query<Game>("SELECT ListNumber, games.Name, games.GenreID, Platforms, IfEnds, IfFinished, HowLongToBeat FROM games_schema.games INNER JOIN genres ON games.GenreID = genres.GenreID ORDER BY ListNumber;");
        }

        public Game GetGame(int listNum)
        {

            return _conn.QuerySingle<Game>("SELECT * FROM GAMES WHERE listNumber = @listNum", new { listNum = listNum });
        }

        //Only need the Platforms and IfFinised need to be able to change because all the other paramaters for each game can't be diffrent from when it is first made
        public void UpdateGame(Game game)
        {
            _conn.Execute("UPDATE games SET  Platforms = @platforms, IfFinished = @ifFinished WHERE listNumber = @listNumber",
             new {  platforms = game.Platforms, ifFinished = game.IfFinished, listNumber = game.ListNumber });
        }

        // has all of the game paramaters because the game is being made from strach
        public void InsertGame(Game gameToInsert)
        {
            
            _conn.Execute("INSERT INTO games (NAME, GENREID, PLATFORMS, IFFINISHED, IFENDS, HOWLONGTOBEAT) VALUES (@name, @genreID, @platforms, @ifFinished, @ifEnds, @howLongToBeat);",
                new { name = gameToInsert.Name, genreID = gameToInsert.GenreID,  platforms = gameToInsert.Platforms, ifFinished = gameToInsert.IfFinished, ifEnds = gameToInsert.IfEnds, howLongToBeat = gameToInsert.HowLongToBeat});
        }
        
        public IEnumerable<Genre> GetAllGenres()
        {
            return _conn.Query<Genre>("SELECT * FROM genres;");
        }

        public Game AssignGenre()
        {
            
                var genreList = GetAllGenres();
                var game = new Game();
                game.Genres = genreList;
                return game;
            
        }
        public void DeleteGame(Game game)
        {
            _conn.Execute("DELETE FROM games WHERE ListNumber = @id;", new { id = game.ListNumber });
        }
    }
}
