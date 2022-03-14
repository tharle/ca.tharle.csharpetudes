using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
        public Horse Horse { get; set; }

        
        public string printSamurai()
        {
            var print = new StringBuilder();
            print.AppendLine($"Samurai ({Id} - {Name})");
            print.AppendLine($"Quote(s) ({Quotes.Count}) : ");
            Quotes.ForEach(q => print.Append(q.ToString()));
            print.AppendLine($"Battle(s) ({Battles.Count}) : ");
            Battles.ForEach(b => print.Append(b.ToString()));
            print.AppendLine("Horse: ");
            print.AppendLine(Horse != null ? Horse.ToString() : "Don't have an horse");
            return print.ToString();
        }
    }
}
