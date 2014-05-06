using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madtrix.Factories.GameObjects;

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
        public GameObjects.IGameObject CreateGameObject(int objectType)
        {
            switch (objectType)
            {
                case (int)ObjectType.Human:
                    return this.CreateHuman();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates the human.
        /// </summary>
        /// <returns>A game object base</returns>
        private GameObjects.IGameObject CreateHuman()
        {
            var dodgingObject = new Human();
            dodgingObject.Name = "Dodger";
            dodgingObject.Size = new System.Drawing.Size(25, 40);
            dodgingObject.Location = new System.Drawing.Point(216, 500);
            dodgingObject.ImageLocation = ConfigurationManager.AppSettings["dodgingobjectpic"];
            dodgingObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            return dodgingObject;
        }
    }
}
