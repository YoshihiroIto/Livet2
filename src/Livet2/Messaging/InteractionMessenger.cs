using System;
using System.Threading.Tasks;
using System.Threading;
namespace Livet.Messaging
{
    public class InteractionMessenger
    {
        public void Raise(InteractionMessage message)
        {
            if (message == null) { throw new ArgumentNullException(nameof(message)); }

            var threadSafeHandler = Interlocked.CompareExchange(ref Raised, null, null);

            if (threadSafeHandler != null)
            {
                if (!message.IsFrozen)
                {
                    message.Freeze();
                }

                threadSafeHandler(this, new InteractionMessageRaisedEventArgs(message));
            }
        }

        public T GetResponse<T>(T message)
            where T : ResponsiveInteractionMessage
        {
            if (message == null) { throw new ArgumentNullException(nameof(message)); }

            var threadSafeHandler = Raised;
            if (threadSafeHandler != null)
            {
                if (!message.IsFrozen)
                {
                    message.Freeze();
                }

                threadSafeHandler(this, new InteractionMessageRaisedEventArgs(message));
                return message;
            }

            return null;
        }

        public event EventHandler<InteractionMessageRaisedEventArgs> Raised;

        public async Task RaiseAsync(InteractionMessage message)
        {
            if (message == null) { throw new ArgumentNullException(nameof(message)); }
            if (!message.IsFrozen)
            {
                message.Freeze();
            }
            await Task.Factory.StartNew(() => Raise(message));
        }

        public async Task<T> GetResponseAsync<T>(T message)
            where T : ResponsiveInteractionMessage
        {
            if (message == null) { throw new ArgumentNullException(nameof(message)); }

            if (!message.IsFrozen)
            {
                message.Freeze();
            }
            return await Task<T>.Factory.StartNew(() => GetResponse(message));
        }
    }

    public class InteractionMessageRaisedEventArgs : EventArgs
    {
        public InteractionMessageRaisedEventArgs(InteractionMessage message)
        {
            Message = message;
        }
        public InteractionMessage Message
        {
            get;
            set;
        }
    }
}