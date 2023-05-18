using Newtonsoft.Json;

namespace GitHubSearchApp.Model
{
    public class RepositoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public OwnerModel Owner { get; set; }
    }
}
