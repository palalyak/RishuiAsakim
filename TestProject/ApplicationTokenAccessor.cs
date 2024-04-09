using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Main       
    public class ApplicationTokenAccessor
    {
        private AuthenticationResult _accessToken;
        private readonly AzureSettings _options;
        private readonly ITokenValidationService _tokenValidationService;
        ILogger<ApplicationTokenAccessor> _logger;

                       
        public ApplicationTokenAccessor(IOptions<AzureSettings> options, ITokenValidationService tokenValidationService,
            ILogger<ApplicationTokenAccessor> logger)
        {
            _logger = logger;
            _options = options.Value;
            _tokenValidationService = tokenValidationService;
        }

        public string GetAcessToken()
        {
            return _accessToken?.AccessToken;
        }

        public bool IsExpired()
        {
            return _accessToken.ExpiresOn.DateTime <= DateTime.Now;
        }

        public bool IsValid()
        {
            try
            {
                _logger.LogInformation("Check if batch Service Token is valid");

                if (string.IsNullOrEmpty(_options.BatchSecretKey))
                {
                    _logger.LogError("BatchSecretKey is empty. It's ok in debug mode for non batch services");
                    return true;
                }


                _logger.LogInformation("Batch token is valid");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return false;
            }
        }

        public async Task LoadServiceToken()
        {
            _logger.LogInformation("Start Load batch Service Token");

            if (string.IsNullOrEmpty(_options.BatchSecretKey))
            {
                _logger.LogError("BatchSecretKey is empty. It's ok in debug mode for non batch services");
                return;
            }

            _accessToken = null;

            var app = ConfidentialClientApplicationBuilder.Create(_options.ClientId)
                       .WithClientSecret(_options.BatchSecretKey)
                       .Build();

            var authResult = await app.AcquireTokenForClient(scopes: new[] { _options.ClientScope })
                   .WithAuthority(AzureCloudInstance.AzurePublic, _options.TenantId)
                   .ExecuteAsync();

            _accessToken = authResult;

            _logger.LogInformation("End Load batch Service Token");
        }
    }
}
