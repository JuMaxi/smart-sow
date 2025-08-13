using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Models;

namespace SmartTray.Tests.Mappers;

public class TrayMapperTests
{
    // Verifying that the interface's method has been called
    [Fact]
    public void When_Converting_TrayRequest_To_Tray_It_Should_Receive_One_Call_To_Interface_Method()
    {
        ITraySettingsMapper traySettingsMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingsMapperMock);

        TrayRequest trayRequest = new TrayRequest()
        {
            settings = new()
        };

        Tray tray = trayMapper.ConvertToTray(trayRequest);

        traySettingsMapperMock.Received(1).ConvertToTraySettings(trayRequest.settings);
    }

    // Verifying that the interface's method has been called, but also FORCING a method to return null
    [Fact]
    public void When_Converting_TrayRequest_To_Tray_It_Should_Receive_One_Call_To_Interface_Method_As_Null()
    {
        ITraySettingsMapper traySettingsMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingsMapperMock);

        TrayRequest trayRequest = new TrayRequest()
        {
            settings = new()
        };

        // Not CALLING the method here, CONFIGURING the return - the actual call will be performed by the code being tested
        traySettingsMapperMock.ConvertToTraySettings(trayRequest.settings).ReturnsNull();

        Tray tray = trayMapper.ConvertToTray(trayRequest);

        traySettingsMapperMock.Received(1).ConvertToTraySettings(trayRequest.settings);
        tray.Settings.Should().BeNull();
    }

    // Verifying that the interface's method has been called, but also FORCING a method to return a settings tray, a static result/value.
    [Fact]
    public void When_Converting_TrayRequest_It_Should_Be_Equal_To_Tray()
    {
        ITraySettingsMapper traySettingsMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingsMapperMock);

        TrayRequest trayRequest = new TrayRequest()
        {
            Name = "My First Tray",
            CropType = "Basil",
            SowingDate = DateTime.UtcNow,
            settings = new()
            {
                Temperature = 25,
                Humidity = 1,
                LightTime = 12
            }
        };

        TraySettings traySettings = new()
        {
            TemperatureCelsius = trayRequest.settings.Temperature,
            Humidity = (HumidityLevel)trayRequest.settings.Humidity,
            DailySolarHours = trayRequest.settings.LightTime
        };

        traySettingsMapperMock.ConvertToTraySettings(trayRequest.settings).Returns(traySettings);

        Tray tray = trayMapper.ConvertToTray(trayRequest);

        tray.Name.Should().Be(trayRequest.Name);
        tray.CropType.Should().Be(trayRequest.CropType);
        tray.SowingDate.Should().BeCloseTo(trayRequest.SowingDate, TimeSpan.FromSeconds(1));
        tray.Settings.TemperatureCelsius.Should().Be(traySettings.TemperatureCelsius);
        tray.Settings.Humidity.Should().Be(traySettings.Humidity);
        tray.Settings.DailySolarHours.Should().Be(traySettings.DailySolarHours);
    }

    // Verifying that the interface's method has been called
    [Fact]
    public void When_Converting_Tray_To_TrayResponse_It_Should_Receive_One_Call_To_Interface_Method()
    {
        ITraySettingsMapper traySettingsMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingsMapperMock);

        Tray tray = new()
        {
            Settings = new()
        };

        TrayResponse trayResponse = trayMapper.ConvertToResponse(tray);

        traySettingsMapperMock.Received(1).ConvertToResponse(tray.Settings);
    }

    // Verifying that the interface's method has been called and returned null
    [Fact]
    public void When_Converting_Tray_To_TrayResponse_It_Should_Receive_One_Call_To_Interface_Method_As_Null()
    {
        ITraySettingsMapper traySettingsMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingsMapperMock);

        Tray tray = new()
        {
            Settings = null
        };

        traySettingsMapperMock.ConvertToResponse(tray.Settings).ReturnsNull();

        TrayResponse trayResponse = trayMapper.ConvertToResponse(tray);

        traySettingsMapperMock.Received(1).ConvertToResponse(tray.Settings);
        trayResponse.Settings.Should().BeNull();
    }

    // Verifying that tray response data is equal to tray data received
    [Fact]
    public void When_Converting_Tray_It_Should_Be_Equal_To_TrayResponse()
    {
        ITraySettingsMapper traySettingsMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingsMapperMock);

        Tray tray = new()
        {
            Name = "My First Tray",
            CropType = "Basil",
            SowingDate = DateTime.UtcNow,
            Settings = new()
            {
                TemperatureCelsius = 25,
                Humidity = HumidityLevel.MediumHumidity,
                DailySolarHours = 12
            }
        };

        TraySettingsResponse traySettingsResponse = new()
        {
            TemperatureCelsius = tray.Settings.TemperatureCelsius,
            Humidity = Convert.ToInt32(tray.Settings.Humidity),
            DailySolarHours = tray.Settings.DailySolarHours,
        };

        // Forcing the interface's method returning the tray settings response above
        traySettingsMapperMock.ConvertToResponse(tray.Settings).Returns(traySettingsResponse);

        TrayResponse trayResponse = trayMapper.ConvertToResponse(tray);
        trayResponse.Name.Should().Be(tray.Name);
        trayResponse.CropType.Should().Be(tray.CropType);
        trayResponse.SowingDate.Should().BeCloseTo(tray.SowingDate, TimeSpan.FromSeconds(1));
        trayResponse.Settings.TemperatureCelsius.Should().Be(traySettingsResponse.TemperatureCelsius);
        trayResponse.Settings.Humidity.Should().Be(traySettingsResponse.Humidity);
        trayResponse.Settings.DailySolarHours.Should().Be(traySettingsResponse.DailySolarHours);
    }

    // Verifying that tray response list data is equal to tray data received
    [Fact]
    public void When_Converting_List_Tray_It_Should_Be_Equal_To_List_Tray_Response()
    {
        ITraySettingsMapper traySettingMapperMock = Substitute.For<ITraySettingsMapper>();

        TrayMapper trayMapper = new(traySettingMapperMock);

        List<Tray> trays = new()
        {
            new Tray()
            {
                Id = 1,
                Name = "My First Tray",
                CropType = "Basil",
                SowingDate = DateTime.UtcNow,
                Status = Status.Inactive,
                Token = "kd9Of30"
            },
            new Tray()
            {
                Id = 2,
                Name = "My Second Tray",
                CropType = "Dill",
                SowingDate = DateTime.UtcNow,
                Status = Status.Active,
                Token = "gT8lE0w"
            }
        };

        traySettingMapperMock.ConvertToResponse(null).ReturnsNull();

        List<TrayResponse> traysResponse = trayMapper.ConvertToResponseList(trays);

        // Verifying index 0
        traysResponse[0].Id.Should().Be(trays[0].Id);
        traysResponse[0].Name.Should().Be(trays[0].Name);
        traysResponse[0].CropType.Should().Be(trays[0].CropType);
        traysResponse[0].SowingDate.Should().BeCloseTo(trays[0].SowingDate, TimeSpan.FromSeconds(1));
        traysResponse[0].Status.Should().Be(trays[0].Status.ToString());
        traysResponse[0].Token.Should().Be(trays[0].Token);

        // Verifying index 1
        traysResponse[1].Id.Should().Be(trays[1].Id);
        traysResponse[1].Name.Should().Be(trays[1].Name);
        traysResponse[1].CropType.Should().Be(trays[1].CropType);
        traysResponse[1].SowingDate.Should().BeCloseTo(trays[1].SowingDate, TimeSpan.FromSeconds(1));
        traysResponse[1].Status.Should().Be(trays[1].Status.ToString());
        traysResponse[1].Token.Should().Be(trays[1].Token);
    }
}
