using AutoMapper;
using MyCommune.DataModels.Account;
using MyCommune.DataModels.Users;
using MyCommune.Models;
using MyCommune.Repository;
using MyCommune.Utilities;

namespace MyCommune.Services.Account
{

    public interface IAccountService
    {
        ServiceResponse Register(Registration registration);
        Task<ServiceResponse> IsRegistered(string username, string password);
        Task<ServiceResponse> IsRegisteredEmail(string email);

    }
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse> IsRegistered(string username, string password)
        {
            ServiceResponse serviceResponse = new()
            {
                Status = StatusType.Failure
            };
            try
            {
                if (await _unitOfWork.AccountRepository.IsRegistered(username, password))
                {
                    serviceResponse.Status = StatusType.Success;
                }
                else
                {
                    serviceResponse.ErrorMessage = MessageInfo.Account.InValidCredentials;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Error = ex;
                serviceResponse.ErrorMessage = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse> IsRegisteredEmail(string email)
        {
            ServiceResponse serviceResponse = new()
            {
                Status = StatusType.Failure
            };
            try
            {
                if (await _unitOfWork.AccountRepository.IsRegistered(email))
                {
                    serviceResponse.Status = StatusType.Success;
                }
                else
                {
                    serviceResponse.ErrorMessage = MessageInfo.Account.InValidEmail;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Error = ex;
                serviceResponse.ErrorMessage = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse Register(Registration registration)
        {
            ServiceResponse serviceResponse = new()
            {
                Status = StatusType.Failure,
                ErrorMessage = MessageInfo.Account.EmailAlreadyRegistered
            };

            IEnumerable<User> users = _unitOfWork.UserRepository.Find(a => a.Email == registration.Email);
            if (!users.Any())
            {
                User user = _mapper.Map<User>(registration);
                _unitOfWork.AccountRepository.RegisterUser(user);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                serviceResponse.Status = StatusType.Success;
            }
            else
            {
                serviceResponse.ErrorMessage = MessageInfo.Account.EmailAlreadyRegistered;
            };
            return serviceResponse;
        }
    }
}
