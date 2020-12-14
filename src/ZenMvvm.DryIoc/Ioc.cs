using System;
using DryIoc;

namespace ZenMvvm
{
    /// <summary>
    /// Utility to initialize the container and set the <see cref="ViewModelLocator.Ioc"/>
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// Returns a <see cref="DryIoc.IContainer"/>
        /// </summary>
        public static IContainer Container { get; internal set; }

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with the given
        ///  <paramref name="container"/> and registers <see cref="INavigationService"/>
        ///  for Mvvm navigation.
        /// </summary>
        /// <param name="container"></param>
        public static void Init(IContainer container)
        {
            container
                .Register<INavigationService, NavigationService>(
                    made: Made.Of(
                        typeof(NavigationService)
                        .GetConstructor(Type.EmptyTypes)));
            Container = container;
            ViewModelLocator.Ioc = new IocAdaptor(Container);
        }

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with a default 
        /// container and registers <see cref="INavigationService"/>
        ///  for Mvvm navigation.
        /// </summary>
        public static void Init()
            => Init(new Container());

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with a container 
        /// configured with provided <see cref="ContainerOptions"/> and registers
        /// <see cref="INavigationService"/> for Mvvm navigation.
        /// </summary>
        public static void Init(Rules rules)
            => Init(new Container(rules));

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with a container 
        /// configured with provided configuration and registers
        /// <see cref="INavigationService"/> for Mvvm navigation.
        /// </summary>
        public static void Init(Func<Rules, Rules> configureRules)
            => Init(new Container(configureRules));
    }
}
