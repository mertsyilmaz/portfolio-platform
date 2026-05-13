namespace Blog.Application.Common.Exceptions
{
    public static class ErrorMessages
    {
        public const string PostNotFound = "Post not found.";
        public const string CategoryNotFound = "Category not found.";
        public const string TagNotFound = "Tag not found.";
        public const string CommentNotFound = "Comment not found.";
        public const string ImageNotFound = "Image not found.";
        public const string FileNotFound = "File not found.";
        public const string CoverImageNotFound = "Cover image not found.";
        public const string FileServiceRequestFailed = "File service request failed.";

        public const string InvalidCategoryIds = "One or more category ids are invalid.";
        public const string InvalidTagIds = "One or more tag ids are invalid.";
    }
}
