using GalaSoft.MvvmLight;
using GitHubSearchApp.Model;
using System.Collections.ObjectModel;

namespace GitHubSearchApp.ViewModel
{
    public class BookmarkViewModel : ViewModelBase
    {
        private ObservableCollection<RepositoryViewModel> bookmarkedRepositories;

        public ObservableCollection<RepositoryViewModel> BookmarkedRepositories
        {
            get { return bookmarkedRepositories; }
            set { Set(ref bookmarkedRepositories, value); }
        }

        public BookmarkViewModel()
        {
            var bookmarks = BookmarkStorage.GetBookmarks();
            BookmarkedRepositories = new ObservableCollection<RepositoryViewModel>(bookmarks);
        }
        public BookmarkViewModel(ObservableCollection<RepositoryViewModel> bookmarkedRepositories)
        {
            var bookmarks = BookmarkStorage.GetBookmarks();
            BookmarkedRepositories = new ObservableCollection<RepositoryViewModel>(bookmarks);
        }
    }
}
