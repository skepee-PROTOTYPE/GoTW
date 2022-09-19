using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GotwAPI.Model
{
    public record SkillDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
    }
}
