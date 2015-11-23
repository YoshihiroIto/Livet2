using Livet.Messaging;
using StatefulModel;
using System;

namespace Livet
{
    public abstract class ViewModel : NotificationObject, IDisposable
    {
        public InteractionMessenger Messenger { get; set; } = new InteractionMessenger();
        public MultipleDisposable MultipleDisposable { get; set; } = new MultipleDisposable();

        #region IDisposable Support
        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    MultipleDisposable?.Dispose();
                }
                _disposedValue = true;

                MultipleDisposable?.Dispose();
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
