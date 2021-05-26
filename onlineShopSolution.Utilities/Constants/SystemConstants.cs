using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Utilities.Constants
{   // GetConnectionString của ConfigureServices in BackendApi
    public class SystemConstants
    {
        public const string MainConnectionString = "onlineShopSolutionDb";
        public const string CartSession = "CartSession";
        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }
       
        public class ProductConstants
        {
            public const string NA = "N/A";
        }

        public class ProductSettings
        {
            public const int NumberOfLatestProducts = 12;
            public const int NumberOfFeaturedProducts = 8;
            public const int NumberOfRelatedProducts = 4;
        }

        public class CategoryConstants
        {
            public const string NA = "N/A";
        }

    }
}
