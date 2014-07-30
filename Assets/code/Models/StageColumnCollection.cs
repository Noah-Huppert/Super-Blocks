using UnityEngine;
using System.Collections;

public class StageColumnCollection : DictionaryBase {

    public void Add(string id, StageColumn stageColumn) {
        Dictionary.Add(id, stageColumn);
    }

    public void Remove(string id) {
        Dictionary.Remove(id);
    }

    public StageColumn this[string id] {
        get {
            return (StageColumn)Dictionary[id];
        }
        set {
            Dictionary[id] = value;
        }
    }
}
