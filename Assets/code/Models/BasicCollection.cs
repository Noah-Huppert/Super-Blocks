using UnityEngine;
using System.Collections;

public class BasicCollection : DictionaryBase {

    public void Add(string id, string setting) {
        Dictionary.Add(id, setting);
    }

    public void Remove(string id) {
        Dictionary.Remove(id);
    }

    public string this[string id] {
        get {
            return (string)Dictionary[id];
        }
        set {
            Dictionary[id] = value;
        }
    }
}
