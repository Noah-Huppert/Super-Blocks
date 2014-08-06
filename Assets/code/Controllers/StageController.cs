using UnityEngine;
using System.Collections;

public class StageController {
    private StageColumnCollection stageColumnCollection;
    private ProblemGenerator problemGenerator { get; set; }

    private System.Collections.Generic.List<ProblemBlob> problemList { get; set; }
    private float nextProblemTime { get; set; }

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

            Debug.Log("Time: " + Time.time + 
                " Next Problem Time: " + this.nextProblemTime + 
                " Max Problem Count: " + GameController.controller.data.maxProblemCount + 
                " Current Problem Count: " + this.problemList.Count); 
        }

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

    public ProblemBlob generate() {
        Problem problem = this.problemGenerator.generate();

        Block leftBlock = this.getStageColumn("left").addBLock(problem.getTermOne().ToString());
        Block centerBlock = this.getStageColumn("center").addBLock(problem.getOperationSign());
        Block rightBlock = this.getStageColumn("right").addBLock(problem.getTermTwo().ToString());

        ProblemBlob problemBlob = new ProblemBlob(leftBlock, centerBlock, rightBlock, problem);
        Debug.Log(problem.getTermOne() + " " + problem.getOperationSign() + " " + problem.getTermTwo() + " = " + problem.solve());
        return problemBlob;
    }
}
