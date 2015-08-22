using Livet.Messaging;
using StatefulModel;
using System;

namespace Livet
{
    public abstract class ViewModel : NotificationObject, IDisposable
    {
        public InteractionMessenger Messenger { get; set; } = new InteractionMessenger();
        public CompositeDisposable CompositeDisposable { get; set; } = new CompositeDisposable();

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
