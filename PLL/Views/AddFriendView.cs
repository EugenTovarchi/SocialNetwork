using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

public class AddFriendView
{
    UserService userService;
    FriendService friendService;

    public AddFriendView(UserService userService, FriendService friendService)
    {
        this.userService = userService;
        this.friendService = friendService;
    }

    public void Show(User user)
    {
        var addingFriendData = new AddingFriendData();

        Console.WriteLine("Введите почту вашего друга: ");
        addingFriendData.FriendEmail = Console.ReadLine();

        //id пользователя который вошёл в систему
        addingFriendData.UserId = user.Id; 
        
        try
        {
            friendService.AddFriend(addingFriendData);

            SuccessMessage.Show($"Пользователь успешно добавлен в друзья!");
            user = userService.FindById(user.Id);
        }

        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }

        catch (UserAlreadyExistException)
        {
            AlertMessage.Show("Пользователь уже у вас в друзьях!");
        }

        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }

        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при попытке добавить друга!");
        }
    }
}
