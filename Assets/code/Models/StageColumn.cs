using UnityEngine;
using System.Collections;

public class StageColumn {
    private GameObject gameObject;

    public StageColumn(string gameObjName) {
        GameObject gameObject = GameObject.Find(gameObjName);
        this.setGameObject(gameObject);
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
    public Block addBLock(string blockText) {
        Block block = new Block(blockText);
        block.getCubeObject().transform.position = this.getSpawnPos();
        return block;
    }
}
