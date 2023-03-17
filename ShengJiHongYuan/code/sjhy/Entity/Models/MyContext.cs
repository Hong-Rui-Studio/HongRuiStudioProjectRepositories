using Microsoft.EntityFrameworkCore;
namespace Entity.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        public DbSet<WelcomeMsgs> WelcomeMsgs { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<BranchStores> BranchStores { get; set; }
        public DbSet<WebMenus> WebMenus { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Advantages> Advantages { get; set; }
        public DbSet<ProductAdvantages> ProductAdvantages { get; set; }
        public DbSet<ProductAdvantagesInfo> ProductAdvantagesInfo { get; set; }
        public DbSet<Cases> Cases { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<CompanyCultures> CompanyCultures { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<CompanyHonor> CompanyHonor { get; set; }
        public DbSet<WoodWindowCultures> WoodWindowCultures { get; set; }
        public DbSet<WoodWindowSystem> WoodWindowSystem { get; set; }
        public DbSet<Authentications> Authentications { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductCategoryInfo> ProductCategoryInfo { get; set; }
        public DbSet<Notices> Notices { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<FriendLink> FriendLink { get; set; }
        public DbSet<SoleNets> SoleNets { get; set; }
        public DbSet<TechnicalSystem> TechnicalSystem { get; set; }
        public DbSet<TechnicalEquipment> TechnicalEquipment { get; set; }
        public DbSet<WindowCategory> WindowCategory { get; set; }
        public DbSet<WindowInfo> WindowInfo { get; set; }
        public DbSet<ServicesIdea> ServicesIdea { get; set; }
        public DbSet<ServiceProcess> ServiceProcess { get; set; }
        public DbSet<FranchiseAdvantages> FranchiseAdvantages { get; set; }
        public DbSet<JoiningStandard> JoiningStandard { get; set; }
        public DbSet<JoiningProgam> JoiningProgam { get; set; }
        public DbSet<OnlineMsg> OnlineMsg { get; set; }
        public DbSet<MeasuringRulerTime> MeasuringRulerTime { get; set; }
        public DbSet<MeasuringRulerHouse> MeasuringRulerHouse { get; set; }
        public DbSet<DecorationStage> DecorationStage { get; set; }
        public DbSet<DecorationCategory> DecorationCategory { get; set; }
        public DbSet<HouseType> HouseType { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<SystemMenus> SystemMenus { get; set; }
        public DbSet<AdminsPermission> AdminsPermission { get; set; }
        public DbSet<Seos> Seos { get; set; }
        public DbSet<Copyright> Copyright { get; set; }




    }
}
