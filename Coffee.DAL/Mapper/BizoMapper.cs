using AutoMapper;
//using Globals;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mapper
{
    public class BizOMapper : Profile
    {
        public BizOMapper()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            //
            //user
            //
            CreateMap<Coffee.DAL.Entity.User, Coffee.DAL.DTO.User>();
            CreateMap<Coffee.DAL.DTO.User, Coffee.DAL.Entity.User>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Purchases, opt => opt.Ignore());

            //
            //tax
            //
            CreateMap<Coffee.DAL.Entity.Tax, Coffee.DAL.DTO.Tax>();
            CreateMap<Coffee.DAL.DTO.Tax, Coffee.DAL.Entity.Tax>()
                .ForMember(dest => dest.OrderTaxDetails, opt => opt.Ignore());

            //
            //order
            //
            // 1. Map the child details first
            CreateMap<Coffee.DAL.Entity.OrderDetail, Coffee.DAL.DTO.OrderDetail>().ReverseMap();
            CreateMap<Coffee.DAL.Entity.OrderTaxDetail, Coffee.DAL.DTO.OrderTaxDetail>().ReverseMap();
            // 2. Map the Order
            CreateMap<Coffee.DAL.Entity.Order, Coffee.DAL.DTO.Order>(); // Entity -> DTO (Includes details)
            CreateMap<Coffee.DAL.DTO.Order, Coffee.DAL.Entity.Order>()  // DTO -> Entity (For Saving)
                .ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore the User object to prevent DB errors

            //
            //OrderDeail
            //
            // 1. Map the 'Additional' child first so the list can be filled
            CreateMap<Coffee.DAL.Entity.Additional, Coffee.DAL.DTO.Additional>().ReverseMap();
            // 2. Map the OrderDetail
            CreateMap<Coffee.DAL.Entity.OrderDetail, Coffee.DAL.DTO.OrderDetail>(); // Forward (to UI)
            CreateMap<Coffee.DAL.DTO.OrderDetail, Coffee.DAL.Entity.OrderDetail>()  // Backward (to DB)
                .ForMember(dest => dest.Order, opt => opt.Ignore())   // Protect Parent link
                .ForMember(dest => dest.Product, opt => opt.Ignore()); // Protect Product link

            //
            //menu
            //
            // 1. Map the child Recipe first so the List<Recipe> works
            CreateMap<Coffee.DAL.Entity.Recipe, Coffee.DAL.DTO.Recipe>().ReverseMap();
            // 2. Map the Menu (Entity -> DTO)
            CreateMap<Coffee.DAL.Entity.Menu, Coffee.DAL.DTO.Menu>();
            // 3. Map the Menu (DTO -> Entity) for Saving
            CreateMap<Coffee.DAL.DTO.Menu, Coffee.DAL.Entity.Menu>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore())
                .ForMember(dest => dest.ProductLostAndDamages, opt => opt.Ignore());

            //
            //category
            //
            CreateMap<Coffee.DAL.Entity.Category, Coffee.DAL.DTO.Category>()
                .ReverseMap()
                .ForMember(dest => dest.Menus, opt => opt.Ignore());


            //
            //ingredient
            //
            CreateMap<Coffee.DAL.Entity.Ingredient, Coffee.DAL.DTO.Ingredient>()
                .ReverseMap()
                .ForMember(dest => dest.Additionals, opt => opt.Ignore())
                .ForMember(dest => dest.IngredientLosses, opt => opt.Ignore())
                .ForMember(dest => dest.PurchaseDetails, opt => opt.Ignore())
                .ForMember(dest => dest.Recipes, opt => opt.Ignore());

            //
            //ingredientLoss
            //
            CreateMap<Coffee.DAL.Entity.IngredientLoss, Coffee.DAL.DTO.IngredientLoss>()
                .ReverseMap()
                .ForMember(dest => dest.Ingredient, opt => opt.Ignore());

            //
            //ordertaxdetail
            //
            CreateMap<Coffee.DAL.Entity.OrderTaxDetail, Coffee.DAL.DTO.OrderTaxDetail>()
                .ReverseMap()
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Tax, opt => opt.Ignore());

            //
            //productLossAndDamage
            //
            CreateMap<Coffee.DAL.Entity.ProductLostAndDamage, Coffee.DAL.DTO.ProductLostAndDamage>()
                .ReverseMap()
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            //
            //purchase
            //
            // 1. Map the child details first so the list in Purchase can be filled
            CreateMap<Coffee.DAL.Entity.PurchaseDetail, Coffee.DAL.DTO.PurchaseDetail>().ReverseMap();
            // 2. Map the Purchase
            CreateMap<Coffee.DAL.Entity.Purchase, Coffee.DAL.DTO.Purchase>()
                .ReverseMap()
                .ForMember(dest => dest.PurchaseDetails, opt => opt.Ignore()) // Protect existing details
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())        // Protect Supplier link
                .ForMember(dest => dest.SupplierPayments, opt => opt.Ignore()) // Protect Payment history
                .ForMember(dest => dest.User, opt => opt.Ignore());           // Protect User link

            //
            //purchasedetail
            //
            CreateMap<Coffee.DAL.Entity.PurchaseDetail, Coffee.DAL.DTO.PurchaseDetail>()
                .ReverseMap()
                .ForMember(dest => dest.Ingredient, opt => opt.Ignore())
                .ForMember(dest => dest.Purchase, opt => opt.Ignore());

            //
            //recipe
            //
            CreateMap<Coffee.DAL.Entity.Recipe, Coffee.DAL.DTO.Recipe>()
                .ReverseMap()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Ingredient, opt => opt.Ignore());

            //
            //supplier
            //
            CreateMap<Coffee.DAL.Entity.Supplier, Coffee.DAL.DTO.Supplier>()
                .ReverseMap()
                .ForMember(dest => dest.Purchases, opt => opt.Ignore());

            //
            //supplierPayment
            //
            CreateMap<Coffee.DAL.Entity.SupplierPayment, Coffee.DAL.DTO.SupplierPayment>()
                .ReverseMap()
                .ForMember(dest => dest.Purchase, opt => opt.Ignore());
        }
    }
}
