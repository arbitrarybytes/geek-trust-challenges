using GeekTrust.Models;
namespace GeekTrust.Contracts
{
    interface IUniverseBuilder
    {
        ///<summary>The current <see cref="Universe"/></summary>
        public Universe Universe { get; set; }

        ///<summary>Builds the <see cref="Universe"/> based on the provided name and aspirational kingdom</summary>
        ///<param name="name">the name of the universe</param>
        ///<param name="aspirationalKingdom">the aspiration kingdom who wants to rule (e.g Space)</param>
        public void Build(string name, string aspirationalKingdom);
    }
}
