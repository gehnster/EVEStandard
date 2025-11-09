using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using EVEStandard.Models.API;
using Xunit;

namespace EVEStandard.API.Tests
{
    public class APIBaseTests
    {
        [Fact]
        public async Task ProcessResponse_MissingRateLimitHeaders_ShouldNotThrowException()
        {
            // Arrange - Create a response with error status but no rate limit headers
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Test error message")
            };
            
            // Act & Assert - should not throw an exception
            var result = await InvokeProcessResponse(response);
            
            Assert.True(result.Error);
            Assert.Equal("Test error message", result.Message);
            Assert.Equal(0, result.RemainingErrors);
            Assert.Equal(0, result.ErrorsTimeRemainingInWindowInSeconds);
        }

        [Fact]
        public async Task ProcessResponse_WithRateLimitHeaders_ShouldParseCorrectly()
        {
            // Arrange - Create a response with error status and rate limit headers
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Test error message")
            };
            response.Headers.Add("X-ESI-Error-Limit-Remain", "50");
            response.Headers.Add("X-ESI-Error-Limit-Reset", "120");
            
            // Act
            var result = await InvokeProcessResponse(response);
            
            // Assert
            Assert.True(result.Error);
            Assert.Equal("Test error message", result.Message);
            Assert.Equal(50, result.RemainingErrors);
            Assert.Equal(120, result.ErrorsTimeRemainingInWindowInSeconds);
        }

        [Fact]
        public async Task ProcessResponse_429WithMissingHeaders_ShouldNotThrowException()
        {
            // Arrange - Create a 429 response without the X-ESI-Error-Limit-Reset header
            var response = new HttpResponseMessage((HttpStatusCode)429)
            {
                Content = new StringContent("")
            };
            
            // Act & Assert - should not throw an exception
            var result = await InvokeProcessResponse(response);
            
            Assert.True(result.Error);
            Assert.Contains("Too many requests", result.Message);
            Assert.Equal(0, result.RemainingErrors);
            Assert.Equal(0, result.ErrorsTimeRemainingInWindowInSeconds);
        }

        [Fact]
        public async Task ProcessResponse_429WithRetryAfterHeader_ShouldParseCorrectly()
        {
            // Arrange - Create a 429 response with Retry-After header
            var response = new HttpResponseMessage((HttpStatusCode)429)
            {
                Content = new StringContent("")
            };
            response.Headers.Add("Retry-After", "60");
            
            // Act
            var result = await InvokeProcessResponse(response);
            
            // Assert
            Assert.True(result.Error);
            Assert.Contains("Too many requests", result.Message);
            Assert.Equal(60, result.RemainingErrors);
        }

        [Fact]
        public async Task ProcessResponse_520WithMissingHeaders_ShouldNotThrowException()
        {
            // Arrange - Create a 520 response without rate limit headers
            var response = new HttpResponseMessage((HttpStatusCode)520)
            {
                Content = new StringContent("")
            };
            
            // Act & Assert - should not throw an exception
            var result = await InvokeProcessResponse(response);
            
            Assert.True(result.Error);
            Assert.Contains("Internal error thrown by EVE server", result.Message);
            Assert.Equal(0, result.RemainingErrors);
            Assert.Equal(0, result.ErrorsTimeRemainingInWindowInSeconds);
        }

        [Fact]
        public async Task ProcessResponse_422WithMissingHeaders_ShouldNotThrowException()
        {
            // Arrange - Create a 422 response without rate limit headers
            var response = new HttpResponseMessage((HttpStatusCode)422)
            {
                Content = new StringContent("Invalid request")
            };
            
            // Act & Assert - should not throw an exception
            var result = await InvokeProcessResponse(response);
            
            Assert.True(result.Error);
            Assert.Contains("Your request was invalid", result.Message);
            Assert.Equal(0, result.RemainingErrors);
            Assert.Equal(0, result.ErrorsTimeRemainingInWindowInSeconds);
        }

        [Fact]
        public async Task ProcessResponse_DefaultCaseWithMissingHeaders_ShouldNotThrowException()
        {
            // Arrange - Create a response with an unhandled status code and no headers
            var response = new HttpResponseMessage((HttpStatusCode)418) // I'm a teapot
            {
                Content = new StringContent("")
            };
            
            // Act & Assert - should not throw an exception
            var result = await InvokeProcessResponse(response);
            
            Assert.True(result.Error);
            Assert.Contains("An error code we didn't handle was returned", result.Message);
            Assert.Equal(0, result.RemainingErrors);
            Assert.Equal(0, result.ErrorsTimeRemainingInWindowInSeconds);
        }

        [Fact]
        public async Task ProcessResponse_SuccessWithMissingWarningHeader_ShouldNotThrowException()
        {
            // Arrange - Create a successful response without warning header
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}")
            };
            
            // Act & Assert - should not throw an exception
            var result = await InvokeProcessResponse(response);
            
            Assert.False(result.Error);
            Assert.False(result.LegacyWarning);
        }

        [Fact]
        public async Task ProcessResponse_SuccessWithWarningHeader_ShouldParseCorrectly()
        {
            // Arrange - Create a successful response with warning header
            // RFC 7234 warning header format: warn-code SP warn-agent SP warn-text
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}")
            };
            // Use a properly formatted warning header per RFC 7234
            response.Headers.TryAddWithoutValidation("warning", "299 - \"This endpoint is deprecated\"");
            
            // Act
            var result = await InvokeProcessResponse(response);
            
            // Assert
            Assert.False(result.Error);
            Assert.True(result.LegacyWarning);
            Assert.Contains("299", result.Message);
        }

        // Helper method to invoke the private ProcessResponse method using reflection
        private async Task<APIResponse> InvokeProcessResponse(HttpResponseMessage response)
        {
            var method = typeof(APIBase).GetMethod("ProcessResponse", 
                BindingFlags.NonPublic | BindingFlags.Static);
            
            if (method == null)
            {
                throw new InvalidOperationException("ProcessResponse method not found");
            }
            
            var task = (Task<APIResponse>)method.Invoke(null, new object[] { response });
            return await task;
        }
    }
}
