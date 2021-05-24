using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class HandleSaveScenario
{
    private string generateFileName(string filename)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        return textInfo.ToTitleCase(filename);
    }
    public void Handle(Scenario _scenario)
    {
        string scenario = JsonUtility.ToJson(_scenario);
        string path = SaveDataUtils.GetDataDirectory() + "\\scenarios\\";
        String saveName = generateFileName(_scenario.Name);
        path = String.Format("{0}\\{1}.scenario", path, saveName);

        File.WriteAllText(path, scenario);
    }
}
