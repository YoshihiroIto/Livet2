using System.Collections.Concurrent;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using StatefulModel.EventListeners.WeakEvents;

namespace Livet.Messaging
{
    public sealed class MessageListener : IDisposable, IEnumerable<KeyValuePair<string, ConcurrentBag<Action<InteractionMessage>>>>
    {
        private readonly WeakEventListener<EventHandler<InteractionMessageRaisedEventArgs>, InteractionMessageRaisedEventArgs> _listener;
        private readonly WeakReference<InteractionMessenger> _source;
        private readonly ConcurrentDictionary<string, ConcurrentBag<Action<InteractionMessage>>> _actionDictionary = new ConcurrentDictionary<string, ConcurrentBag<Action<InteractionMessage>>>();
       
        public MessageListener(InteractionMessenger messenger)
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            _source = new WeakReference<InteractionMessenger>(messenger);
            _listener = new WeakEventListener<EventHandler<InteractionMessageRaisedEventArgs>, InteractionMessageRaisedEventArgs>
                (
                    h => h,
                    h => messenger.Raised += h,
                    h => messenger.Raised -= h,
                    MessageReceived
                );
        }

        public MessageListener(InteractionMessenger messenger, string messageKey, Action<InteractionMessage> action)
            : this(messenger)
        {
            if (messageKey == null)
            {
                messageKey = string.Empty;
            }

            RegisterAction(messageKey, action);
        }

        public MessageListener(InteractionMessenger messenger, Action<InteractionMessage> action)
            : this(messenger, null, action) { }

        public void RegisterAction(Action<InteractionMessage> action)
        {
            _actionDictionary.GetOrAdd(string.Empty, _ => new ConcurrentBag<Action<InteractionMessage>>()).Add(action);
        }

        public void RegisterAction(string messageKey, Action<InteractionMessage> action)
        {
            _actionDictionary.GetOrAdd(messageKey, _ => new ConcurrentBag<Action<InteractionMessage>>()).Add(action);
        }

        private void MessageReceived(object sender, InteractionMessageRaisedEventArgs e)
        {
            var message = e.Message;

            var cloneMessage = (InteractionMessage)message.Clone();

            cloneMessage.Freeze();

            DoActionOnDispatcher(() =>
                {
                    GetValue(e, cloneMessage);
                });

            var responsiveMessage = message as ResponsiveInteractionMessage;

            object response;
            if (responsiveMessage != null &&
                (response = ((ResponsiveInteractionMessage)cloneMessage).Response) != null)
            {
                responsiveMessage.Response = response;
            }
        }

        private void GetValue(InteractionMessageRaisedEventArgs e, InteractionMessage cloneMessage)
        {
            InteractionMessenger sourceResult;
            var result = _source.TryGetTarget(out sourceResult);

            if (!result) return;

            if (e.Message.MessageKey != null)
            {
                ConcurrentBag<Action<InteractionMessage>> list;
                _actionDictionary.TryGetValue(e.Message.MessageKey, out list);

                if (list != null)
                {
                    foreach (var action in list)
                    {
                        action(cloneMessage);
                    }
                }
            }

            ConcurrentBag<Action<InteractionMessage>> allList;
            _actionDictionary.TryGetValue(string.Empty, out allList);
            if (allList != null)
            {
                foreach (var action in allList)
                {
                    action(cloneMessage);
                }
            }
        }

        private void DoActionOnDispatcher(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Dispatcher.Invoke(action);
            }
        }

        IEnumerator<KeyValuePair<string, ConcurrentBag<Action<InteractionMessage>>>> IEnumerable<KeyValuePair<string, ConcurrentBag<Action<InteractionMessage>>>>.GetEnumerator() =>
            _actionDictionary.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _actionDictionary.GetEnumerator();

        public Dispatcher Dispatcher { get; set; }

        public void Add(Action<InteractionMessage> action)
        {
            RegisterAction(action);
        }

        public void Add(string messageKey, Action<InteractionMessage> action)
        {
            RegisterAction(messageKey, action);
        }

        public void Add(string messageKey, params Action<InteractionMessage>[] actions)
        {
            foreach (var action in actions)
            {
                RegisterAction(messageKey, action);
            }
        }


        public void Dispose()
        {
            _listener.Dispose();
        }
    }
}
