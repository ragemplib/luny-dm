using System;
using RAGE;
using RAGE.Game;

namespace client
{
    public class Class1 : Events.Script
    {
        private Class1()  {
            Events.Add("Time", TimeHandler);
        }

        private void TimeHandler(object[] args) {
            RAGE.Chat.Output("Time");
        }
    }
}
