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
        private IList<IGameObject> fallingObjects = new List<IGameObject>();

        /// <summary>
        /// The dodging object
        /// </summary>
        private IGameObject dodgingGameObject = new GameObjectBase();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Getfactories the specified factory DLL.
        /// </summary>
        /// <param name="factoryDll">The factory DLL.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        Factories.IGameObjectFactory Getfactory(string factoryDll, string typeName)
        {
            var assembly = Assembly.LoadFrom(factoryDll);
            return (IGameObjectFactory)assembly.CreateInstance(typeName);
        }

        /// <summary>
        /// Gets the falling object factory.
        /// </summary>
        /// <returns></returns>
        IGameObjectFactory GetFallingObjectFactory()
        {
            return Getfactory(ConfigurationManager.AppSettings["FactoriesAssembly"], ConfigurationManager.AppSettings["FallingObjectFactoryTypeName"]);
        }

        /// <summary>
        /// Gets the dodging object factory.
        /// </summary>
        /// <returns></returns>
        IGameObjectFactory GetDodgingObjectFactory()
        {
            return Getfactory(ConfigurationManager.AppSettings["FactoriesAssembly"], ConfigurationManager.AppSettings["DodgingObjectFactoryTypeName"]);
        }

        private void Initialise()
        {
            var factoryController = new FactoryController();
            IGameObjectFactory fallingObjectfactory = GetFallingObjectFactory();
            IGameObjectFactory dodgingObjectfactory = GetDodgingObjectFactory();
            //interface injection
            factoryController.Inject(fallingObjectfactory);
            this.fallingObjects = factoryController.CreateFallingGameObjects((int)ObjectType.Raindrop);
            //interface injection - this is more expressive that you have to inject igameobject factory
            factoryController.Inject(dodgingObjectfactory);
            this.dodgingGameObject = (GameObjectBase)factoryController.CreateGameObject((int)ObjectType.Human);
            this.Controls.Add(dodgingGameObject as Control);
            foreach (var item in this.fallingObjects)
            {
                this.Controls.Add(item as Control);
            }

            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var gameController = new GameController();
            bool crashed = gameController.MonitorCrashes(this.fallingObjects, this.dodgingGameObject, pictureBox1);
            if (crashed)
            { 
                foreach (var fallingobject in fallingObjects)
                {
                    this.Controls.RemoveByKey(fallingobject.Name);
                }
                this.Controls.RemoveByKey(this.dodgingGameObject.Name);
                fallingObjects.Clear();
                MessageBox.Show("Game Over, try again");
                
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var gameController = new GameController();
            gameController.KeyDown(sender, e, dodgingGameObject);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialise();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
