using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Core.Infrastructure.Exceptions
{
    public class ApiDomainException : Exception
    {
        public ApiDomainException(IList<ValidationFailure> errors)
        {
            this.Errors = errors;
        }

        public ApiDomainException(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Errors of model
        /// </summary>
        public IList<ValidationFailure> Errors { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; }
    }
}
