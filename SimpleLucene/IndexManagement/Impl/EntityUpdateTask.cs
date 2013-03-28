using SimpleLucene.Utils;

namespace SimpleLucene.IndexManagement
{
    /// <summary>
    /// An task for reindexing an entity
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to index</typeparam>
    public class EntityUpdateTask<TEntity> : IIndexTask where TEntity : class
    {
        protected readonly TEntity entity;
        protected readonly IIndexDefinition<TEntity> definition;

        public EntityUpdateTask(TEntity entity, IIndexDefinition<TEntity> definition, IIndexLocation indexLocation)
        {
            Helpers.EnsureNotNull(indexLocation, "indexLocation");
            Helpers.EnsureNotNull(entity, "entity");
            Helpers.EnsureNotNull(definition, "definition");           
            
            this.entity = entity;
            this.definition = definition;
            this.IndexOptions = new IndexOptions { IndexLocation = indexLocation};
        }

        public void Execute(IIndexService indexService) {
            var result = indexService.IndexEntity(entity, definition);
        }

        public IndexOptions IndexOptions { get; set; }
    }
}
