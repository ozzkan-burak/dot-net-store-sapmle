namespace StoreApp.Infrastructure.Extensions
{
  public static class HttpRequestExtension
  {
    public static string PathAndQuery(this HttpRequest request)
    {
      return request.Path.HasValue
        ? request.Path.Value + request.QueryString.Value
        : request.QueryString.ToString() ?? string.Empty;
    }
  }
}