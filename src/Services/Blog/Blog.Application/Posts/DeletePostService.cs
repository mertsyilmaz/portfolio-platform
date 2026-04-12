using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public class DeletePostService : IDeletePostService
    {
        private readonly IPostRepository _postRepository;

        public DeletePostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<DeletePostResponse?> DeleteAsync(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            if (post == null)
                return null;

            await _postRepository.DeleteAsync(post);

            return new DeletePostResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
