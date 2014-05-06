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

        /// <summary>
        /// The game object factory
        /// </summary>
        private IGameObjectFactory gameObjectFactory;

        /// <summary>
        /// Injects the specified game object factory.
        /// </summary>
        /// <param name="gameObjectFactory">The game object factory.</param>
        public void Inject(IGameObjectFactory gameObjectFactory)
        {
            this.gameObjectFactory = gameObjectFactory;
        }

        

        /// <summary>
        /// Creates the game object.
        /// </summary>
        /// <param name="gameFactory">The game factory.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public Factories.GameObjects.IGameObject CreateGameObject(int objectType)
        {
            return this.gameObjectFactory.CreateGameObject(objectType);
        }

        public IList<Factories.GameObjects.IGameObject> CreateDodgingGameObjects(int objectType, int numberObjects)
        {
            var gameObjects = new List<Factories.GameObjects.IGameObject>();

            for (int i = 0; i < numberObjects; i++)
            { 
                var gameObject = this.gameObjectFactory.CreateGameObject(objectType);
                gameObjects.Add(gameObject);
            }
            return gameObjects;
        }


        /// <summary>
        /// Creates the falling game objects.
        /// </summary>
        /// <param name="gameFactory">The game factory.</param>
        /// <param name="objectTypeId">The object type identifier.</param>
        /// <param name="numberOfFallingObjects">The number of falling objects.</param>
        /// <returns></returns>
        public IList<Factories.GameObjects.IGameObject> CreateFallingGameObjects(int objectTypeId, int numberOfFallingObjects)
        {
            var gameObjects = new List<Factories.GameObjects.IGameObject>();

            for (int i = 0; i < numberOfFallingObjects; i++)
            {
                var gameObject = this.gameObjectFactory.CreateGameObject(objectTypeId);
                    gameObjects.Add(gameObject);  
            }
            return Initialize(gameObjects);
        }

        /// <summary>
        /// Creates the falling game objects.
        /// </summary>
        /// <param name="gameFactory">The game factory.</param>
        /// <param name="objectTypeId">The object type identifier.</param>
        /// <returns></returns>
        public IList<Factories.GameObjects.IGameObject> CreateFallingGameObjects(int objectTypeId)
        {
            var gameObjects = new List<Factories.GameObjects.IGameObject>();
            int numberOfFallingObjects = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfFallingObjects"]);
            for (int i = 0; i < numberOfFallingObjects; i++)
            {
                var gameObject = this.gameObjectFactory.CreateGameObject(objectTypeId);
                gameObjects.Add(gameObject);
            }
            return Initialize(gameObjects);
        }

        /// <summary>
        /// Initializes the specified game objects.
        /// </summary>
        /// <param name="gameObjects">The game objects.</param>
        /// <returns></returns>
        public IList<Madtrix.Factories.GameObjects.IGameObject> Initialize(IList<Madtrix.Factories.GameObjects.IGameObject> gameObjects)
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


        /// <summary>
        /// Intersectses the specified rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="gameObjects">The game objects.</param>
        /// <returns></returns>
        public bool Intersects(Rectangle rectangle, IList<Madtrix.Factories.GameObjects.IGameObject> gameObjects)
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

        /// <summary>
        /// Gets the random rectangle.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRandomRectangle()
        {
            int num1 = this.random.Next(0, 450);
            int num2 = this.random2.Next(0, 120);
            return new Rectangle(num1, num2, 50, 50);
        }







        





    }
}
