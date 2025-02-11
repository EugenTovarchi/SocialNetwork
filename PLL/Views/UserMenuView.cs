﻿using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

public class UserMenuView
{
    UserService userService;
    public UserMenuView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show(User user)
    {
        while (true)
        {
            Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
            Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
            Console.WriteLine("Мои друзья: {0}", user.UserFriends.Count());

            Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
            Console.WriteLine("Редактировать мой профиль (нажмите 2)");
            Console.WriteLine("Добавить в друзья (нажмите 3)");
            Console.WriteLine("Просмотреть список ваших друзей (нажмите 4)");
            Console.WriteLine("Написать сообщение (нажмите 5)");
            Console.WriteLine("Просмотреть входящие сообщения (нажмите 6)");
            Console.WriteLine("Просмотреть исходящие сообщения (нажмите 7)");
            Console.WriteLine("Выйти из профиля (нажмите 8)");

            string keyValue = Console.ReadLine();

            if (keyValue == "8") break;

            switch (keyValue)
            {
                case "1":
                    {
                        Program.userInfoView.Show(user);
                        break;
                    }
                case "2":
                    {
                        Program.userDataUpdateView.Show(user);
                        break;
                    }
                case "3":
                    {
                        Program.addFriendView.Show(user);
                        user = userService.FindById(user.Id);
                        break;
                    }
                case "4":
                    {
                        Program.userFriendsView.Show(user.UserFriends);
                        break;
                    }

                case "5":
                    {
                        Program.messageSendingView.Show(user);
                        break;
                    }

                case "6":
                    {

                        Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    }

                case "7":
                    {
                        Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                        break;
                    }
            }
        }
    }
}
