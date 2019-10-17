using MasterGroup.Data;
using MasterGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Services
{
    public class PostServices
    {
        private readonly Guid _userId;

        public PostServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var username = ctx.Users.Single(e => e.Id == _userId.ToString()).UserName;

            var entity =
                new Post()
                {
                    OwnerId = _userId,
                    GroupId = model.GroupID,
                    Title =model.Title,
                    Content = model.Content,
                };

                ctx.MGPosts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<PostListItem> GetPost()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MGPosts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PostListItem
                        {
                            Title = e.Title,
                            Content = e.Content,
                            PostId = e.PostId,
                            PostDate=e.PostDate,
                        }


                        );

                return query.ToArray();
            }
        }
    }
}
