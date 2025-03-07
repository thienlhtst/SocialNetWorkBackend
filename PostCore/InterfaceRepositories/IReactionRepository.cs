﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface IReactionRepository
    {
        public Task<int> CountReaction(string id);

        public Task<bool> FindUserReaction(string id, string AccountName);

        public Task<int> RemoveReaction(string AccountName, string postorCommentId);

        public Task<int> CreateReaction(string AccountName, string postorCommentId);
    }
}