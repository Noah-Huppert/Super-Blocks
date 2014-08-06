using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

public class GameController : MonoBehaviour {
    public static GameController controller { get; private set; }
    public DataController data { get; private set; }
    public StageController stage { get; private set; }

    /* Unity Lifecycle Methods
     * Awake
     * OnEnable
     * Start
     * Update
     * OnGUI
     * OnDisable
     * OnDestroy
     */
    public void Awake() {
        this.doSingleton();
        this.initProperties();
    }

    public void OnEnable() {
        this.Load();
    }

    public void Update() {
        GameController.controller.stage.update();
    }

    public void OnDisable() {
        this.Save();
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
    }


    /* Save & Load */
    public void Save() {
        File.WriteAllText(this.data._dataFile, Newtonsoft.Json.JsonConvert.SerializeObject(this.data));
    }

    public void Load() {
        if (File.Exists(this.data._dataFile)) {
            var saveFileText = File.ReadAllText(this.data._dataFile);
            DataController dataController = Newtonsoft.Json.JsonConvert.DeserializeObject<DataController>(saveFileText);
            this.data = dataController;
        }
    }
}