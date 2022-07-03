using RAGE;

namespace clientside.Camera {
    public class CameraManager {
        public CameraManager() {
            int cameraTo = RAGE.Game.Cam.CreateCamWithParams("DEFAULT_SCRIPTED_CAMERA", 2350f, 2350f, 2350f + 2350f, 25f, 25f, 25f, 2, false, 0);
            RAGE.Game.Cam.SetCamActive(cameraTo, true);
            RAGE.Game.Cam.SetCamFov(cameraTo, 5.0f);
            RAGE.Game.Cam.PointCamAtCoord(cameraTo, 2350f, 2350f, 2350f);
            RAGE.Game.Cam.RenderScriptCams(true, false, 0, true, false, 0);
        }
    }
}