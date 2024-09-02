using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services.Objects
{
    public class EstateObjectService : IEstateObjectService
    {
        IUnitOfWork Database { get; set; }

        public EstateObjectService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<EstateObjectDTO>> GetAllFlats()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EstateObject, EstateObjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<EstateObject>, IEnumerable<EstateObjectDTO>>(await Database.EstateObject.GetAll());
        }
        public async Task<EstateObjectDTO> GetEstateObjectById(int id)
        {
            var estateObject = await Database.EstateObject.Get(id);
            if (estateObject == null)
                throw new ValidationException("Wrong flat!");
            return new EstateObjectDTO
            {
                Id = estateObject.Id,
                countViews = estateObject.countViews,
                clientName = estateObject.Client.Name,
                clientPhone = estateObject.Client.Phone1,
                employeeId = estateObject.employeeId,
                employeeName = estateObject.Employee.Name,
                employeePhone = estateObject.Employee.Phone1,
                operationId = estateObject.operationId,
                operationName = estateObject.Operation.Name,
                locationId = estateObject.locationId,
                Street = estateObject.Street,
                numberStreet = estateObject.numberStreet,
                Price = estateObject.Price,
                currencyId = estateObject.currencyId,
                currencyName = estateObject.Currency.Name,
                Area = estateObject.Area,
                unitAreaId = estateObject.unitAreaId,
                areaName = estateObject.unitArea.Name,
                Description = estateObject.Description,
                Status = estateObject.Status,
                Date = estateObject.Date,
                pathPhoto = estateObject.pathPhoto

            };
        }


        public async Task CreateEstateObject(EstateObjectDTO estateObjectDTO)
        {
            var estateObject = new EstateObject
            {
                Id = estateObjectDTO.Id,
                countViews = estateObjectDTO.countViews,
                employeeId = estateObjectDTO.employeeId,
                operationId = estateObjectDTO.operationId,
                locationId = estateObjectDTO.locationId,
                Street = estateObjectDTO.Street,
                Price = estateObjectDTO.Price,
                currencyId = estateObjectDTO.currencyId,
                Area = estateObjectDTO.Area,
                unitAreaId = estateObjectDTO.unitAreaId,
                Description = estateObjectDTO.Description,
                Status = estateObjectDTO.Status,
                Date = estateObjectDTO.Date,
                pathPhoto = estateObjectDTO.pathPhoto
            };
            await Database.EstateObject.Create(estateObject);
            await Database.Save();
        }

        public async Task UpdateEstateObject(EstateObjectDTO estateObjectDTO)
        {
            var estateObject = new EstateObject
            {
                Id = estateObjectDTO.Id,
                countViews = estateObjectDTO.countViews,
                employeeId = estateObjectDTO.employeeId,
                operationId = estateObjectDTO.operationId,
                locationId = estateObjectDTO.locationId,
                Street = estateObjectDTO.Street,
                Price = estateObjectDTO.Price,
                currencyId = estateObjectDTO.currencyId,
                Area = estateObjectDTO.Area,
                unitAreaId = estateObjectDTO.unitAreaId,
                Description = estateObjectDTO.Description,
                Status = estateObjectDTO.Status,
                Date = estateObjectDTO.Date,
                pathPhoto = estateObjectDTO.pathPhoto
            };
            Database.EstateObject.Update(estateObject);
            await Database.Save();
        }

        public async Task DeleteEstateObjet(int id)
        {
            await Database.EstateObject.Delete(id);
            await Database.Save();
        }

    }
}
