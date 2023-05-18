using Newtonsoft.Json;

namespace GitHubSearchApp.Model
{
    public class OwnerModel
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
