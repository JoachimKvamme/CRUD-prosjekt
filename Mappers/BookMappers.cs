using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Dto.Book;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel) 
        {
            return new BookDto 
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                FirstNameAuthor = bookModel.FirstNameAuthor,
                LastNameAuthor = bookModel.LastNameAuthor,
                Year = bookModel.Year,
                Place = bookModel.Place,
                ProjectId = bookModel.ProjectId
            };
        }

        public static Book ToBookFromCreate(this CreateBookRequestDto bookDto) 
        {
            return new Book 
            {
                Title = bookDto.Title,
                FirstNameAuthor = bookDto.FirstNameAuthor,
                LastNameAuthor = bookDto.LastNameAuthor,
                Year = bookDto.Year,
                Place = bookDto.Place,
                
            };
        }
    }
}