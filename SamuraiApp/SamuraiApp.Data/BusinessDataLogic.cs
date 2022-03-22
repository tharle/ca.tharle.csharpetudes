using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class BusinessDataLogic
    {
        private SamuraiContext _context;

        public BusinessDataLogic(SamuraiContext context)
        {
            _context = context;
        }

        public BusinessDataLogic()
        {
            _context = new SamuraiContext();
        }

        public int AddSamuraiByName(params string[] names)
        {
            foreach (var name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }

            return _context.SaveChanges();
        }


    }
}
