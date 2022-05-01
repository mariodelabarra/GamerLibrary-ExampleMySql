using GamerLibrary.Common.Domain;
using GamerLibrary.Common.Repository;
using GameDomain = GamerLibrary.Game.Domain.Game;

namespace GamerLibrary.Game.Repository
{
    public interface IGameRepository : IBaseEntityRepository<GameDomain>
    {
    }

    public class GameRepository : BaseEntityRepository<GameDomain>, IGameRepository
    {
        public GameRepository(GameDbContext dbContext) : base(dbContext)
        {
        }
    }
}
