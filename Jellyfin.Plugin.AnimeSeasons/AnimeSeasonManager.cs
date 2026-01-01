using System;
using System.Threading;
using System.Threadin.Tasks;
using Jellyfin.Data.Enums;
using Jellyfin.Database.Implementations.Enums;
using MediaBrowser.Controller.Collections;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Entities;
using Microsoft.Extensions.Hosting;

namespace Jellyfin.Plugin.AnimeSeasons;

public class AnimeSeasonManager : IHostedService, IDisposable
{
    private readonly ILibraryManager _libraryManger;
    private readonly ICollectionManager _collectionManager;
    private readonly Timer _timer;

    public AnimeSeasonManager(ILibraryManager libraryManager, ICollectionManager collectionManager)
    {
        _libraryManager = libraryManager;
        _collectionManager = collectionManager;
        _timer = new Timer(_ => OnTimerElapsed(), null, Timeout.Infinite, Timeout.Infinite);
    }

    public async Task ScanLibrary(IProgress<double> progress)
    {
        //full scan
    }

    private void OnTimerElapsed()
    {
        //cleanups, add new items
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool dispose)
    {
        if (dispose)
        {
            _timer.Dispose();
        }
    }
}
