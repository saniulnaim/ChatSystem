using Chat.Core.Services;
using Chat.Repository.Core.EntityModel;
using Chat.Repository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Services.Services
{
    public class ChatHistoryService : IChatHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatHistoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ChatHistory> AddAsync(ChatHistory entity)
        {
            var result = await _unitOfWork.IChatHistoryRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<bool> Delete(long id)
        {
            var existingChat = await _unitOfWork.IChatHistoryRepository.FirstOrDefaultAsync(a => a.Id == id);
            _unitOfWork.IChatHistoryRepository.Remove(existingChat);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public Task<ChatHistory> FirstOrDefaultAsync(Expression<Func<ChatHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ChatHistory>> GetAllAsync()
        {
            return await _unitOfWork.IChatHistoryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ChatHistory>> GetAllAsync(Expression<Func<ChatHistory, bool>> predicate)
        {
            return await _unitOfWork.IChatHistoryRepository.GetAllAsync(predicate);
        }

        public async Task<ChatHistory> Remove(ChatHistory entity)
        {
            _unitOfWork.IChatHistoryRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }
    }
}
