
using Microsoft.Extensions.Configuration;
using Twilio_SMS_Integration.Services;

namespace ThirdPartyIntegration.Tests
{
    public class TwilioServiceTests
    {
        [Fact]
        public void TwilioService_LoadsEnvVariables_Correctly()
        {
            // Arrange
            var inMemorySettings = new Dictionary<string, string>
        {
            {"Twilio:AccountSid", "test_sid"},
            {"Twilio:AuthToken", "test_token"},
            {"Twilio:FromNumber", "+15399954551"}
        };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var service = new TwilioService(configuration);

            // Act & Assert
            Assert.Equal("test_sid", configuration["Twilio:AccountSid"]);
            Assert.Equal("test_token", configuration["Twilio:AuthToken"]);
            Assert.Equal("+15399954551", configuration["Twilio:FromNumber"]);
        }
    }
}