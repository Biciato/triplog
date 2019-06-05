using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TripLog.Exceptions;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Tests.ViewModels
{
    [TestFixture]
    public class DetailViewModelTests
    {
        DetailViewModel _vm;
        [SetUp]
        public void Setup()
        {
            var navMock = new Mock<INavService>().Object;
            var analyticMock = new Mock<IAnalyticsService>().Object;
            _vm = new DetailViewModel(navMock, analyticMock);
        }

        [Test]
        public async Task Init_ParameterProvided_EntryIsSet()
        {
            // Arrange
            var mockEntry = new Mock<TripLogEntry>().Object;
            _vm.Entry = null;

            // Act
            await _vm.Init(mockEntry);

            // Assert 
            Assert.ThrowsAsync<EntryNotProvidedException>(async () =>
            {
                await _vm.Init();
            });
        }
    }
}
