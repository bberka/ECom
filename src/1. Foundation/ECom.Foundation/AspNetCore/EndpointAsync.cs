using Microsoft.AspNetCore.Mvc;

namespace ECom.Foundation.AspNetCore;

public static class EndpointAsync
{
  public static class WithRequest<TRequest>
  {
    public abstract class WithResult<TResponse> : EndpointBase
    {
      public abstract Task<TResponse> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithoutResult : EndpointBase
    {
      public abstract Task HandleAsync(TRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithActionResult<TResponse> : EndpointBase
    {
      public abstract Task<ActionResult<TResponse>> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithActionResult : EndpointBase
    {
      public abstract Task<ActionResult> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithAsyncEnumerableResult<T> : EndpointBase
    {
      public abstract IAsyncEnumerable<T> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken = default(CancellationToken));
    }
  }

  public static class WithoutRequest
  {
    public abstract class WithResult<TResponse> : EndpointBase
    {
      public abstract Task<TResponse> HandleAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithoutResult : EndpointBase
    {
      public abstract Task HandleAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithActionResult<TResponse> : EndpointBase
    {
      public abstract Task<ActionResult<TResponse>> HandleAsync(
        CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithActionResult : EndpointBase
    {
      public abstract Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class WithAsyncEnumerableResult<T> : EndpointBase
    {
      public abstract IAsyncEnumerable<T> HandleAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
  }
}