using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Models
{
    public class Post
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int? AcceptedAnswersId { get; set; }
        public int? UserId { get; set; }

        //public User UserInstance { get; set; }
        //public List<Comment> Comments { get; set; }

        //// Make the instance of our subobjects. 
        //public Post()
        //{
        //    UserInstance = new User();
        //    Comments = new List<Comment>();

        //    //Comments.Add(new Comment()
        //    //{
        //    //    Text = "hfuhefijegfbeifgsjgebf",
        //    //    CommentId = 6439
                
        //    //});
        //    //Comments.Add(new Comment()
        //    //{
        //    //    Text = "wgsfgeghertger",
        //    //    CommentId = 3144657

        //    //});
        //}




        //// Nested User Object.
        //public class User
        //{
        //    public int UserId { get; set; }
        //    public string Name { get; set; }
        //}

        //// Nested Comment Object
        //public class Comment
        //{
        //    public int CommentId { get; set; }
        //    public string Text { get; set; }
        //    public DateTime CreationDate { get; set; }
        //    public int CommentAuthorId { get; set; }
        //    public string AuthorName { get; set; }
        //    //public int PostId { get; set; }
        //}
       
    }
}