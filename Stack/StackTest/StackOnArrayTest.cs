using NUnit.Framework;

using Stack;
using System;

namespace StackTest;
    public class StackOnArrayTest
    {
        StackOnArray<int>? stackOnArray;
        [SetUp]
        public void Setup()
        {
            stackOnArray = new StackOnArray<int>();
        }

        [Test]
        public void RemoveElementFromEmptyStack()
        {
            var exception = Assert.Throws<NullReferenceException>(() => stackOnArray?.Pop());
            Assert.That(exception?.Message, Is.EqualTo("Stack is empty"));
        }

        [Test]
        public void ReturnTopOfEmptyStack()
        {
            var exception = Assert.Throws<NullReferenceException>(() => stackOnArray?.ReturnTopOfTheStack());
            Assert.That(exception?.Message, Is.EqualTo("Stack is empty"));
        }

        [Test]
        public void ReturnTopOfStackAfterPush()
        {
            stackOnArray?.Push(1);
            Assert.AreEqual(stackOnArray?.ReturnTopOfTheStack(), 1);
        }

        [Test]
        public void PushAfterPush()
        {
            stackOnArray?.Push(1);
            Assert.AreEqual(stackOnArray?.ReturnTopOfTheStack(), 1);
        }

        [Test]
        public void ReturnNumberOfElementForEmptyStack()
        {
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 0);
        }

        [Test]
        public void ReturnNumberOfElementAfterPush()
        {
            stackOnArray?.Push(1);
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 1);
        }

        [Test]
        public void ReturnNumberOfElementAfterPushAfterPop()
        {
            stackOnArray?.Push(1);
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 1);
            stackOnArray?.Pop();
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 0);
        }

        [Test]
        public void ReturnNumberOfElementAfterPushPush()
        {
            stackOnArray?.Push(1);
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 1);
            stackOnArray?.Push(2);
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 2);
        }

        [Test]
        public void ReturnTopOfTheStackAfterPushPushPop()
        {
            stackOnArray?.Push(1);
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 1);
            stackOnArray?.Push(2);
            stackOnArray?.Pop();
            Assert.AreEqual(stackOnArray?.ReturnNumberOfElements(), 1);
        }
    }