using AutoMapper;
using Bargheto.Application.Common.JWT;
using Bargheto.Application.Common.UnitOfWorkPattern;
using Bargheto.Application.Common.Utilities;
using Bargheto.Application.Common.Validation;
using Bargheto.Application.DataTransferObjects;
using Bargheto.Application.DataTransferObjects.UserManagement;
using Bargheto.Application.Services.Interfaces;
using Bargheto.Domain.Entities.UserManagement;
using Bargheto.Domain.ValurObjects;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Services.Implementations
{
    public class UserManagementServices : IUserManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        private readonly IValidator<UserInputDto> _userValidator;

        public UserManagementServices(IUnitOfWork unitOfWork, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator, IValidator<UserInputDto> userValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userValidator = userValidator;
        }

        #region Users
        public async Task<ResultStatusDto> CreateUser(UserInputDto userInputDto, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _userValidator.ValidateAsync(userInputDto,cancellationToken);
            if (!validationResult.IsValid)
            {
                List<string> messageList = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return new() { Status = Common.Enums.ResultStatusEnum.InvalidInput, Message = string.Join("\r\n", messageList) };
            }

            User user = await _unitOfWork.UserReopsitory.GetByEmailAsync(userInputDto.Email, cancellationToken);
            if (user != null)
            {
                return new() { Status = Common.Enums.ResultStatusEnum.Exists, Message = "The Email is already exist!" };
            }

            Guid userId = Guid.NewGuid();

            UserRole role = new()
            {
                RoleId = userInputDto.RoleId,
                UserId = userId,
            };

            user = new()
            {
                Id = userId,
                FullName = userInputDto.FullName,
                Email = Email.Create(userInputDto.Email),
                HashedPassword = HashedPassword.CheckHashed(PasswordHasher.HashPassword(userInputDto.Password)),
                UserRoles = new[] { role },
            };

            await _unitOfWork.UserReopsitory.AddAsync(user, cancellationToken);
            await _unitOfWork.CompleteTaskAsync(cancellationToken);

            return new() { Status = Common.Enums.ResultStatusEnum.Success, Message = "Successfully Added" };
        }

        public Task<ResultStatusDto> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserOutputDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        

        public Task<UserOutputDto> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResultStatusDto> UpdateUser(Guid id, UserInputDto userInputDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenRespons> LoginUser(LoginDto loginDto, CancellationToken cancellationToken)
        {
            string email = Email.Create(loginDto.Email).Value;

            User user = await _unitOfWork.UserReopsitory.GetByEmailAsync(email, cancellationToken);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Credentials");
            }

            bool isPasswordValid = PasswordHasher.VerifyPassword(loginDto.Password, user.HashedPassword.Value);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Invalid Credentials");
            }

            List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

            string token = _jwtTokenGenerator.GenerateToken(user, roles, out DateTime expireTime);

            return new() { AccessToken = token, ExpirationDate = expireTime };
        }


        #endregion

        #region Roles

        

        public async Task<List<RoleOutputDto>> GetRoles(CancellationToken cancellationToken)
        {
            List<Role> roles = await _unitOfWork.RoleRepository.GetAllAsync(false, cancellationToken);
            return _mapper.Map<List<RoleOutputDto>>(roles);
        }

        #endregion
    }
}
