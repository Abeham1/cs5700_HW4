using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace ShapeApplication
{
    public class Commander
    {
        public List<Command> commandList;
        private int currentCommand;
        public List<Shape> shapeList;

        public Commander(List<Shape> shapes)
        {
            currentCommand = 0;
            commandList = new List<Command>();
            shapeList = shapes;
        }

        public string Undo()
        {
            string errorMessage = null;
            try
            {
                Command commandx = commandList[currentCommand - 1];
            }
            catch
            {
                errorMessage = "Command index exceeded!";
                return errorMessage;
            }

            Command command = commandList[currentCommand - 1];
            switch (command.type)
            {
                case Command.commandType.DRAW:
                    shapeList.RemoveAt(command.shapeListPosition);
                    break;
                case Command.commandType.MOVE:
                    shapeList[command.shapeListPosition].Move(command.deltaX * -1, command.deltaY * -1);
                    break;
                case Command.commandType.ERASE:
                    shapeList.Add(command.preAction);
                    commandList[currentCommand - 1].shapeListPosition = shapeList.Count - 1;
                    break;
                default:
                    break;
            }
            currentCommand--;
            return errorMessage;
        }

        public string Redo()
        {
            string errorMessage = null;
            try
            {
                Command commandx = commandList[currentCommand - 1];
            }
            catch
            {
                errorMessage = "Command index exceeded!";
                return errorMessage;
            }
            Command command = commandList[currentCommand];
            switch (command.type)
            {
                case Command.commandType.DRAW:
                    shapeList.Add(command.postAction);
                    break;
                case Command.commandType.MOVE:
                    shapeList[command.shapeListPosition].Move(command.deltaX, command.deltaY);
                    break;
                case Command.commandType.ERASE:
                    shapeList.Remove(command.preAction);
                    break;
                default:
                    break;
            }
            currentCommand++;
            return errorMessage;
        }

        public void AddCommand(Command command)
        {
            commandList.Add(command);
            currentCommand++;
        }

        public void createCommand(Command.commandType ct, Shape preA, Shape postA, int shapePosition, int deltx, int delty)
        {
            Command command = new Command(ct);
            command.preAction = preA;
            if (ct == Command.commandType.MOVE)
            {
                shapeList[shapePosition].Move(deltx, delty);
                command.postAction = shapeList[shapePosition];
                command.deltaX = deltx;
                command.deltaY = delty;
            }
            else
            {
                command.postAction = postA;
            }
            command.shapeListPosition = shapePosition;
            AddCommand(command);
        }

        public void clearCommands()
        {
            commandList.Clear();
        }
    }
}
