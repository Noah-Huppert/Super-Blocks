using UnityEngine;
using System.Collections;

public class DataController {
    /* Data */
    public int gameScore { get; set; }
    public int strikes { get; set; }

    public DataController() {
        /* Data */
        gameScore = 0;
        strikes = 0;
    }

    public void modifyGameScore(int modifer) {
        Debug.Log("ModifyGameScore");
        if ((gameScore + modifer) <= 0) {
            gameScore = 0;
            strikes += 1;
        }
        else {
            gameScore += modifer;
        }

        checkFailure();
    }

    public void checkFailure() {
        if (strikes >= GameController.controller.constants.strikeLimit) {
            GameController.controller.OnGameFail();
            Debug.Log("OnGameFail");
        }
    }
}