﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ExtensibilityMargin
{
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(PackageGuids.guidPackageString)]
    [ProvideProfile(typeof(DialogPageProvider.General), "Environment", Vsix.Name, 0, 0, true)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class ExtensibilityMarginPackage : AsyncPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await MarginToggleCommand.InitializeAsync(this);
        }
    }
}
