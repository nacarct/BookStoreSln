﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>());
            if(context.Books.Any())
                return;
            
            context.Books.AddRange(new Book
                {
                    //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001,06,12)
                },
                new Book
                {
                    //Id = 2,
                    Title = "Her land",
                    GenreId = 2,
                    PageCount = 300,
                    PublishDate = new DateTime(2010,09,06)
                });

            context.SaveChanges();
        }
    }
}