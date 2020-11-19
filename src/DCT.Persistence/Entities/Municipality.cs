using DCT.Persistence.Enums;

namespace DCT.Persistence.Entities
{
    public class Municipality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RuleKeyEnum RuleKey { get; set; }
    }
}
