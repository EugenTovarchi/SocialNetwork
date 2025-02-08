using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services;

public class FriendService
{
    IUserRepository userRepository;
    IFriendRepository friendRepository;

    public FriendService()
    {
        userRepository = new UserRepository();
        friendRepository = new FriendRepository();
    }
    /// <summary>
    /// Возвращает список всех друзей пользователя по id пользователя
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public IEnumerable<Friend> GetUserFriendsByUserId(int userId)
    {
        var userFriends = new List<Friend>();

        friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
        {
            var friendUserEntity = userRepository.FindById(f.friend_id);

            userFriends.Add(new Friend(f.id, friendUserEntity.email, friendUserEntity.firstname, friendUserEntity.lastname));
        });

        return userFriends;
    }

    public void AddFriend(AddingFriendData addingFriendData) 
    {
        var findUserEntity = this.userRepository.FindByEmail(addingFriendData.FriendEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var currentUserEntity = this.userRepository.FindById(addingFriendData.UserId);
        if (currentUserEntity.email == addingFriendData.FriendEmail)                   
        {
            throw new Exception("Нельзя добавить самого себя в друзья!"); 
        }

        var friendEntity = new FriendEntity()
        {
            user_id = addingFriendData.UserId,
            friend_id = findUserEntity.id,
        };

        if (this.friendRepository.Create(friendEntity) == 0)
            throw new Exception();
    }
}
