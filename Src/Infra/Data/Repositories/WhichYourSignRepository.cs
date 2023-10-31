using DMS_WhichYourSign_API.Src.Domain.Interfaces.Repositories;
using DMS_WhichYourSign_API.Src.Infra.Data.Contexts;
using DMS_WhichYourSign_API.Src.Infra.Data.Contexts.Interface;
using DMS_WhichYourSign_API.Src.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMS_WhichYourSign_API.Src.Infra.Data.Repositories
{
    public class WhichYourSignRepository : IWhichYourSignRepository
    {
        private readonly WhichYourSignDBContext _whichYourSignDBContext;
        private readonly IUnitOfWork _unitOfWork;

        public WhichYourSignRepository(WhichYourSignDBContext whichYourSignDBContext, IUnitOfWork unitOfWork)
        {
            _whichYourSignDBContext = whichYourSignDBContext;
            _unitOfWork = unitOfWork;
        }

        public WhichYourSign SearchData(DateTime data)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                WhichYourSign result = _whichYourSignDBContext.WhichYourSigns                     
                    .Where(search => search.InicialDate <= data && search.FinalDate >= data)
                    .AsNoTracking()
                    .FirstOrDefault();

                _unitOfWork.Commit();

                return result;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception(StatusCodes.Status400BadRequest.ToString(ex.Message));
            }
        }
    }
}
