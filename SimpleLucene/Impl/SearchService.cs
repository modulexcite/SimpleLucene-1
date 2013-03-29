using System.Linq;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using SimpleLucene.Utils;

namespace SimpleLucene.Impl
{
    /// <summary>
    /// Default search service implementation
    /// </summary>
    public class SearchService : ISearchService {
        private bool _isDisposed;
        private readonly IIndexSearcher _indexSearcher;
        private Searcher _luceneSearcher;

        public SearchService(IIndexSearcher indexSearcher) {
            Helpers.EnsureNotNull(indexSearcher, "indexSearcher");
            this._indexSearcher = indexSearcher;
        }

        /// <summary>
        /// Searches an index using the provided query
        /// </summary>
        /// <param name="query">A Lucene query to use for the search</param>
        /// <returns>A search result containing Lucene documents</returns>
        public SearchResult<Document> SearchIndex(Query query) {
            return SearchIndex(query, new DocumentResultDefinition());
        }

        /// <summary>
        /// Searches an index using the provided query and returns a strongly typed result object
        /// </summary>
        /// <typeparam name="T">The type of result object to return</typeparam>
        /// <param name="query">A Lucene query to use for the search</param>
        /// <param name="definition">A search definition used to transform the returned Lucene documents</param>
        /// <returns>A search result object containing both Lucene documents and typed objects based on the definition</returns>
        public SearchResult<T> SearchIndex<T>(Query query, IResultDefinition<T> definition) {
            var searcher = GetSearcher();
            var collector = TopScoreDocCollector.Create(25000, true);
            searcher.Search(query, collector);
            var results = collector.TopDocs().ScoreDocs.Select(h => searcher.Doc(h.Doc));
            return new SearchResult<T>(results, definition);
        }

        public void Dispose() {
            if (!_isDisposed && _luceneSearcher != null)
                _luceneSearcher.Dispose();
            _luceneSearcher = null;
        }

        protected Searcher GetSearcher() {
            if (_isDisposed)
                _isDisposed = false;

            if (_luceneSearcher == null)
                _luceneSearcher = _indexSearcher.Create();

            return _luceneSearcher;
        }
    }
}
