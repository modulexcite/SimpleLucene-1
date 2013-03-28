using System.IO;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SimpleLucene.Utils;

namespace SimpleLucene.Impl
{
    /// <summary>
    /// A searcher for directory based indexes
    /// </summary>
    public class DirectoryIndexSearcher : IIndexSearcher
    {
        private readonly DirectoryInfo indexLocation;
        private readonly bool readOnly;

        public DirectoryIndexSearcher(DirectoryInfo indexLocation, bool readOnly = true) {
            Helpers.EnsureNotNull(indexLocation, "indexLocation");
            Helpers.EnsureNotNull(indexLocation, "readOnly");
            this.indexLocation = indexLocation;
            this.readOnly = readOnly;
        }

        /// <summary>
        /// Creates the underlying Lucene searcher.
        /// </summary>
        /// <returns>A Lucene Searcher</returns>
        public Searcher Create() {
            var fsDirectory = FSDirectory.Open(indexLocation);
            return new IndexSearcher(fsDirectory, true);
        }
    }
}
