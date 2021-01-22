using Chat.Core.Services;
using Chat.Repository.Core.EntityModel;
using Chat.Repository.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task<User> AddAsync(User entity)
        {
            var existEmail = await _unitOfWork.IUserRepository.FirstOrDefaultAsync(a => a.Email == entity.Email);
            if (existEmail != null)
                throw new ArgumentException("This email already exist!");

            var result = await _unitOfWork.IUserRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            return await _unitOfWork.IUserRepository.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.IUserRepository.GetAllAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> predicate)
        {
            return await _unitOfWork.IUserRepository.GetAllAsync(predicate);
        }

        public async Task<User> Remove(User entity)
        {
            _unitOfWork.IUserRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<User> UpdateLoginStatus(string email)
        {
            var existEmail = await _unitOfWork.IUserRepository.FirstOrDefaultAsync(a => a.Email == email);
            if (existEmail == null)
                throw new ArgumentException("This email not exist!");

            existEmail.LoginStatus = true;
            _unitOfWork.IUserRepository.Update(existEmail);
            await _unitOfWork.CommitAsync();
            return existEmail;
        }

        public async Task<User> UpdateLogoutStatus(string email)
        {
            var existEmail = await _unitOfWork.IUserRepository.FirstOrDefaultAsync(a => a.Email == email);
            if (existEmail == null)
                throw new ArgumentException("This email not exist!");

            existEmail.LoginStatus = false;
            _unitOfWork.IUserRepository.Update(existEmail);
            await _unitOfWork.CommitAsync();
            return existEmail;
        }
    }
}
