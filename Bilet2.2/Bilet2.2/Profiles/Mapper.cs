using AutoMapper;
using Bilet2._2.Models;
using Bilet2._2.ViewModels.TeamMemberViewModels;

namespace Bilet2._2.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<TeamMember, TeamGetVM>();
            CreateMap<TeamPostVM, TeamMember>();
        }
    }
}
