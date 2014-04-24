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

        /// <summary>
        /// The random
        /// </summary>
        private Random random = new Random(80);

        /// <summary>
        /// The random2
        /// </summary>
        private Random random2 = new Random(90);

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
                int num1 = this.random.Next(55, 700);
                int num2 = this.random2.Next(55, 120);
                Rectangle r = new Rectangle(num1, num2, 50, 50);

                if (this.pictureBox1.Bounds.IntersectsWith(item.Bounds))
                {
                    while (this.Intersects(r))
                    {
                        num1 = this.random.Next(55, 700);
                        num2 = this.random2.Next(55, 120);
                        r = new Rectangle(num1, num2, 50, 50);
                    }

                    item.Location = new Point(num1, num2);
                }
                else
                {
                    item.Location = new Point(item.Location.X, item.Location.Y + 2);
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
