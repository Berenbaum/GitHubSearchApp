using GitHubSearchApp.Model;
using System.Collections.Generic;

namespace GitHubSearchApp.Models
{
    public class SearchResponse
    {
        public List<RepositoryModel> Items { get; set; }
    }
}