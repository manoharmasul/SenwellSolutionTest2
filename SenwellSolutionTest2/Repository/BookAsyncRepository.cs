using Dapper;
using SenwellSolutionTest2.Context;
using SenwellSolutionTest2.Model;
using SenwellSolutionTest2.Repository.Interface;

namespace SenwellSolutionTest2.Repository
{
    public class BookAsyncRepository:IBookAsyncRepository
    {
        private readonly DapperContext _dapperContext;
        public BookAsyncRepository(DapperContext context)
        {
          _dapperContext = context;
        }

        public async Task<int> AddNewBook(Book book)
        {
            var query = @"Insert into tblBooks(title,author,publicationYear)
                       values(@title,@author,@publicationYear)";
            using(var connection=_dapperContext.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,book);
                return result;
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var qeury = @"select title,author,publicationYear from tblBooks";
            using(var connection=_dapperContext.CreateConnection())
            {
                var result =await connection.QueryAsync<Book>(qeury);
                return result.ToList();
            }
        }
    }
}
