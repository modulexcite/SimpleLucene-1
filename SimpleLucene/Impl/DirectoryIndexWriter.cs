﻿using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using SimpleLucene.Utils;

namespace SimpleLucene.Impl
{
    /// <summary>
    /// A writer for directory based indexes
    /// </summary>
    public class DirectoryIndexWriter : IIndexWriter
    {
        public DirectoryIndexWriter(DirectoryInfo indexLocation, bool recreateIndex = false)
            : this(indexLocation, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), recreateIndex)
        { }

        public DirectoryIndexWriter(DirectoryInfo indexLocation, Analyzer analyzer, bool recreateIndex = false) {
            Helpers.EnsureNotNull(indexLocation, "indexLocation");
            Helpers.EnsureNotNull(recreateIndex, "recreateIndex");
            Helpers.EnsureNotNull(analyzer, "analyzer");
            
            this.IndexOptions = new IndexOptions {
                IndexLocation = new FileSystemIndexLocation(indexLocation),
                RecreateIndex = recreateIndex,
                Analyzer = analyzer
            };
        }

        public IndexOptions IndexOptions { get; set; }

        /// <summary>
        /// Creates the underlying Lucene index writer.
        /// </summary>
        /// <returns>A Lucene Index Writer </returns>
        public IndexWriter Create() {
            var fsDirectory = FSDirectory.Open(IndexOptions.IndexLocation.GetDirectory());

            var recreateIndex = this.IndexOptions.RecreateIndex;

            if (!recreateIndex) // then we should create anyway
                recreateIndex = !(IndexReader.IndexExists(fsDirectory));

            return new IndexWriter(fsDirectory,
                                        IndexOptions.Analyzer,
                                        recreateIndex,
                                        IndexWriter.MaxFieldLength.UNLIMITED);
        }
    }
}
