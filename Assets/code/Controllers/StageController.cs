using UnityEngine;
using System.Collections;

public class StageController {
    private StageColumnCollection stageColumnCollection;
    private ProblemGenerator problemGenerator { get; set; }

    private System.Collections.Generic.List<ProblemBlob> problemList { get; set; }
    private float nextProblemTime { get; set; }
    private float timeUntilAnswerTimeout { get; set; }

    public StageController(string leftColumnGameObjectName, string centerColumnGameObjectName, string rightColumnGameObjectName) {
        /* Init Stage Columns */
        stageColumnCollection = new StageColumnCollection();
        stageColumnCollection.Add("left", new StageColumn(leftColumnGameObjectName));
        stageColumnCollection.Add("center", new StageColumn(centerColumnGameObjectName));
        stageColumnCollection.Add("right", new StageColumn(rightColumnGameObjectName));

        /* Set Problem Generator */
        this.problemGenerator = new ProblemGenerator(GameController.controller.data.minProblemTerm, GameController.controller.data.maxProblemTerm, GameController.controller.data.advancedProblemMode);

        /* Misc */
        problemList = new System.Collections.Generic.List<ProblemBlob>();
        this.nextProblemTime = Time.time;
        this.timeUntilAnswerTimeout = Time.time + GameController.controller.data.answerTimeout;
    }


    /* Getters */
    public StageColumn getStageColumn(string columnPosition) {
        return stageColumnCollection[columnPosition];
    }

    /* Setters */
    public void setStageColumn(string columnPosition, StageColumn stageColumn) {
        this.stageColumnCollection[columnPosition] = stageColumn;
    }


    /* Actions */
    public void update() {
        /* Add new blocks */
        if (Time.time >= this.nextProblemTime && (this.problemList.Count + 1) <= GameController.controller.data.maxProblemCount) {//Check if it has been enough time since last problem, check if the max number of problems hasnt been met
            ProblemBlob newProblem = this.generate();

            this.problemList.Add(newProblem);
            this.nextProblemTime = Time.time + GameController.controller.data.problemIntervalTime;

            this.updateAnswerButtons();

            /*Debug.Log("Time: " + Time.time + 
                " Next Problem Time: " + this.nextProblemTime + 
                " Max Problem Count: " + GameController.controller.data.maxProblemCount + 
                " Current Problem Count: " + this.problemList.Count);*/ 
        }

        /* Update Slider */
        /*float timeLeft = this.timeUntilAnswerTimeout - Time.time;

        GuiController.controller.setSlider(GameController.controller.data.answerTimeout / timeLeft);

        Debug.Log(timeLeft.ToString());

        if (timeLeft <= 0) {
            Debug.Log("Times Up");
            this.problemList[0].destroy();
            this.timeUntilAnswerTimeout = Time.time + GameController.controller.data.answerTimeout;
        }*/

        /* Make sure Blocks do not bounce */
        for (int i = 0; i < this.problemList.Count; i++) {
            ProblemBlob currentProblem = this.problemList[i];

            for (int n = 0; n <= 3; n++) {
                string currentBlockName = "left";

                switch (n) {
                    case 1:
                        currentBlockName = "left";
                        break;
                    case 2:
                        currentBlockName = "center";
                        break;
                    case 3:
                        currentBlockName = "right";
                        break;
                }
                        
                Block currentBlock = currentProblem.getBlock(currentBlockName);
                Vector3 currentBlockVelocity = currentBlock.getCubeObject().rigidbody.velocity;

                if (currentBlockVelocity.y >= 0f) {
                    currentBlockVelocity.y = 0;
                    currentBlock.getCubeObject().rigidbody.velocity = currentBlockVelocity;
                }
            }
        }
    }

