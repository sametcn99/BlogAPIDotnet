using System;
using BlogAPIDotnet.Dtos.Comment;
using BlogAPIDotnet.Models;

namespace BlogAPIDotnet.Mappers;

/// <summary>
/// Maps between Comment models and Comment DTOs.
/// </summary>
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
