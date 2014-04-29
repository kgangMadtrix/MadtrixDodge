using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Madtrix.Factories.GameObjects;

namespace Madtrix.Controllers
{
    public interface IGameController
    {
        bool MonitorCrashes(IList<IGameObject> fallingObjects, IGameObject dodgingGameObject, PictureBox Ground);

        void KeyDown(object sender, KeyEventArgs e, IGameObject dodgingGameObject);
    }
}
