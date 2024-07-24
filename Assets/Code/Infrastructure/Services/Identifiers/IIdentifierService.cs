namespace AbilityMadness.Code.Infrastructure.Services.Identifiers
{
    public interface IIdentifierService
    {
        int Next(Identity identity);
        void Reset();
        int Next();
    }
}
