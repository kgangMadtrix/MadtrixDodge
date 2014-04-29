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
        /// <param name="objectTypeId">The falling object type identifier.</param>
        /// <returns>A game object base</returns>
        public GameObjects.IGameObject CreateGameObject(int objectTypeId)
        {
            switch (objectTypeId)
            {
                case (int)ObjectType.Raindrop:
                    return this.CreateRaindrop();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates the raindrop.
        /// </summary>
        /// <returns>A game object base</returns>
        private GameObjects.IGameObject CreateRaindrop()
        {
            var fallingObject = new Raindrop();
            fallingObject.Size = new System.Drawing.Size(50, 50);
            fallingObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fallingObject.ImageLocation = @"..\..\images\enemy.png";
            fallingObject.Name = "Falling";
            return fallingObject;
        }
    }
}
