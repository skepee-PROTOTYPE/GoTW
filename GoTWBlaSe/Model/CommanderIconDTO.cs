namespace GoTWBlaSe.Model
{
    public record CommanderIconDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Image { get; set; } = String.Empty;
        public string ClassType { get; set; } = String.Empty;
        public SkillDTO Skill { get; set; }
    }
}
