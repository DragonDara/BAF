using AutoMapper;
using Xunit;

namespace BAF.Tests
{
    public class AutoMapperTests
    {
        [Fact]
        public void TestMapping()
        {
           //Arrange
           var config = new MapperConfiguration(cfg =>
           {
               cfg.AddMaps("BAF.UseCases");
           });

           // Assert
           config.AssertConfigurationIsValid();

        }
    }
}
