using Delivery_order.VModel;

namespace Delivery_order.Repository
{
    public interface IRepository
    {
        //Order
        public Task<Order> AddItem(AddItemToOrdre info, User user);
        public Task<Order> OrderDone(Guid orderId);
        public Task<List<VMUserOrder>> GetUserOrder(string userid);
        public Task<List<Order>> GetDoneOrderByRegion(string user);
        public Task<double> GetPrice(Guid OrderId);        
        public Task<bool> DeleteOrder(Guid?  OrderId);
        public Task<bool> DeleteItemInOrder(Guid itemPayId);
        public Task<Order> RequestAccept(VMRequestAccept info);
        //Order

        //Shop
        public Task<Shop> AddQote(AddQoteToShop qote);
        public Task<bool> AddType(AddType type);
        public  Task<List<VMSShop>> GetShopsByRegion(string user);
        public Task<List<VMSQote>> GetTodayQotes(string user);
        public Task<List<ShopType>> GetAllType();
        //Shop

        //User
        public Task<bool> AddUserLocation(AddUserLocation userLocation);       
        public Task<List<VMSUserLoction>> GetUserLocation(string userId);
       
        //User 

        //Get
        public Task<Item> GetItem(Guid? itemId);
        public Task<VMSUserLocation> GetUserLocation(Guid? userLocationId);
        public Task<Order> GetOrderShop(Guid? shopId,User user);
        public Task<Shop> GetShop(Guid? shopId);
        public Task<ItemPay> GetItemPay(Guid? itemPayId);
        public Task<List<ItemPay>> GetAllItemPayOrder(Guid? orderId);
        public Task<Order> GetOrder(Guid? shopId);
        public Task<List<VMItemByEvaluation>> GetItemByEvaluation(string userId);
        public Task<List<Region>> GetRegion();
        public Task<VMUserInfo> GetUsersInfo(string userId);
        public Task<bool> UpdateUserInfo(VMUserInfo info);
        public Task<VMShop> GetItemByShop(Guid shopId);
    }
}
