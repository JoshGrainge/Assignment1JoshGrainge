using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using A1;

namespace A1UnitTests
{
    [TestClass]
    public class SubsequenceFinderTester
    {

        [TestMethod]
        public void InvalidSubsequence()
        {
            // Creates list of sequence and invalid subsequence
            List<int> seq = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> subSeq = new List<int>() { 1, 5, 6 };

            // Tests that valid subsequences returns false
            bool isValidResult = SubsequenceFinder.IsValidSubsequeuce(seq,subSeq);
            Assert.AreEqual(isValidResult, false);
        }

        [TestMethod]
        public void ValidSubsequence()
        {
            // Creates list of sequence and valid subsequence
            List<int> seq = new List<int>() { 1,2,3,4,5};
            List<int> subSeq = new List<int>() { 1, 2};

            // Tests that valid subsequences returns true
            bool isValidResult = SubsequenceFinder.IsValidSubsequeuce(seq, subSeq);
            Assert.AreEqual(isValidResult, true);

        }
    }
}