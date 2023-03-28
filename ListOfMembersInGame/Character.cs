using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfMembersInGame
{
    public enum Class
    {
        Warlok,
        Warior,
        Mage,
        Priest,
        Paladin,
        Druid,
    }

    public sealed class Character
    {
        public Character(string name, int level, Class @class)
        {
            this.Name = name;
            this.Level = level;
            this.Class = @class;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Class Class { get; set; }

        public override string ToString()
        {
            return $"{this.Name} class - {this.Class}, level - {this.Level}";
        }
    }
}
