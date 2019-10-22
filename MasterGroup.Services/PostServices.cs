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
                        Username = username,
                        GroupId = model.GroupID,
                        Title = model.Title,
                        Content = model.Content,
                        PostDate = DateTimeOffset.Now
                    };

                ctx.MGPosts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<PostListItem> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
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
                            PostDate = e.PostDate,
                        }


                        );

                return query.ToArray();
            }
        }
        public IEnumerable<PostListItem> GetPostByGroupId(int GroupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MGPosts
                    .Where(e => e.OwnerId == _userId && e.GroupId == GroupId)
                    .Select(
                        e =>
                        new PostListItem
                        {
                            Title = e.Title,
                            Content = e.Content,
                            PostId = e.PostId,
                            PostDate = e.PostDate,
                            GroupId=e.GroupId

                        }


                        );

                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MGPosts
                    .Single(e => e.PostId == id && e.OwnerId == _userId);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Username = entity.Username,
                        Title = entity.Title,
                        Content = entity.Content,
                        PostDate = entity.PostDate,
                        GroupId=entity.GroupId
                    };
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MGPosts
                    .Single(e => e.PostId == postId && e.OwnerId == _userId);

                ctx.MGPosts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
