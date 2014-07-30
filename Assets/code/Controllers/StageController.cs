using UnityEngine;
using System.Collections;

public class StageController {
    private StageColumnCollection stageColumnCollection;
    private ProblemGenerator problemGenerator { get; set; }

    public StageController(string leftColumnGameObjectName, string centerColumnGameObjectName, string rightColumnGameObjectName) {
        /* Init Stage Columns */
        stageColumnCollection = new StageColumnCollection();
        stageColumnCollection.Add("left", new StageColumn(leftColumnGameObjectName));
        stageColumnCollection.Add("center", new StageColumn(centerColumnGameObjectName));
        stageColumnCollection.Add("right", new StageColumn(rightColumnGameObjectName));

        /* Set Problem Generator */
        this.problemGenerator = new ProblemGenerator(GameController.controller.data.minProblemTerm, GameController.controller.data.maxProblemTerm, GameController.controller.data.advancedProblemMode);
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
