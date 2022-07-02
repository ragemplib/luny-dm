using System;
using System.Collections.Generic;
using GTANetworkAPI;
using server.Util;

namespace server.Server {
    public class ServerEvent : Script {
        // [ServerEvent(Event.IncomingConnection)]
        // /// Event Params: <see cref="T:System.String" /> ip, <see cref="T:System.String" /> serial, <see cref="T:System.String" /> rgscName, <see cref="T:System.UInt64" /> rgscId, <see cref="T:GTANetworkAPI.CancelEventArgs" /> cancel
        // public void OnIncomingConnection(System.String ip, System.String serial, System.String rgscName, System.UInt64 rgscId, GTANetworkAPI.CancelEventArgs cancel) {
        //     AsyncUtil.RunAsyncTask(
        //         async () =>
        //             await HttpUtil.PostRequest(
        //                 Environment.GetEnvironmentVariable("DISCORD_URL"),
        //                 new Dictionary<string, string>() {
        //                     {"content",
        //                         $"Incoming connection - ipPtr: {ip}, serialPtr: {serial}, rgscPtr: {rgscName}, rgscId: {rgscId}"
        //                     }
        //                 })
        //     );
        // }
    }
}