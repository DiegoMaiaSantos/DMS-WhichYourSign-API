using AutoMapper;
using DMS_WhichYourSign_API.Src.Application.Errors;
using DMS_WhichYourSign_API.Src.Domain.DTOs;
using DMS_WhichYourSign_API.Src.Domain.Interfaces.Repositories;
using DMS_WhichYourSign_API.Src.Domain.Interfaces.Services;
using DMS_WhichYourSign_API.Src.Domain.Models;
using DMS_WhichYourSign_API.Src.Infra.Data.Entities;

namespace DMS_WhichYourSign_API.Src.Service
{
    public class WhichYourSignService : IWhichYourSignService
    {
        private readonly IWhichYourSignRepository _whichYourSignRepository;
        private readonly IMapper _mapper;

        public WhichYourSignService(IWhichYourSignRepository whichYourSignRepository, IMapper mapper)
        {
            _whichYourSignRepository = whichYourSignRepository;
            _mapper = mapper;
        }

        public WhichYourSignResponseDTO ValidationOfReceivedData(WhichYourSignModel model)
        {
            try
            {
                string dateOfBirth = model.DateOfBirth.ToString();

                if (model.UserName == null || dateOfBirth == null)
                    throw new AppException(StatusCodes.Status400BadRequest.ToString());

                DateTime inicalDate = new DateTime(model.DateOfBirth.Year, 1, 1);
                DateTime finalDate = new DateTime(model.DateOfBirth.Year, 12, 31);

                int changeYear = 2023;
                if (model.DateOfBirth >= inicalDate && model.DateOfBirth <= finalDate)
                    model.DateOfBirth = new DateTime(changeYear, model.DateOfBirth.Month, model.DateOfBirth.Day);
                else
                    throw new AppException(StatusCodes.Status422UnprocessableEntity.ToString());

                DateTime initialDateValidation = new DateTime(2023, 12, 22);
                DateTime finalDateValidation = new DateTime(2023, 12, 31);

                if (model.DateOfBirth >= initialDateValidation && model.DateOfBirth <= finalDateValidation)
                    model.DateOfBirth = new DateTime(2022, model.DateOfBirth.Month, model.DateOfBirth.Day);

                WhichYourSign whichYourSign = _whichYourSignRepository.SearchData(model.DateOfBirth);

                WhichYourSignResponseDTO result = _mapper.Map<WhichYourSignResponseDTO>(whichYourSign);

                result.UserName = model.UserName;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(StatusCodes.Status400BadRequest.ToString(ex.Message));
            }
        }
    }
}
