using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Factories
{
    /// <summary>
    /// This is my falling object factory
    /// </summary>
    public class FallingObjectFactory : IGameObjectFactory
    {
        /// <summary>
        /// Creates the game object.
        /// </summary>
        /// <param name="fallingObjectTypeId">The falling object type identifier.</param>
        /// <returns>A game object base</returns>
        public GameObjects.GameObjectBase CreateGameObject(int fallingObjectTypeId)
        {
            switch (fallingObjectTypeId)
            {
                case (int)FallingObjectType.Raindrop:
                    return this.CreateRaindrop();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates the raindrop.
        /// </summary>
        /// <returns>A game object base</returns>
        private GameObjects.GameObjectBase CreateRaindrop()
        {
            var fallingObject = new Raindrop();
            fallingObject.Size = new System.Drawing.Size(50, 50);

            fallingObject.ImageLocation = @"..\..\images\enemy.png";
            return fallingObject;
        }
    }
}
