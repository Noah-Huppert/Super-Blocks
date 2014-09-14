using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    private CustomEventListener customEventListener { get; set; }

    public void Start() {
        this.customEventListener = new CustomEventListener(OnCustomEvent);
    }

    public void Destroy() {
        this.customEventListener.Destroy();
    }

    /* Stubs */
    public virtual void OnGameStart() { }
    public virtual void OnGameUpdate() { }
    public virtual void OnGameGuiClick(string clickId) { }
    public virtual void OnGameFail() { }
    public virtual void OnGameDisable() { }

    /* Listener */
    public void OnCustomEvent(CustomEventBlob eventBlob) {
        if (eventBlob.name == EventController.EVENT_GAME_START) {
            OnGameStart();
        }

        if (eventBlob.name == EventController.EVENT_GAME_UPDATE) {
            OnGameUpdate();
        }

        if (eventBlob.name == EventController.EVENT_GAME_ON_GUI_CLICK) {
            OnGameGuiClick((string)eventBlob.data);
        }

        if (eventBlob.name == EventController.EVENT_GAME_ON_GAME_FAIL) {
            OnGameFail();
        }

        if (eventBlob.name == EventController.EVENT_GAME_ON_DISABLE) {
            OnGameDisable();
        }
    }
}
