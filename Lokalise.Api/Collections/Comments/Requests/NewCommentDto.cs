namespace Lokalise.Api.Collections.Comments.Requests
{
    internal class NewCommentDto
    {
        public string Comment { get; set; }

        internal NewCommentDto(string comment)
        {
            Comment = comment;
        }
    }
}
