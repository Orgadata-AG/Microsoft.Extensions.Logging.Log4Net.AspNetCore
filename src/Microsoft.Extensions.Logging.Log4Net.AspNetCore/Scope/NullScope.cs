using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Logging.Scope
{
    internal class NullScope : IDisposable
    {
        internal static NullScope Instance { get; } = new NullScope();

        /// <summary>
        /// Constructor that prevents external instanciation.
        /// </summary>
        private NullScope()
        {
        }

        public void Dispose()
        {
            // This is a null scope so we need to dispose nothing.
        }
    }
}
