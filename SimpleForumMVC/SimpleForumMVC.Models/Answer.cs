using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleForumMVC.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        private ICollection<Comment> comments;

        public virtual ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
