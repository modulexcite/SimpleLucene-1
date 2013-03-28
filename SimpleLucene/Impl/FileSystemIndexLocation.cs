using System.IO;
using SimpleLucene.Utils;

namespace SimpleLucene.Impl
{
    /// <summary>
    /// Represents a file sytem based index location
    /// </summary>
    public class FileSystemIndexLocation : BaseIndexLocation
    {
        private readonly DirectoryInfo directoryInfo;
        
        public FileSystemIndexLocation(DirectoryInfo directoryInfo) {
            Helpers.EnsureNotNull(directoryInfo, "directoryInfo");
            this.directoryInfo = directoryInfo;
        }

        public override string GetPath() {
            return directoryInfo.FullName;
        }
    }
}
