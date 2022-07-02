namespace clientside.Player {
    public static class PlayerUtils {
        public static int GetCurrentPlayerId() {
            return RAGE.Game.Player.PlayerPedId();
        }
    }
}