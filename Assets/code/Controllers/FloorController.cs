using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloorController : MonoBehaviour {
    private GameObject fakeFloor { get; set; }
    private GameObject canvas { get; set; }
    private GameObject mCamera { get; set; }

    public void Start() {
        canvas = GameObject.Find("Canvas");
        fakeFloor = GameObject.Find("UI Fake Floor");
        mCamera = GameObject.Find("Main Camera");
    }

    public void Update() {
        float fakeFloorPosY = fakeFloor.transform.position.y;

        float cameraHeight = mCamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, mCamera.GetComponent<Camera>().nearClipPlane)).y;

        float fakeFloorSetPosY = (fakeFloorPosY / Screen.height) * cameraHeight;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, fakeFloorSetPosY, gameObject.transform.position.z);
    }
}
