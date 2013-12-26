using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleForumMVC.Models
{
   public class  Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICollection<Question> questions;

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

       

       
        



    }
}
