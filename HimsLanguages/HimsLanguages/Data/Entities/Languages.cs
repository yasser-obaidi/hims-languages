using HimsLanguages.Data.Entities;
using HimsLanguages.Data.Entities.Commen;
using System;

namespace HimsLanguages.Data.Entities
{
    public class Languages : BaseEntity
       


    {

        public int Id { get; set; }
       

        public string Name { get; set; }

        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Rtl { get; set; }
        public bool Published { get; set; }

      
     
      


    }
}
