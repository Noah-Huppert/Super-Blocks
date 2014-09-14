using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverSceneController : SceneController {

    public override void OnGameStart() {
        base.OnGameStart();
    }

    public override void OnSceneStart() {
        base.OnSceneStart();

        GameObject gameScore = GameObject.Find("Game Over Score");
        gameScore.GetComponent<Text>().text = PlayerPrefs.GetInt("LatestScore").ToString() + " Points";
    }

    public override void OnGameUpdate() {
        base.OnGameUpdate();
    }

    public override void OnGameGuiClick(string clickId) {
        base.OnGameGuiClick(clickId);

        if (clickId == GuiController.controller.gameOverNavToMenuButtonId) {
            Application.LoadLevel("Menu Scene");
        }

        if (clickId == GuiController.controller.gameOverReplayButtonId) {
            GameController.controller.prepareForNewGame();
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
