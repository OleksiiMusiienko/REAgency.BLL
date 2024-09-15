using AutoMapper;
using REAgency.BLL.Infrastructure;
using REAgency.DAL.Interfaces;
using REAgency.BLL.DTO;
using REAgency.BLL.Interfaces;
using REAgency.DAL.Entities;

namespace REAgency.BLL.Services
{
    public class OrderService: IOrderService
    {
        IUnitOfWork Database { get; set; }
        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(await Database.Orders.GetAll());

        }
        public async Task Create(OrderDTO clientOrder)
        {
            var order = new Order
            {
                Id = clientOrder.Id,
                orderClient = clientOrder.orderClient,
                objectsForOrders = clientOrder.objectsForOrders,
                idClient = clientOrder.idClient,
                Name = clientOrder.Name,
                Phone = clientOrder.Phone
            };
            await Database.Orders.Create(order);
            await Database.Save();
        }
        public async Task Update(OrderDTO clientOrder)
        {
            var order = new Order
            {
                Id = clientOrder.Id,
                orderClient = clientOrder.orderClient,
                objectsForOrders = clientOrder.objectsForOrders,
                idClient = clientOrder.idClient,
                Name = clientOrder.Name,
                Phone = clientOrder.Phone
            };
            await Database.Orders.Update(order);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.Orders.Delete(id);
            await Database.Save();
        }
        public async Task<OrderDTO> Get(int id)
        {
            var order = await Database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Wrong order!", "");
            return new OrderDTO
            {
                Id = order.Id,
                orderClient = order.orderClient,
                objectsForOrders = order.objectsForOrders,
                idClient = order.idClient,
                Name = order.Name,
                Phone = order.Phone
            };
        }
    }
}
