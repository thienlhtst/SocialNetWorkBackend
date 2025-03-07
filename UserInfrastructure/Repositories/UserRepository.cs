﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using UserCore.Entities;
using UserCore.InterfaceRepositories;

namespace UserInfrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext=userDbContext;
        }

        public async Task<User?> GetbyUniqueString(string request)
        {
            var result = await _userDbContext.Users.FirstOrDefaultAsync(x => x.UserName.Equals(request) || x.Email.Equals(request));
            if (result !=null)
                return result;
            return null;
        }

        public async Task<User?> GetbyAccountName(string request)
        {
            var result = await _userDbContext.Users.FirstOrDefaultAsync(x => x.AccountName.Equals(request));
            if (result !=null)
                return result;
            return null;
        }

        public async Task<User?> GetInfoUser(string requestName)
        {
            var result = await _userDbContext.Users
                            .Include(u => u.Followees)
                            .Include(u => u.Followers)
                            .Where(u => u.AccountName == requestName)
                            .Select(u => new
                            {
                                User = u,
                                Followees = u.Followers.ToList(),
                                Followers = u.Followees.ToList(),
                            }).FirstOrDefaultAsync();
            if (result==null) return null;
            if (result.Followees!=null)
                result.User.Followees = result.Followees;
            if (result.Followers!=null)
                result.User.Followers = result.Followers;
            return result.User;
        }

        public async Task<List<User>?> GetFollowerOrFolloweeUser(string requestId, string type, bool typePrivate)
        {
            if (type.Equals("Follower"))// nguoi theo doi
            {
                var result = await _userDbContext.Follows
                             .Where(f => f.UserIdFollowee == requestId && f.IsFollowing==typePrivate)  // userId là ID của người dùng cần kiểm tra
                             .Select(f => f.UserFollower)
                             .ToListAsync();
                return result;
            }
            else if (type.Equals("Followee"))//nguoi duoc theo doi
            {
                var result = await _userDbContext.Follows
                            .Where(f => f.UserIdFollower == requestId && f.IsFollowing==typePrivate)  // userId là ID của người dùng cần kiểm tra
                            .Select(f => f.UserFollowee)
                            .ToListAsync();
                return result;
            }
            return null;
        }

        public async Task<List<User>?> GetUserToSreach(string request)
        {
            var result = await _userDbContext.Users
                            .Include(u => u.Followees)
                           .Where(u => u.FullName.Contains(request) || u.AccountName.Contains(request))
                           .ToListAsync();
            return result;
        }

        public async Task<int> CountFolloweeorFollower(string requestId, bool requestType)
        {
            var result = await _userDbContext.Users.FirstOrDefaultAsync(x => x.AccountName.Equals(requestId));
            if (result == null) return -1;
            if (requestType)// follower
            {
                if (result.Followers == null) return 0;
                return result.Followers.Count;
            }
            else//followee
            {
                if (result.Followees == null) return 0;
                return result.Followees.Count;
            }
        }
    }
}