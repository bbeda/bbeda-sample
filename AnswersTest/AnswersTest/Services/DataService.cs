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
        public IEnumerable<PersonSummary> LoadPeople()
        {
            using (var dbContext = new TechTestEntities())
            {
                return dbContext.People.OrderBy(p => p.FirstName).ToList().Select(GetPersonSummary).ToList();
            }
        }
        public PersonSummary LoadPerson(int id)
        {
            using (var dbContext = new TechTestEntities())
            {
                return dbContext.People.Select(GetPersonSummary).FirstOrDefault(p => p.Id == id);
            }
        }


        public IEnumerable<ColorModel> LoadColours()
        {
            using (var dbContext = new TechTestEntities())
            {
                return dbContext.Colours.OrderBy(c => c.Name).Select(GetColorModel).ToList();
            }
        }

        public void UpdatePerson(PersonData data)
        {
            using (var dbContext = new TechTestEntities())
            {
                var person = dbContext.People.FirstOrDefault(p => p.PersonId == data.Id);
                if (person == null)
                {
                    throw new InvalidOperationException("Required person does not exist");
                }

                person.IsAuthorised = data.IsAuthorised;
                person.IsEnabled = data.IsEnabled;
                if (data.FavouriteColoursIds == null || !data.FavouriteColoursIds.Any())
                {
                    person.Colours.Clear();
                }
                else
                {
                    UpdatePersonColors(data, dbContext, person);
                }

                dbContext.SaveChanges();
            }
        }

        private Colour GetColour(int id, TechTestEntities dbContext)
        {
            return dbContext.Colours.First(c => c.ColourId == id);
        }

        private void UpdatePersonColors(PersonData data, TechTestEntities dbContext, Person person)
        {
            var existingColours = person.Colours.ToList();
            //remove colors which have been removed
            foreach (var c in existingColours)
            {
                if (!data.FavouriteColoursIds.Contains(c.ColourId))
                {
                    person.Colours.Remove(c);
                }
            }

            //add new colors
            foreach (var colorId in data.FavouriteColoursIds)
            {
                if (!person.Colours.Any(c => c.ColourId == colorId))
                {
                    var color = GetColour(colorId, dbContext);
                    person.Colours.Add(color);
                }
            }
        }

        private static PersonSummary GetPersonSummary(Person p)
        {
            return new PersonSummary()
            {
                Id = p.PersonId,
                Name = NameFormatter.FormatName(p.FirstName, p.LastName),
                IsEnabled = p.IsEnabled,
                IsAuthorised = p.IsAuthorised,
                Colours = p.Colours.OrderBy(c => c.Name).Select(c => new ColorModel()
                {
                    Id = c.ColourId,
                    Name = c.Name,
                })
            };
        }

        private static ColorModel GetColorModel(Colour c)
        {
            return new ColorModel()
            {
                Id = c.ColourId,
                Name = c.Name
            };
        }
    }
}