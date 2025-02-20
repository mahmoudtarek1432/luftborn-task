namespace luftborn_task.Endpoints.Model
{
    public record class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public record class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
