using Microsoft.Extensions.DependencyInjection;
using Penalty.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Services.Books
{
    public interface IBookService 
    {

        /// <summary>
        /// Create a book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Book> CreateBookAsync(Book book);

        /// <summary>
        /// Update the book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateBookAsync(Book book);

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteBookAsync(int id);

        /// <summary>
        /// Get Book by id
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Book> GetBookByIdAsync(int id);

        /// <summary>
        /// Calculate Penalty
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<Book> CalculatePenalty(int id);

    }
}
