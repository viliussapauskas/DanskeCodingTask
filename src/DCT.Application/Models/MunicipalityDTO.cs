using DCT.Persistence.Enums;

namespace DCT.Application.Models
{
    public class MunicipalityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RuleKeyEnum RuleKey { get; set; }
    }
}
