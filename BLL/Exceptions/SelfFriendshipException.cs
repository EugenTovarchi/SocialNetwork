using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions;

public class SelfFriendshipException : Exception
{
    public SelfFriendshipException() : base("Нельзя добавить самого себя в друзья!") { }
}
