using System.Collections.Generic;

namespace CH22RepoPattern.Models
{
    public class RepoAuthor
    {
        public RepoAuthor()
        {
            Titles = new List<RepoTitle>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<RepoTitle> Titles { get; set; }
    }
}