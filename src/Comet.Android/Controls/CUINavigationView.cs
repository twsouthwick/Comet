﻿using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Comet.Android.Controls
{
    public class CUINavigationView : CustomFrameLayout
    {
        public CUINavigationView(Context context) : base(context)
        {
        }

        public void SetRoot(View view)
        {
            AndroidContext.AppCompatActivity.SupportFragmentManager
                .BeginTransaction()
                .Replace(Id, new CometFragment(view))
                .CommitAllowingStateLoss();
        }

        public void NavigateTo(View view)
        {
            AndroidContext.AppCompatActivity.SupportFragmentManager.BeginTransaction()
                .SetTransition((int)global::Android.App.FragmentTransit.FragmentFade)
                .AddToBackStack(view.Id)
                .Replace(Id, new CometFragment(view))
                .CommitAllowingStateLoss();
        }
    }
}
