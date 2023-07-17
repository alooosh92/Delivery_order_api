using FirebaseAdmin.Messaging;

namespace Delivery_order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController(IRepository repository, UserManager<User> userManager)
        {
            Repository = repository;
            UserManager = userManager;
        }

        public IRepository Repository { get; }
        public UserManager<User> UserManager { get; }
        [HttpPost]
        [Route("AddQote")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<Shop> AddQote([FromBody] AddQoteToShop qote)
        {
            try
            {
                var shop = await Repository.AddQote(qote);
                return shop;
            }
            catch { throw; }
        }
        [HttpPost]
        [Route("AddType")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<bool> AddType([FromBody] AddType type)
        {
            try
            {
                var b = await Repository.AddType(type);
                return b;
            }
            catch { throw; }
        }
        [HttpGet]
        [Route("GetAllType")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<List<ShopType>> GetAllType()
        {
            try
            {
                var type = await Repository.GetAllType();
                return type;
            }
            catch { throw; }
        }
        [HttpGet]
        [Route("GetDoneOrderByRegion")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<Order>> GetDoneOrderByRegion()
        {
            try
            {
                var user = UserManager.GetUserId(User);
                var orders = await Repository.GetDoneOrderByRegion(user!);
                return orders;
            }
            catch { throw; }
        }
        [HttpPut]
        [Route("RequestAccept")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<Order> RequestAccept([FromBody]Guid orderId)
        {
            try
            {
                var vmr = new VMRequestAccept {
                    orderId = orderId,
                    userid = UserManager.GetUserId(User),
                };
                var order = await Repository.RequestAccept(vmr);
                return order;
            }
            catch { throw; }
        }
        [HttpPost]
        [Route("SentMessageToManyUser")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> SentMessageToManyUser([FromBody] VMMessage message)
        {
            try
            {
                var b = await Repository.SentMessageToManyUser(message.Title, message.Message, message.Region);
                return b;
            }
            catch { throw; }
        }
        [HttpPost]
        [Route("SentMessageToManyEmployee")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> SentMessageToManyEmployee([FromBody] VMMessage message)
        {
            try
            {
                var b = await Repository.SentMessageToManyEmployee(message.Title, message.Message, message.Region);
                return b;
            }
            catch { throw; }
        }
    }
}
