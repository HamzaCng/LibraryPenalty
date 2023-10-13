using Microsoft.EntityFrameworkCore;
using Penalty.Api.Core.Models;
using Penalty.Api.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Penalty.Api.Services.Books
{
    public class BookService : IBookService
    {
        #region Fields
        private readonly IRepository<Book> _bookRepository;
        #endregion

        #region Methods
        public BookService(IRepository<Book> bookRepository) 
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> CalculatePenalty(int id)
        {   
            if (id != 0)
            {
                var req = await _bookRepository.GetById(id);
                if(req != null)
                {    
                  //Calculate for penalty  
                  Calculate(req.Penaltyies); 
                }
            }
            throw new NotImplementedException();
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            if(book != null)
            {
                 await _bookRepository.Create(book);
            }
            throw new NotImplementedException();
        }

        public async Task DeleteBookAsync(int id)
        {
            if (id != 0)
            {
                await _bookRepository.Delete(id);
            }
            throw new NotImplementedException();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            if(id == 0)
                throw new NotImplementedException();

            return await _bookRepository.GetById(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            if (book != null)
            {
                await _bookRepository.Update(book);
            }
            throw new NotImplementedException();
        }

        #endregion

        #region Utilities 
        /// <summary>
        /// Calculate to penalty day and price
        /// </summary>
        /// <param name="penalties">Penality</param>
        /// <exception cref="ArgumentNullException"></exception>
        static void Calculate(Penalties penalties)
        {
            if (penalties == null)
                throw new ArgumentNullException(nameof(penalties));
          
            int counter = default;            

            // First day check
            if (penalties.CheckedOutDate.DayOfWeek == DayOfWeek.Saturday || penalties.ReturnedDate.DayOfWeek == DayOfWeek.Sunday )
            {
                counter++;
            }

            //Weekend loop
            do
            {
                penalties.CheckedOutDate.AddDays(1);
                if (penalties.CheckedOutDate.DayOfWeek == DayOfWeek.Saturday || penalties.CheckedOutDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    counter++;
                }

            } while (penalties.ReturnedDate >= penalties.CheckedOutDate);

            int FirstDate = int.Parse(penalties.CheckedOutDate.ToString("yyyyMMdd"));
            int LastDate = int.Parse(penalties.ReturnedDate.ToString("yyyyMMdd"));

            //Penalty
            if ((LastDate - FirstDate) > 10) {

                penalties.PenaltyDay = (LastDate - FirstDate) - (counter + 10);
                penalties.Price = penalties.PenaltyDay * 5;
            }           
           
        } 

        #endregion
    }
}
