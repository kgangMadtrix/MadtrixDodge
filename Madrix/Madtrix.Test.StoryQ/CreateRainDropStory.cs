using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;
using NUnit.Framework;
using StoryQ;

namespace Madtrix.Test.StoryQ
{
    [TestFixture]
    [Category("Create Falling Object")]
    public class CreateRainDropStory
    {
        IGameObjectFactory fallingObjectFactory = null;
        IGameObject fallingGameObject = null;
        [Test]
        public void CreateFallingObject()
        {
            new Story("Create FallingObject")
                .InOrderTo("create rain drops")
                .AsA("System")
                .IWant("to create a falling object")

                        .WithScenario("Create a raindrop")
                            .Given(IHaveAFallingObjectFactory)
                            .When(ICreateARaindrop)
                            .Then(TheResultShouldBeARainDropOnTheScreen)
                .ExecuteWithReport();
        }

        private void IHaveAFallingObjectFactory()
        {
            fallingObjectFactory = new FallingObjectFactory();
            
            
        }

        private void ICreateARaindrop()
        {
            fallingGameObject = fallingObjectFactory.CreateGameObject((int)ObjectType.Raindrop);
            
        }

        private void TheResultShouldBeARainDropOnTheScreen()
        {
            Assert.IsInstanceOf(typeof(Raindrop), fallingGameObject, "The falling object factory did not return a raindrop");
        }
    }
}
