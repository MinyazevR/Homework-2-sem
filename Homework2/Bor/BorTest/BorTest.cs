using NUnit.Framework;

using String;

using System;

namespace BorTest
{
    public class Tests
    {
        Bor? bor;
        [SetUp]
        public void Setup()
        {
            bor = new Bor();
        }

        [Test]
        public void DeleteLineFromEmptyBor()
        {
            Assert.IsFalse(bor?.Remove("hello"));
        }

        [Test]
        public void AddExistingString()
        {
            Assert.IsTrue(bor?.Add("hello"));
            Assert.IsFalse(bor?.Add("hello"));
        }

        [Test]
        public void FindNonExistentString()
        {
            Assert.IsFalse(bor?.Contains("hello"));
        }

        [Test]
        public void FindStringAfterAdd()
        {
            Assert.IsTrue(bor?.Add("hello"));
            Assert.IsTrue(bor?.Contains("hello"));
        }

        [Test]
        public void RemoveStringAfterRemove()
        {
            Assert.IsTrue(bor?.Add("hello"));
            Assert.IsTrue(bor?.Remove("hello"));
            Assert.IsFalse(bor?.Remove("hello"));
        }

        [Test]
        public void FindStringAfterRemove()
        {
            Assert.IsTrue(bor?.Add("hello"));
            Assert.IsTrue(bor?.Remove("hello"));
            Assert.IsFalse(bor?.Contains("hello"));
        }
    }
}