using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
        User GetByMail(string email);
        IDataResult<List<UserDetailDto>> GetUserByEmail(string email);
    }
}
