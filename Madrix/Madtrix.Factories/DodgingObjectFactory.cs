using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madtrix.Factories
{
    /// <summary>
    /// This is a dodging object factory
    /// </summary>
    public class DodgingObjectFactory : IGameObjectFactory
    {
        /// <summary>
        /// Creates the game object.
        /// </summary>
        /// <param name="fallingObjectType">Type of the falling object.</param>
        /// <returns>Return a game object</returns>
        public GameObjects.GameObjectBase CreateGameObject(int fallingObjectType)
        {
            throw new NotImplementedException();
        }
    }
}
