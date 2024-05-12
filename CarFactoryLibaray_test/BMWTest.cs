using CarFactoryLibrary;


namespace CarFactoryLibaray_test
{
    public class BMWTest
    {
        [Fact]
        public void Equal_velocityAndMode_true()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.velocity = 0;
            bmw.drivingMode = DrivingMode.Forward;

            BMW bmw2 = new BMW();
            bmw2.velocity = 0;
            bmw2.drivingMode = DrivingMode.Forward;

            // Act
            bool result = bmw.Equals(bmw2);

            // Boolean Asserts
            Assert.True(result);
        }

        [Fact]
        public void InRange_velocity_distance_true()
        {
            BMW bmw = new BMW();
            bmw.velocity = 10;

            double d = bmw.TimeToCoverDistance(100);

            Assert.InRange(d, 5, 15);
        }

        [Fact]
        public void OutRange_velocity_distance_true()
        {
            BMW bmw = new BMW();
            bmw.velocity = 10;

            double d = bmw.TimeToCoverDistance(100);

            Assert.NotInRange(d, 5, 6);
        }

        [Fact]
        public void TestString1_Direction_Backward()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Backward;

            // Act
            string result = bmw.GetDirection();


            Assert.Equal(DrivingMode.Backward.ToString(), result);
            Assert.EndsWith("rd", result);

            Assert.Contains("wa", result);
            Assert.DoesNotContain("mm", result);

        }

        [Fact]
        public void TestString2_Direction_Stopped()
        {
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Stopped;
            string result = bmw.GetDirection();
            Assert.StartsWith("S", result);
            Assert.Matches("^S.*", result);
        }

        [Fact]
        public void GetMyCar_callFunction_NptNull()
        {

            BMW bmw = new BMW();

            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.NotNull(car);

        }

        [Fact]
        public void GetMyCar_callFunction_NotSameCar()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW bmw2 = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.NotSame(bmw2, car);
        }

        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bmw = new BMW();

            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.Same(bmw, car);

        }

        [Fact]
        public void NewCar_CarTypeBMW_BMW()
        {
            Car? car = CarFactory.NewCar(CarTypes.BMW);
            Assert.IsType<BMW>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
        }

        [Fact]
        public void NewCar_CarTypeHonad_Exception()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }

    }
}






