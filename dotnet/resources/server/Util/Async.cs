using System;
using GTANetworkAPI;

namespace server.Util {
    public static class AsyncUtil {
        public static void RunAsyncTask(Action act, long delay = 0) {
            NAPI.Task.Run(act, delay);
        }
    }
}