using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleForumMVC.Models;

namespace SimpleForumMVC.Data
{
    public class ForumInitializer:DropCreateDatabaseIfModelChanges<ForumContext>
    {
        protected override void Seed(ForumContext context)
        {
            var categories = new List<Category>()
            {
                new Category {Name="C#"},
                new Category {Name="CSS"},
                new Category {Name="Javascript"},
                new Category {Name="Jquery"},
                new Category {Name="PHP"}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var tags = new List<Tag>()
            {
                new Tag {Name="Lecture"},
                new Tag {Name="Exam"},
                new Tag {Name="Homework"},
                new Tag {Name="Problem"},
                new Tag {Name="Algorithm"},
                new Tag {Name="Database"},
            };

            //tags.ForEach(t => context.Tags.Add(t));
            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }
            context.SaveChanges();

        }
    }
}
