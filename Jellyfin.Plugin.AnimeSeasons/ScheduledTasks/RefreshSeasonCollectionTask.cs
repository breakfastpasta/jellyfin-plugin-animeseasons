using System;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller.Collections;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Tasks;

namespace Jellyfin.Plugin.AnimeSeasons.ScheduledTasks;

public class RefreshSeasonCollectionTask : IScheduledTask, IDisposable
{
    private readonly AnimeSeasonManager _animeSeasonManager;

    public GenerateSeasonCollectionTask(
        ILibraryManager libraryManager,
        ICollectionManager collectionManager)
    {
        _animeSeasonManager = new AnimeSeasonManager(libraryManager, collectionManager);
    }

    public string Name => "Refresh anime season collection";

    public string Key => "AnimeSeasonsRefreshSeasonCollectionTask";

    public string Description => "Scans library for anime directly related to the current season";

    public async Task ExecuteAsync(IProgress<double> progress, CancellationToken cancellationToken)
    {
        await _animeSeasonManager.ScanLibrary(progress).ConfigureAwait(false);
    }

    public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
    {
        // Run this task every 24 hours
        return [new TaskTriggerInfo { Type = TaskTriggerInfoType.IntervalTrigger, IntervalTicks = TimeSpan.FromHours(24).Ticks }];
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
            _animeSeasonManager.Dispose();
        }
    }
}
