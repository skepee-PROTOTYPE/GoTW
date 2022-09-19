using GotwAPI.Context;
using GotwAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GotwAPI.Service
{
    public class CommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _commanderContext;

        public CommanderRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public async Task<CommandersDTO> GetCommanderSkill(Uri imgUri, string skill)
        {
            string IcoPath = string.Concat(imgUri.AbsoluteUri, "/Images/Types/");
            string CommanderPath = string.Concat(imgUri.AbsoluteUri, "/Images/Commanders/");

            IEnumerable<CommanderSkill> res = new List<CommanderSkill>();
            List<CommanderSkillDTO> commandersDTO = new();

            await Task.Run(() =>
            {
                res = _commanderContext.CommanderSkill.FromSqlRaw<CommanderSkill>("Execute CommanderSkills").ToList();

                if (res != null)
                {
                    if (!string.IsNullOrEmpty(skill))
                    {
                        res = res.Where(x => x.Skills.Contains(skill.ToLower())); 
                    }

                    foreach (var item in res)
                    {
                        commandersDTO.Add(new CommanderSkillDTO()
                        {
                            Name = item.Name,
                            Image = string.Concat(CommanderPath, item.Name.Replace(" ", "").Replace("'", ""), ".jpg"),
                            Type = item.Type,
                            ClassType = item.ClassType,
                            Skills = Helper.AddSkills(item),
                            Source = item.Source,
                            Notes = item.Notes
                        });
                    }
                }
             });

            return new CommandersDTO()
            {
                CommanderSkills = commandersDTO,
                CommanderTypes = new List<TypeDTO>() {
                    new TypeDTO(){ Name=CommanderType.Bowman.ToString(), Ico=string.Concat(IcoPath, CommanderType.Bowman.ToString() + ".jpg") },
                    new TypeDTO(){ Name=CommanderType.Cavalry.ToString(), Ico=string.Concat(IcoPath, CommanderType.Cavalry.ToString() + ".jpg") },
                    new TypeDTO(){ Name=CommanderType.Spearman.ToString(), Ico=string.Concat(IcoPath, CommanderType.Spearman.ToString() + ".jpg") },
                    new TypeDTO(){ Name=CommanderType.Infantry.ToString(), Ico=string.Concat(IcoPath, CommanderType.Infantry.ToString() + ".jpg") }
            }
            };
        }    
    }
}
