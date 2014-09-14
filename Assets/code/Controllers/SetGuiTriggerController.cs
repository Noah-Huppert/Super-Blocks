using UnityEngine;
using System.Collections;

public class SetGuiTriggerController : MonoBehaviour {

    public void OnTriggerEnter() {
        EventController.controller.fire(MainGameSceneController.EVENT_ON_GUI_TRIGGER_UPDATE);        
    }
}
