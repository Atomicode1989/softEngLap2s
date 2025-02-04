using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Codeequa; // Important: so we can access QuadraticSolver in the Codeequa namespace

 namespace Xunittest
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests that solver returns no real roots when discriminant < 0.
        /// Example:  a=1, b=0, c=1 => 1*x^2 + 0*x + 1 => discriminant = 0 - 4 = -4
        /// </summary>
        [Fact]
        public void Solve_NegativeDiscriminant_ReturnsNoRealRoots()
        {
            // Arrange
            double a = 1, b = 0, c = 1;

            // Act
            var (count, root1, root2) = QuadraticSolver.Solve(a, b, c);

            // Assert
            Assert.Equal(0, count);
            Assert.Null(root1);
            Assert.Null(root2);
        }

        /// <summary>
        /// Tests that solver returns exactly one real root when discriminant = 0.
        /// Example:  a=1, b=2, c=1 => x^2 + 2x + 1 => discriminant = 4 - 4 = 0 => root = -1
        /// </summary>
        [Fact]
        public void Solve_ZeroDiscriminant_ReturnsOneRealRoot()
        {
            // Arrange
            double a = 1, b = 2, c = 1;

            // Act
            var (count, root1, root2) = QuadraticSolver.Solve(a, b, c);

            // Assert
            Assert.Equal(1, count);
            Assert.NotNull(root1);
            Assert.Equal(-1, root1.Value, precision: 5);
            Assert.Null(root2);
        }

        /// <summary>
        /// Tests that solver returns two distinct real roots when discriminant > 0.
        /// Example:  a=1, b=-5, c=6 => x^2 - 5x + 6 => discriminant = 25 - 24 = 1 => roots = 2,3
        /// </summary>
        [Fact]
        public void Solve_PositiveDiscriminant_ReturnsTwoRealRoots()
        {
            // Arrange
            double a = 1, b = -5, c = 6;

            // Act
            var (count, root1, root2) = QuadraticSolver.Solve(a, b, c);

            // Assert
            Assert.Equal(2, count);
            Assert.NotNull(root1);
            Assert.NotNull(root2);

            // Because we don’t know the order, let's check with a small set
            var roots = new double?[] { root1, root2 };
            Assert.Contains(2.0, roots);
            Assert.Contains(3.0, roots);
        }

        /// <summary>
        /// Tests that an ArgumentException is thrown when a = 0 (not a valid quadratic).
        /// </summary>
        [Fact]
        public void Solve_AIsZero_ThrowsArgumentException()
        {
            // Arrange
            double a = 0, b = 2, c = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => QuadraticSolver.Solve(a, b, c));
        }

        /// <summary>
        /// Demonstrates multiple input cases using [Theory] and [InlineData].
        /// </summary>
        [Theory]
        [InlineData(1, 2, 1, 1)]   // => discriminant = 0
        [InlineData(1, 0, 1, 0)]   // => discriminant < 0
        [InlineData(1, -5, 6, 2)]  // => discriminant > 0
        public void Solve_VariousCoefficients_ReturnsExpectedRootCount(double a, double b, double c, int expectedCount)
        {
            var (count, r1, r2) = QuadraticSolver.Solve(a, b, c);
            Assert.Equal(expectedCount, count);
        }
    }
}
