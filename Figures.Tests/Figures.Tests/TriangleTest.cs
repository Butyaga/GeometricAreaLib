using GeometricArea.Figures;

namespace GeometricArea.Tests.Figures.Tests
{
    [TestClass]
    public class TriangleTest
    {
        private Triangle _triagle = null!;

        [TestInitialize]
        public void Init()
        {
            _triagle = new Triangle();
        }

        [TestCleanup]
        public void Clean()
        {
            _triagle = null!;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetParametrsWithNull()
        {
            // arrange

            // act
            _triagle.SetParametrs();

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetParametrsWithoutParam()
        {
            // arrange
            double[] prms = Array.Empty<double>();

            // act
            _triagle.SetParametrs(prms);

            // assert
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestWrongData), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentException))]
        public void SetParametrsWrongData(double[] prms)
        {
            // arrange

            // act
            _triagle.SetParametrs(prms);

            // assert
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestWrongTriangle), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetParametrsWrongTriangle(double[] prms)
        {
            // arrange

            // act
            _triagle.SetParametrs(prms);

            // assert
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestRightData), DynamicDataSourceType.Method)]
        public void SetParametrsRightData(double[] prms, double expected)
        {
            // arrange

            // act
            _triagle.SetParametrs(prms);
            double actual = _triagle.Area;

            // assert
            Assert.AreEqual(expected, actual, 0.01);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestWrongExpected), DynamicDataSourceType.Method)]
        public void SetParametrsWrongExpected(double[] prms, double expected)
        {
            // arrange

            // act
            _triagle.SetParametrs(prms);
            double actual = _triagle.Area;

            // assert
            Assert.AreNotEqual(expected, actual, 0.01);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestIsRectangular), DynamicDataSourceType.Method)]
        public void SetParametrsIsRectangular(double[] prms, bool expected)
        {
            // arrange

            // act
            _triagle.SetParametrs(prms);
            bool actual = _triagle.IsRectangular;

            // assert
            Assert.AreEqual(expected, actual);
        }


        private static IEnumerable<object?[]> GetTestWrongData()
        {
            yield return new object?[] { new double[] {1.1} };
            yield return new object?[] { new double[] { 1.1, 2.2 } };
            yield return new object?[] { new double[] { 1.1, 2.2, 0 } };
            yield return new object?[] { new double[] { 1.1, 2.2, -5.3 } };
        }

        private static IEnumerable<object?[]> GetTestWrongTriangle()
        {
            yield return new object?[] { new double[] { 1.1, 2.2, 5.5 } };
            yield return new object?[] { new double[] { 10, 1, 3 } };
            yield return new object?[] { new double[] { 2.3, 10.1, 5.7 } };
        }

        private static IEnumerable<object?[]> GetTestRightData()
        {
            yield return new object?[] { new double[] { 1.6, 2.2, 3.5 }, 1.28 };
            yield return new object?[] { new double[] { 5.2, 1.7, 3.9 }, 2.45 };
            yield return new object?[] { new double[] { 3.7, 10.1, 8.4 }, 14.89 };
        }

        private static IEnumerable<object?[]> GetTestWrongExpected()
        {
            yield return new object?[] { new double[] { 1.6, 2.2, 3.5 }, 1.26 };
            yield return new object?[] { new double[] { 5.2, 1.7, 3.9 }, 2.5 };
            yield return new object?[] { new double[] { 3.7, 10.1, 8.4 }, 14.8 };
        }

        private static IEnumerable<object?[]> GetTestIsRectangular()
        {
            yield return new object?[] { new double[] { 3, 2, 3.60555 }, true };
            yield return new object?[] { new double[] { 3, 2, 3.7 }, false };
            yield return new object?[] { new double[] { 5.2, 1.7, 5.47083 }, true };
            yield return new object?[] { new double[] { 5.2, 1.7, 5.5 }, false };
            yield return new object?[] { new double[] { 3.7, 10.1, 9.39787 }, true };
            yield return new object?[] { new double[] { 3.7, 10.1, 9.3 }, false };
        }
    }
}
