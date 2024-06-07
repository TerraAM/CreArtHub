using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Model
{
    public class ProfileModel
    {
        public UserDto User;
        public List<SubscriptionDto> Subscriptions = new List<SubscriptionDto>();
    }
}
