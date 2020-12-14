using System;
using Moq;
using SmartDi;
using Xunit;

namespace ZenMvvm.DryIoc.Tests
{
    public class IocTests
    {
        [Fact]
        public void Init_SetsContainer()
        {
            Ioc.Container = null;

            Ioc.Init();

            Assert.NotNull(Ioc.Container);
        }
        [Fact]
        public void Init_SetsViewModelLocatorIoc()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;

            Ioc.Init();

            Assert.NotNull(ViewModelLocator.Ioc);
        }

        [Fact]
        public void Init_settings_SetsContainer()
        {
            Ioc.Container = null;
            var mockSettings = new Mock<ContainerOptions>();

            Ioc.Init(mockSettings.Object);

            Assert.NotNull(Ioc.Container);
        }

        [Fact]
        public void Init_settings_SetsViewModelLocatorIoc()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;
            var mockSettings = new Mock<ContainerOptions>();

            Ioc.Init(mockSettings.Object);

            Assert.NotNull(ViewModelLocator.Ioc);
        }

        [Fact]
        public void Init_configureSettings_SetsContainer()
        {
            Ioc.Container = null;
            var mockSettingsAction = new Mock<Action<ContainerOptions>>();

            Ioc.Init(mockSettingsAction.Object);

            Assert.NotNull(Ioc.Container);
        }

        [Fact]
        public void Init_configureSettings_SetsViewModelLocatorIoc()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;
            var mockSettingsAction = new Mock<Action<ContainerOptions>>();

            Ioc.Init(mockSettingsAction.Object);

            Assert.NotNull(ViewModelLocator.Ioc);
        }

        [Fact]
        public void Init_Registers_INavigationService()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;
            var mockContainer = new Mock<IDiContainer>();

            Ioc.Init(mockContainer.Object);

            mockContainer.Verify(c => c.Register<INavigationService, NavigationService>(Type.EmptyTypes));
        }
    }
}
