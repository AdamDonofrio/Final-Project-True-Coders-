
namespace Final_Project__True_Coders_.Models
{
    public class GameGenresViewGameModel
    {

        public IEnumerable<Genre> ModelGenres { get; set; }
        public IEnumerable<Game> ModelGames { get; set; }

        public int ListNumber { get; set; }

        public string? Name { get; set; }
    }
}
