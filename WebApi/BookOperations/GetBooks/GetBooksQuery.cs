using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle(Expression<Func<BooksViewModel, bool>> filter = null)
        {
            var bookList = _dbContext.Books.OrderBy(b=>b.Id).ToList();

            var vm = _mapper.Map<List<BooksViewModel>>(bookList);
            //List<BooksViewModel> vm = new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum) book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
            //        PageCount = book.PageCount
            //    });
            //}
            
            return vm;
        }
        
    }
}