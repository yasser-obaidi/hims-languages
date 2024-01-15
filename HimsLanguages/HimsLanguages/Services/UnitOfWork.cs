
using HimsLanguages.Services;
using HimsLanguages.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace HimsLanguages.Services
{


    public interface IUnitOfWork
    {

        public LanguagesRepo languagesRepo { get; }
        

    }



    public class UnitOfWork : IUnitOfWork
    {
        public LanguagesRepo languagesRepo { get; }

        //LanguagesRepo IUnitOfWork.currencyRepo => throw new NotImplementedException();

        public UnitOfWork(LanguagesRepo Repo)
        {
            languagesRepo = Repo;
            


        }


    }


}

