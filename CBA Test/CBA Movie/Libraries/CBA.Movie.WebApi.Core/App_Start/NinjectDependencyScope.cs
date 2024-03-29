﻿//-----------------------------------------------------------------------
// <copyright file="DtoMapperConfig.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.WebApi.Core.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Web.Http.Dependencies;
    using Ninject;
    using Ninject.Syntax;

    /// <summary>
    /// Defines dependency scope of this project.
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has already been disposed");

            return resolver.GetAll(serviceType);
        }
    }
}