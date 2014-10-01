using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnswersTest.Helpers;
using AnswersTest.Model;

namespace AnswersTest.Services
{
    internal class DataService : IDataService
    {
        public IEnumerable<PersonModel> LoadPeople()
        {
            using (var dbContext = new TechTestEntities())
            {
                return dbContext.People.OrderBy(p => p.FirstName).ToList().Select(p => new PersonModel()
                {
                    Name = NameFormatter.FormatName(p.FirstName, p.LastName),
                    IsEnabled = p.IsEnabled,
                    IsAuthorised = p.IsAuthorised,
                    Colours = p.Colours.OrderBy(c => c.Name).Select(c => new ColorModel()
                    {
                        Id = c.ColourId,
                        Name = c.Name,
                        IsEnabled = c.IsEnabled
                    })
                }).ToList();
            }
        }
    }
}