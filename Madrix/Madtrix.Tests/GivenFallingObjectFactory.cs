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
    public class Given_I_Have_A_FallingObjectFactory
    {
        [Test]
        public void Then_return_a_raindrop_object_based_on_my_FallingObjectTypeRaindropId_parameter()
        {
            var fallingObjectFactory = new FallingObjectFactory();
            var fallingGameObject = fallingObjectFactory.CreateGameObject((int)FallingObjectType.Raindrop);
            Assert.IsInstanceOf(typeof(Raindrop), fallingGameObject, "The falling object factory did not return a raindrop");
        }
        [Test]
        public void Then_do_not_return_a_Fridge_object_based_on_my_FallingObjectTypeRaindropId_parameter()
        {
            var fallingObjectFactory = new FallingObjectFactory();
            var fallingGameObject = fallingObjectFactory.CreateGameObject((int)FallingObjectType.Raindrop);
            Assert.IsNotInstanceOf(typeof(Fridge), fallingGameObject, "The falling object factory did not return a fridge");
        }
    }

    public class Fridge
    {
    }
}
