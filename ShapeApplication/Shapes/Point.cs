namespace Shapes
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            Validator.ValidatePositiveint(x, "Invalid x-location point");
            Validator.ValidatePositiveint(y, "Invalid y-location point");
            X = x;
            Y = y;
        }

        /**
        * Move the point in the x direction
        *
        * @param deltaX            The delta amount to move the point -- must be a valid int
        * @throws ShapeException   Exception thrown if the parameter is invalid
        */
        public void MoveX(int deltaX)
        {
            Validator.Validateint(deltaX, "Invalid delta-x value");
            X += deltaX;
        }

        /**
         * Move the point in the y direction
         *
         * @param deltaY            The delta amount to move the point -- must be a valid int
         * @throws ShapeException   Exception thrown if the parameter is invalid
         */
        public void MoveY(int deltaY)
        {
            Validator.Validateint(deltaY, "Invalid delta-y value");
            Y += deltaY;
        }

        /**
         * Move the point
         *
         * @param deltaX            The delta amount to move the point in the x direction -- must be a valid int
         * @param deltaY            The delta amount to move the point in the y direction -- must be a valid int
         * @throws ShapeException   Exception throw if any parameter is invalid
         */
        public void Move(int deltaX, int deltaY)
        {
            MoveX(deltaX);
            MoveY(deltaY);
        }

        /**
         * Copy the point
         * @return                  A new point with same x and y locations
         * @throws ShapeException   Should never thrown because the current x and y are valid
         */
        public Point Copy()
        {
            return new Point(X, Y);
        }

    }
}
