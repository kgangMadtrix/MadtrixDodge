using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;
using NUnit.Framework;
using NUnit.Mocks;
using TechTalk.SpecFlow;

namespace Madtrix.Tests.FallingObject
{
    [Binding]
    public class Steps
    {
        IGameObjectFactory fallingObjectFactory;
        GameObjectBase fallingGameObject;

        //[BeforeScenario]
        //public void CreateFallingObjectFactory()
        //{
        //    fallingObjectFactory = new FallingObjectFactory();
        //}

        [Given(@"I have a falling object factory")]
        public void GivenIHaveAFallingObjectFactory()
        {
            fallingObjectFactory = new FallingObjectFactory();
        }

        [When(@"I create a raindrop")]
        public void WhenICreateARaindrop()
        {
            fallingGameObject = fallingObjectFactory.CreateGameObject((int)FallingObjectType.Raindrop);
        }

        [Then(@"the result should be a rain drop on the screen")]
        public void ThenTheResultShouldBeARainDropOnTheScreen()
        {
            Assert.IsInstanceOf(typeof(Raindrop), fallingGameObject, "The falling object factory did not return a raindrop");
        }
    }
}
