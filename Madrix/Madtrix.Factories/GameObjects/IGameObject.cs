using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Madtrix.Factories.GameObjects
{
    public interface IGameObject
    {
        string ImageLocation { get; set; }

        Rectangle Bounds { get; set; }

        Point Location { get; set; }

        string Name { get; set; }
    }
}
