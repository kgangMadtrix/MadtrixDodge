using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;
using NUnit.Framework;

namespace Madtrix.Tests
{
    [TestFixture]
    public class GivenFallingObjectFactory
    {
        [Test]
        public void ThenReturnRaindropObject()
        {
            var fallingObjectFactory = new FallingObjectFactory();
            var fallingGameObject = fallingObjectFactory.CreateGameObject();
            Assert.IsInstanceOf(typeof(Raindrop), fallingGameObject, "The falling object factory did not return a raindrop");
        }
    }
}
