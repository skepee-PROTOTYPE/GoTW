using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GotwAPI.Model
{
    public enum CommanderType
    {
        Bowman,
        Cavalry,
        Infantry,
        Spearman
    }

    public record TypeDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Ico { get; set; } = String.Empty;
    }
}
