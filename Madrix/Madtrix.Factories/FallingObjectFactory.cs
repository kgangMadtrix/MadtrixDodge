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
        public GameObjects.GameObjectBase CreateGameObject()
        {
            var fallingObject = new Raindrop();
            fallingObject.Size = new System.Drawing.Size(50, 50);
            
            fallingObject.ImageLocation = @"C:\Users\Madtrix\Documents\Visual Studio 2012\Projects\Madrix\Madtrix.GameInterface\images\enemy.png";
            return fallingObject;
        }
    }
}
