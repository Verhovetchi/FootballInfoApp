using FootballInfoApp.Domain;

namespace FootballInfoApp.API.Dtos.Players
{
     public class PlayerDto
     {
          public string Name { get; set; }
          public string Surname { get; set; }
          public string PlayNumber { get; set; }
          public int Height { get; set; }
          public int Weight { get; set; }

          public Position Position { get; set; }
          public Country Country { get; set; }
          public Team Team { get; set; }
     }
}
