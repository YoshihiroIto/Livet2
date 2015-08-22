﻿//this code generated by T4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Windows.Interop;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Annotations;
using System.Windows.Ink;
using System.Windows.Automation.Peers;
using System.Windows.Markup.Localizer;
using System.Windows.Media.Imaging;
using System.IO.Packaging;
using System.Security.RightsManagement;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Security.Permissions;
using System.Windows.Annotations.Storage;
using System.Diagnostics;

namespace Livet.Converters
{
    public class IntersectionDetailAndBooleanConverter : IValueConverter
    {
        //VM→View
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool)) throw new ArgumentException();

            if ((bool)value)
            {
                if (_isConvertWhenTrueSet)
                {
                    return ConvertWhenTrue;
                }
            }
            else
            {
                if (_isConvertWhenFalseSet)
                {
                    return ConvertWhenFalse;
                }
            }

            return DependencyProperty.UnsetValue;
        }

        private bool _isConvertWhenTrueSet;
        private IntersectionDetail _convertWhenTrue;
        public IntersectionDetail ConvertWhenTrue
        {
            get
            {
                return _convertWhenTrue;
            }
            set
            {
                _convertWhenTrue = value;
                _isConvertWhenTrueSet = true;
            }
        }

        private bool _isConvertWhenFalseSet;
        private IntersectionDetail _convertWhenFalse;
        public IntersectionDetail ConvertWhenFalse
        {
            get
            {
                return _convertWhenFalse;
            }
            set
            {
                _convertWhenFalse = value;
                _isConvertWhenFalseSet = true;
            }
        }

        //View→VM
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is IntersectionDetail)) throw new ArgumentException();

            var enumValue = (IntersectionDetail)value;

			switch(enumValue.ToString())
			{
				case "NotCalculated":
					if (_isConvertBackWhenNotCalculatedSet)
					{
						return ConvertBackWhenNotCalculated;
					}
					break;
				case "Empty":
					if (_isConvertBackWhenEmptySet)
					{
						return ConvertBackWhenEmpty;
					}
					break;
				case "FullyInside":
					if (_isConvertBackWhenFullyInsideSet)
					{
						return ConvertBackWhenFullyInside;
					}
					break;
				case "FullyContains":
					if (_isConvertBackWhenFullyContainsSet)
					{
						return ConvertBackWhenFullyContains;
					}
					break;
				case "Intersects":
					if (_isConvertBackWhenIntersectsSet)
					{
						return ConvertBackWhenIntersects;
					}
					break;
				default:
					throw new ArgumentException();
			}

            if (_isConvertBackDefaultBooleanValueSet)
            {
                return ConvertBackDefaultBooleanValue;
            }

            return DependencyProperty.UnsetValue;
        }

        private bool _isConvertBackDefaultBooleanValueSet;
        private bool _convertBackDefaultBooleanValue;
        public bool ConvertBackDefaultBooleanValue
        {
            get
            {
                return _convertBackDefaultBooleanValue;
            }
            set
            {
                _convertBackDefaultBooleanValue = value;
				_isConvertBackDefaultBooleanValueSet = true;
            }
        }

        private bool _isConvertBackWhenNotCalculatedSet;
        private bool _convertBackWhenNotCalculated;

        public bool ConvertBackWhenNotCalculated
        {
            get
            {
                return _convertBackWhenNotCalculated;
            }
            set
            {
                _convertBackWhenNotCalculated = value;
                _isConvertBackWhenNotCalculatedSet = true;
            }
        }
        private bool _isConvertBackWhenEmptySet;
        private bool _convertBackWhenEmpty;

        public bool ConvertBackWhenEmpty
        {
            get
            {
                return _convertBackWhenEmpty;
            }
            set
            {
                _convertBackWhenEmpty = value;
                _isConvertBackWhenEmptySet = true;
            }
        }
        private bool _isConvertBackWhenFullyInsideSet;
        private bool _convertBackWhenFullyInside;

        public bool ConvertBackWhenFullyInside
        {
            get
            {
                return _convertBackWhenFullyInside;
            }
            set
            {
                _convertBackWhenFullyInside = value;
                _isConvertBackWhenFullyInsideSet = true;
            }
        }
        private bool _isConvertBackWhenFullyContainsSet;
        private bool _convertBackWhenFullyContains;

        public bool ConvertBackWhenFullyContains
        {
            get
            {
                return _convertBackWhenFullyContains;
            }
            set
            {
                _convertBackWhenFullyContains = value;
                _isConvertBackWhenFullyContainsSet = true;
            }
        }
        private bool _isConvertBackWhenIntersectsSet;
        private bool _convertBackWhenIntersects;

        public bool ConvertBackWhenIntersects
        {
            get
            {
                return _convertBackWhenIntersects;
            }
            set
            {
                _convertBackWhenIntersects = value;
                _isConvertBackWhenIntersectsSet = true;
            }
        }
    }
}