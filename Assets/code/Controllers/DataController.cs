using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.Runtime.Serialization;

[System.Serializable]
public class DataController {
    /* Data */
    public int minProblemTerm { get; set; }
    public int maxProblemTerm { get; set; }
    public bool advancedProblemMode { get; set; }

    public int test { get; set; }

    /* Meta */
    public string _dataFile { get; private set; }

    public DataController() {
        /* Meta */
        _dataFile = Application.persistentDataPath + "/data.dat";


        /* Data */
        minProblemTerm = 1;
        maxProblemTerm = 10;
        advancedProblemMode = false;

        test = 100;
    }


    /* Actions */
    /*public void Load(System.Object loadedData) {
        foreach (var loadedProp in loadedData.GetType().GetProperties()) {

            PropertyInfo realProp = this.GetType().GetProperty(loadedProp.Name);

            if (realProp != null) {//If property still exists

                Debug.Log("Current: " + realProp.Name + " = " + realProp.GetValue(this, null) + "  Loaded: " + loadedProp.Name + " = " + loadedProp.GetValue(loadedData, null));

                realProp.SetValue(this, Convert.ChangeType(loadedProp.GetValue(loadedData, null), loadedProp.PropertyType), null);
            }
            else {
                Debug.Log(" DEPRECATED Loaded: " + loadedProp.Name + " = " + loadedProp.GetValue(loadedData, null));
            }
        }
    }*/

   /*public void Load(System.Object loadedData) {
        foreach(var loadedProp in loadedData.GetType().GetProperties()){
            var loadedPropValue = loadedProp.GetValue(loadedData, null);
            var loadedPropName = loadedProp.Name;

            System.Object currentData = this;
            var currentProp = currentData.GetType().GetProperty(loadedPropName);

            if (currentProp != null) {//Values is used
                var currentPropValue = currentProp.GetValue(this, null);
                var currentPropName = currentProp.Name;

                Debug.Log("Real Value: " + currentPropName + " = " + currentPropValue + "  Loaded Value: " + loadedPropName + " = " + loadedPropValue);
            }
            else {//Value is not longer used
                Debug.Log("Deprecated Loaded Data: " + loadedPropName + " = " + loadedPropValue);
            }
        }
    }*/
}