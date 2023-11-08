using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages //new lenmesini istemediğim için static yaptım
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductNameInValid = "Geçersiz ürün ismi";

        public static string CategoriesListed = "Kategoriler listelendi";

        public static string AddedCategory = "Kategori eklendi";

        public static string NoDataInList = "Geçersiz işlem";

        public static string NoDataOnFilter = "Böyle bir kategori bulunmamaktadır   ";

        public static string AddedCustomer = "Müşteriler listelendi";
    }
}
