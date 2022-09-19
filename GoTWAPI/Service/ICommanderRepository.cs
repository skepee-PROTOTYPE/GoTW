using GotwAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GotwAPI.Service
{
    public interface ICommanderRepository
    {
        Task<CommandersDTO> GetCommanderSkill(Uri imgUri, string skill);
    }
}
