using DCT.Persistence.Enums;
using DCT.Persistence.Shared;

namespace DCT.Persistence.Entities
{
    public class Municipality: Entity
    {
        public string Name { get; set; }
        public RuleKeyEnum RuleKey { get; set; }
    }
}
