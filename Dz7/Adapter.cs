using System;

namespace Dz7
{
    public interface IInfoPrinter
    {
        string Name { get;}
        int Age { get;}
        int FriendsCount { get;}

    }
    public static class Adapter: IInfoPrinter
    {
        public string Name => throw new NotImplementedException();

        public int Age => throw new NotImplementedException();

        public int FriendsCount => throw new NotImplementedException();

        public static InfoPrinter GetInfoPrinter(IVk vk) => new InfoPrinter(vk.ReturnName(), vk.ReturnAge(), vk.ReturnFriendsCount());
        public static InfoPrinter GetInfoPrinter(IFacebook facebook) => new InfoPrinter(facebook.Name, facebook.Age, facebook.FriendsCount);
        public static InfoPrinter GetInfoPrinter(ITwitter twitter) => new InfoPrinter(twitter.GetName(), twitter.GetAge(), twitter.GetFriendsCount());

    }

    public interface ITwitter
    {
        string GetName();
        int GetAge();
        int GetFriendsCount();
    }
    public class Twitter : ITwitter
    {
        public Twitter(string name, int age, int friendsCount)
        {
            Name = name;
            Age = age;
            FriendsCount = friendsCount;
        }

        string Name { get; }
        int Age { get; }
        int FriendsCount { get; }

        public string GetName() => Name;
        public int GetAge() => Age;
        public int GetFriendsCount() => FriendsCount;
    }
    public interface IVk
    {
        string ReturnName();
        int ReturnAge();
        int ReturnFriendsCount();
    }
    public class Vk : IVk
    {
        public Vk(string name, int age, int friendsCount)
        {
            Name = name;
            Age = age;
            FriendsCount = friendsCount;
        }

        string Name { get; }
        int Age { get; }
        int FriendsCount { get; }

        public string ReturnName() => Name;
        public int ReturnAge() => Age;
        public int ReturnFriendsCount() => FriendsCount;
    }
    public interface IFacebook
    {
        string Name { get; set; }
        int Age { get; set; }
        int FriendsCount { get; set; }
    }
    public class Facebook : IFacebook
    {
        public Facebook(string name, int age, int friendsCount)
        {
            Name = name;
            Age = age;
            FriendsCount = friendsCount;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int FriendsCount { get; set; }
    }
}
