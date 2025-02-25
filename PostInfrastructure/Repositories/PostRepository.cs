using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostDbContext _postDbContext;

        public PostRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<List<Posts>> GetPostAndMedia()
        {
            List<Posts> result = await _postDbContext.Posts
                .ToListAsync();
            return result;
        }

        public async Task<List<Posts>> GetByAccountName(string accountName)
        {
            List<Posts> result = await _postDbContext.Posts
                .Where(p => p.AccountName.Equals(accountName))
                .ToListAsync();
            return result;
        }

        public async Task<List<Posts>> GetListLikeByAccountName(string accountName)
        {
            List<Posts> result = await _postDbContext.Posts
                .Where(p => p.AccountName.Contains(accountName))
                .ToListAsync();
            return result;
        }

        public async Task<List<Posts>> GetPrioritizedPosts(string accountName, int numberPosts)
        {
            var query = await _postDbContext.Posts
      .Where(p => p.TopicPosts.Any(tp => _postDbContext.TopicUsers
          .Where(tu => tu.AccountName == accountName)
          .Select(tu => tu.TopicId)
          .Contains(tp.TopicId)
      ))
      .GroupJoin(
          _postDbContext.UserPostViews.Where(uv => uv.AccountName == accountName),
          post => post.Id,
          view => view.PostId,
          (post, views) => new
          {
              Post = post,
              ViewCount = views.Select(v => v.Count).FirstOrDefault(), // Số lần xem (nếu chưa xem thì mặc định 0)
              LastViewedAt = views.Select(v => v.Posts.CreatedAt).FirstOrDefault() // Thời gian đăng bài
          }
      )
      .OrderBy(p => p.ViewCount == 0 ? int.MinValue : p.ViewCount) // Ưu tiên bài chưa xem
      .ThenBy(p => p.ViewCount) // Sau đó ưu tiên bài xem ít nhất
      .ThenByDescending(p => p.LastViewedAt) // Ưu tiên bài mới nhất
      .Select(p => p.Post)
      .Take(numberPosts)
      .ToListAsync();
            foreach (var post in query)
            {
                var userPostView = await _postDbContext.UserPostViews
                    .FirstOrDefaultAsync(uv => uv.PostId == post.Id && uv.AccountName == accountName);

                if (userPostView == null)
                {
                    // Nếu chưa có, tạo mới
                    _postDbContext.UserPostViews.Add(new UserPostViews
                    {
                        PostId = post.Id,
                        AccountName = accountName,
                        Count = 1, // Lượt xem đầu tiên
                    });
                }
                else
                {
                    // Nếu đã có, tăng số lượt xem
                    userPostView.Count += 1;
                }
            }

            // Lưu thay đổi vào database
            await _postDbContext.SaveChangesAsync();
            return query;
        }
    }
}