using UnityEngine;
using System.Collections;

public class SaveController {
    private BasicCollection settingsCollection;

    public SaveController(){
        /* Load Settings Collection */
        this.setSettingsCollection(new BasicCollection());

        /* Init basic settings */
        this.declareInt("minProblemTerm", 1);
        this.declareInt("maxProblemTerm", 10);
        this.declareBool("advancedProblemMode", false);
    }


    /* Getters */
    public BasicCollection getSettingsCollection() {
        return this.settingsCollection;
    }


    /* Setters */
    public void setSettingsCollection(BasicCollection settingsCollection) {
        if (this.getSettingsCollection() == null) {
            this.settingsCollection = settingsCollection;
        }
    }


    /* Actions */
    private void declare(string id, string defValue) {
        if (this.get(id) == null) {
            this.add(id, defValue);
        }
    }

    
    /* DECLARE Types */
    private void declareInt(string id, int defValue) {
        this.declare(id, defValue.ToString());
    }

    private void declareFloat(string id, float defValue) {
        this.declare(id, defValue.ToString());
    }

    private void declareBool(string id, bool defValue) {
        this.declare(id, defValue.ToString());
    }


    /* Base Actions */
    public string get(string id) {
        return this.getSettingsCollection()[id];
    }

    public void add(string id, string value) {
        this.getSettingsCollection().Add(id, value);
    }

    public void remove(string id) {
        this.getSettingsCollection().Remove(id);
    }


    /* GET Types */
    public string getString(string id) {
        return this.get(id);
    }

    public int getInt(string id) {
        return int.Parse(this.get(id));
    }

    public float getFloat(string id) {
        return float.Parse(this.get(id));
    }

    public bool getBool(string id) {
        return bool.Parse(this.get(id));
    }


    /* ADD Types */
    public void addInt(string id, int value) {
        this.add(id, value.ToString());
    }

    public void addFloat(string id, float value) {
        this.add(id, value.ToString());
    }

    public void addBool(string id, bool value) {
        this.add(id, value.ToString());
    }

}