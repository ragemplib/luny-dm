namespace clientside.UI {
    public static class UiUtils {
        public static void ChangeRadarVisibility(bool state) {
            RAGE.Game.Ui.DisplayRadar(state);
        }

        public static void ChangeChatVisibility(bool state) {
            RAGE.Chat.Show(state);
        }
    }
}