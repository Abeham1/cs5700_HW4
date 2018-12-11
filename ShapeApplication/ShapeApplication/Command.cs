using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace ShapeApplication
{
    public class Command
    {
        public enum commandType { DRAW, ERASE, MOVE, NONE};
        public commandType type;
        public Shape preAction;
        public Shape postAction;
        public int shapeListPosition;
        public int deltaX;
        public int deltaY;

        public Command()
        {
            preAction = null;
            postAction = null;
            shapeListPosition = -1;
            type = commandType.NONE;
            deltaX = 0;
            deltaY = 0;
        }

        public Command(commandType t)
        {
            preAction = null;
            postAction = null;
            shapeListPosition = -1;
            type = t;
            deltaX = 0;
            deltaY = 0;
        }
    }
}
