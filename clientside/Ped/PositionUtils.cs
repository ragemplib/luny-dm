namespace clientside.Ped {
    public static class PositionUtils {
        public static void FreezePedPosition(int pedId) {
            RAGE.Chat.Output($"HI THERE: {pedId}");
            RAGE.Game.Entity.FreezeEntityPosition(pedId, true);
        }
    }
}