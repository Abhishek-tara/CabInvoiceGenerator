using CabInvoiceGenerator;
using CabInvoiceGeneratorTest;
namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {

        InvoiceGenerator invoiceGenerator = null;


        // Test Case for UC1-Calculate Total Fa
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

        // Test Case for  UC-2- Add Multiple rides

        [TestMethod]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expected, invoiceSummary);
        }

        // Test Case for UC3- Invoice summary with Averange Fare
        [TestMethod]
        public void GivenMultipleRidesShouldReturnInvoiceSummaryAndAverangeFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 65.0);

            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
            
        }
    }
}