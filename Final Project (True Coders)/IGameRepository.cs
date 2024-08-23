using Final_Project__True_Coders_.Models;

namespace Final_Project__True_Coders_
{
    public interface IGameRepository
    {
        public IEnumerable<Game> GetAllGames();
        public Game GetGame(int listNum);
        public void UpdateGame(Game game);
        public void InsertGame(Game gameToInsert);
        public IEnumerable<Genre> GetAllGenres();
        public Game AssignGenre();
        public void DeleteGame(Game game);
    }
}
