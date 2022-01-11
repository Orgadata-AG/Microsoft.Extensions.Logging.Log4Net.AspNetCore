using System;

namespace Microsoft.Extensions.Logging.Scope
{
    internal class NullScopeProvider : IExternalScopeProvider
    {
        internal static NullScopeProvider Instance { get; } = new NullScopeProvider();

        /// <summary>
        /// Constructor that prevents external instantiation.
        /// </summary>
        private NullScopeProvider()
        {
        }

        public void ForEachScope<TState>(Action<object, TState> callback, TState state)
        {
            // All scopes are null scopes so do nothing.
        }

        public IDisposable Push(object state)
        {
            return NullScope.Instance;
        }
    }
}
