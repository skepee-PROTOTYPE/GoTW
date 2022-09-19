using System.ComponentModel.DataAnnotations;

namespace GotwAPI.Context
{
    public record CommanderSkill
    {
        [Key]
        public int CommanderId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string ClassType { get; set; } = String.Empty;
        public int FightingId { get; set; }
        public string Fighting { get; set; } = String.Empty;
        public int ExpeditionId { get; set; }
        public string Expedition { get; set; } = String.Empty;
        public int TrainingGroundId { get; set; }
        public string TrainingGround { get; set; } = String.Empty;
        public int StrategicSkillId { get; set; }
        public string StrategicSkill { get; set; } = String.Empty;
        public int WeirwoodId { get; set; }
        public string Weirwood { get; set; } = String.Empty;
        public int AwakeningId { get; set; }
        public string Awakening { get; set; } = String.Empty;
        public string Skills { get; set; } = String.Empty;
        public string Source { get; set; } = String.Empty;
        public string Notes { get; set; } = String.Empty;
    }
}
