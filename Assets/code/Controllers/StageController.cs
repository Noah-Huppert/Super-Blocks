using UnityEngine;
using System.Collections;

public class StageController {
    private StageColumnCollection stageColumnCollection;
    private ProblemGenerator problemGenerator;
    private bool advancedMode;//Wether or not center column is generated

    public StageController(string leftColumnGameObjectName, string centerColumnGameObjectName, string rightColumnGameObjectName) {
        /* Init Stage Columns */
        stageColumnCollection = new StageColumnCollection();
        stageColumnCollection.Add("left", new StageColumn(leftColumnGameObjectName));
        stageColumnCollection.Add("center", new StageColumn(centerColumnGameObjectName));
        stageColumnCollection.Add("right", new StageColumn(rightColumnGameObjectName));

        /* Set Problem Generator */
        this.setProblemGenerator(new ProblemGenerator(GameController.controller.saveData.getInt("minProblemTerm"), GameController.controller.saveData.getInt("maxProblemTerm"), this.getAdvancedMode()));
    }


    /* Getters */
    public StageColumn getStageColumn(string columnPosition) {
        return stageColumnCollection[columnPosition];
    }

    public ProblemGenerator getProblemGenerator() {
        return this.problemGenerator;
    }

    public bool getAdvancedMode() {
        return GameController.controller.saveData.getBool("advancedProblemMode");
    }


    /* Setters */
    public void setStageColumn(string columnPosition, StageColumn stageColumn) {
        this.stageColumnCollection[columnPosition] = stageColumn;
    }

    public void setProblemGenerator(ProblemGenerator problemGenerator) {
        this.problemGenerator = problemGenerator;
    }


    /* Actions */
    public ProblemBlob generate() {
        Problem problem = this.getProblemGenerator().generate();

        Block leftBlock = this.getStageColumn("left").addBLock(problem.getTermOne().ToString());
        Block centerBlock = this.getStageColumn("center").addBLock(problem.getOperationSign());
        Block rightBlock = this.getStageColumn("right").addBLock(problem.getTermTwo().ToString());

        ProblemBlob problemBlob = new ProblemBlob(leftBlock, centerBlock, rightBlock, problem);
        Debug.Log(problem.getTermOne() + " " + problem.getOperationSign() + " " + problem.getTermTwo() + " = " + problem.solve());
        return problemBlob;
    }
}
