using GotwAPI.Context;
using GotwAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace GotwAPI
{
    public enum CommanderSkillType
    {
        Fighting,
        Expedition, 
        TrainingGround,
        StrategicSkill,
        Weirwood,
        Awakening
    }


public static class Helper
    {
        public static IEnumerable<SkillDTO> AddSkills(CommanderSkill item)
        {
            var res = new List<SkillDTO>();

            if (item?.FightingId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Fighting.ToString(),
                    Value = item.Fighting
                });

            if (item?.ExpeditionId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Expedition.ToString(),
                    Value = item.Expedition
                });

            if (item?.TrainingGroundId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.TrainingGround.ToString(),
                    Value = item.TrainingGround
                });

            if (item?.StrategicSkillId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.StrategicSkill.ToString(),
                    Value = item.StrategicSkill
                });

            if (item?.WeirwoodId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Weirwood.ToString(),
                    Value = item.Weirwood
                });

            if (item?.AwakeningId != null)
                res.Add(new SkillDTO
                {
                    Name = CommanderSkillType.Awakening.ToString(),
                    Value = item.Awakening
                });

            return res.AsEnumerable();
        }

    }
}
