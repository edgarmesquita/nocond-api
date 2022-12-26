using System;

namespace NoCond.Application.Email.Models
{
    public class EmailTemplate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}