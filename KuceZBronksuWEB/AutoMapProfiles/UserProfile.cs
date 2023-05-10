using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuWEB.AutoMapProfiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserViewModel>()
				.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
				.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName))
				.ForMember(dest => dest.EmailConfirmed, opts => opts.MapFrom(src => src.EmailConfirmed));
		}
	}
}