using System;
using BlogAPIDotnet.Dtos.Comment;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Content = commentModel.Content,
            CreatedAt = commentModel.CreatedAt
        };
    }
}
