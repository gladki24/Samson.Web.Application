using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.User;
using Samson.Web.Application.Api.ViewModels.User;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.Dtos.User;
using Samson.Web.Application.Queries.User;

namespace Samson.Web.Application.Api.MapperProfiles
{
    /// <summary>
    /// Mapping profile to map User controller related objects.
    /// </summary>
    public class UserControllerMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public UserControllerMapperProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<UpdateUserRequest, CreateUserCommand>();
            CreateMap<DeleteUserRequest, DeleteUserCommand>();
            CreateMap<LoginUserRequest, LoginUserCommand>();

            CreateMap<CreateUserCommand, CreateUserDataStructure>();
            CreateMap<UpdateUserCommand, UpdateUserDataStructure>();
            CreateMap<DeleteUserCommand, DeleteUserDataStructure>();
            CreateMap<LoginUserCommand, AuthenticateUserDataStructure>();

            CreateMap<UserDto, UserViewModel>();

            CreateMap<string, GetUserByIdQuery>().ConstructUsing((id, context) =>
                new GetUserByIdQuery(context.Mapper.Map<string, ObjectId>(id)));
        }
    }
}
