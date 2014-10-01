﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswersTest.Model
{
    public class PersonModel
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                SetIsPalindrome(value);
            }
        }

        private void SetIsPalindrome(string value)
        {
            IsPalindrome = false;
        }

        public bool IsAuthorised { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsPalindrome { get; private set; }

        public IEnumerable<ColorModel> Colours { get; set; }

        public string ColoursDisplay
        {
            get
            {
                if (Colours == null)
                {
                    return string.Empty;
                }

                return string.Join(", ", Colours.Select(c => c.Name));
            }
        }
    }
}