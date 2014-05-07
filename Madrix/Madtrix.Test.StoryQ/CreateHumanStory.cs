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
    [Category("Create dodging Object")]
    public class CreateHumanDropStory
    {
        IGameObjectFactory DodgingObjectFactory = null;
        IGameObject DodgingGameObject = null;
        [Test]
        public void CreateFallingObject()
        {
            new Story("Create dodgingObject")
                .InOrderTo("create a human")
                .AsA("System")
                .IWant("to create a human object")

                        .WithScenario("Create a human")
                            .Given(IHaveADodgingObjectFactory)
                            .When(ICreateAHuman)
                            .Then(TheResultShouldBeAHumanOnTheScreen)
                .ExecuteWithReport();
        }

        private void IHaveADodgingObjectFactory()
        {
            DodgingObjectFactory = new DodgingObjectFactory();


        }

        private void ICreateAHuman()
        {
            DodgingGameObject = DodgingObjectFactory.CreateGameObject((int)ObjectType.Human);

        }

        private void TheResultShouldBeAHumanOnTheScreen()
        {
            Assert.IsInstanceOf(typeof(Human), DodgingGameObject, "The dodging object factory did not return a raindrop");
        }
    }
}
