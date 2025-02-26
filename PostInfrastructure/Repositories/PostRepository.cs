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
            var topicIds = await _postDbContext.TopicUsers
    .Where(tu => tu.AccountName == accountName)
    .Select(tu => tu.TopicId)
    .ToListAsync();

            if (!topicIds.Any())
            {
                topicIds = await _postDbContext.Topics
                    .OrderByDescending(t => t.CountTopic) // Sắp xếp giảm dần theo số bài viết
                    .Take(3)
                    .Select(t => t.Id)
                    .ToListAsync();
            }
            try
            {
                var query = await _postDbContext.Posts
                .Include(t => t.TopicPosts)
      .Where(p => topicIds.AsQueryable().Any(id => p.TopicPosts.Any(tp => tp.TopicId == id)))
      .GroupJoin(
          _postDbContext.UserPostViews.Where(uv => uv.AccountName == accountName),
          post => post.Id,
          view => view.PostId,
          (post, views) => new
          {
              Post = post,
              ViewCount = views.Select(v => v.Count).FirstOrDefault(), // Số lần xem (nếu chưa xem thì mặc định 0)
              LastViewedAt = post.CreatedAt // Thời gian đăng bài
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            return new List<Posts>();
        }
    }
}