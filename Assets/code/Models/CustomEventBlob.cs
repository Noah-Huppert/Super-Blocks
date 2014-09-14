using UnityEngine;
using System.Collections;

public class CustomEventBlob {
    public string name { get; set; }
    public object data { get; set; }

    public CustomEventBlob(string name) {
        this.name = name;
        this.data = null;
    }

    public CustomEventBlob(string name, object data) {
        this.name = name;
        this.data = data;
    }
}