
using HimsLanguages.Services;
using HimsLanguages.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace HimsLanguages.Services
{


    public interface IUnitOfWork
    {

        public LanguagesRepo languagesRepo { get; }
        public LocaleStringResourcesRepo localeRepo { get; }

    }



    public class UnitOfWork : IUnitOfWork
    {
        public LanguagesRepo languagesRepo { get; }
        public LocaleStringResourcesRepo localeRepo { get; }

        //LanguagesRepo IUnitOfWork.currencyRepo => throw new NotImplementedException();

        public UnitOfWork(LanguagesRepo Repo, LocaleStringResourcesRepo _Repo)
        {
            languagesRepo = Repo;
            localeRepo=_Repo;




        }


    }


}

