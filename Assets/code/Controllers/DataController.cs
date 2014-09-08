using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;

[System.Serializable]
public class DataController {
    /* Data */
    public int minProblemTerm { get; set; }
    public int maxProblemTerm { get; set; }
    public bool advancedProblemMode { get; set; }
    public float problemIntervalTime { get; set; }
    public int maxProblemCount { get; set; }
    public int wrongProblemVariationMin { get; set; }
    public int wrongProblemVariationMax { get; set; }
    public float answerTimeout { get; set; }

    /* Meta */
    public string _dataFile { get; private set; }

    public DataController() {
        /* Meta */
        _dataFile = Application.persistentDataPath + "/data.dat";


        /* Data */
        minProblemTerm = 1;
        maxProblemTerm = 5;
        advancedProblemMode = false;
        problemIntervalTime = 4f;
        maxProblemCount = 4;

        wrongProblemVariationMin = 1;
        wrongProblemVariationMax = 5;

        answerTimeout = 5;
    }
}