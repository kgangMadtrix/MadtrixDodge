using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Controllers
{
    public class GameController : IGameController
    {

        public bool MonitorCrashes(IList<Factories.GameObjects.IGameObject> fallingObjects, Factories.GameObjects.IGameObject dodgingGameObject, System.Windows.Forms.PictureBox Ground)
        {
            bool crashed = false;
            foreach (var item in fallingObjects)
            {
                if (dodgingGameObject.Bounds.IntersectsWith(item.Bounds))
                {
                    crashed = true;
                    break ;
                }

                var factoryController = new FactoryController();
                Rectangle r = factoryController.GetRandomRectangle();



                if (Ground.Bounds.IntersectsWith(item.Bounds))
                {
                    while (this.Intersects(r,fallingObjects))
                    {
                        r = factoryController.GetRandomRectangle();
                    }

                    item.Location = new Point(r.X, r.Y);
                }
                else
                {
                    item.Location = new Point(item.Location.X, item.Location.Y + Convert.ToInt32(ConfigurationManager.AppSettings["GameSpeed"]));
                }
            }
            return crashed;
        }

        private bool Intersects(Rectangle r, IList<Factories.GameObjects.IGameObject> fallingObjects)
        {
            if (fallingObjects.Where(a => a.Bounds.IntersectsWith(r)).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e, IGameObject dodgingGameObject)
        {
            //keep y position
            var Y = 500;
            var X = dodgingGameObject.Location.X;
            if (e.KeyCode.ToString().Equals(ConfigurationManager.AppSettings["Player1MoveLeftKey"], StringComparison.OrdinalIgnoreCase))
            {
                if (dodgingGameObject.Location.X <= 530 && dodgingGameObject.Location.X >= 10)
                {
                    dodgingGameObject.Location = new Point(X - 10, Y);
                }
                else
                {
                    //looping play to the other side
                    dodgingGameObject.Location = new Point(530, Y);
                }
            }

            if (e.KeyCode.ToString().Equals(ConfigurationManager.AppSettings["Player1MoveRightKey"], StringComparison.OrdinalIgnoreCase))
            {
                //and player is within the forms bounds
                if (dodgingGameObject.Location.X <= 530 && dodgingGameObject.Location.X >= 10)
                {
                    dodgingGameObject.Location = new Point(X + 10, Y);
                }
                else
                {
                    dodgingGameObject.Location = new Point(10, Y);
                }
            }
        }


        
    }
}
