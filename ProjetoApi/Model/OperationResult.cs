using System.Net;

namespace Api.Model
{
    public abstract class OperationResult<TMessage>
    {
        public TMessage Message { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }
    }

    public class Result : OperationResult<string>
    {
        public static Result Create<T>(T content, HttpStatusCode statusCode, string message = "")
        {
            return new Result<T>(content, statusCode, message);
        }
    }

    public class Result<T> : Result
    {
        public Result(T content, HttpStatusCode statusCode, string message)
        {
            this.Content = content;
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public T Content { get; }
    }
}
