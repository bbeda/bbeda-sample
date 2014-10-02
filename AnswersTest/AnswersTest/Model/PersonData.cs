using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswersTest.Model
{
    public class PersonData
    {
        public int Id { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAuthorised { get; set; }
        public IEnumerable<int> FavouriteColoursIds { get; set; }
    }
}