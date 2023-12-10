using LocalDBSM.Models;

namespace LocalTests
{
    public class ColumnsTests
    {
        private Column column;

        [Fact]
        public void TestColorColumnValidation()
        {
            //Arrange
            column = new TextFileColumn("Document", false);

            //Act
            bool result = column.Validate("id.txt");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestRealColumnValidation()
        {
            //Arrange
            column = new RealColumn("Price", false);

            //Act
            bool result = column.Validate("aboba");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestIntegerIntervalColumnValidation()
        {
            //Arrange
            column = new IntegerInvlColumn("Age", false);

            //Act
            bool result = column.Validate("10-12");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestIntegerColumnValidation()
        {
            //Arrange
            column = new IntColumn("Weight", true);

            //Act
            bool result = column.Validate(null);

            //Assert
            Assert.False(result);
        }
    }
}
