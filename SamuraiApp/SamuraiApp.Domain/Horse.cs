using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SamuraiId { get; set; }

        public override string ToString()
        {
            var print = new StringBuilder();
            print.AppendLine($"Horse ({Id}) - {Name}");
            return print.ToString();
        }
    }
}
