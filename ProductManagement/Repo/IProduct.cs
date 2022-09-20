using ServiceBookingLibrary.Models;

namespace ProductManagement.Repo
{
    public interface IProduct
    {
        public Task<Product> AddNewProduct(Product p);
        public Task<Product> UpdateProduct(int produid, Product u);
        public Task<List<Product>> getAllProduct();
        public Task<Product> getProduct(int pid);
        public void deleteProduct(int pid);
    }
}
