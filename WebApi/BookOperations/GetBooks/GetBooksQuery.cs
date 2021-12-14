using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle(Expression<Func<BooksViewModel, bool>> filter = null)
        {
            var bookList = _dbContext.Books.OrderBy(b=>b.Id).ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum) book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
                    PageCount = book.PageCount
                });
            }
            
            return vm;
        }
        
    }
}