using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnswersTest.Model;

namespace AnswersTest.Services
{
    internal interface IDataService
    {
        IEnumerable<PersonSummary> LoadPeople();

        PersonSummary LoadPerson(int id);

        IEnumerable<ColorModel> LoadColours();

        void UpdatePerson(PersonData data);
    }
}