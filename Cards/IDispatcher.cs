using System;

namespace Cards
{
    /// <summary>
    /// Dispatcher "service" to be used in ViewModel
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Runs application on UI
        /// </summary>
        /// <param name="action">Action to be preformed on UI</param>
        void RunOnUi(Action action);
    }
}
