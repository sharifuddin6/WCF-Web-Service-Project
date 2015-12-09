using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Web_Service_Project
{
    [ServiceContract]
    public interface IInventoryService
    {
        [OperationContract]
        Product GetProduct(int productId);

        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        bool AddProduct(Product product);

        [OperationContract]
        bool RemoveProduct(int productId);
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Abstract { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string Thumbnail { get; set; }

        [DataMember]
        public DateTime DateAdded { get; set; }
    }
}
