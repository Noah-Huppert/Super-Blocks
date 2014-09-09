using UnityEngine;
using System.Collections;

public class SetGuiTriggerController : MonoBehaviour {

    public void OnTriggerEnter() {
        GameController.controller.stage.updateAnswerButtons();
        GuiController.controller.setAnswerButtonsActive(true);
    }
}
