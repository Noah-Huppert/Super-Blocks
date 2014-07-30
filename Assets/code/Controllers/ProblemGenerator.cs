using UnityEngine;
using System.Collections;

public class ProblemGenerator {
    private int maxGen;
    private int minGen;
    private bool advancedMode;

    public ProblemGenerator(int minGen, int maxGen, bool advancedMode) {
        /* Set min an max generation values */
        this.setMinGen(minGen);
        this.setMaxGen(maxGen);

        /* Set advanced mode */
        this.setAdvancedMode(advancedMode);
    }


    /* Getters */
    public int getMaxGen() {
        return this.maxGen;
    }

    public int getMinGen() {
        return this.minGen;
    }

    public bool getAdvancedMode() {
        return this.advancedMode;
    }


    /* Setters */
    public void setMaxGen(int maxGen) {
        this.maxGen = maxGen;
    }

    public void setMinGen(int minGen) {
        this.minGen = minGen;
    }

    public void setAdvancedMode(bool advancedMode) {
        this.advancedMode = advancedMode;
    }


    /* Actions */
    public Problem generate() {
        /* Generate Values */
        int termOne = Random.Range(this.getMinGen(), this.getMaxGen());
        int termTwo = Random.Range(this.getMinGen(), this.getMaxGen());

        /*
            ------ Operations ------
            addition => +
            subtraction => -
            division => /
            multipication => *
        */
        string operation;
        string[] operations = new string[4];
        operations[0] = "addition";
        operations[1] = "subtraction";
        operations[2] = "division";
        operations[3] = "multipication";

        if (this.getAdvancedMode()) {
            operation = operations[Random.Range(0, 3)];
        }
        else {
            operation = operations[Random.Range(0, 1)];
        }

        
        /* Quality Control */
        Problem qaProblem = new Problem(termOne, termTwo, operation);
        if (qaProblem.solve() <= 0) {
            /* Problem is ba, regen */
            this.generate();
        }

        return qaProblem;
    }
}
