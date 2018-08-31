using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace BrightspaceCli
{
    public class Configuration : IConfigurationRoot
    {
        private IConfigurationRoot configuration;

        public Configuration()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("app.json.config")
                .Build();
        }

        public string this[string key] { get => configuration[key]; set => configuration[key] = value; }

        public IEnumerable<IConfigurationProvider> Providers => configuration.Providers;

        public IEnumerable<IConfigurationSection> GetChildren() => configuration.GetChildren();

        public IChangeToken GetReloadToken() => configuration.GetReloadToken();

        public IConfigurationSection GetSection(string key) => configuration.GetSection(key);

        public void Reload() => configuration.Reload();
    }
}
