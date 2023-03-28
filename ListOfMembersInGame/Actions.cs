using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfMembersInGame
{
    public class Actions
    {
        private List<Character> myGuild = new List<Character> 
        { 
            new Character("SandD", 60, Class.Priest),
            new Character("Lok", 15, Class.Warlok),
            new Character("Lok", 15, Class.Warlok),
            new Character("Musipusi", 55, Class.Paladin),
            new Character("SomthingName", 14, Class.Mage),
            new Character("Funtik", 56, Class.Druid),
            new Character("Paket", 46, Class.Warior),
            new Character("Tabletka", 45, Class.Priest),
        };

        public event ListOfMembersInGameDelegate GuildEvent;

        public void Start()
        {
            this.GuildEvent += this.UniqueValues;
            this.GuildEvent += this.FirstThreeValues;
            this.GuildEvent += this.FindeValues;
            var eventList = this.GuildEvent.GetInvocationList();
            List<Character> result = new List<Character>();
            foreach (var item in eventList)
            {
                var a = (Task<List<Character>>)item.DynamicInvoke(this.myGuild);
                result.AddRange(a.Result);
            }
        }

        private Task<List<Character>> UniqueValues(List<Character> guild)
        {
            var result = guild
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToList();
            Task.Delay(1000);
            return Task.FromResult(result);
        }

        private Task<List<Character>> FirstThreeValues(List<Character> guild)
        {
            var result = guild.Take(3).ToList();
            Task.Delay(1000);
            return Task.FromResult(result);
        }

        private Task<List<Character>> FindeValues(List<Character> guild)
        {
            var result = guild.FindAll(x => x.Level == 15 && x.Class == Class.Warlok).ToList();
            Task.Delay(1000);
            return Task.FromResult(result);
        }
    }
}
