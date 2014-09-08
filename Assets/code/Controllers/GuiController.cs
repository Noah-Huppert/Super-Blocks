﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {
    public static GuiController controller = null;

    public string leftAnswerButtonId { get; set; }
    public string centerAnswerButtonId { get; set; }
    public string rightAnswerButtonId { get; set; }

    public GameObject leftAnswerButton;
    public GameObject centerAnswerButton;
    public GameObject rightAnswerButton;
    public GameObject answerTimer;

    public void Awake() {
        this.doSingleton();
        this.initProperties();
    }

    public void Start() {
        leftAnswerButton = GameObject.Find(GuiController.controller.leftAnswerButtonId);
        centerAnswerButton = GameObject.Find(GuiController.controller.centerAnswerButtonId);
        rightAnswerButton = GameObject.Find(GuiController.controller.rightAnswerButtonId);
        answerTimer = GameObject.Find("Answer Timer");
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
        leftAnswerButtonId = "Left Answer Button";
        centerAnswerButtonId = "Center Answer Button";
        rightAnswerButtonId = "Right Answer Button";
    }

    public void setUIText(string uiObjectId, string newText) {
        GameObject gameObject = leftAnswerButton;

        if (uiObjectId == leftAnswerButtonId) {
            gameObject = leftAnswerButton;
        }

        if (uiObjectId == centerAnswerButtonId) {
            gameObject = centerAnswerButton;
        }

        if (uiObjectId == rightAnswerButtonId) {
            gameObject = rightAnswerButton;
        }

        gameObject.transform.Find("Text").GetComponent<Text>().text = newText;
    }

    public void setSlider(float value) {
        this.answerTimer.GetComponent<Slider>().value = value;
    }

    public string getUIText(string uiObjectId) {
        GameObject gameObject = leftAnswerButton;

        if (uiObjectId == leftAnswerButtonId) {
            gameObject = leftAnswerButton;
        }

        if (uiObjectId == centerAnswerButtonId) {
            gameObject = centerAnswerButton;
        }

        if (uiObjectId == rightAnswerButtonId) {
            gameObject = rightAnswerButton;
        }

        return gameObject.transform.Find("Text").GetComponent<Text>().text;
    }

    public string getAnswerButtonIdByIndex(int index) {
        string answerButtonId = "";

        switch (index) {
            case 1:
                answerButtonId = GuiController.controller.leftAnswerButtonId;
                break;
            case 2:
                answerButtonId = GuiController.controller.centerAnswerButtonId;
                break;
            case 3:
                answerButtonId = GuiController.controller.rightAnswerButtonId;
                break;
        }

        return answerButtonId;
    }

    /* Listeners */
    public void onLeftButtonClick() {
        GameController.controller.OnGuiClick(leftAnswerButtonId);
    }

    public void onCenterButtonClick() {
        GameController.controller.OnGuiClick(centerAnswerButtonId);
    }

    public void onRightButtonClick() {
        GameController.controller.OnGuiClick(rightAnswerButtonId);
    }
}
