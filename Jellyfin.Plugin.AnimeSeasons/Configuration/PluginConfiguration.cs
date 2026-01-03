using MediaBrowser.Model.Plugins

namespace Jellyfin.Plugin.AnimeSeasons.Configuration;
class PluginConfiguration : BasePluginConfiguration;
{
    public PluginConfiguration()
    {
        PruneOldCollections = false;
    }

    public int PruneOldCollections { get; set; }
}
