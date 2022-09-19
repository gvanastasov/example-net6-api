//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Repositories.Interfaces
{
    using System.Linq.Expressions;

    /// <summary>
    /// Base CRUD entity interface.
    /// </summary>
    /// <typeparam name="TEntity">Subject of repository.</typeparam>
    public interface IRepository<TEntity>
    {
         /// <summary>
        /// Query a (sub)set of entities.
        /// </summary>
        /// <param name="filter">Optional query filter.</param>
        /// <param name="orderBy">Optional query sort algorithm.</param>
        /// <param name="includeProperties">Optional query column filtering.</param>
        /// <returns>A collection of entities.</returns>
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Query entity by id.
        /// </summary>
        /// <param name="id">Entity primary key identifier.</param>
        /// <returns>Single entity or null.</returns>
        TEntity? GetByID(object id);

        /// <summary>
        /// Insert entity to context.
        /// </summary>
        /// <param name="entity">Entity to be inserted.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Delete entity from context by id.
        /// </summary>
        /// <param name="id">Entity primary key identifier.</param>
        void Delete(object id);

        /// <summary>
        /// Delete entity from context by reference.
        /// </summary>
        /// <param name="target">Entity reference.</param>
        void Delete(TEntity target);

        /// <summary>
        /// Update entity from context by reference.
        /// </summary>
        /// <param name="target">Entity reference.</param>
        void Update(TEntity target);
    }
}