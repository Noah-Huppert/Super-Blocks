using UnityEngine;
using System.Collections;

public class ProblemBlobCollection : DictionaryBase {

    public void Add(string id, ProblemBlob problemBlob) {
        Dictionary.Add(id, problemBlob);
    }

    public void Remove(string id) {
        Dictionary.Remove(id);
    }

    public ProblemBlob this[string id] {
        get {
            return (ProblemBlob)Dictionary[id];
        }
        set {
            Dictionary[id] = value;
        }
    }
}
