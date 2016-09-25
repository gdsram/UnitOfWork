using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.UoW;

namespace UnitOfWork.Models
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    public class ContainerBootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        /// <summary>
        /// Registering all the types
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            DbContext entities = new TeijonStuffEntities();
            container.RegisterInstance(entities);

            GenericUoW GUoW = new GenericUoW(entities);
            container.RegisterInstance(GUoW);

            MvcUnityContainer.Container = container;
            return container;
        }
    }
}