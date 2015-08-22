﻿using System;
using System.Windows.Interactivity;
using System.Windows;

namespace Livet.Behaviors
{
    public class DataContextDisposeAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke(object parameter)
        {
            var disposable = AssociatedObject.DataContext as IDisposable;
            disposable?.Dispose();
        }
    }
}
