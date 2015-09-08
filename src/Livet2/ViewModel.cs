using Livet.Messaging;
using StatefulModel;
using System;
using System.Threading;
using System.Windows.Threading;

namespace Livet
{
    public abstract class ViewModel : NotificationObject, IDisposable
    {
        public InteractionMessenger Messenger { get; set; } = new InteractionMessenger();
        public CompositeDisposable CompositeDisposable { get; set; } = new CompositeDisposable();
        public static SynchronizationContext DispatcherContext { get; } = new DispatcherSynchronizationContext(DispatcherHelper.UIDispatcher); 

        #region IDisposable Support
        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    CompositeDisposable?.Dispose();
                }
                _disposedValue = true;

                CompositeDisposable?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
