using System.Collections.Generic;

namespace CH22RepoPattern.Models
{
    public class RepoTitle
    {
        public RepoTitle()
        {
            Authors = new List<RepoAuthor>();
        }

        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public int EditionNumber { get; set; }
        public string Copyright { get; set; }

        public List<RepoAuthor> Authors { get; set; }
    }
}