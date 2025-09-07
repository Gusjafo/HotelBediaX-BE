namespace HotelBediaX.Application.UseCases.Common
{
    public class Pagination<T>
    {
        public List<T> Content { get; set; } = [];
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int Size { get; set; }
        public int Number { get; set; }
    }
}
