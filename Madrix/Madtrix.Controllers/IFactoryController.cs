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
        void Inject(IGameObjectFactory gameObjectFactory);

        IGameObject CreateGameObject(int objectTypeId);

        IList<Factories.GameObjects.IGameObject> CreateFallingGameObjects(int objectTypeId, int numberOfFallingObjects);

        IList<Madtrix.Factories.GameObjects.IGameObject> Initialize(IList<Madtrix.Factories.GameObjects.IGameObject> gameObjects);

        bool Intersects(Rectangle rectangle, IList<Madtrix.Factories.GameObjects.IGameObject> gameObjects);

        Rectangle GetRandomRectangle();
    }
}
