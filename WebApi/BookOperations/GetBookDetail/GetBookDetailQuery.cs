using System;
using System.Linq;
using AutoMapper;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            var model = _mapper.Map<BookDetailViewModel>(book);
            
            //BookDetailViewModel model = new BookDetailViewModel()
            //{
            //    Title = book.Title,
            //    Genre = ((GenreEnum) book.GenreId).ToString(),
            //    PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
            //    PageCount = book.PageCount
            //};
            
            return model;
        }
    }
    
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}