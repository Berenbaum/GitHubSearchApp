using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GitHubSearchApp.Model;
using GitHubSearchApp.Models;
using GitHubSearchApp.View;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;

namespace GitHubSearchApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string searchKeyword;
        private ObservableCollection<RepositoryViewModel> searchResults;

        public string SearchKeyword
        {
            get { return searchKeyword; }
            set { Set(ref searchKeyword, value); }
        }

        public ObservableCollection<RepositoryViewModel> SearchResults
        {
            get { return searchResults; }
            set { Set(ref searchResults, value); }
        }

        public ICommand SearchCommand { get; }
        public ICommand BookmarkCommand { get; }
        public ICommand OpenBookmarks { get; }

        public MainViewModel()
        {
            SearchCommand = new RelayCommand(Search);
            BookmarkCommand = new RelayCommand<RepositoryViewModel>(Bookmark);
            OpenBookmarks = new RelayCommand(OpenBookmarksWindow);
        }

        private void OpenBookmarksWindow()
        {
            ObservableCollection<RepositoryViewModel> bookmarkedRepositories = BookmarkStorage.GetBookmarks();
            BookmarkWindow bookmarkWindow = new BookmarkWindow(bookmarkedRepositories);
            bookmarkWindow.ShowDialog();
        }

        private void Bookmark(RepositoryViewModel repository)
        {
            if (repository != null && !BookmarkStorage.IsContain(repository))
            {
                repository.IsBookmarked = true;
                BookmarkStorage.AddBookmark(repository);
            }
        }

        private async void Search()
        {
            string apiUrl = $"https://api.github.com/search/repositories?q={SearchKeyword}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "GitHubSearchApp");
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(responseContent);
                    var repositories = searchResponse?.Items;

                    if (repositories != null)
                    {
                        SearchResults = new ObservableCollection<RepositoryViewModel>();
                        foreach (var repository in repositories)
                        {
                            SearchResults.Add(new RepositoryViewModel(repository));
                        }
                    }
                }
            }
        }
    }
}
