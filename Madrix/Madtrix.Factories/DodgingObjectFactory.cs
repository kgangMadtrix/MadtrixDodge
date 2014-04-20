using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories
{

    public class DodgingObjectFactory : IGameObjectFactory
    {

        public GameObjects.GameObjectBase CreateGameObject(int FallingObjectType)
        {
            throw new NotImplementedException();
        }
    }
}
