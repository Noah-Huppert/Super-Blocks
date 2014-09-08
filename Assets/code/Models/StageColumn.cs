using UnityEngine;
using System.Collections;

public class StageColumn {
    private GameObject gameObject;
    private Material[] blockColors;

    public StageColumn(string gameObjName) {
        GameObject gameObject = GameObject.Find(gameObjName);
        this.setGameObject(gameObject);
        this.blockColors = new Material[8];

        this.blockColors[0] = new Material(Shader.Find("Diffuse"));
        this.blockColors[0].SetColor("_Color", new Color(0, 01f, 0.13f, 1f));//Green #00FF24

        this.blockColors[1] = new Material(Shader.Find("Diffuse"));
        this.blockColors[1].SetColor("_Color", new Color(1f, 0f, 0.86f, 1f));//Purple #FF00DB

        this.blockColors[2] = new Material(Shader.Find("Diffuse"));
        this.blockColors[2].SetColor("_Color", new Color(1f, 0.21f, 0f, 1f));//Red #FF3700

        this.blockColors[3] = new Material(Shader.Find("Diffuse"));
        this.blockColors[3].SetColor("_Color", new Color(0f, 0.78f, 1f, 1f));//Blue #00C8FF

        this.blockColors[4] = new Material(Shader.Find("Diffuse"));
        this.blockColors[4].SetColor("_Color", new Color(1f, 0f, 0.58f, 1f));//Magenta #FF0095

        this.blockColors[5] = new Material(Shader.Find("Diffuse"));
        this.blockColors[5].SetColor("_Color", new Color(0.24f, 0.81f, 0.05f, 1f));//Other Green #3ECF0E

        this.blockColors[6] = new Material(Shader.Find("Diffuse"));
        this.blockColors[6].SetColor("_Color", new Color(0.62f, 0.54f, 0.81f, 1f));//Other Purple #9F0ECF

        this.blockColors[7] = new Material(Shader.Find("Diffuse"));
        this.blockColors[7].SetColor("_Color", new Color(0.74f, 0.23f, 0.33f, 1f));//Other Red #BF3D55
    }

    /* Getters */
    public GameObject getGameObject() {
        return this.gameObject;
    }

    public Vector3 getSpawnPos() {
        return this.getGameObject().transform.position;
    }


    /* Setters */
    public void setGameObject(GameObject gameObject) {
        this.gameObject = gameObject;
    }

    public void setSpawnPos(Vector3 spawnPos) {
        this.getGameObject().transform.position = spawnPos;
    }


    /* Actions */
    public Block addBLock(string blockText, float materialIndex){
        Block block = new Block(blockText, this.blockColors[(int) Mathf.Floor(materialIndex)]);

        block.getCubeObject().transform.position = this.getSpawnPos();
        return block;
    }
}
