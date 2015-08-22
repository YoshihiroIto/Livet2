using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace Livet
{
    public static class DispatcherHelper
    {
        public static Dispatcher UIDispatcher { get; set; } = (bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue) ?
            Dispatcher.CurrentDispatcher :
            null;
    }
}
