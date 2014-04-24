using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;
using NUnit.Framework;

namespace Madtrix.Tests
{
    /// <summary>
    /// This is the Given_I_Have_A_FallingObjectFactory test method
    /// </summary>
    [TestFixture]
    public class Given_I_Have_A_FallingObjectFactory
    {
        /// <summary>
        /// Then_return_a_raindrop_object_based_on_my_s the falling object type raindrop id_parameter.
        /// </summary>
        [Test]
        public void Then_return_a_raindrop_object_based_on_my_FallingObjectTypeRaindropId_parameter()
        {
            var fallingObjectFactory = new FallingObjectFactory();
            var fallingGameObject = fallingObjectFactory.CreateGameObject((int)FallingObjectType.Raindrop);
            Assert.IsInstanceOf(typeof(Raindrop), fallingGameObject, "The falling object factory did not return a raindrop");
        }

        /// <summary>
        /// Then_do_not_return_a_s the fridge_object_based_on_my_ falling object type raindrop id_parameter.
        /// </summary>
        [Test]
        public void Then_do_not_return_a_Fridge_object_based_on_my_FallingObjectTypeRaindropId_parameter()
        {
            var fallingObjectFactory = new FallingObjectFactory();
            var fallingGameObject = fallingObjectFactory.CreateGameObject((int)FallingObjectType.Raindrop);
            Assert.IsNotInstanceOf(typeof(Fridge), fallingGameObject, "The falling object factory did not return a fridge");
        }

        [Test]
        public void Then_load_it_throughSettings()
        {
            var assembly = Assembly.LoadFrom("Madtrix.Factories.dll");
            var fallingObjectFactory = (IGameObjectFactory)assembly.CreateInstance("Madtrix.Factories.FallingObjectFactory");
            Assert.IsInstanceOf(typeof(FallingObjectFactory), fallingObjectFactory, "The falling did not load through settings");
        }
    }

    /// <summary>
    /// This is the Fridge class.
    /// </summary>
    public class Fridge
    {
    }
}
