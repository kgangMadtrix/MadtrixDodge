using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Controllers
{
    public interface IFactoryController
    {
        IGameObjectFactory Getfactory(string factoryDll, string typeName);

        IGameObjectFactory GetFallingObjectFactory();

        IGameObjectFactory GetDodgingObjectFactory();

        IGameObject CreateGameObject(IGameObjectFactory gameFactory, int objectTypeId);

        IList<Factories.GameObjects.IGameObject> CreateFallingGameObjects(IGameObjectFactory gameFactory, int objectTypeId, int numberOfFallingObjects);

        IList<Madtrix.Factories.GameObjects.IGameObject> Initialize(IList<Madtrix.Factories.GameObjects.IGameObject> gameObjects);

        bool Intersects(Rectangle rectangle, IList<Madtrix.Factories.GameObjects.IGameObject> gameObjects);

        Rectangle GetRandomRectangle();
    }
}
