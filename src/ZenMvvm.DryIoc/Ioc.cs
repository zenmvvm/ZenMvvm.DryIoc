using System;
using SmartDi;

namespace ZenMvvm
{
    /// <summary>
    /// Utility to initialize the container and set the <see cref="ViewModelLocator.Ioc"/>
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// Returns a <see cref="SmartDi.IDiContainer"/>
        /// </summary>
        public static IDiContainer Container { get; internal set; }

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with the given
        ///  <paramref name="container"/> and registers <see cref="INavigationService"/>
        ///  for Mvvm navigation.
        /// </summary>
        /// <param name="container"></param>
        public static void Init(IDiContainer container)
        {
            container
                .Register<INavigationService, NavigationService>(Type.EmptyTypes);
            Container = container;
            ViewModelLocator.Ioc = new IocAdaptor(Container);
        }

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with a default 
        /// container and registers <see cref="INavigationService"/>
        ///  for Mvvm navigation.
        /// </summary>
        public static void Init()
            => Init(new DiContainer());

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with a container 
        /// configured with provided <see cref="ContainerOptions"/> and registers
        /// <see cref="INavigationService"/> for Mvvm navigation.
        /// </summary>
        public static void Init(ContainerOptions settings)
            => Init(new DiContainer(settings));

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with a container 
        /// configured with provided configuration and registers
        /// <see cref="INavigationService"/> for Mvvm navigation.
        /// </summary>
        public static void Init(Action<ContainerOptions> configureSettings)
            => Init(new DiContainer(configureSettings));
    }
}
