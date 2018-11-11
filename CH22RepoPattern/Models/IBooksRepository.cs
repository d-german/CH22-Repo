using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CH22RepoPattern.Models
{
    public interface IBooksRepository
    {
        IEnumerable<AuthorAndTitle> GetAuthorsAndTitles();
        IEnumerable<AuthorAndISBN> GetAuthorsAndISBNs();
        bool Add(RepoAuthor repoAuthor, params RepoTitle[] repoTitles);
    }
}