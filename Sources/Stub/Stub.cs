﻿using Model;

namespace Stub
{
    public class Stub : IPersistance
    {
        public List<Game> LoadGame()
        {
            return null;
        }

        public List<User> LoadUser()
        {
            return null;
        }

        public void SaveGame(List<Game> games)
        {

        }

        public void SaveUser(List<User> users)
        {

        }
    }
}