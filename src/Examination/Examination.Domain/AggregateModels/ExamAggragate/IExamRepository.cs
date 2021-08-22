using Examination.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examination.Domain.AggregateModels.ExamAggragate
{
    public interface IExamRepository : IRepositoryBase<Exam>
    {
        Task<IList<Exam>> GetExamListAsync();

        Task<Exam> GetExamByIdAsync(string id);
    }
}