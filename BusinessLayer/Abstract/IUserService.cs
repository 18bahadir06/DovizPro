using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        void UserAdd(User user);
        void UserUpdate(User user);
        User UserRegister(string Gmail, string Password);
        User GetById(int id);
    }
}
