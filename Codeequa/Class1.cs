using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Codeequa
{
    /// <summary>
    /// Provides methods to solve a quadratic equation ax^2 + bx + c = 0.
    /// </summary>
    public static class QuadraticSolver
    {
        /// <summary>
        /// Solves the quadratic equation for real roots.
        /// </summary>
        /// <param name="a">Coefficient a (must be non-zero).</param>
        /// <param name="b">Coefficient b.</param>
        /// <param name="c">Coefficient c.</param>
        /// <returns>
        /// A tuple (rootsCount, root1, root2):
        ///   rootsCount = 0 -> No real solutions
        ///   rootsCount = 1 -> One real solution (root1)
        ///   rootsCount = 2 -> Two real solutions (root1 and root2)
        /// </returns>
        public static (int rootsCount, double? root1, double? root2) Solve(double a, double b, double c)
        {
            // If 'a' is approximately zero, it's not a valid quadratic equation.
            if (Math.Abs(a) < 1e-14)
            {
                throw new ArgumentException("Coefficient 'a' cannot be zero in a quadratic equation.");
            }

            double discriminant = (b * b) - (4 * a * c);

            if (discriminant < 0)
            {
                // No real solutions.
                return (0, null, null);
            }
            else if (Math.Abs(discriminant) < 1e-14)
            {
                // One real solution => a double root.
                double root = -b / (2 * a);
                return (1, root, null);
            }
            else
            {
                // Two distinct real solutions.
                double sqrtDelta = Math.Sqrt(discriminant);
                double root1 = (-b + sqrtDelta) / (2 * a);
                double root2 = (-b - sqrtDelta) / (2 * a);
                return (2, root1, root2);
            }
        }
    }
}
