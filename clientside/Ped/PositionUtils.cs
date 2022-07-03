namespace clientside.Ped {
    public static class PositionUtils {
        public static void ChangePositionMutabilityState(int pedId, bool state) {
            RAGE.Chat.Output($"HI THERE: {pedId}");
            RAGE.Game.Entity.FreezeEntityPosition(pedId, state);
        }
    }
}