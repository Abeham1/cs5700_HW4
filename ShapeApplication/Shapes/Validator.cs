using System;

namespace Shapes
{
    public class Validator
    {
        public static void Validateint(int value, string errorMessage)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
                throw new ShapeException(errorMessage);
        }

        public static void ValidatePositiveint(int value, String errorMessage)
        {
            Validateint(value, errorMessage);
            if (value < 0)
                throw new ShapeException(errorMessage);
        }
    }
}
