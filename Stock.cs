//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Education_Practic_num_1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public int Stock_ID { get; set; }
        public Nullable<int> Stock_Number_of_Products { get; set; }
        public System.DateTime Stock_Date_of_Receipt { get; set; }
        public int ID_Product { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
