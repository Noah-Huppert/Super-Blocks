using UnityEngine;
using System.Collections;

public class MainGameSceneController : SceneController {
    public override void OnGameStart() {
        base.OnGameStart();
    }

    public override void OnGameUpdate() {
        base.OnGameUpdate();

        GameController.controller.stage.update();
    }

    public override void OnGameGuiClick(string clickId) {
        base.OnGameGuiClick(clickId);

        GameController.controller.stage.checkAnswer(clickId);
    }

    public override void OnGameFail() {
        base.OnGameFail();
    }

    public override void OnGameDisable() {
        base.OnGameDisable();
    }
}
