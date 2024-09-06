using GeometricArea.Figures;

namespace GeometricArea.Tests.Figures.Tests
{
    [TestClass]
    public class CircleTest
    {
        private Circle _circle = null!;

        [TestInitialize]
        public void Init()
        {
            _circle = new Circle();
        }

        [TestCleanup]
        public void Clean()
        {
            _circle = null!;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetParametrsWithNull()
        {
            // arrange

            // act
            _circle.SetParametrs();

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetParametrsWithoutParam()
        {
            // arrange
            double[] prms = Array.Empty<double>();

            // act
            _circle.SetParametrs(prms);

            // assert
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1.1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetParametrsWrongData(double radius)
        {
            // arrange
            double[] prms = [radius];

            // act
            _circle.SetParametrs(prms);

            // assert
        }

        [DataTestMethod]
        [DataRow(1, 3.14159)]
        [DataRow(1.3, 5.30929)]
        [DataRow(3.6, 40.71504)]
        public void SetParametrsRightData(double radius, double expected)
        {
            // arrange
            //Circle circle = new();
            double[] prms = [radius];

            // act
            _circle.SetParametrs(prms);
            double actual = _circle.Area;

            // assert
            Assert.AreEqual(expected, actual, 0.00001);
        }

        [DataTestMethod]
        [DataRow(1, 3.14158)]
        [DataRow(1.3, 5.3092)]
        [DataRow(3.6, 40.71509)]
        public void SetParametrsWrongEcpected(double radius, double expected)
        {
            // arrange
            //Circle circle = new();
            double[] prms = [radius];

            // act
            _circle.SetParametrs(prms);
            double actual = _circle.Area;

            // assert
            Assert.AreNotEqual(expected, actual, 0.00001);
        }

    }
}