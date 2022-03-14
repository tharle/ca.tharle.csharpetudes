using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder();
            print.AppendLine($"Quote ({Id}) - {Text}");
            return print.ToString();
        }
    }
}
