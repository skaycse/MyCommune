using MyCommune.DataModels.Users;
using MyCommune.Models;
using MyCommune.Repository;
using MyCommune.Utilities;

namespace MyCommune.Services.Users
{

    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetUser(Guid id);
        ServiceResponse UpdateUser(User usr);
    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _unitOfWork.UserRepository.GetAllUsers();
            _unitOfWork.Dispose();
            return users;
        }

        public User GetUser(Guid id)
        {
            var user = _unitOfWork.UserRepository.Find(a => a.Id == id).FirstOrDefault();
            _unitOfWork.Dispose();
            return user;
        }

        public ServiceResponse UpdateUser(User usr)
        {
            ServiceResponse sres = new()
            {
                Status = StatusType.Failure
            };
            try
            {
                User listEmail = _unitOfWork.UserRepository.Find(m => m.Email.Equals(usr.Email) || m.Mobile.Equals(usr.Mobile)).FirstOrDefault();

                if (listEmail is not null && listEmail.Id != usr.Id)
                {
                    if (listEmail.Email == usr.Email)
                    {
                        sres.ErrorMessage = MessageInfo.User.EmailAlreadyAssociated;
                        return sres;
                    }
                    else
                    {
                        sres.ErrorMessage = MessageInfo.User.MobileAlreadyAssociated;
                        return sres;
                    }
                }
                else
                {
                    User updateUser = listEmail;
                    updateUser.UserDetails = usr.UserDetails;
                    updateUser.Mobile = usr.Mobile;
                    updateUser.ModifiedDate = DateTime.Now;
                    updateUser.Email = usr.Email;
                    _unitOfWork.UserRepository.Update(updateUser);
                    _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    sres.Status = StatusType.Success;
                }

            }
            catch (Exception ex)
            {
                sres.Error = ex;
                sres.ErrorMessage = ex.Message;
            }
            return sres;
        }
    }
}
