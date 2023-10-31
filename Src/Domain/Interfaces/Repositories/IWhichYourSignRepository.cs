using DMS_WhichYourSign_API.Src.Domain.DTOs;
using DMS_WhichYourSign_API.Src.Infra.Data.Entities;

namespace DMS_WhichYourSign_API.Src.Domain.Interfaces.Repositories
{
    public interface IWhichYourSignRepository
    {
        WhichYourSign SearchData(DateTime data);
    }
}
