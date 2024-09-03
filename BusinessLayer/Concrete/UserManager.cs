using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserManager:IUserService
    {
        IUserRepository _UserRepository;
        public UserManager(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public User GetById(int id)
        {
            return _UserRepository.Get(x=>x.UserId==id);
        }

        public void UserAdd(User user)
        {
            string hashpasword = UserHashing.Hashing(user.Password);
            user.Password = hashpasword;
            _UserRepository.Add(user);
        }

        public User UserRegister(string Gmail, string Password)
        {
            string hashpaswword= UserHashing.Hashing(Password);
            return _UserRepository.Get(x => x.Gmail == Gmail && x.Password == hashpaswword); 
        }

        public void UserUpdate(User user)
        {
            _UserRepository.Update(user);
        }


    }
}
