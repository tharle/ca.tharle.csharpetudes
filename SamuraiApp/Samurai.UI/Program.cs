using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static void Main(string[] args)
        {
            AddSamuraiByName("Shimada", "Okamoto", "Kikuchio", "Hyashida");
        }

        private static void AddSamuraiByName(params string[] names)
        {
            var _bizData = new BusinessDataLogic();
            var newSamuraisCreateCount = _bizData.AddSamuraiByName(names);
        }
        
    }
}
