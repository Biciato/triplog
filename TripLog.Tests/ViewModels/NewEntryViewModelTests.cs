using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Tests.ViewModels
{
    [TestFixture]
    public class NewEntryViewModelTests
    {
        NewEntryViewModel _vm;

        [SetUp]
        public void Setup()
        {
            var navMock = new Mock<INavService>();
            var analyticMock = new Mock<IAnalyticsService>().Object;
            var dataMock = new Mock<ITripLogDataService>();
            var locMock = new Mock<ILocationService>();
            locMock.Setup(x => x.GetGeoCoordinatesAsync())
                   .ReturnsAsync(new GeoCoords
                   {
                       Latitude = 123,
                       Longitude = 321
                   });

            _vm = new NewEntryViewModel(navMock.Object,
                                        locMock.Object,
                                        dataMock.Object,
                                        analyticMock);
        }
        [Test]
        public async Task Init_EntryIsSetWithGeoCoordinates()
        {
            // Arrange
            _vm.Latitude = 0.0;
            _vm.Longitude = 0.0;

            // Act
            await _vm.Init();

            // Assert
            Assert.AreEqual(123, _vm.Latitude);
            Assert.AreEqual(321, _vm.Longitude);
        }
    }
}
