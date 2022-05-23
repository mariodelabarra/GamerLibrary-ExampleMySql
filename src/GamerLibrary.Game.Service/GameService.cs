using GamerLibrary.Common.Domain;
using GamerLibrary.Game.Repository;
using GameDomain = GamerLibrary.Game.Domain.Game;

namespace GamerLibrary.Game.Service
{
    public interface IGameService
    {
        /// <summary>
        /// Gets all entities from the table
        /// </summary>
        /// <returns>Collection of <see cref="GameDomain"/></returns>
        Task<IEnumerable<GameDomain>> ReadAllAsync();
    }

    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GameDomain>> ReadAllAsync()
        {
            throw new NotFoundException(nameof(Domain.Game), "123");

            //return await _gameRepository.ReadAllAsync();
        }
    }
}
