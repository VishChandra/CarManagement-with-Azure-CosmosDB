using Cosmonaut.Attributes;

namespace CarManagement.Models
{
    [CosmosCollection("mycars")]
    public class Car
    {
        [CosmosPartitionKey]
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public string BodyType { get; set; }
        public bool Automatic { get; set; }

    }
}
