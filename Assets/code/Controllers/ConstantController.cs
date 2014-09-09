using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;

public class ConstantController {
    /* Data */
    public int minProblemTerm { get; set; }
    public int maxProblemTerm { get; set; }
    public bool advancedProblemMode { get; set; }
    public float problemIntervalTime { get; set; }
    public int maxProblemCount { get; set; }
    public int wrongProblemVariationMin { get; set; }
    public int wrongProblemVariationMax { get; set; }
    public float answerTimeout { get; set; }
    public int correctProblemScore { get; set; }
    public int wrongProblemScore { get; set; }
    public int strikeLimit { get; set; }

    /* Meta */
    public string _settingsFile { get; private set; }

    public ConstantController() {
        /* Meta */
        _settingsFile = Application.persistentDataPath + "/settings.dat";


        /* Data */
        minProblemTerm = 1;
        maxProblemTerm = 5;
        advancedProblemMode = false;
        problemIntervalTime = 2f;
        maxProblemCount = 4;

        wrongProblemVariationMin = 1;
        wrongProblemVariationMax = 5;

        answerTimeout = 5;

        correctProblemScore = 10;
        wrongProblemScore = -10;

        strikeLimit = 3;
    }
}