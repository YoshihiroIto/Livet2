using System.Collections.Concurrent;
using System.ComponentModel;

namespace Livet
{
    internal class EventArgsFactory
    {
        private static readonly ConcurrentDictionary<string, PropertyChangedEventArgs> PropertyChangedEventArgsDictionary = new ConcurrentDictionary<string, PropertyChangedEventArgs>();
        public static PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
        {
            return PropertyChangedEventArgsDictionary.GetOrAdd(propertyName, name => new PropertyChangedEventArgs(name));
        }
    }
}
