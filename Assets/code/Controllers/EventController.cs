using UnityEngine;
using System;
using System.Collections;

public class EventController : MonoBehaviour {
    public static EventController controller { get; set; }

    public delegate void CustomEventHandler(CustomEventBlob eventBlob);
    public event CustomEventHandler CustomEvent;

    public static string EVENT_GAME_START = "EVENT_GAME_START";
    public static string EVENT_GAME_UPDATE = "EVENT_GAME_UPDATE";
    public static string EVENT_GAME_ON_GUI_CLICK = "EVENT_GAME_ON_GUI_CLICK";
    public static string EVENT_GAME_ON_GAME_FAIL = "EVENT_GAME_ON_GAME_FAIL";
    public static string EVENT_GAME_ON_DISABLE = "EVENT_GAME_ON_DISABLE";

    public void Awake() {
        this.doSingleton();
        this.initProperties();
    }

    //Actions
    private void doSingleton() {
        //Makes this a singleton
        if (controller != null && controller != this) {//Make sure current singleton is this one
            Destroy(gameObject);
        }

        controller = this;
        DontDestroyOnLoad(gameObject);
    }

    private void initProperties() {

    }

    //Actions
    private void onFire(string name, object data) {
        if (CustomEvent != null) {
            CustomEvent(new CustomEventBlob(name, data));
        }
    }
    public void fire(string name, object data) {
        onFire(name, data);
    }

    public void fire(string name) {
        onFire(name, null);
    }
}
