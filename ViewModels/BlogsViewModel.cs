using AndroidBlog.Business;
using AndroidBlog.Business.DTO;
using AndroidBlog.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AndroidBlog.ViewModels
{
    public class BlogsViewModel : BaseViewModel
    {
        private BlogsService blogsService;
        public ObservableCollection<BlogsDTO> Blogs { get; set; }
        public MProp<string> Keyword { get; } = new MProp<string>();

        public BlogsViewModel()
        {
            blogsService = new BlogsService();

            SearchBlogs();

            SearchRestaurantsCommand = new Command(SearchBlogs);
            DeleteBlogCommand = new Command<int>(DeleteBlog);
        }
        public ICommand SearchRestaurantsCommand { get; }
        public ICommand DeleteBlogCommand { get; }

        private void SearchBlogs()
        {
            AllBlogs allBlogs = blogsService.GetBlogs(Keyword.Value);

            IEnumerable<BlogsDTO> blogs = allBlogs.Items;

            Blogs = new ObservableCollection<BlogsDTO>(blogs);

            OnPropertyChanged(nameof(Blogs));
        }

        private void DeleteBlog(int id)
        {
            if (blogsService.DelteBlog(id))
            {
                SearchBlogs();
            }
        }
    }
}
