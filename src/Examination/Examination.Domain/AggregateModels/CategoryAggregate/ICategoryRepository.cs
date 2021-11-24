using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Domain.AggregateModels.CategoryAggregate
{
    public interface ICategoryRepository
    {
        Task<IList<Category>> GetExamListAsync();

        Task<Category> GetExamByIdAsync(string id);
    }
}
