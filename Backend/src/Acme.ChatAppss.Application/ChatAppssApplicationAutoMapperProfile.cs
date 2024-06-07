using Acme.ChatApp.Groups;
using Acme.ChatApp.Messages;
using AutoMapper;

namespace Acme.ChatAppss;

public class ChatAppssApplicationAutoMapperProfile : Profile
{
    public ChatAppssApplicationAutoMapperProfile()
    {
        CreateMap<Message, MessageDto>();
        CreateMap<CreateUpdateDto, Message>();

        CreateMap<Group, GroupDto>();
        CreateMap<CreateUpdateGroupDto, Group>();

        CreateMap<GroupUser, GroupUserDto>();
        CreateMap<CreateUpdateGroupUser, GroupUser>();
    }
}
