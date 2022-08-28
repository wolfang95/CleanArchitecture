using FluentValidation.Results;


namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public ValidationExceptions() :base("Se presentaron uno o mas errores de validación")
        {
            Errors = new Dictionary<string, string[]>();

        }
        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(failareGroup => failareGroup.Key, failareGroup => failareGroup.ToArray());

        }

        public IDictionary<string, string[]> Errors { get; }
        
    }
}
