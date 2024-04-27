using System.ComponentModel.DataAnnotations;

namespace BlazorStore.Frontend;

public class GameDetails
{
 public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
    [Required(ErrorMessage = "Genre is required")]
    public string? GenreId { get; set;}
    [Range(1,100)]
    public decimal Price    { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
