using MediatR;
using System;

namespace Examination.Application.Commands.V2.StartExam
{
    public class StartExamCommand : IRequest<bool>
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ExamId { get; set; }

        public DateTime StartDate { get; set; }
    }
}