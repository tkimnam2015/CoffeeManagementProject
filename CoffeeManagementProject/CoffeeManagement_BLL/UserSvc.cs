using CoffeeManagement.Common.BLL;
using CoffeeManagement.Common.Req;
using CoffeeManagement.Common.Rsp;
using CoffeeManagement.DAL;
using CoffeeManagement.DAL.Models;
using System;
using System.Linq;

namespace CoffeeManagement.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;

        public UserSvc()
        {
            userRep = new UserRep();
        }

        public SingleRsp CreateUser(UserReq user)
        {
            var res = new SingleRsp();
            User u = new User();
            u.UserName = user.UserName;
            u.Password = user.Password;
            u.Role = user.Role;
            res = userRep.CreateUser(u);
            return res;
        }

        public SingleRsp UpdateUser(UpdateUserReq updateUser)
        {
            var res = new SingleRsp();
            var u = _repository.Read(updateUser.UserId); //lấy thông tin của đối tượng cần update, xong chỉ thay đổi những thuộc tính mình cần đổi
            u.FirstName = updateUser.FirstName;
            u.LastName = updateUser.LastName;
            u.Phone = updateUser.Phone;
            u.Email = updateUser.Email;
            u.Address = updateUser.Address;
            res = userRep.UpdateUser(u);
            return res;
        }

        
    }
}
