using System.Collections.Generic;

namespace GoTWBlaSe.Model
{
    public record CommandersDTO
    {
        public IEnumerable<CommanderSkillDTO> CommanderSkills { get; set; }
        public IEnumerable<TypeDTO> CommanderTypes { get; set; }
    }
}
