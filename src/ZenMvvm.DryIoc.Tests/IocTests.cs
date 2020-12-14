using System;
using Moq;
using DryIoc;
using Xunit;

// Note that some of DryIoc classes are not mockable with Moq
// so this test code also tests some of DryIoc
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

            Ioc.Init(Rules.Default);

            Assert.NotNull(Ioc.Container);
        }

        [Fact]
        public void Init_settings_SetsViewModelLocatorIoc()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;

            
            Ioc.Init(Rules.Default);

            Assert.NotNull(ViewModelLocator.Ioc);
        }

        [Fact]
        public void Init_configureSettings_SetsContainer()
        {
            Ioc.Container = null;

            Ioc.Init(rules => rules.WithDefaultIfAlreadyRegistered(IfAlreadyRegistered.Throw));

            Assert.NotNull(Ioc.Container);
        }

        [Fact]
        public void Init_configureSettings_SetsViewModelLocatorIoc()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;
            var mockSettingsAction = new Mock<Func<Rules, Rules>>();

            Ioc.Init(mockSettingsAction.Object);

            Assert.NotNull(ViewModelLocator.Ioc);
        }

        [Fact]
        public void Init_Registers_INavigationService()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;
            var container = new Container();

            Ioc.Init(container);

            Assert.IsType<NavigationService>(Ioc.Container.Resolve<INavigationService>());                
        }
    }
}
