using System;
using System.Collections.Generic;
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

        GameObjectBase CreateGameObject(IGameObjectFactory gameFactory, int objectTypeId);

        
    }
}
