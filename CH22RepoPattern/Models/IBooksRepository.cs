using System;
using System.Collections.Generic;
using System.Linq;
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

    class BooksRepository : IBooksRepository
    {
        private readonly BooksDbEntities _dbContext = new BooksDbEntities();


        public IEnumerable<AuthorAndTitle> GetAuthorsAndTitles()
        {
            return
                from book in _dbContext.Titles
                from author in book.Authors
                orderby author.LastName, author.FirstName, book.Title1
                select new AuthorAndTitle
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Title = book.Title1
                };
        }

        public IEnumerable<AuthorAndISBN> GetAuthorsAndISBNs()
        {
            return
                from author in _dbContext.Authors
                from title in author.Titles
                orderby author.LastName, author.FirstName
                select new AuthorAndISBN
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    ISBN = title.ISBN
                };
        }

        public bool Add(RepoAuthor author, params RepoTitle[] titles)
        {
            try
            {
                var authors = _dbContext.Authors;
                var authorDb = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Titles = new List<Title>()
                };

                foreach (var title in titles)
                {
                    authorDb.Titles.Add(
                        new Title
                        {
                            Title1 = title.BookTitle,
                            Copyright = title.Copyright,
                            ISBN = title.ISBN,
                            EditionNumber = title.EditionNumber
                        });
                }

                authors.Add(authorDb);
                _dbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }


            return true;
        }
    }


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

    public class AuthorAndISBN
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ISBN { get; set; }
    }

    public class AuthorAndTitle
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}