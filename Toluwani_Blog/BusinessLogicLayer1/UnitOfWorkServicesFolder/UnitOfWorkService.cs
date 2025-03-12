using BusinessLogicLayer.Service;
using DataAccessLayer.UnitOfWorkFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UnitOfWorkServicesFolder
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private CategoriesService _categoriesService;
        private CommentService _commentService;
        private LikeService _likeService;
        private PostService _postService;
        private UserService _userService;

        public CategoriesService categoryService => _categoriesService ??= new CategoriesService(_unitOfWork);

        public CommentService commentService => _commentService ??= new CommentService(_unitOfWork);

        public LikeService likeService => _likeService ??= new LikeService(_unitOfWork);

        public PostService postService => _postService ??= new PostService(_unitOfWork);

        public UserService userService => _userService ??= new UserService(_unitOfWork);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
