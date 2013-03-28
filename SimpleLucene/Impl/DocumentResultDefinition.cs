using Lucene.Net.Documents;

namespace SimpleLucene.Impl
{
    /// <summary>
    /// A simple result definition for untyped searches (just returns the Lucene document)
    /// </summary>
    public class DocumentResultDefinition : IResultDefinition<Document> {
        public Document Convert(Document document) {
            return document;
        }
    }
}
