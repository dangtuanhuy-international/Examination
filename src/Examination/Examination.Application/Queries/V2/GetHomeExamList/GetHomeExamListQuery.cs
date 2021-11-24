using Examination.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Examination.Application.Queries.V2.GetHomeExamList
{
    public class GetHomeExamListQuery : IRequest<IEnumerable<ExamDto>>
    {
    }
}