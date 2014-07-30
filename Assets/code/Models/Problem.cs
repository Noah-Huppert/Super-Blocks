using UnityEngine;
using System.Collections;

public class Problem {
    private int termOne;
    private int termTwo;
    private string operation;
    /*
     ------ Operations ------
     addition => +
     subtraction => -
     division => /
     multipication => *
    */

    public Problem(int termOne, int termTwo, string operation) {
        /* Set terms */
        this.setTermOne(termOne);
        this.setTermTwo(termTwo);

        /* Set operation */
        this.setOperation(operation);
    }


    /* Getters */
    public int getTermOne() {
        return this.termOne;
    }

    public int getTermTwo() {
        return this.termTwo;
    }

    public string getOperation() {
        return this.operation;
    }

    public string getOperationSign() {
        switch (this.getOperation()) {
            case "addition":
                return "+";
            case "subtraction":
                return "-";
            case "division":
                return "/";
            case "multipication":
                return "*";
        }
        return "+";
    }


    /* Setters */
    public void setTermOne(int termOne) {
        this.termOne = termOne;
    }

    public void setTermTwo(int termTwo) {
        this.termTwo = termTwo;
    }

    public void setOperation(string operation) {
        this.operation = operation;
    }


    /* Action */
    public int solve() {
        switch (this.getOperation()) {
            case "addition":
                return this.getTermOne() + this.getTermTwo();
            case "subtraction":
                return this.getTermOne() - this.getTermTwo();
            case "division":
                if (this.getTermOne() != 0 && this.getTermTwo() != 0) {
                    return this.getTermOne() / this.getTermTwo();
                }
                //TODO CHECK IF VALUE IS INT
                else {
                    return -1;
                }
            case "multipication":
                return this.getTermOne() * this.getTermTwo();
        }
        return 0;
    }
}