using Moq;
using Xunit;
using DryIoc;

// Note that some of DryIoc classes are not mockable with Moq
// so this test code also tests some of DryIoc
namespace ZenMvvm.DryIoc.Tests
{
    public class IocAdaptorTests
    {
        [Fact]
        public void Constructor_SetsContainer()
        {
            var containerMock = new Mock<IContainer>();

            var adaptor = new IocAdaptor(containerMock.Object);

            Assert.NotNull(adaptor.container);
        }

        [Fact]
        public void Resolve_CallsContainerResolve()
        {
            var containerMock = new Mock<IContainer>();
            var adaptor = new IocAdaptor(containerMock.Object);

            adaptor.Resolve(typeof(object));

            containerMock.Verify(c => c.Resolve(typeof(object), IfUnresolved.Throw));
        }
    }
}
