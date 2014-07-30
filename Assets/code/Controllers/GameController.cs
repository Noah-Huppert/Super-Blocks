using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

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

    public void OnGUI() {
        if (GUI.Button(new Rect(10, 5, 100, 30), "New Problem")) {
            this.stage.generate();
        }

        if (GUI.Button(new Rect(10, 40, 100, 30), "Data")) {
            Debug.Log(this.data.maxProblemTerm);
        }

        if (GUI.Button(new Rect(10, 80, 100, 30), "Change Data")) {
            this.data.maxProblemTerm += 11;
        }
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
    /*public void Save() {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(this.data._dataFile);
        
        binaryFormatter.Serialize(fileStream, Convert.ChangeType(this.data, typeof(System.Ex)));

        fileStream.Close();
    }

    public void Load() {
        if (File.Exists(this.data._dataFile)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(this.data._dataFile, FileMode.Open);

            System.Object loadedData = binaryFormatter.Deserialize(fileStream);

            this.data.Load(loadedData);

            fileStream.Close();
        }
    }*/
}