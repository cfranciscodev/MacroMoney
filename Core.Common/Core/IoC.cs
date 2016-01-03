using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Core.Common.Core
{
    public class IoC
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    throw new InvalidOperationException("IoC backing container has not been initialized.");
                }
                return _container;
            }
            set { _container = value; }
        }
    }
}
