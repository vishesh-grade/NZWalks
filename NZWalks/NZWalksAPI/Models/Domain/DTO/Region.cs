namespace NZWalksAPI.Models.Domain.DTO
{
    public class Region
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
