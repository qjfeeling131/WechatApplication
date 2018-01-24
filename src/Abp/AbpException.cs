﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abp
{
    /// <summary>
    /// Base exception type for those are thrown by Abp system for Abp specific exceptions.
    /// </summary>
    public class AbpException:Exception
    {
        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        public AbpException()
        {

        }
        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AbpException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AbpException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
