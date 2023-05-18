using GitHubSearchApp.ViewModel;
using System.Collections.ObjectModel;

namespace GitHubSearchApp.Model
{
    public static class BookmarkStorage
    {
        private static ObservableCollection<RepositoryViewModel> bookmarksData = new ObservableCollection<RepositoryViewModel>();

        public static void AddBookmark(RepositoryViewModel repository)
        {
            bookmarksData.Add(repository);
        }

        public static void RemoveBookmark(RepositoryViewModel repository)
        {
            bookmarksData.Remove(repository);
        }

        public static ObservableCollection<RepositoryViewModel> GetBookmarks()
        {
            return bookmarksData;
        }

        public static bool IsContain(RepositoryViewModel repository)
        {
            return bookmarksData.Contains(repository);
        }
    }
}
