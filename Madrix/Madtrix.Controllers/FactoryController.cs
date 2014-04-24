using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories;

namespace Madtrix.Controllers
{
    public class FactoryController : IFactoryController
    {
        public Factories.IGameObjectFactory Getfactory(string factoryDll, string typeName)
        {
            var assembly = Assembly.LoadFrom(factoryDll);
            return (IGameObjectFactory)assembly.CreateInstance(typeName);
        }


        public Factories.GameObjects.GameObjectBase CreateGameObject(IGameObjectFactory gameFactory, int fallingObjectType)
        {
            return gameFactory.CreateGameObject(fallingObjectType);
        }
    }
}
