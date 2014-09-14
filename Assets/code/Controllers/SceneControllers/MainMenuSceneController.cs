using UnityEngine;
using System.Collections;

public class MainMenuSceneController : SceneController {
    public override void OnGameStart() {
        base.OnGameStart();
    }

    public override void OnGameUpdate() {
        base.OnGameUpdate();
    }

    public override void OnGameGuiClick(string clickId) {
        base.OnGameGuiClick(clickId);

        if (clickId == GuiController.controller.menuPlayButtonId) {
            Application.LoadLevel("Super Blocks");
        }
    }

    public override void OnGameFail() {
        base.OnGameFail();
    }

    public override void OnGameDisable() {
        base.OnGameDisable();
    }
}
