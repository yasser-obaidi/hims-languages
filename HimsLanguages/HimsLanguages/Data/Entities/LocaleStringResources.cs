using HimsLanguages.Data.Entities;
using HimsLanguages.Data.Entities.Commen;
using System;
using System.ComponentModel;

namespace HimsLanguages.Data.Entities
{
    public class LocaleStringResources:BaseEntity
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int LanguagesId { get; set; }


    }
}
