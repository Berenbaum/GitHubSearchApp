using GitHubSearchApp.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace GitHubSearchApp.View
{
    /// <summary>
    /// Interaction logic for BookmarkWindow.xaml
    /// </summary>
    public partial class BookmarkWindow : Window
    {
        public BookmarkWindow()
        {
            InitializeComponent();
        }

        public BookmarkWindow(ObservableCollection<RepositoryViewModel> bookmarkedRepositories)
        {
            InitializeComponent();
            DataContext = new BookmarkViewModel(bookmarkedRepositories);
        }
    }
}
