using EduPost.Data;
using EduPost.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduPost.Service
{
	public class ReactionService
	{
		private readonly ApplicationDbContext _context;

		public ReactionService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<UserReaction> GetUserReaction(int userId, int articleId)
		{
			return await _context.UserReaction
			   .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.ArticleId == articleId);
		}

		public async Task LikeOrDislikeArticle(int userId, int articleId, bool isLike)
		{
			var userReaction = await _context.UserReaction
				.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.ArticleId == articleId);

			if (userReaction != null)
			{
				if (userReaction.ReactionType == isLike)
				{
					_context.UserReaction.Remove(userReaction);
				}
				else
				{
					userReaction.ReactionType = isLike;
					_context.UserReaction.Update(userReaction);
				}
			}
			else
			{
				var newUserReaction = new UserReaction
				{
					UserId = userId,
					ArticleId = articleId,
					ReactionType = isLike
				};
				_context.UserReaction.Add(newUserReaction);
			}

			await _context.SaveChangesAsync();
		}

		public Task LikeArticle(int userId, int articleId) => LikeOrDislikeArticle(userId, articleId, true);
		public Task DislikeArticle(int userId, int articleId) => LikeOrDislikeArticle(userId, articleId, false);
	}
}
