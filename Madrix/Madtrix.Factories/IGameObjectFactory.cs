using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Factories
{
    /// <summary>
    /// This is the IGameObjectFactory interface
    /// </summary>
    public interface IGameObjectFactory
    {
        /// <summary>
        /// Creates the game object.
        /// </summary>
        /// <param name="fallingObjectType">Type of the falling object.</param>
        /// <returns>GameObjectBase</returns>
        GameObjectBase CreateGameObject(int objectType);
    }
}
