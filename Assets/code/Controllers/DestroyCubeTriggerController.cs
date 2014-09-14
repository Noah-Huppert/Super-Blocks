using UnityEngine;
using System.Collections;

public class DestroyCubeTriggerController : MonoBehaviour {
    public void OnTriggerEnter(Collider objectCollider) {
        Destroy(objectCollider.gameObject);
    }
}
