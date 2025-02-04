using FireWarningSystem.Data.Services;
using FireWarningSystem.UiLogic.Models.FireWarningModels;
using FireWarningSystem.UiLogic.Services;
using FireWarningSystem.UiLogic.ViewModels.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;
using WarningClient.Client;
using WarningClient.Models;

namespace FireWarningSystem.UiLogic.Tests.ViewModels
{
    [TestClass]
    public class FireWarningViewModelTest
    {
        private Mock<IAzureMapsRenderService> _azureMapsRenderService = default!;
        private Mock<IConfiguration> _configuration = default!;
        private Mock<IEmailService> _emailService = default!;
        private Mock<ILogger<FireWarningViewModel>> _logger = default!;
        private Mock<ISnackbarService> _snackbarService = default!;
        private Mock<IWarningClient> _warningClient = default!;

        private FireWarningViewModel _viewModel = default!;

        [TestInitialize]
        public void InitialiseTest() 
        {
            _azureMapsRenderService = new Mock<IAzureMapsRenderService>(MockBehavior.Strict);
            _configuration = new Mock<IConfiguration>(MockBehavior.Strict);
            _emailService = new Mock<IEmailService>(MockBehavior.Strict);
            _logger = new Mock<ILogger<FireWarningViewModel>>(MockBehavior.Strict);
            _snackbarService = new Mock<ISnackbarService>(MockBehavior.Strict);
            _warningClient = new Mock<IWarningClient>(MockBehavior.Strict);

            _viewModel = new FireWarningViewModel(_azureMapsRenderService.Object, _configuration.Object, _emailService.Object,
                _logger.Object, _snackbarService.Object, _warningClient.Object);
        }

        //A private method SetupWarningApi() is declared to remeove the need to repeat the setup between tests that call the API.
        // the actual logic for testing the result of the GenerateWarningsAsync() Method is done in the unit test covering
        //RefreshWarningsAsync()

        [TestMethod]
        public async Task ChangeViewMode_ToContactForm() 
        {
            _viewModel.Model.ViewType = FireWarningViewType.WarningPage;

            await _viewModel.ChangeViewMode();

            Assert.AreEqual(FireWarningViewType.ContactPage, _viewModel.Model.ViewType);
        }

        [TestMethod]
        public async Task ChangeViewMode_ToWarningPage()
        {
            _viewModel.Model.ViewType = FireWarningViewType.ContactPage;

            SetupWarningApi();

            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            await _viewModel.ChangeViewMode();

            Mock.VerifyAll(_azureMapsRenderService, _warningClient);

            Assert.AreEqual(FireWarningViewType.WarningPage, _viewModel.Model.ViewType);
        }

        [TestMethod]
        public async Task OnInitialisedAsync() 
        {
            SetupWarningApi();

            await _viewModel.OnInitialisedAsync();

            Mock.VerifyAll(_azureMapsRenderService, _warningClient);
        }

        [TestMethod]
        public async Task OnInitialisedAsync_Exception()
        {

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Something went wrong, Please contact support@email.com"));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");

