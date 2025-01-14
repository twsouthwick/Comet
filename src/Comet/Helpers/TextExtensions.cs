﻿using System;

// ReSharper disable once CheckNamespace
namespace Comet
{
    public static class TextExtensions
    {        
        public static T TextAlignment<T>(this T view, TextAlignment? alignment, bool cascades = false) where T : View
        {
            view.SetEnvironment(EnvironmentKeys.Text.Alignment, alignment, cascades);
            return view;
        }

        public static TextAlignment? GetTextAlignment(this View view, TextAlignment? defaultValue = null)
        {
            var value = view.GetEnvironment<TextAlignment?>(view, EnvironmentKeys.Text.Alignment);
            return value ?? defaultValue;
        }
    }
}
