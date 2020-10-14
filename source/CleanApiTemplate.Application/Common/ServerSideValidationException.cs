using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace CleanApiTemplate.Application.Common
{
    public class ServerSideValidationException : Exception
    {
        public ServerSideValidationException(IEnumerable<ValidationFailure> failures) :
            base("One or more server side validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();

            var groups = failures.GroupBy(f => f.PropertyName, f => f.ErrorMessage);
            foreach (var failedGroup in groups)
            {
                Errors.Add(failedGroup.Key, failedGroup.ToArray());
            }
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
