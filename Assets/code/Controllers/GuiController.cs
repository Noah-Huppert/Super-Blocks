﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {
    public static GuiController controller = null;

    public string leftAnswerButtonId { get; set; }
    public string centerAnswerButtonId { get; set; }
    public string rightAnswerButtonId { get; set; }
    public string gameScoreTextId { get; set; }
    public string gameStrikesTextId { get; set; }
    public string answerTimeoutSliderId { get; set; }

    public string menuPlayButtonId { get; set; }

    public string gameOverNavToMenuButtonId { get; set; }
    public string gameOverReplayButtonId { get; set; }

    public GameObject leftAnswerButton;
    public GameObject centerAnswerButton;
    public GameObject rightAnswerButton;
    public GameObject gameScore;
    public GameObject gameStrikes;
    public GameObject answerTimer;

    public void Awake() {
        this.doSingleton();
        this.initProperties();
    }

    public void Start() {
        leftAnswerButton = GameObject.Find(GuiController.controller.leftAnswerButtonId);
        centerAnswerButton = GameObject.Find(GuiController.controller.centerAnswerButtonId);
        rightAnswerButton = GameObject.Find(GuiController.controller.rightAnswerButtonId);
        answerTimer = GameObject.Find(GuiController.controller.answerTimeoutSliderId);
        gameScore = GameObject.Find(GuiController.controller.gameScoreTextId);
        gameStrikes = GameObject.Find(GuiController.controller.gameStrikesTextId);
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
        answerTimeoutSliderId = "Answer Timer";
        gameScoreTextId = "Game Score";
        gameStrikesTextId = "Game Strikes";

        menuPlayButtonId = "Menu Play Button";

        gameOverNavToMenuButtonId = "Game Over Nav To Menu";
        gameOverReplayButtonId = "Game Over Replay";
    }

    public void setAnswerButtonsActive(bool active) {
        leftAnswerButton.SetActive(active);
        centerAnswerButton.SetActive(active);
        rightAnswerButton.SetActive(active);
    }

    public void setUIText(string uiObjectId, string newText) {
        Text textObject = leftAnswerButton.transform.Find("Text").GetComponent<Text>();

        if (uiObjectId == leftAnswerButtonId) {
            textObject = leftAnswerButton.transform.Find("Text").GetComponent<Text>();
        }

        if (uiObjectId == centerAnswerButtonId) {
            textObject = centerAnswerButton.transform.Find("Text").GetComponent<Text>();
        }

        if (uiObjectId == rightAnswerButtonId) {
            textObject = rightAnswerButton.transform.Find("Text").GetComponent<Text>();
        }

        if (uiObjectId == gameScoreTextId) {
            textObject = gameScore.GetComponent<Text>();
        }

        if (uiObjectId == gameStrikesTextId) {
            textObject = gameStrikes.GetComponent<Text>();
        }

        textObject.text = newText;
    }

    public void setSlider(float value) {
        this.answerTimer.GetComponent<Slider>().value = value;
    }

    public string getUIText(string uiObjectId) {
        Text textObject = leftAnswerButton.transform.Find("Text").GetComponent<Text>();

        if (uiObjectId == leftAnswerButtonId) {
            textObject = leftAnswerButton.transform.Find("Text").GetComponent<Text>();
        }

        if (uiObjectId == centerAnswerButtonId) {
            textObject = centerAnswerButton.transform.Find("Text").GetComponent<Text>();
        }

        if (uiObjectId == rightAnswerButtonId) {
            textObject = rightAnswerButton.transform.Find("Text").GetComponent<Text>();
        }

        if (uiObjectId == gameScoreTextId) {
            textObject = gameScore.GetComponent<Text>();
        }

        return textObject.text;
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

    public void onMenuPlayButtonClick() {
        GameController.controller.OnGuiClick(menuPlayButtonId);
    }

    public void onGameOverNavToMenuButtonClick() {
        GameController.controller.OnGuiClick(gameOverNavToMenuButtonId);
    }

    public void onGameOverReplayButtonClick() {
        GameController.controller.OnGuiClick(gameOverReplayButtonId);
    }
}
