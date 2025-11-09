using Tut2_s20123;

namespace Tut2_s20123_Tests
{
    public class Tests
    {
        [TestCase(5, 314.159)]
        [TestCase(1, 12.566)]
        [TestCase(10, 1256.637)]
        [TestCase(0.5, 3.142)]
        [TestCase(0, 0)]
        public void TestSphereCalculateAreaWithMultipleValues(double radius, double expectedArea)
        {
            var sphere = new Sphere(radius);
            Assert.That(sphere.CalculateArea(), Is.EqualTo(expectedArea).Within(0.001));
        }

        [TestCase(5, 523.598)]
        [TestCase(1, 4.189)]
        [TestCase(10, 4188.790)]
        [TestCase(0.5, 0.524)]
        [TestCase(0, 0)]
        public void TestSphereCalculateVolumeWithMultipleValues(double radius, double expectedVolume)
        {
            var sphere = new Sphere(radius);
            Assert.That(sphere.CalculateVolume(), Is.EqualTo(expectedVolume).Within(0.001));
        }

        //todo : Complete the remaning tests here

        [TestCase(3,7,188.496)]
        [TestCase(1, 1, 12.566)]
        [TestCase(5, 10, 471.239)]
        [TestCase(2.5, 4.5, 109.955)]
        [TestCase(0, 5, 0)]
        [TestCase(3, 0, 56.549)]
        public void TestCylinderCalculateAreaWithMultipleValues(double radius, double height, double expectedArea)
        {
            var cylinder = new Cylinder(radius, height);
            Assert.That(cylinder.CalculateArea(), Is.EqualTo(expectedArea).Within(0.001));
        }
        
        [TestCase(3,7, 197.920)]
        [TestCase(1, 1, 3.142)]
        [TestCase(5, 10, 785.398)]
        [TestCase(2.5, 4.5, 88.357)]
        [TestCase(0, 5, 0)]
        [TestCase(3, 0, 0)]
        public void TestCylinderCalculateVolumeWithMultipleValues(double radius, double height, double expectedVolume)
        {
            var cylinder = new Cylinder(radius, height);
            Assert.That(cylinder.CalculateVolume(), Is.EqualTo(expectedVolume).Within(0.001));
        }
        
        [TestCase(4,8, 32.000)]
        [TestCase(1, 1, 1.000)]
        [TestCase(10, 15, 150.000)]
        [TestCase(2.5, 3.5, 8.750)]
        [TestCase(0, 8, 0)]
        [TestCase(4, 0, 0)]
        [TestCase(0, 0, 0)]
        public void TestRectangleCalculateAreaWithMultipleValues(double radius, double height, double expectedArea)
        {
            var rectangle = new Rectangle(radius, height);
            Assert.That(rectangle.CalculateArea(), Is.EqualTo(expectedArea).Within(0.001));
        }
        
        [TestCase(4, 8, 0)]
        [TestCase(1, 1, 0)]
        [TestCase(10, 15, 0)]
        public void TestRectangleCalculateVolumeWithMultipleValues(double radius, double height, double expectedVolume)
        {
            var rectangle = new Rectangle(radius, height);
            Assert.That(rectangle.CalculateVolume(), Is.EqualTo(expectedVolume).Within(0.001));
        }
        
        [TestCase(4, 96.000)]
        [TestCase(1, 6.000)]
        [TestCase(10, 600.000)]
        [TestCase(2.5, 37.500)]
        [TestCase(0, 0)]
        public void TestCubeCalculateAreaWithMultipleValues(double side, double expectedArea)
        {
            var cube = new Cube(side);
            Assert.That(cube.CalculateArea(), Is.EqualTo(expectedArea).Within(0.001));
        }
        
        [TestCase(4, 64.000)]
        [TestCase(1, 1.000)]
        [TestCase(10, 1000.000)]
        [TestCase(2.5, 15.625)]
        [TestCase(0, 0)]
        public void TestCubeCalculateVolumeWithMultipleValues(double side, double expectedVolume)
        {
            var cube = new Cube(side);
            Assert.That(cube.CalculateVolume(), Is.EqualTo(expectedVolume).Within(0.001));
        }

    }
}