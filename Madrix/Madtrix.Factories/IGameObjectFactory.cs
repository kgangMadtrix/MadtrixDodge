using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Factories
{
    public interface IGameObjectFactory
    {
        GameObjectBase CreateGameObject(int FallingObjectType);
    }
}
