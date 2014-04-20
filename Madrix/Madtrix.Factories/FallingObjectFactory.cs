using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Factories
{
    public class FallingObjectFactory:IGameObjectFactory
    {
        public GameObjects.GameObjectBase CreateGameObject(int FallingObjectTypeId)
        {
            FallingObjectBase fallingObjectType = (FallingObjectBase)FallingObjectTypes[FallingObjectTypeId];
            return fallingObjectType;
        }

        private Dictionary<int, FallingObjectBase> FallingObjectTypes = new Dictionary<int, FallingObjectBase>
        {
            {1, new Raindrop()}
        };

    }
}
