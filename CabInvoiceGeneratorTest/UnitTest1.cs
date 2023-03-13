using CabInvoiceGenerator;
using CabInvoiceGeneratorTest;
namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {

        InvoiceGenerator invoiceGenerator = null;

        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double expected = 25;

            //Act
            double fare = invoiceGenerator.CalculateFare(distance, time);

            //Assert
            Assert.AreEqual(expected, fare);   
        }

        [TestMethod]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expected, invoiceSummary);
        }
    }
}