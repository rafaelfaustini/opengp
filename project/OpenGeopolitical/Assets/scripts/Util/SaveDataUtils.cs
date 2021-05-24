using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataUtils
{
    public static string GetDataDirectory()
    {
        String base_path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        base_path = String.Format("{0}\\OpenGP", base_path);
        Directory.CreateDirectory(base_path);
        Directory.CreateDirectory(base_path+"\\Saves");
        Directory.CreateDirectory(base_path+"\\Scenarios");
        Directory.CreateDirectory(base_path+"\\Mods");
        return base_path;
    }
}
