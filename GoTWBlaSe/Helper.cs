using GoTWBlaSe.Model;
using System.Collections.Generic;
using System.Linq;

namespace GoTWBlaSe
{
    public static class Helper 
    {
        public static IEnumerable<CommanderIconDTO> CommanderSkillDetail(this IEnumerable<CommanderSkillDTO> commanders)
        {
            return commanders.Select(a =>
               new CommanderIconDTO()
               {
                   Name = a.Name,
                   Image = a.Image,
                   ClassType = a.ClassType,
                   Skill = a.Skills.FirstOrDefault()!
               }).OrderByDescending(x => x.Skill.Value).ToList();
        }

        public static string apiAddress { get; set; }=String.Empty;
    }
}
