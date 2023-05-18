using GalaSoft.MvvmLight;
using GitHubSearchApp.Model;

namespace GitHubSearchApp.ViewModel
{
    public class RepositoryViewModel : ViewModelBase
    {
        private string name;
        private string avatarUrl;
        private bool isBookmarked;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }
        
        public string AvatarUrl
        {
            get { return avatarUrl; }
            set { Set(ref avatarUrl, value); }
        }

        public bool IsBookmarked
        {
            get { return isBookmarked; }
            set { Set(ref isBookmarked, value); }
        }

        public RepositoryViewModel(RepositoryModel repository)
        {
            Name = repository.Name;
            AvatarUrl = repository.Owner?.AvatarUrl;
            IsBookmarked = false;
        }

    }
}
