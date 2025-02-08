using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models;

public class Friend
{
    public int Id { get; }
    public string FriendEmail { get;  }
    public string FriendFirstName { get; }
    public string FriendLastName { get; }

    public Friend (int id, string friendEmail, string friendFirstName, string friendLastName)
    {
        Id = id;
        FriendEmail = friendEmail;
        FriendFirstName = friendFirstName;
        FriendLastName = friendLastName;
    }
}
