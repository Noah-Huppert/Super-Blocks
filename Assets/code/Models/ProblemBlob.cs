using UnityEngine;
using System.Collections;

public class ProblemBlob {
    private Block leftBlock;
    private Block centerBlock;
    private Block rightBlock;
    private Problem problem;

    public ProblemBlob(Block leftBlock, Block centerBlock, Block rightBlock, Problem problem) {
        /* Set Blocks */
        this.setBlock("left", leftBlock);
        this.setBlock("center", centerBlock);
        this.setBlock("right", rightBlock);

        /* Set Problems */
        this.setProblem(problem);
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

    public Problem getProblem() {
        return this.problem;
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

    public void setProblem(Problem problem) {
        this.problem = problem;
    }
}
