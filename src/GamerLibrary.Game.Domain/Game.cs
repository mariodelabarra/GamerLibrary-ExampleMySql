using GamerLibrary.Common.Domain;

namespace GamerLibrary.Game.Domain
{
    public class Game : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ReleasedDate { get; set; }
    }
}
