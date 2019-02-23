using Core.Models.Entities;
using Core.Repositories.Abstract;
using Core.Services.Abstract;


namespace Core.Services
{
    public class MessageService : EntityBaseService<Message>, IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
