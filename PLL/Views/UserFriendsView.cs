using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

public class UserFriendsView
{
    public void Show(IEnumerable<Friend> userFriends)
    {
        Console.WriteLine("Ваши друзья");

        if (userFriends.Count() == 0)
        {
            NeutralMessage.Show("У вас еще нет друзей. Не печальтесь!");
            return;
        }

        userFriends.ToList().ForEach(friend =>
        {
            Console.WriteLine($"Ваши друзья: {friend.FriendFirstName} {friend.FriendLastName}");
        });
    }
}
