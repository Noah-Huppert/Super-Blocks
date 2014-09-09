using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController controller { get; private set; }
    public ConstantController constants { get; private set; }
    public SettingsController settings { get; private set; }
    public StageController stage { get; private set; }
    public DataController data { get; private set; }

    /* Unity Lifecycle Methods
     * Awake
     * OnEnable
     * Start
     * Update
     * OnGUI <--Deprecated
     * GameController.controller.OnGuiClick <-- Use Instead
     * GameController.controller.OnGameFail 
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
    }

    public void OnGameFail() {
        Application.Quit();
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
        this.constants = new ConstantController();
        this.stage = new StageController("leftColumn", "centerColumn", "rightColumn");
        this.settings = new SettingsController();
        this.data = new DataController();
    }


    /* Save & Load */
    public void save() {
        File.WriteAllText(this.constants._settingsFile, Newtonsoft.Json.JsonConvert.SerializeObject(this.settings));
    }

    public void load() {
        if (File.Exists(this.constants._settingsFile)) {
            var saveFileText = File.ReadAllText(this.constants._settingsFile);
            SettingsController settingsController = Newtonsoft.Json.JsonConvert.DeserializeObject<SettingsController>(saveFileText);
            this.settings = settingsController;
        }
    }
}