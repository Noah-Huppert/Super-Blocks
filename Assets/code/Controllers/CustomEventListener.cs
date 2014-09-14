using UnityEngine;
using System;
using System.Collections;

public class CustomEventListener {
    private Action<CustomEventBlob> onEventFunction;

    public CustomEventListener(Action<CustomEventBlob> onEventFunction) {
        this.onEventFunction = onEventFunction;

        EventController.controller.CustomEvent += new EventController.CustomEventHandler(onEventFunction);
    }

    public void Destroy() {
        EventController.controller.CustomEvent -= new EventController.CustomEventHandler(this.onEventFunction);
    }
}