    private void updateAnswerButtons() {
        ProblemBlob latestProblem = this.problemList[0];

        if (!latestProblem.getAnswersUIButtonsSet()) {
            latestProblem.setAnswersUIButtonsSet(true);

            int wrongAnswerOneVariation = Random.Range(GameController.controller.data.wrongProblemVariationMin, GameController.controller.data.wrongProblemVariationMax);
            int wrongAnswerTwoVariation = Random.Range(GameController.controller.data.wrongProblemVariationMin, GameController.controller.data.wrongProblemVariationMax);

            int wrongAnswerOneBase = latestProblem.getProblem().solve();
            int wrongAnswerTwoBase = latestProblem.getProblem().solve();

            int wrongAnswerOne = wrongAnswerOneBase + wrongAnswerOneVariation;
            int wrongAnswerTwo = wrongAnswerTwoBase + wrongAnswerTwoVariation;

            int correctAnswerButtonId = Random.Range(1, 3);

            string correctAnswerButtonName = GuiController.controller.getAnswerButtonIdByIndex(correctAnswerButtonId);
            string wrongAnswerButtonNameOne = "";
            string wrongAnswerButtonNameTwo = "";

            switch (correctAnswerButtonId) {
                case 1:
                    wrongAnswerButtonNameOne = GuiController.controller.getAnswerButtonIdByIndex(2);
                    wrongAnswerButtonNameTwo = GuiController.controller.getAnswerButtonIdByIndex(3);
                    break;
                case 2:
                    wrongAnswerButtonNameOne = GuiController.controller.getAnswerButtonIdByIndex(1);
                    wrongAnswerButtonNameTwo = GuiController.controller.getAnswerButtonIdByIndex(3);
                    break;
                case 3:
                    wrongAnswerButtonNameOne = GuiController.controller.getAnswerButtonIdByIndex(2);
                    wrongAnswerButtonNameTwo = GuiController.controller.getAnswerButtonIdByIndex(1);
                    break;
            }

            GuiController.controller.setUIText(correctAnswerButtonName, latestProblem.getProblem().solve().ToString());
            GuiController.controller.setUIText(wrongAnswerButtonNameOne, wrongAnswerOne.ToString());
            GuiController.controller.setUIText(wrongAnswerButtonNameTwo, wrongAnswerTwo.ToString());
        }
    }

    public void checkAnswer(string answerButtonId) {
        string answerButtonValue = GuiController.controller.getUIText(answerButtonId);
        int answerValue = System.Convert.ToInt32(answerButtonValue);

        ProblemBlob latestProblem = this.problemList[0];

        if (answerValue == latestProblem.getProblem().solve()) {
            Debug.Log("Correct");
        }
        else {
            Debug.Log("Wrong");
        }

        this.problemList.Remove(latestProblem);
        latestProblem.destroy();
        //GuiController.controller.setSlider(1);
        //this.timeUntilAnswerTimeout = Time.time + GameController.controller.data.answerTimeout;
    }

    private Vector3 generateProblemMaterialIndex() {
        int leftBlock = Random.Range(0, 7);
        int centerBlock = Random.Range(0, 7);
        int rightBlock = Random.Range(0, 7);

        return new Vector3(leftBlock, centerBlock, rightBlock);
    }

    public ProblemBlob generate() {
        Problem problem = this.problemGenerator.generate();

        Vector3 materialIndex = generateProblemMaterialIndex();

        Block leftBlock = this.getStageColumn("left").addBLock(problem.getTermOne().ToString(), materialIndex.x);
        Block centerBlock = this.getStageColumn("center").addBLock(problem.getOperationSign(), materialIndex.y);
        Block rightBlock = this.getStageColumn("right").addBLock(problem.getTermTwo().ToString(), materialIndex.z);

        ProblemBlob problemBlob = new ProblemBlob(leftBlock, centerBlock, rightBlock, materialIndex, false, problem);
        Debug.Log(problem.getTermOne() + " " + problem.getOperationSign() + " " + problem.getTermTwo() + " = " + problem.solve());
        return problemBlob;
    }
}
