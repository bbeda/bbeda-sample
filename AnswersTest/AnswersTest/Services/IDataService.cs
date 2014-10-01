using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnswersTest.Model;

namespace AnswersTest.Services
{
    public interface IDataService
    {
        IEnumerable<PersonModel> LoadPeople();
    }
}