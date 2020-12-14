using Moq;
using Xunit;
using SmartDi;

namespace ZenMvvm.DryIoc.Tests
{
    public class IocAdaptorTests
    {
        [Fact]
        public void Constructor_SetsContainer()
        {
            var containerMock = new Mock<IDiContainer>();

            var adaptor = new IocAdaptor(containerMock.Object);

            Assert.NotNull(adaptor.container);
        }

        [Fact]
        public void Resolve_CallsContainerResolve()
        {
            var containerMock = new Mock<IDiContainer>();
            var adaptor = new IocAdaptor(containerMock.Object);

            adaptor.Resolve(typeof(object));

            containerMock.Verify(c => c.Resolve(typeof(object)));
        }
    }
}
