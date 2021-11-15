using System;
using System.Collections;
using System.Threading;

namespace CommonLibrary.Classes
{
    public class DateTimeProviderContext : IDisposable
    {
        internal DateTime ContextDateTimeNow;

        private static readonly ThreadLocal<Stack> ThreadScopeStack = new(() => new Stack());

        private Stack _contextStack = new();

        public DateTimeProviderContext(DateTime contextDateTimeNow)
        {
            ContextDateTimeNow = contextDateTimeNow;
            ThreadScopeStack.Value.Push(this);
        }

        public static DateTimeProviderContext Current => ThreadScopeStack.Value.Count == 0 ? null : ThreadScopeStack.Value.Peek() as DateTimeProviderContext;

        public void Dispose()
        {
            ThreadScopeStack.Value.Pop();
        }
    }
}