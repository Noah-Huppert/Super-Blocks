using UnityEngine;
using System.Collections;

public class SceneControllerTemplate : SceneController {

    public override void OnGameStart() {
        base.OnGameStart();
    }

    public override void OnSceneStart() {
        base.OnSceneStart();
    }

    public override void OnGameUpdate() {
        base.OnGameUpdate();
    }

    public override void OnGameGuiClick(string clickId) {
        base.OnGameGuiClick(clickId);
    }

    public override void OnGameFail() {
        base.OnGameFail();
    }

    public override void OnGameDisable() {
        base.OnGameDisable();
    }
}
