using Delivery_order.VModel;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics.Contracts;

namespace Delivery_order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        public AppController(IRepository repository, UserManager<User> userManager)
        {
            Repository = repository;
            UserManager = userManager;
        }

        public IRepository Repository { get; }
        public UserManager<User> UserManager { get; }

        [HttpPost]
        [Route("AddItemToOrder")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<Order> AddItemToOrder([FromBody] AddItemToOrdre info) 
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(UserManager.GetUserId(User)!);
                var order = await Repository.AddItem(info, user!);
                return order!;
            }
            catch { throw; }
        }
        [HttpPost]
        [Route("AddUserLocation")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> AddUserLocation([FromBody] AddUserLocation addUserLocation)
        {
            try
            {
                addUserLocation.User = UserManager.GetUserId(User);
                var b = await Repository.AddUserLocation(addUserLocation);
                return b;
            }catch { throw; }
        }
        [HttpDelete]
        [Route("DeleteItemInOrder")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> DeleteItemInOrder([FromBody] Guid id)
        {
            try
            {
                var b = await Repository.DeleteItemInOrder(id);
                return b;
            }
            catch { throw; }
        }
        [HttpDelete]
        [Route("DeleteOrder")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> DeleteOrder([FromBody] Guid id)
        {
            try
            {
                var b = await Repository.DeleteOrder(id);
                return b;
            }catch { throw; }
        }
        [HttpGet]
        [Route("GetShopsByRegion")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<VMSShop>> GetShopsByRegion()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var shops = await Repository.GetShopsByRegion(user!);
                return shops;
            }
            catch { throw; }
        }
        [HttpGet]
        [Route("GetTodayQotes")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<VMSQote>> GetTodayQotes()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var qote = await Repository.GetTodayQotes(user!);                
                return qote;
            }
            catch { throw; }
        }
        [HttpGet]
        [Route("GetUserLocation")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<VMSUserLoction>> GetUserLocation()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var locations  = await Repository.GetUserLocation(user!);
                return locations;
            }
            catch { throw; }
        }
        [HttpGet]
        [Route("GetUserOrder")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<VMUserOrder>> GetUserOrder()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var orders = await Repository.GetUserOrder(user!);
                return orders;
            }
            catch { throw; }
        }
        [HttpPut]
        [Route("OrderDone")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<Order> OrderDone([FromBody]Guid orderId)
        {
            try
            {
                var order = await Repository.OrderDone(orderId);
                return order;
            }
            catch { throw; }
        }      
        [HttpGet]
        [Route("GetItemByEvaluation")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<VMItemByEvaluation>> GetItemByEvaluation()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var item = await Repository.GetItemByEvaluation(user!);
                return item;
            }catch{ throw; }
        }
        [HttpGet]
        [Route("GetRegions")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<Region>> GetRegions()
        {
            try
            {
                var regions = await Repository.GetRegion();
                return regions;
            }
            catch { throw; }
        }
        [HttpGet]
        [Route("GetUserInfo")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<VMUserInfo> GetUserInfo()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var info = await Repository.GetUsersInfo(user!);
                return info;
            }
            catch { throw; }
        }
        [HttpPut]
        [Route("UpdateUserInfo")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> UpdateUserInfo([FromBody] VMUserInfo info)
        {
            try
            {
                var user = UserManager.GetUserId(User);
                info.Id = user;
                var b = await Repository.UpdateUserInfo(info);
                return b;
            }
            catch { throw; }
        }
        [HttpPost]
        [Route("GetShop")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<VMShop> GetIShop([FromBody]Guid shopId)
        {
            try
            {
                var item = await Repository.GetItemByShop(shopId);
                return item;
            }
            catch { throw; }
        }
    }
}