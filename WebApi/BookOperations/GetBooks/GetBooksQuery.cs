using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;



namespace WebApi.BookOperations.GetBooksQuery
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            /*new List<BooksViewModel>();
            foreach(var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                    
                });
            }*/
            return vm;
        }
        
    }
    //İstediğim veri tipinin UI'a döndüğünden her zaman için emin olmak istiyorum bunun için view model yapıcaz.
    public class BooksViewModel
    {
        public string Title {get;set;}
        public int PageCount{get;set;}
        public string PublishDate{get;set;}
        public string Genre {get;set;}

    }
}