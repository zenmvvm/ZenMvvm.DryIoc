using System;
using SmartDi;

namespace ZenMvvm
{
    /// <summary>
    /// Adapts the <see cref="IDiContainer"/> to implement <see cref="IIoc"/>
    /// </summary>
    public class IocAdaptor : IIoc
    {
        internal readonly IDiContainer container;

        /// <summary>
        /// Construct the <see cref="IocAdaptor"/> from the provided
        ///  see <paramref name="container"/>
        /// </summary>
        /// <param name="container"></param>
        public IocAdaptor(IDiContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Resolves an object from the container
        /// </summary>
        /// <param name="typeToResolve"></param>
        /// <returns></returns>
        public object Resolve(Type typeToResolve)
        {
            return container.Resolve(typeToResolve);
        }
    }
}
