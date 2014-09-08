using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController controller { get; private set; }
    public DataController data { get; private set; }
    public StageController stage { get; private set; }
    //public GuiController gui { get; private set; }

    /* Unity Lifecycle Methods
     * Awake
     * OnEnable
     * Start
     * Update
     * OnGUI <--Deprecated
     * GameController.controller.OnGuiClick <-- Use Instead
     * OnDisable
     * OnDestroy
     */
    public void Awake() {
        this.doSingleton();
        this.initProperties();
    }

    public void OnEnable() {
        this.load();
    }

    public void Start() {
        
    }

    public void Update() {
        GameController.controller.stage.update();
    }

    public void OnGuiClick(string clickId) {
        GameController.controller.stage.checkAnswer(clickId);

        /*if (clickId == GuiController.controller.leftAnswerButtonId) {
            Debug.Log("Left");
        }

        if (clickId == GuiController.controller.centerAnswerButtonId) {
            Debug.Log("Center");
        }

        if (clickId == GuiController.controller.rightAnswerButtonId) {
            Debug.Log("Right");
        }*/
    }

    public void OnDisable() {
        this.save();
    }


    /* Actions */
    private void doSingleton() {
        /* Makes this a singleton */
        if (controller != null && controller != this) {//Make sure current controller is this one
            Destroy(gameObject);
        }

        controller = this;
        DontDestroyOnLoad(gameObject);
    }

    private void initProperties() {
        this.data = new DataController();
        this.stage = new StageController("leftColumn", "centerColumn", "rightColumn");
        //this.gui = new GuiController();
    }


    /* Save & Load */
    public void save() {
        File.WriteAllText(this.data._dataFile, Newtonsoft.Json.JsonConvert.SerializeObject(this.data));
    }

    public void load() {
        if (File.Exists(this.data._dataFile)) {
            var saveFileText = File.ReadAllText(this.data._dataFile);
            DataController dataController = Newtonsoft.Json.JsonConvert.DeserializeObject<DataController>(saveFileText);
            this.data = dataController;
        }
    }
}