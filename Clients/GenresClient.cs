using BlazorStore.Frontend.Models;

namespace BlazorStore.Frontend.Clients;

public class GenresClient
{
    public Genre[] GetGenres => genres;
  

       private readonly Genre[] genres = [
        new (){
            Id=1,
            Name="Fighting"
        },
        new (){
            Id=2,
            Name="RolePlaying"

        },
        new (){
            Id=3,
            Name="Sports"


        },
        new (){
            Id=4,
            Name="Racing",
        },
        new (){
            Id=5,
            Name="Kids and Family"
        }
    ];
}
