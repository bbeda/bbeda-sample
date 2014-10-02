using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnswersTestUnitTesting
{
    [TestClass]
    public class IsPalindromeUnitTest
    {
        [TestMethod]
        public void Palindrome_NoSpaces_Correct()
        {
            var input = "abcdefDfedcba";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Palindrome_SpacesStart_Correct()
        {
            var input = "  abcdefDfedcba";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_SpacesEnd_Correct()
        {
            var input = "abcdefDfedcba    ";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_SpacesScattered_Correct()
        {
            var input = "   aBcd  ef Dfe  dcb a    ";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_Casing_Correct()
        {
            var input = "   ABCD  Ef Dfe  dcb a    ";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_General_NotCorect()
        {
            var input = "ABCDeCBA";
            var expected = false;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_Empty_Correct()
        {
            var input = "";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_Null_NotCorrect()
        {
            string input = null;
            var expected = false;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_SpacesOnly_Correct()
        {
            string input = "      ";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Palindrome_SpecialCharacters_Correct()
        {
            string input = "    ~he @^@e h  ~";
            var expected = true;
            var result = input.IsPalindrome();
            Assert.AreEqual(expected, result);
        }
    }
}
