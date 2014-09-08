using UnityEngine;
using System.Collections;

public class ProblemBlob {
    private Block leftBlock;
    private Block centerBlock;
    private Block rightBlock;
    private Vector3 materialIndex;
    private bool answersUIButtonsSet;
    private Problem problem;

    public ProblemBlob(Block leftBlock, Block centerBlock, Block rightBlock, Vector3 materialIndex, bool answersUIButtonsSet, Problem problem) {
        /* Set Blocks */
        this.setBlock("left", leftBlock);
        this.setBlock("center", centerBlock);
        this.setBlock("right", rightBlock);

        this.answersUIButtonsSet = answersUIButtonsSet;

        /* Set Problems */
        this.setProblem(problem);
    }


    /* Actions */
    public void destroy() {
        getBlock("left").destroy();
        getBlock("center").destroy();
        getBlock("right").destroy();
    }


    /* Getters */
    public Block getBlock(string position) {
        switch (position) {
            case "left":
                return this.leftBlock;
            case "center":
                return this.centerBlock;
            case "right":
                return this.rightBlock;
        }

        return this.leftBlock;
    }

    public bool getAnswersUIButtonsSet() {
        return this.answersUIButtonsSet;
    }

    public Problem getProblem() {
        return this.problem;
    }

    public float getMaterialIndex(string position) {
        switch (position) {
            case "left":
                return this.materialIndex.x;
            case "center":
                return this.materialIndex.y;
            case "right":
                return this.materialIndex.z;
        }
        return this.materialIndex.x;
    }


    /* Setters */
    public void setBlock(string position, Block block) {
        switch (position) {
            case "left":
                this.leftBlock = block;
                break;
            case "center":
                this.centerBlock = block;
                break;
            case "right":
                this.rightBlock = block;
                break;
        }
    }

    public void setAnswersUIButtonsSet(bool answersUIButtonsSet) {
        this.answersUIButtonsSet = answersUIButtonsSet;
    }

    public void setProblem(Problem problem) {
        this.problem = problem;
    }

    public void setMaterialIndex(string position, int index) {
        switch (position) {
            case "left":
                this.materialIndex.x = index;
                break;
            case "center":
                this.materialIndex.y = index;
                break;
            case "right":
                this.materialIndex.z = index;
                break;
        }
    }
}
