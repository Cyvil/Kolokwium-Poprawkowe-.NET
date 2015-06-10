using System;

namespace Cards
{
    /// <summary>
    /// Provides <see cref="IDispatcher"/> implementation
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public class MyDispatcher : IDispatcher
    {
        private readonly System.Windows.Threading.Dispatcher _dispatcher;

        public MyDispatcher(System.Windows.Threading.Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void RunOnUi(Action action)
        {
            _dispatcher.BeginInvoke(action);
        }
    }
}
