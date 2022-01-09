using Models;
namespace DataRepository;
public interface DataRepositoryInterface
{
    List<Store> GetAllStores ();
    List<Inventory> GetInventoryByStoreId (int StId);
}
