using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoTW.API.Model
{
    public class CommanderSkill
    {
        [Key]
        public int CommanderId { get; set; }
        public string Name { get; set; }
        //public string Image { get; set; }
        public string Type { get; set; }
        public string ClassType { get; set; }
        public int FightingId { get; set; }
        public string Fighting { get; set; }

        public IEnumerable<SkillDTO> Skills { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }



    }
}
