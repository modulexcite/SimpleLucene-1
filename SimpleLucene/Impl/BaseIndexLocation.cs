using System;

namespace SimpleLucene.Impl
{
    /// <summary>
    /// A base class for index locations.
    /// </summary>
    public abstract class BaseIndexLocation : IIndexLocation
    {
        public abstract string GetPath();

        /// <summary>
        /// Compares the index location based on it's path
        /// </summary>
        public virtual bool Equals(IIndexLocation other) {
            if (other == null) return false;
            return (other.GetPath().Equals(this.GetPath(), StringComparison.InvariantCultureIgnoreCase));
        }

        public override bool Equals(object obj) {
            return Equals(obj as IIndexLocation);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
