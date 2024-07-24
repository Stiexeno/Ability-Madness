using System.Collections.Generic;

namespace AbilityMadness.Code.Infrastructure.Services.Identifiers
{
    public enum Identity{ General }
    public class IdentifierService : IIdentifierService
    {
        private Dictionary<Identity, int> idenrifiers = new Dictionary<Identity, int>();

        public int Next(Identity identity)
        {
            if (idenrifiers == null)
            {
                idenrifiers = new Dictionary<Identity, int>();
            }

            int last = idenrifiers.TryGetValue(identity, out int idenrifier) ? idenrifier : 0;
            int next = ++last;

            idenrifiers[identity] = next;

            return next;
        }

        public int Next()
        {
            if (idenrifiers == null)
            {
                idenrifiers = new Dictionary<Identity, int>();
            }

            int last = idenrifiers.TryGetValue(Identity.General, out int idenrifier) ? idenrifier : 0;
            int next = ++last;

            idenrifiers[Identity.General] = next;

            return next;
        }

        public void Reset() => idenrifiers.Clear();
    }
}
