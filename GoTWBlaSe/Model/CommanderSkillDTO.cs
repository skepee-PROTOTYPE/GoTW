using System.Collections.Generic;

namespace GoTWBlaSe.Model
{
    public record CommanderSkillDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Image { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string ClassType { get; set; } = String.Empty;
        public IEnumerable<SkillDTO> Skills { get; set; }
        public string Source { get; set; } = String.Empty;
        public string Notes { get; set; } = String.Empty;
    }
}
