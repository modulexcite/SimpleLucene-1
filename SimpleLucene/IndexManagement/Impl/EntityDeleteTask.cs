using Lucene.Net.Index;
using SimpleLucene.Utils;

namespace SimpleLucene.IndexManagement
{
    /// <summary>
    /// A task for removing an entity from an index
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to remove</typeparam>
    public class EntityDeleteTask<TEntity> : IIndexTask where TEntity : class {
        protected readonly Term term;

        public EntityDeleteTask(IIndexLocation indexLocation, string fieldName, string value) {
            
            Helpers.EnsureNotNull(indexLocation, "indexLocation");
            Helpers.EnsureNotNull(fieldName, "fieldName");
            Helpers.EnsureNotNull(value, "value");

            this.IndexOptions = new IndexOptions { IndexLocation = indexLocation };
            this.term = new Term(fieldName, value);
        }

        public void Execute(IIndexService indexService) {
            indexService.Remove(term);
        }

        public IndexOptions IndexOptions { get; set; }
    }
}
