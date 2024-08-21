namespace AbilityMadness.Code.Infrastructure.Identifiers
{
    public interface IIdentifierService
    {
        int Next(Identity identity);
        void Reset();
        int Next();
    }
}
