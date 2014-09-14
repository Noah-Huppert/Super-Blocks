using UnityEngine;
using System.Collections;

public class SetGuiTriggerController : MonoBehaviour {
    private int inTrigger = 0;

    public void OnTriggerEnter() {
        inTrigger++;
        EventController.controller.fire(MainGameSceneController.EVENT_ON_GUI_UPDATE_TRIGGER_UPDATE);        
    }

    public void OnTriggerExit() {
        inTrigger--;
    }

    public void Update() {
        if (inTrigger == 0) {
            EventController.controller.fire(MainGameSceneController.EVENT_ON_GUI_UPDATE_TRIGGER_EMPTY);  
        }
    }
}
