using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Samurai> Samurais { get; set; } = new List<Samurai>();

        public override string ToString()
        {
            var print = new StringBuilder();
            print.AppendLine($"Battle ({Id}) - {Name}");
            print.AppendLine($"-- From {StartDate} to {EndDate}");
            return print.ToString();
        }
    }
}
