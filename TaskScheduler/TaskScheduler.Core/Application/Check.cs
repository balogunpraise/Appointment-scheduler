using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.Core.Application.Extensions;

namespace TaskScheduler.Core.Application
{
    public static class Check
    {
        public static class Argument
        {
            [DebuggerStepThrough]
            public static void IsNotEmpty(Guid argument, string argumentName)
            {
                if(argument == Guid.Empty)
                {
                    throw new ArgumentException("\"{0}\" cannot be empty guid", argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(int argument, string argumentName)
            {
                if(argument < 0)
                {
                    throw new ArgumentException("\"{0}\", cannot be a negative value", argumentName);
                }
            }

            public static void IsNotNullOrEmpty(string argument, string argumentName)
            {
                var check = argument.IsNotNullOrEmpty();
                if(!check)
                {
                    throw new ArgumentException("\"{0}\", cannot be null", argumentName);
                }
            }
        }
    }
}
