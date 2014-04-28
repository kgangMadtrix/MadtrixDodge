using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Madtrix.Factories;
using Madtrix.Factories.GameObjects;
using System.Configuration;
using Madtrix.Controllers;

namespace Madtrix.GameInterface
{
    /// <summary>
    /// This is the Form1 class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The falling objects
        /// </summary>
        private IList<GameObjectBase> fallingObjects = new List<GameObjectBase>();

        

        private void Form1_Load(object sender, EventArgs e)
        {
            IGameObjectFactory factory = this.LoadFactory();
            var factoryController = new FactoryController();
            int numberOfFallingObject = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfFallingObjects"]);
            this.fallingObjects = factoryController.CreateGameObjects(factory, 1, numberOfFallingObject);

            foreach (var item in this.fallingObjects)
            {
                this.Controls.Add(item);
            }
            
            this.timer1.Start();
        }

        private IGameObjectFactory LoadFactory()
        {
            // load factory through setting
            var factoryController = new FactoryController();
            return factoryController.Getfactory(ConfigurationManager.AppSettings["FactoriesAssembly"], ConfigurationManager.AppSettings["FallingObjectFactoryTypeName"]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in this.fallingObjects)
            {
                var factoryController = new FactoryController();
                Rectangle r = factoryController.GetRandomRectangle();

                if (this.pictureBox1.Bounds.IntersectsWith(item.Bounds))
                {
                    while (this.Intersects(r))
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
        }


        private bool Intersects(Rectangle r)
        {
            if (this.fallingObjects.Where(a => a.Bounds.IntersectsWith(r)).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
