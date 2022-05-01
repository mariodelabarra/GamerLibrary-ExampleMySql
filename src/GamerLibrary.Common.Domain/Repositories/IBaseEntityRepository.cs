namespace GamerLibrary.Common.Domain
{
    public interface IBaseEntityRepository<TBaseEntity>
        where TBaseEntity : BaseEntity
    {
        /// <summary>
        /// Gets all entities from the table
        /// </summary>
        /// <returns>Collection of <see cref="TBaseEntity"/></returns>
        Task<IEnumerable<TBaseEntity>> ReadAllAsync();
    }
}
