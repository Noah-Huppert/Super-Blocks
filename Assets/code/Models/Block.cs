using UnityEngine;
using System.Collections;

public class Block{
    private GameObject textObject;
    private GameObject cubeObject;

    public Block(string displayText) {
        /* Create Cube Object */
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeObject.name = "Block " + displayText;
        cubeObject.transform.localScale = new Vector3(3, 3, 3);

        cubeObject.AddComponent<Rigidbody>();
        cubeObject.GetComponent<Rigidbody>().constraints =
            RigidbodyConstraints.FreezePositionX |
            RigidbodyConstraints.FreezePositionZ |
            RigidbodyConstraints.FreezeRotation;
        cubeObject.GetComponent<Rigidbody>().mass = 100;

        this.setCubeObject(cubeObject);

        /* Create Text Object */
        GameObject textObject = new GameObject("Block Text");
        textObject.transform.parent = cubeObject.transform;
        textObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        textObject.transform.localPosition = new Vector3(-0.225f, 0.5f, 0.0f);

        textObject.AddComponent<TextMesh>();
        textObject.GetComponent<TextMesh>().fontSize = 130;
        textObject.GetComponent<TextMesh>().offsetZ = -5;
        textObject.GetComponent<TextMesh>().color = new Color(0, 0, 0);
        textObject.GetComponent<TextMesh>().font = (Font)Resources.Load("aaram-regular");

        textObject.GetComponent<MeshRenderer>().material = textObject.GetComponent<TextMesh>().font.material;

        this.setTextObject(textObject);

        /* Set text */
        this.setDisplayText(displayText);
    }


    /* Getters */
    public string getDisplayText() {
        return this.getTextObject().GetComponent<TextMesh>().text;
    }

    public GameObject getTextObject() {
        return this.textObject;
    }

    public GameObject getCubeObject() {
        return this.cubeObject;
    }


    /* Setters */
    public void setDisplayText(string displayText) {
        this.getTextObject().GetComponent<TextMesh>().text = displayText;
    }

    public void setTextObject(GameObject textObject) {
        this.textObject = textObject;
    }

    public void setCubeObject(GameObject cubeObject) {
        this.cubeObject = cubeObject;
    }
}
