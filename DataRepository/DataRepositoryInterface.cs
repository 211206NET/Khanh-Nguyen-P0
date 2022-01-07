using Models;
namespace DataRepository;
public interface DataRepositoryInterface
{
    int SignIn (string email, string pass );
    List<Store> GetAllStores ();
    List<Inventory> GetInventoryByStoreId (int StId);
}
