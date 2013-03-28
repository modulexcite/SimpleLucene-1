using System;
using Lucene.Net.Documents;

namespace SimpleLucene
{
    public class DelegateSearchResultDefinition<T> : IResultDefinition<T>
    {
        private readonly Func<Document, T> converter;
        public DelegateSearchResultDefinition(Func<Document, T> converter)
        {
            this.converter = converter;
        }

        public T Convert(Document document)
        {
            return converter(document);
        }
    }
}