            await _viewModel.OnInitialisedAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService);
        }

        [TestMethod]
        public async Task RenderMapAsync()
        {

            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RenderMapAsync();

            Mock.Verify(_azureMapsRenderService);
        }

        [TestMethod]
        public async Task RenderMapAsync_Exception()
        {

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to render map, Please contact support@email.com"));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");

            await _viewModel.RenderMapAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService);
        }

        //primary Test for asserting returns from Warnings API

        [TestMethod]
        public async Task RefreshWarningsAsync() 
        {
            SetupWarningApi();

            WarningsModel warnings = default!;

            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Callback<WarningsModel>(x => warnings = x)
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();


            Assert.AreEqual("Act Warning", warnings.ActWarnings.Single().Title);
            Assert.AreEqual(30, warnings.ActWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.ActWarnings.Single().Longitude);

            Assert.AreEqual("Vic Warning", warnings.VicWarnings.Single().Title);
            Assert.AreEqual(30, warnings.VicWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.VicWarnings.Single().Longitude);

            Assert.AreEqual("Nt Warning", warnings.NtWarnings.Single().Title);
            Assert.AreEqual(30, warnings.NtWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.NtWarnings.Single().Longitude);

            Assert.AreEqual("Nsw Warning", warnings.NswWarnings.Single().Title);
            Assert.AreEqual(30, warnings.NswWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.NswWarnings.Single().Longitude);

            Assert.AreEqual("Qld Warning", warnings.QldWarnings.Single().Title);
            Assert.AreEqual(30, warnings.QldWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.QldWarnings.Single().Longitude);

            Assert.AreEqual("Sa Warning", warnings.SaWarnings.Single().Title);
            Assert.AreEqual(30, warnings.SaWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.SaWarnings.Single().Longitude);

            Assert.AreEqual("Tas Warning", warnings.TasWarnings.Single().Title);
            Assert.AreEqual(30, warnings.TasWarnings.Single().Latitude);
            Assert.AreEqual(31, warnings.TasWarnings.Single().Longitude);

            Assert.AreEqual("Wa Warning", warnings.WaWarnings.First().Title);
            Assert.AreEqual(30, warnings.WaWarnings.First().Latitude);
            Assert.AreEqual(31, warnings.WaWarnings.First().Longitude);

            //This is a warning with invalid lat / long. Check that it went to the Invalid Warnings table. 
            Assert.AreEqual("Wa Warning Invalid", warnings.InvalidWarnings.First().Title);
            Assert.AreEqual(1000, warnings.InvalidWarnings.First().Latitude);
            Assert.AreEqual(1001, warnings.InvalidWarnings.First().Longitude);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_ActApiError() 
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetActWarningsAsync())
                .ThrowsAsync(new Exception("Act Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get ACT Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_NswApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetNswWarningsAsync())
                .ThrowsAsync(new Exception("Nsw Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get NSW Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_NTApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetNtWarningsAsync())
                .ThrowsAsync(new Exception("NT Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get NT Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_QldApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetQldWarningsAsync())
                .ThrowsAsync(new Exception("QLD Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get QLD Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_SaApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetSaWarningsAsync())
                .ThrowsAsync(new Exception("SA Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get SA Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_TasApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetTasWarningsAsync())
                .ThrowsAsync(new Exception("TAS Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get TAS Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_VicApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetVicWarningsAsync())
                .ThrowsAsync(new Exception("VIC Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get VIC Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task RefreshWarningsAsync_WaApiError()
        {
            SetupWarningApi();
            //override intended test api setup
            _warningClient.Setup(x => x.GetWaWarningsAsync())
                .ThrowsAsync(new Exception("WA Api Error"));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to get WA Warnings from State emergency service. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");


            _azureMapsRenderService.Setup(x => x.GenerateWarningsMap(It.IsAny<WarningsModel>()))
                .Returns(Task.CompletedTask);

            await _viewModel.RefreshWarningsAsync();

            Mock.VerifyAll(_configuration, _logger, _snackbarService, _warningClient);
        }

        [TestMethod]
        public async Task SubmitContactFormAsync() 
        {
            _viewModel.Model = new()
            {
                Contact = new() 
                {
                    Email = "john@gmail.com",
                    Name = "john smith",
                    Message = "johns message"
                },
                ViewType = FireWarningViewType.ContactPage
            };

            _emailService.Setup(x => x.SendFormEmailAsync("john@gmail.com", "Fire Warning Contact Form - john smith", "johns message"))
                .Returns(Task.CompletedTask);

            _snackbarService.Setup(x => x.Success("Message successfully sent."));

            await _viewModel.SubmitContactFormAsync();

            Mock.VerifyAll(_emailService, _snackbarService);

            Assert.AreEqual(FireWarningViewType.WarningPage, _viewModel.Model.ViewType);
        }

        [TestMethod]
        public async Task SubmitContactFormAsync_Exception()
        {
            _viewModel.Model = new()
            {
                Contact = new()
                {
                    Email = "john@gmail.com",
                    Name = "john smith",
                    Message = "johns message"
                },
                ViewType = FireWarningViewType.ContactPage
            };

            _emailService.Setup(x => x.SendFormEmailAsync("john@gmail.com", "Fire Warning Contact Form - john smith", "johns message"))
                .ThrowsAsync(new Exception("Email exception."));

            _logger.Setup(logger => logger.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((@object, @type) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ));

            _snackbarService.Setup(x => x.Error("Unable to send your message. Please contact support@email.com if this persists."));

            _configuration.Setup(x => x["supportEmail"])
                .Returns("support@email.com");

            await _viewModel.SubmitContactFormAsync();

            Mock.VerifyAll(_emailService, _snackbarService);

            Assert.AreEqual(FireWarningViewType.ContactPage, _viewModel.Model.ViewType);
        }

        private void SetupWarningApi()
        {
            _warningClient.Setup(x => x.GetActWarningsAsync())
                .ReturnsAsync(new ActIncident[] { new ActIncident() { Title = "Act Warning", Region="act", Latitude = "30", Longitude = "31" } });

            _warningClient.Setup(x => x.GetVicWarningsAsync())
                .ReturnsAsync(new VicIncident[] { new VicIncident() { Name = "Vic Warning", Latitude = 30, Longitude = 31 } });

            _warningClient.Setup(x => x.GetNtWarningsAsync())
                .ReturnsAsync(
                new NtIncident[]
                {
                    new NtIncident()
                    {
                        Properties = new()
                        {
                            EventType = "Nt Warning"
                        },
                        Geometry = new()
                        {
                            Coordinates =  JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(new List<double>() { 31, 30 })),
                            Type = "Point"
                        }
                    }
                });

            _warningClient.Setup(x => x.GetNswWarningsAsync())
                .ReturnsAsync(
                new NswFeature[]
                {
                    new NswFeature()
                    {
                        Properties = new()
                        {
                            Title = "Nsw Warning"
                        },
                        Geometry = new()
                        {
                            Coordinates = [31, 30]
                        }
                    }
                });

            _warningClient.Setup(x => x.GetQldWarningsAsync())
               .ReturnsAsync(
               new QldIncident[]
               {
                    new QldIncident()
                    {
                        Properties = new()
                        {
                            MasterIncidentNumber = "Qld Warning",
                            Latitude = 30,
                            Longitude = 31
                        }
                    }
               });


            _warningClient.Setup(x => x.GetSaWarningsAsync())
                .ReturnsAsync(new SaIncident[] { new SaIncident() { IncidentNo = "Sa Warning", Location = "30,31" } });

            _warningClient.Setup(x => x.GetTasWarningsAsync())
                     .ReturnsAsync(
                     new TasFeature[]
                     {
                    new TasFeature()
                    {
                        Properties = new()
                        {
                            Title = "Tas Warning"
                        },
                        Geometry = new()
                        {
                            Geometries = new List<TasGeometry>
                            {
                                new()
                                {
                                    Type = "Point",
                                    Coordinates = JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(new List<double>() { 31, 30 }))
                                }
                            }
                        }
                    }
                     });

            _warningClient.Setup(x => x.GetWaWarningsAsync())
                .ReturnsAsync(
                new WaIncident[]
                { 
                    new WaIncident() { Name = "Wa Warning", Location = new() { Latitude = 30, Longitude = 31 } },
                    new WaIncident() { Name = "Wa Warning Invalid", Location = new() { Latitude = 1000, Longitude = 1001 } }}
                );
        }
    }
}
