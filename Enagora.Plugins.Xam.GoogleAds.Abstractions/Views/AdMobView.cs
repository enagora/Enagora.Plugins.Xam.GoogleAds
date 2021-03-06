﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Enagora.Plugins.Xam.GoogleAds.Abstractions.Views
{
    public class AdMobView : Xamarin.Forms.View
    {
        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
                    nameof(AdUnitId),
                    typeof(string),
                    typeof(AdMobView),
                    string.Empty);

        public string AdUnitId
        {
            get => (string)GetValue(AdUnitIdProperty);
            set => SetValue(AdUnitIdProperty, value);
        }
    }
}
