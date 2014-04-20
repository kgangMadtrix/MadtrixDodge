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

namespace Madtrix.GameInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<GameObjectBase> fallingObjects = new List<GameObjectBase>();
        Random random = new Random(80);
        Random random2 = new Random(90);

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();


            IGameObjectFactory factory = LoadFactory();
            GameObjectBase gameObject = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject.Location = new System.Drawing.Point(55, 55);

            GameObjectBase gameObject2 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject2.Location = new System.Drawing.Point(120, 120);

            GameObjectBase gameObject3 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject3.Location = new System.Drawing.Point(200, 55);

            GameObjectBase gameObject4 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject4.Location = new System.Drawing.Point(300, 55);

            GameObjectBase gameObject5 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject5.Location = new System.Drawing.Point(400, 120);

            GameObjectBase gameObject6 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject6.Location = new System.Drawing.Point(500, 70);

            GameObjectBase gameObject7 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject7.Location = new System.Drawing.Point(600, 120);

            GameObjectBase gameObject8 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject8.Location = new System.Drawing.Point(700, 70);

            GameObjectBase gameObject9 = factory.CreateGameObject((int)FallingObjectType.Raindrop);
            gameObject9.Location = new System.Drawing.Point(570, 70);


            
            this.Controls.Add(gameObject);
            fallingObjects.Add(gameObject);
            this.Controls.Add(gameObject2);
            fallingObjects.Add(gameObject2);
            this.Controls.Add(gameObject3);
            fallingObjects.Add(gameObject3);
            this.Controls.Add(gameObject4);
            fallingObjects.Add(gameObject4);
            this.Controls.Add(gameObject5);
            fallingObjects.Add(gameObject5);
            this.Controls.Add(gameObject6);
            fallingObjects.Add(gameObject6);
            this.Controls.Add(gameObject7);
            fallingObjects.Add(gameObject7);
            this.Controls.Add(gameObject8);
            fallingObjects.Add(gameObject8);
            this.Controls.Add(gameObject9);
            fallingObjects.Add(gameObject9);
        }

        private IGameObjectFactory LoadFactory()
        {
            //load factory through setting
            var assembly = Assembly.LoadFrom("Madtrix.Factories.dll");
            return (IGameObjectFactory)assembly.CreateInstance("Madtrix.Factories.FallingObjectFactory");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in fallingObjects)
            {
                int num1 = random.Next(55,700);
                int num2 = random2.Next(55,120);
                Rectangle r = new Rectangle(num1,num2,50,50);

                
                
                if(pictureBox1.Bounds.IntersectsWith(item.Bounds))
                {
                    while (intersects(r))
                    {
                        num1 = random.Next(55, 700);
                        num2 = random2.Next(55, 120);
                        r = new Rectangle(num1, num2, 50, 50);
                    }
                    
                    item.Location = new Point(num1, num2);
                }
                else
                    item.Location = new Point(item.Location.X, item.Location.Y + 2);
            }
                
        }

        private bool intersects(Rectangle r)
        {
            if (fallingObjects.Where(a => a.Bounds.IntersectsWith(r)).Count() > 0)
                return true;
            else
                return false;

        }

         
    }
}
