namespace clientside.Player {
    public static class PlayerUtils {
        public static int GetCurrentPlayerPedId() {
            return RAGE.Game.Player.PlayerPedId();
        }
    }
}