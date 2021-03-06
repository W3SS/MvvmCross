﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;
using MvvmCross.Platform.Logging;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.tvOS.Views;

namespace MvvmCross.tvOS.Views
{
    public class MvxBindingViewControllerAdapter : MvxBaseViewControllerAdapter
    {
        protected IMvxTvosView TvosView => ViewController as IMvxTvosView;

        public MvxBindingViewControllerAdapter(IMvxEventSourceViewController eventSource)
            : base(eventSource)
        {
            if (!(eventSource is IMvxTvosView))
                throw new ArgumentException(nameof(eventSource), $"{nameof(eventSource)} should be a {nameof(IMvxTvosView)}");

            TvosView.BindingContext = Mvx.Resolve<IMvxBindingContext>();
        }

        public override void HandleDisposeCalled(object sender, EventArgs e)
        {
            if (TvosView == null)
            {
                MvxLog.Instance.Warn($"{nameof(TvosView)} is null for clearup of bindings");
                return;
            }
            TvosView.ClearAllBindings();
            base.HandleDisposeCalled(sender, e);
        }
    }
}
