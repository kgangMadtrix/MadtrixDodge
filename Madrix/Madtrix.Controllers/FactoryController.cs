using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Controllers
{
    public class FactoryController : IFactoryController
    {
        /// <summary>
        /// The random
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// The random2
        /// </summary>
        private Random random2 = new Random(90);

        public Factories.IGameObjectFactory Getfactory(string factoryDll, string typeName)
        {
            var assembly = Assembly.LoadFrom(factoryDll);
            return (IGameObjectFactory)assembly.CreateInstance(typeName);
        }


        public Factories.GameObjects.GameObjectBase CreateGameObject(IGameObjectFactory gameFactory, int objectType)
        {
            return gameFactory.CreateGameObject(objectType);
        }


        public IList<Factories.GameObjects.GameObjectBase> CreateFallingGameObjects(IGameObjectFactory gameFactory, int objectTypeId, int numberOfFallingObjects)
        {
            var gameObjects = new List<Factories.GameObjects.GameObjectBase>();

            for (int i = 0; i < numberOfFallingObjects; i++)
            {
                var gameObject = gameFactory.CreateGameObject(objectTypeId);
                    gameObjects.Add(gameObject);  
            }
            return Initialize(gameObjects);
        }

        public IList<Factories.GameObjects.GameObjectBase> CreateFallingGameObjects(IGameObjectFactory gameFactory, int objectTypeId)
        {
            var gameObjects = new List<Factories.GameObjects.GameObjectBase>();
            int numberOfFallingObjects = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfFallingObjects"]);
            for (int i = 0; i < numberOfFallingObjects; i++)
            {
                var gameObject = gameFactory.CreateGameObject(objectTypeId);
                gameObjects.Add(gameObject);
            }
            return Initialize(gameObjects);
        }

        public IList<Madtrix.Factories.GameObjects.GameObjectBase> Initialize(IList<Madtrix.Factories.GameObjects.GameObjectBase> gameObjects)
        {
            foreach (var item in gameObjects)
            {
                int num1 = this.random.Next(0, 450);
                int num2 = this.random2.Next(0, 120);
                Rectangle r = new Rectangle(num1, num2, 50, 50);
                
                if (Intersects(r, gameObjects))
                {
                    while (Intersects(r, gameObjects))
                    {
                        num1 = this.random.Next(0, 450);
                        num2 = this.random2.Next(0, 120);
                        r = new Rectangle(num1, num2, 50, 50);
                        
                    }
                    item.Location = new Point(num1, num2);
                }
                else
                {
                    item.Location = new Point(num1, num2);
                }

                

            }
            return gameObjects;
        }


        public bool Intersects(Rectangle rectangle, IList<Madtrix.Factories.GameObjects.GameObjectBase> gameObjects)
        {
            if (gameObjects.Where(a => a.Bounds.IntersectsWith(rectangle)).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Rectangle GetRandomRectangle()
        {
            int num1 = this.random.Next(0, 450);
            int num2 = this.random2.Next(0, 120);
            return new Rectangle(num1, num2, 50, 50);
        }







        public IGameObjectFactory GetFallingObjectFactory()
        {
            var factoryController = new FactoryController();
            return factoryController.Getfactory(ConfigurationManager.AppSettings["FactoriesAssembly"], ConfigurationManager.AppSettings["FallingObjectFactoryTypeName"]);
        }

        public IGameObjectFactory GetDodgingObjectFactory()
        {
            var factoryController = new FactoryController();
            return factoryController.Getfactory(ConfigurationManager.AppSettings["FactoriesAssembly"], ConfigurationManager.AppSettings["DodgingObjectFactoryTypeName"]);
        }
    }
}
