using BlazorStore.Frontend.Models;

namespace BlazorStore.Frontend.Clients;

public class GamesClient
{
  public GameSummary[] Games => [.. games];

   public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        var gameSummary = new GameSummary
        {
            Id = games.Count() + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(gameSummary);
    }

    public void UpdateGame(GameDetails game){
        Genre genre = GetGenreById(game.GenreId);
        GameSummary existingGame = GetGameSummaryById(game.Id);
        existingGame.Name = game.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;
    }
  
    public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);
        var genre = genres.SingleOrDefault(genre => string.Equals(
            genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));
        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre?.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
    public void DeleteGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);
        games.Remove(game);
    }

  
    private readonly Genre[] genres=new GenresClient().GetGenres;
      private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

      private Genre GetGenreById(string? Id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Id);
        var genre = genres.Single(genre => genre.Id == int.Parse(Id));
        return genre;
    }

  private readonly List<GameSummary> games=[
  new(){
    Id=1,
    Name="Street fighter 2",
    Genre="Fighting",
    Price=19.99M,
    ReleaseDate=new DateOnly(1992,7,15)
  },
   new(){
    Id=2,
    Name="Final Fantrasy 1V",
    Genre="RolePlaying",
    Price=59.99M,
    ReleaseDate=new DateOnly(2010,9,30)
  },
   new(){
    Id=3,
    Name="FIFA 23",
    Genre="Sports",
    Price=69.99M,
    ReleaseDate=new DateOnly(2022,9,27)
  }

  ];
}
