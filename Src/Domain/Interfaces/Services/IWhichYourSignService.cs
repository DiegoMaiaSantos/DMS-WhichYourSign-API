using DMS_WhichYourSign_API.Src.Domain.DTOs;
using DMS_WhichYourSign_API.Src.Domain.Models;

namespace DMS_WhichYourSign_API.Src.Domain.Interfaces.Services
{
    public interface IWhichYourSignService
    {
        WhichYourSignResponseDTO ValidationOfReceivedData(WhichYourSignModel model);
    }
}
