//-----------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Repositories
{
    using System.Linq.Expressions;

    using ExampleNet6Api.Context.Repositories.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Base CRUD entity interface.
    /// </summary>
    /// <typeparam name="TEntity">Subject of repository.</typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DataContext context;
        private readonly DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public BaseRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Query a (sub)set of entities.
        /// </summary>
        /// <param name="filter">Optional query filter.</param>
        /// <param name="orderBy">Optional query sort algorithm.</param>
        /// <param name="includeProperties">Optional query column filtering.</param>
        /// <returns>A collection of entities.</returns>
        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in
                includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        /// <summary>
        /// Query entity by id.
        /// </summary>
        /// <param name="id">Entity primary key identifier.</param>
        /// <returns>Single entity or null.</returns>
        public virtual TEntity? GetByID(object id)
        {
            return id != null
                ? this.dbSet.Find(id)
                : throw new ArgumentNullException(nameof(id));
        }

        /// <summary>
        /// Insert entity to context.
        /// </summary>
        /// <param name="entity">Entity to be inserted.</param>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.dbSet.Add(entity);
        }

        /// <summary>
        /// Delete entity from context by id.
        /// </summary>
        /// <param name="id">Entity primary key identifier.</param>
        public virtual void Delete(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            TEntity? target = this.dbSet.Find(id);

            if (target == null)
            {
                throw new ArgumentException(nameof(target));
            }

            this.Delete(target);
        }

        /// <summary>
        /// Delete entity from context by reference.
        /// </summary>
        /// <param name="target">Entity reference.</param>
        public virtual void Delete(TEntity target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (this.context.Entry(target).State == EntityState.Detached)
            {
                this.dbSet.Attach(target);
            }

            this.dbSet.Remove(target);
        }

        /// <summary>
        /// Update entity from context by reference.
        /// </summary>
        /// <param name="target">Entity reference.</param>
        public virtual void Update(TEntity target)
        {
            this.dbSet.Attach(target);
            this.context.Entry(target).State = EntityState.Modified;
        }
    }
}