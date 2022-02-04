using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanicilar Listelendi.");
        }

        IResult IUserService.Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult("Kullanici Eklendi.");
        }

        public IResult Update(User entity)
        {
            var user = _userDal.Get(u => u.Id == entity.Id);
            user.Email = entity.Email;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            _userDal.Update(user);
            return new SuccessResult("Kullanici Güncellendi.");
        }

        public IResult Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserDetailDto>> GetUserByEmail(string email)
        {
            var result = _userDal.GetUserByEmail(email);
            return new SuccessDataResult<List<UserDetailDto>>(result);
        }
    }
}
