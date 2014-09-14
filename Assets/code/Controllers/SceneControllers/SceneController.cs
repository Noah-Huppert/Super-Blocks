using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    private CustomEventListener customEventListener { get; set; }

    public void Start() {
        this.customEventListener = new CustomEventListener(OnCustomEvent);

        EventController.controller.fire(EventController.EVENT_SCENE_START);
    }

    public void Destroy() {
        this.customEventListener.Destroy();
    }

    /* Stubs */
    public virtual void OnGameStart() { }
    public virtual void OnSceneStart() { }
    public virtual void OnGameUpdate() { }
    public virtual void OnGameGuiClick(string clickId) { }
    public virtual void OnGameFail() { }
    public virtual void OnGameDisable() { }
    public virtual void OnUnknownEvent(CustomEventBlob eventBlob) { }

    /* Listener */
    public void OnCustomEvent(CustomEventBlob eventBlob) {
        if (eventBlob.name == EventController.EVENT_GAME_START) {
            OnGameStart();
        } else if (eventBlob.name == EventController.EVENT_GAME_UPDATE) {
            OnGameUpdate();
        } else if (eventBlob.name == EventController.EVENT_GAME_ON_GUI_CLICK) {
            OnGameGuiClick((string)eventBlob.data);
        } else if (eventBlob.name == EventController.EVENT_GAME_ON_GAME_FAIL) {
            OnGameFail();
        } else if (eventBlob.name == EventController.EVENT_GAME_ON_DISABLE) {
            OnGameDisable();
        } else if (eventBlob.name == EventController.EVENT_SCENE_START) {
            OnSceneStart();
        } else {
            OnUnknownEvent(eventBlob);
        }
    }
}
