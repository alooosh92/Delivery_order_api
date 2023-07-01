using Delivery_order.Models;
using Delivery_order.VModel;
using Microsoft.EntityFrameworkCore;

namespace Delivery_order.Repository
{
    public class Repository : IRepository
    {
        public Repository(ApplicationDbContext db,UserManager<User> userManager)
        {
            Db = db;
            UserManager = userManager;
        }

        public ApplicationDbContext Db { get; }
        public UserManager<User> UserManager { get; }

        //for test -->
        private async Task<bool> AddDefulteValue()
        {
            try
            {
                await Db.ShopTypes.AddAsync(new ShopType { Type = "وجبات سريعة" ,IsFood = true});
                await Db.ShopTypes.AddAsync(new ShopType { Type = "أكلات غربية" ,IsFood =true});
                await Db.ShopTypes.AddAsync(new ShopType { Type = "هدايا" , IsFood = false });
                await Db.SaveChangesAsync();
                await Db.Shop.AddAsync(new Shop
                {
                    LocationLate = 0,
                    LocationLong = 0,
                    Name = "ماريو",
                    Region = await Db.Regions.FirstOrDefaultAsync(),
                    Type = await Db.ShopTypes.FirstOrDefaultAsync(a=>a.Type == "وجبات سريعة"),
                    UrlIcon = "3.jpeg",
                    UrlImage = "4.jpg",
                });
                await Db.Shop.AddAsync(new Shop
                {
                    LocationLate = 0,
                    LocationLong = 0,
                    Name = "سبونج بب",
                    Region = await Db.Regions.FirstOrDefaultAsync(),
                    Type = await Db.ShopTypes.FirstOrDefaultAsync(a=>a.Type == "أكلات غربية"),
                    UrlIcon = "3.jpeg",
                    UrlImage = "4.jpg"
                });
                await Db.Shop.AddAsync(new Shop
                {
                    LocationLate = 0,
                    LocationLong = 0,
                    Name = "ريبون",
                    Region = await Db.Regions.FirstOrDefaultAsync(),
                    Type = await Db.ShopTypes.FirstOrDefaultAsync(a=>a.Type == "هدايا"),
                    UrlIcon = "3.jpeg",
                    UrlImage = "4.jpg"
                });
                await Db.SaveChangesAsync();
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "جبنة",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a=>a.Name == "ماريو"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "بيتزا",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "ماريو"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "مناقيش زعتر",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "ماريو"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "جكن بركر",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "سبونج بب"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "ميت بركر",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "سبونج بب"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "معكرونة باشاميل",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "سبونج بب"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "ساعات",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "ريبون"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "عطور",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "ريبون"),
                });
                await Db.ShopDescription.AddAsync(new ShopDescription
                {
                    Description = "ألعاب",
                    Shop = await Db.Shop.FirstOrDefaultAsync(a => a.Name == "ريبون"),
                });
                await Db.SaveChangesAsync();
                await Db.Item.AddAsync(new Item
                {
                    Description = "بيتزا كبيرة مع فطر وجبنة",
                    Name = "بيتزا كبيرة فطر",
                    Price = 14000,
                    Shop = await Db.Shop.FirstOrDefaultAsync(),      
                    Image = "1.png"
                });
                await Db.SaveChangesAsync();
                await Db.UserLocation.AddAsync(new VMSUserLocation
                {
                    Description = "بيت",
                    LocationLate = 0,
                    LocationLong = 0,
                    User = await Db.Users.FirstOrDefaultAsync(),                    
                }) ;
                await Db.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }
        //for test <--
        public async Task<Order> AddItem(AddItemToOrdre info,User user)
        {
            try
            {
                //for test  -->
                // var b = await Db.Shop.ToListAsync();
                // if (b.IsNullOrEmpty()) 
                //      await AddDefulteValue();
                //for test <--
                Item? item = await GetItem(info.Item);
                Order? order = await GetOrderShop(item.Shop!.Id,user);
                if (order == null) {
                    VMSUserLocation? userLocation = await GetUserLocation(info.LocationId);
                    order = new Order { 
                        DeliveryPrice = info.Price,
                        FromLate = item.Shop!.LocationLate,
                        FromLong = item.Shop.LocationLong,
                        Shop = item.Shop,
                        ToLate = userLocation!.LocationLate,
                        ToLong = userLocation.LocationLong,
                        User = userLocation.User,
                    };
                    await Db.Order.AddAsync(order);
                }
                ItemPay? itempay = new ItemPay
                {
                    Item = item,
                    Notes = info.Notes,
                    NumberOfItem = info.NumberOfItem,
                    Order = order,
                };
                await Db.ItemPay.AddAsync(itempay);
                await Db.SaveChangesAsync();
                return order!;
            }
            catch { throw; }
        }

        public async Task<Shop> AddQote(AddQoteToShop qote)
        {
            try
            {
                var addqote = new Qote
                {
                    StartDate = qote.StartDate,
                    EndDate = qote.EndDate,
                    ImageUrl = qote.ImageUrl,
                    Price = qote.Price,
                    Shop = await GetShop(qote.Shop),
                };
                var entity = await Db.Qote.AddAsync(addqote);
                await Db.SaveChangesAsync();
                return entity.Entity.Shop!;
            }
            catch { throw; }
        }

        public async Task<bool> AddType(AddType type)
        {
            try
            {
                var shopType = new ShopType 
                {
                    Type = type.Type,
                    IsFood = type.IsFood
                };
                await Db.ShopTypes.AddAsync(shopType);
                await Db.SaveChangesAsync();
                return true;
                
            }catch { throw; }
        }

        public async Task<bool> AddUserLocation(AddUserLocation userLocation)
        {
            try
            {
                var location = new VMSUserLocation
                {
                    Description = userLocation.Description,
                    LocationLate = userLocation.LocationLate,
                    LocationLong = userLocation.LocationLong,
                    User = await UserManager.FindByEmailAsync(userLocation.User!),
                };
                var entity =  await Db.UserLocation.AddAsync(location);
                await Db.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteItemInOrder(Guid itemPayId)
        {
            try
            {
                var item = await GetItemPay(itemPayId);
                if (item.Order!.IsDone != null) { return false; }
                var count = await GetAllItemPayOrder(item.Order.Id);                
                Db.ItemPay.Remove(item);
                if (count.Count == 1) {
                    await DeleteOrder(item.Order.Id);
                }
                await Db.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<bool> DeleteOrder(Guid? orderId)
        {
            try
            {
                var order = await GetOrder(orderId);
                if (order.IsDone != null) { return false; }
                var itempay = await GetAllItemPayOrder(orderId);
                foreach (var item in itempay)
                {
                    Db.ItemPay.Remove(item);
                }
                Db.Order.Remove(order);
                await Db.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<List<ShopType>> GetAllType()
        {
            try
            {
                var type = await Db.ShopTypes.ToListAsync();
                return type;
            }
            catch { throw; }
        }

        public async Task<List<Order>> GetDoneOrderByRegion(string userId)
        {
            try
            {
                var user = await Db.Users.Include(u => u.Region).SingleOrDefaultAsync(a => a.Email == userId);
                var order = await Db.Order.Include(s => s.Shop!.Region).Include(u => u.User).Where(d => d.IsDone != null && d.IsEnd == null && d.Shop!.Region == user!.Region).ToListAsync();
                return order;
            }
            catch { throw; }
        }

        public async Task<Item> GetItem(Guid? itemId)
        {
            try
            {
                var ite = await Db.Item.Include(s=>s.Shop!.Region).SingleOrDefaultAsync(a=> a.Id == itemId);
                ite!.Image = ite.Image;
                return ite!;
            }
            catch { throw; }
        }

        public async Task<Order> GetOrderShop(Guid? shopId,User user)
        {
            try
            {
                Order? order = await Db.Order
                   .Include(s => s.Shop)
                .Include(u => u.User)
                   .SingleOrDefaultAsync(o =>o.User == user && o.IsDone == null && o.Shop!.Id == shopId);
                return order!;
            }
            catch { throw; }
        }

        public async Task<double> GetPrice(Guid orderId)
        {
            try
            {
                double price = 0;
                var item = await GetAllItemPayOrder(orderId);
                foreach(var i in item)
                {
                    var p = i.Item!.Price * i.NumberOfItem;
                    price += p;
                }
                return price;
            }
            catch { throw; }
        }
        //done
        public async Task<List<VMSShop>> GetShopsByRegion(string userId)
        {
            try
            {
                var user = await Db.Users.Include(r => r.Region).SingleOrDefaultAsync(a => a.Email == userId);
                var shops = await Db.Shop.Include(r=>r.Region).Include(i=>i.Type)
                    .Where(r=>r.Region == user!.Region).ToListAsync();
                var vmshop = new List<VMSShop>();
                foreach(var shop in shops)
                {
                    var d = await Db.ShopDescription.Where(a => a.Shop == shop).ToListAsync();
                    var LD = new List<string>();
                    foreach (var item in d)
                    {
                        LD.Add(item.Description!);
                    }
                    var s = new VMSShop
                    {
                        Id = shop.Id,
                        Evaluation = shop.Evaluation,
                        LateLocation = shop.LocationLate,
                        LongLocation = shop.LocationLong,
                        ResidentsNumber = shop.ResidentsNumber,
                        ShopName = shop.Name,
                        UrlImage = shop.UrlImage,
                        UrlLogo = shop.UrlIcon,
                        IsFood = shop.Type!.IsFood,
                        Type = shop.Type.Type,
                        ShopDescription = LD,
                    };
                    vmshop.Add(s);
                }
                return vmshop;
            }
            catch { throw; }
        }
        //done
        public async Task<List<VMSQote>> GetTodayQotes(string userId)
        {
            try
            {
                var user = await Db.Users.Include(r => r.Region).SingleOrDefaultAsync(a => a.Email == userId);
                var qote = await Db.Qote.Include(t=>t.Shop!.Type).Include(r=>r.Shop!.Region)
                    .Where(q => q.Shop!.Region == user!.Region && q.StartDate <= DateTime.Now && DateTime.Now <= q.EndDate )
                    .ToListAsync();
                var vmqote = new List<VMSQote>();
                foreach (var item in qote)
                {
                    var q = new VMSQote
                    {
                        Id = item.Id,
                        ImageUrl = item.ImageUrl,
                        Shoptype = item.Shop!.Type!.Type,
                        ShopId = item.Shop!.Id,
                    };
                    vmqote.Add(q);
                }
                return vmqote;
            }
            catch { throw; }
        }
        //done
        public async Task<List<VMSUserLoction>> GetUserLocation(string userId)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(userId);
                var location = await Db.UserLocation.Include(u => u.User)
                    .Where(a => a.User == user).ToListAsync();
                var vmlocation = new List<VMSUserLoction>();
                foreach (var item in location)
                {
                    var loc = new VMSUserLoction
                    {
                        Description = item.Description,
                        Id = item.Id,
                        LocationLate = item.LocationLate,
                        LocationLong = item.LocationLong
                    };
                    vmlocation.Add(loc);
                }
                return vmlocation;
            }
            catch { throw; }
        }

        public async Task<VMSUserLocation> GetUserLocation(Guid? userLocationId)
        {
            try
            {
                VMSUserLocation? userLocation = await Db.UserLocation
                        .Include(s => s.User)
                        .SingleOrDefaultAsync(a => a.Id == userLocationId);
                return userLocation!;
            }
            catch { throw; }
        }

        public async Task<List<VMUserOrder>> GetUserOrder(string userId)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(userId);
                var order = await Db.Order.Include(u => u.User).Include(s => s.Shop)
                    .Where(o => o.User == user).ToListAsync();
                var vmOrder = new List<VMUserOrder>();
                foreach (var item in order)
                {
                    var itemOr = await GetAllItemPayOrder(item.Id);
                    var list = new List<TabelRowItem>();
                    foreach (var item1 in itemOr)
                    {
                        var t = new TabelRowItem
                        {
                            ItemName = item1.Item!.Name,
                            Number = item1.NumberOfItem,
                            Price = item1.Item.Price,
                        };
                        list.Add(t);
                    }
                    var vm = new VMUserOrder
                    {
                        Id = item.Id,
                        CreateDate = item.OrderDate,
                        ShopName = item.Shop!.Name,
                        Code = item.Pincode,
                        Delivery = item.DeliveryPrice,
                        ConfirmOrder = item.IsDone,
                        DeliveryTime = item.IsEnd,
                        AccseptOrder = item.RequestAccept,
                        ListOrder = list,
                    };
                    vmOrder.Add(vm);
                }
                return vmOrder;
            }
            catch { throw; }
        }

        public async Task<Order> OrderDone(Guid orderId)
        {
            try
            {
                var order = await GetOrder(orderId);
                var user = order.User!;
                user.UserPoint += order.DeliveryPrice * 0.01; 
                order.IsDone = DateTime.Now;
                Db.Users.Update(user);
                Db.Order.Update(order);
                await Db.SaveChangesAsync();
                return order;
            }
            catch { throw; }
        }

        public async Task<Order> RequestAccept(VMRequestAccept info)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(info.userid!);
                var order = await GetOrder(info.orderId);
                var devOrd = new DeliveryEmployee {
                    Employee = user,
                    Order = order,
                };                
                await Db.DeliveryEmployees.AddAsync(devOrd);
                order.RequestAccept = DateTime.Now;
                Db.Order.Update(order);
                await Db.SaveChangesAsync();
                return order;
            }
            catch { throw; }
        }

        public async Task<bool> UpdateUserInfo(VMUser userInfo)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(userInfo.userId!);
                user!.Region = await Db.Regions.FindAsync(userInfo.Region!.Id);
                user.Adress = userInfo.Adress;
                user.Name = userInfo.Name;
                user.Sex = userInfo.Sex;
                user.PhoneNumber = userInfo.Phone;
                await UserManager.UpdateAsync(user);
                return true;
            }
            catch { throw; }
        }

        public async Task<Shop> GetShop(Guid? shopId)
        {
            try
            {                
                var shop = await Db.Shop
                    .Include(r => r.Region)
                    .Include(t => t.Type)
                    .SingleOrDefaultAsync(s => s.Id == shopId);
                shop!.UrlImage = shop.UrlImage;
                shop.UrlIcon = shop.UrlIcon;
                return shop!;
            }
            catch { throw; }
        }

        public async Task<ItemPay> GetItemPay(Guid? itemPayId)
        {
            try
            {
                ItemPay? item = await Db.ItemPay.Include(o => o.Order.Shop).
                    Include(i => i.Item).SingleOrDefaultAsync(i => i.Id == itemPayId);
                return item!;
            }
            catch { throw; }
        }

        public async Task<List<ItemPay>> GetAllItemPayOrder(Guid? orderId)
        {
            try
            {
                var item = await Db.ItemPay.Include(o => o.Order!.Shop).
                    Include(i => i.Item).Where(a => a.Order!.Id == orderId).ToListAsync();
                return item!;
            }
            catch { throw; }
        }

        public async Task<Order> GetOrder(Guid? orderId)
        {
            try
            {
                Order? order = await Db.Order
                   .Include(s => s.Shop)
                .Include(u => u.User)
                   .SingleOrDefaultAsync(o => o.Id == orderId);
                return order!;
            }
            catch { throw; }
        }

        public async Task<List<VMItemByEvaluation>> GetItemByEvaluation(string userId)
        {
            try
            {
                var user = await Db.Users.Include(r => r.Region).SingleOrDefaultAsync(a => a.Email == userId);
                var itemes = await Db.Item.Include(a => a.Shop).
                    Where(a => a.Shop!.Region == user!.Region).ToListAsync();
                itemes = itemes.OrderByDescending(a => a.Evaluation).ThenByDescending(a=>a.ResidentsNumber).ToList();
                List<VMItemByEvaluation> vmi = new List<VMItemByEvaluation>();
                foreach (var item in itemes)
                {
                    var i = new VMItemByEvaluation{ 
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                        Evaluation = item.Evaluation,
                        shop = item.Shop!.Name,
                        image = item.Image
                    };
                    vmi.Add(i);
                }
                return vmi;
            }
            catch { throw; }
        }

        public async Task<List<Region>> GetRegion()
        {
            try
            {
                var regions = await Db.Regions.ToListAsync();
                return regions;
            }
            catch { throw; }
        }

        public async Task<VMUserInfo> GetUsersInfo(string userId)
        {
            try
            {
                var user = await Db.Users.Include(r => r.Region).SingleOrDefaultAsync(a => a.Email == userId);
                var vmuser = new VMUserInfo
                {
                    Id = user!.Id,
                    Mobile = user.PhoneNumber,
                    Name = user.Name,
                    Region = user.Region!.Id,
                    Sex = user.Sex,
                    point = user.UserPoint
                };
                return vmuser;
            }
            catch { throw; }
        }

        public async Task<bool> UpdateUserInfo(VMUserInfo info)
        {
            try
            {
                var user = await Db.Users.Include(r => r.Region).SingleOrDefaultAsync(a => a.Email == info.Id);
                user!.PhoneNumber = info.Mobile;
                user.Name = info.Name;
                user.Region = await Db.Regions.SingleOrDefaultAsync(a => a.Id == info.Region);
                user.Sex = info.Sex;
                Db.Users.Update(user);
                await Db.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<VMShop> GetItemByShop(Guid shopId)
        {
            try
            {                
                var itemes = await Db.Item.Include(a => a.Shop).
                    Where(a => a.Shop!.Id == shopId).ToListAsync();
                itemes = itemes.OrderByDescending(a => a.Evaluation).ThenByDescending(a => a.ResidentsNumber).ToList();
                List<VMItemByEvaluation> vmi = new List<VMItemByEvaluation>();
                foreach (var item in itemes)
                {
                    var i = new VMItemByEvaluation
                    {
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                        Evaluation = item.Evaluation,
                        shop = item.Shop!.Name,
                        image = item.Image
                    };
                    vmi.Add(i);
                }
                VMShop shop = new VMShop();
                var s = await GetShop(shopId);
                var d = await Db.ShopDescription.Where(a => a.Shop == s).ToListAsync();
                var LD = new List<string>();
                foreach (var item in d)
                {
                    LD.Add(item.Description!);
                }
                var vs = new VMSShop
                {
                    Id = s.Id,
                    Evaluation = s.Evaluation,
                    LateLocation = s.LocationLate,
                    LongLocation = s.LocationLong,
                    ResidentsNumber = s.ResidentsNumber,
                    ShopName = s.Name,
                    UrlImage = s.UrlImage,
                    UrlLogo = s.UrlIcon,
                    IsFood = s.Type!.IsFood,
                    Type = s.Type.Type,
                    ShopDescription = LD,
                };
                shop.ListItem = vmi;
                shop.Shop = vs;
                return shop;
            }
            catch { throw; }
        }

        public async Task<VMitem> GetItemInof(Guid itemId)
        {
            try
            {
                var item = await Db.Item.Include(a=>a.Shop!.Region).SingleOrDefaultAsync(a => a.Id == itemId);
                var vmitem = new VMitem
                {
                    Id = item!.Id,
                    Evaluation = item.Evaluation,
                    Image = item.Image,
                    Info = item.Description,
                    Name = item.Name,
                    Price = item.Price,
                    Shopid = item.Shop!.Id,
                    ShopLate = item.Shop.LocationLate,
                    ShopLong = item.Shop.LocationLong,
                };
                return vmitem;
            }
            catch { throw; }
        }

        public async Task<bool> DeleteUserLocation(Guid id)
        {
            try
            {
                var location = await Db.UserLocation.SingleOrDefaultAsync(a => a.Id == id);
                Db.UserLocation.Remove(location!);
                await Db.SaveChangesAsync();
                return true;
            }catch { throw; }
        }
    }
}
