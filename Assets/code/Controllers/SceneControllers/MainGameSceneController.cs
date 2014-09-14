using UnityEngine;
using System.Collections;

public class MainGameSceneController : SceneController {
    private StageController stage { get; set; }

    public static string EVENT_ON_GUI_UPDATE_TRIGGER_UPDATE = "EVENT_ON_GUI_UPDATE_TRIGGER_UPDATE";
    public static string EVENT_ON_GUI_UPDATE_TRIGGER_EMPTY = "EVENT_ON_GUI_UPDATE_TRIGGER_EMPTY";

    /* Lifetime Events */
    public override void OnGameStart() {
        base.OnGameStart();
    }

    public override void OnSceneStart() {
        base.OnSceneStart();

        this.stage = new StageController("leftColumn", "centerColumn", "rightColumn");

        GuiController.controller.setAnswerButtonsActive(false);
    }

    public override void OnGameUpdate() {
        base.OnGameUpdate();

        this.stage.update();
    }

    public override void OnGameGuiClick(string clickId) {
        base.OnGameGuiClick(clickId);

        this.stage.checkAnswer(clickId);
    }

    public override void OnGameFail() {
        base.OnGameFail();

        Application.LoadLevel("Game Over");
    }

    public override void OnGameDisable() {
        base.OnGameDisable();
    }

    /* Custom Events */
    public override void OnUnknownEvent(CustomEventBlob eventBlob) {
        base.OnUnknownEvent(eventBlob);

        if (eventBlob.name == MainGameSceneController.EVENT_ON_GUI_UPDATE_TRIGGER_UPDATE) {
            OnGuiUpdateTriggerUpdate();
        }

        if (eventBlob.name == MainGameSceneController.EVENT_ON_GUI_UPDATE_TRIGGER_EMPTY) {
            OnGuiUpdateTriggerEmpty();
        }
    }

    public void OnGuiUpdateTriggerUpdate() {
        this.stage.updateAnswerButtons();
        GuiController.controller.setAnswerButtonsActive(true);
    }

    public void OnGuiUpdateTriggerEmpty() {
        GuiController.controller.setAnswerButtonsActive(false);
    }
}
