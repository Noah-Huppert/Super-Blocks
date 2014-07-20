using UnityEngine;
using System.Collections;

public class Block {
    private GameObject gameObject;
    private string text;

    public Block(string text) {
        /* Set Class values */
        GameObject toSetGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.setGameObject(toSetGameObject);
        this.setText(text);

        /* Add Components */
        this.getGameObject().AddComponent<Rigidbody>();
        this.getGameObject().AddComponent<TextMesh>();

        /* Setup Components */
        this.getTextMesh().text = this.getText();
        this.getTextMesh().fontSize = 36;
        this.getTextMesh().font = new Font("aaram-regular");
    }


    /* Getters */
    public GameObject getGameObject() {
        return this.gameObject;
    }

    public string getText() {
        return this.text;
    }


    /* Setters */
    public void setGameObject(GameObject gameObject) {
        this.gameObject = gameObject;
    }

    public void setText(string text) {
        this.text = text;
    }
    

    /* Actions */
    public Rigidbody getRigidBody() {
        return this.getGameObject().GetComponent<Rigidbody>();
    }

    public TextMesh getTextMesh() {
        return this.getGameObject().GetComponent<TextMesh>();
    }
}