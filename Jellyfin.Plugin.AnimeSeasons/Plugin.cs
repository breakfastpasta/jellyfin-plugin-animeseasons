using MediaBrowser.Common.Plugins;
using Jellyfin.Plugin.AnimeSeasons.Configuration;

namespace Jellyfin.Plugin.AnimeSeasons;

class Plugin : BasePlugin<PluginConfiguration>
{
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    public override string Name => "Anime Seasons";

    public override string Description => "Create anime collections based on season"

    public override Guid Id => Guid.Parse("f7f4570c-5a53-4d1d-8691-46363b63bf32");

    public static AnimeSeasonPlugin Instance { get; private set; }

    public PluginConfiguration PluginConfiguration => Configuration;

    public IEnumerable<PluginPageInfo> GetPages()
    {
        return
        [
            new PluginPageInfo
            {
                Name = "Anime Seasons",
                EmbeddedResourcePath = GetType().Namespace + ".Configuration.configurationpage.html"
            }
        ];
    }
}
