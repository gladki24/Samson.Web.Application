using AutoMapper;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.User;
using Samson.Web.Application.Api.ViewModels.User;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Commands.User.Client;
using Samson.Web.Application.Commands.User.PersonalTrainer;
using Samson.Web.Application.Models.DataStructures.User;
using Samson.Web.Application.Models.DataStructures.User.Client;
using Samson.Web.Application.Models.DataStructures.User.PersonalTrainer;
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
            CreateMap<DeleteUserRequest, DeleteClientCommand>();
            CreateMap<DeleteUserRequest, DeletePersonalTrainerCommand>();

            CreateMap<DeleteClientCommand, DeleteUserDataStructure>();
            CreateMap<DeletePersonalTrainerCommand, DeleteUserDataStructure>();

            CreateMap<CreatePersonalTrainerCommand, CreateUserDataStructure>();
            CreateMap<UpdatePersonalTrainerCommand, UpdateUserDataStructure>();

            CreateMap<LoginUserRequest, LoginUserCommand>();
            CreateMap<LoginUserCommand, AuthenticateUserDataStructure>();

            CreateMap<UserDto, UserViewModel>();
            CreateMap<ClientDto, ClientViewModel>();
            CreateMap<PersonalTrainerDto, PersonalTrainerViewModel>();

            CreateMap<UpdatePersonalTrainerRequest, UpdatePersonalTrainerCommand>();
            CreateMap<UpdatePersonalTrainerCommand, UpdatePersonalTrainerDataStructure>();

            CreateMap<UpdateClientRequest, UpdateClientCommand>();
            CreateMap<UpdateClientCommand, UpdateClientDataStructure>();

            CreateMap<CreatePersonalTrainerRequest, CreatePersonalTrainerCommand>();
            CreateMap<CreatePersonalTrainerCommand, CreatePersonalTrainerDataStructure>();

            CreateMap<RegisterClientRequest, RegisterClientCommand>();
            CreateMap<RegisterClientCommand, RegisterClientDataStructure>();

            CreateMap<string, GetPersonalTrainerByIdQuery>().ConstructUsing((id, context) =>
                new GetPersonalTrainerByIdQuery(context.Mapper.Map<string, ObjectId>(id)));
            CreateMap<string, GetClientByIdQuery>().ConstructUsing((id, context)
                => new GetClientByIdQuery(context.Mapper.Map<string, ObjectId>(id)));
        }
    }
}
