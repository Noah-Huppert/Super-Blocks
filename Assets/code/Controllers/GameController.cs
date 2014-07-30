using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {
    public static GameController controller;
    public SaveController saveData;
    public StageController stageController;
    public ProblemBlobCollection problems;

    /* Unity Methods */
    public void OnEnable() {
        /* Load Data */
        this.load();
    }

    public void Awake() {
        /* Load Game Controller */
        this.setGameController(this);

        /* Load Settings Controller */
        this.setSaveController(new SaveController());

        /* Load Stage Controller */
        this.setStageController(new StageController("leftColumn", "centerColumn", "rightColumn"));

        /* Load Problem Blob Collection */
        this.setProblemBlobCollection(new ProblemBlobCollection());
    }

    public void Start() {
    }

    public void OnGUI(){
        if(GUI.Button(new Rect(10, 5, 100, 30), "New Problem")){
            stageController.generate();
        }
    }

    public void Update() {

    }

    public void OnDisable() {
        /* Save Data */
        this.save();
    }


    /* Setters */
    public void setGameController(GameController sGameController) {
        if (controller == null) {
            controller = sGameController;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this) {
            Destroy(gameObject);
        }
    }

    public void setSaveController(SaveController sSaveController) {
        if (saveData == null) {
            saveData = sSaveController;
        }
    }

    public void setStageController(StageController sStageController) {
        if (stageController == null) {
            stageController = sStageController;
        }
    }

    public void setProblemBlobCollection(ProblemBlobCollection sProblemBlobCollection) {
        if (problems == null) {
            problems = sProblemBlobCollection;
        }
    }


    /* Saving & Loading */
    public void save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);


    }

    public void load() {

    }
}