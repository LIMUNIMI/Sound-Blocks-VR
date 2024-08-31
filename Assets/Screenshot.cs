using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private static string PathAddBackslash(string path)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        path = path.TrimEnd();

        if (PathEndsWithDirectorySeparator())
            return path;

        return path + GetDirectorySeparatorUsedInPath();

        bool PathEndsWithDirectorySeparator()
        {
            if (path.Length == 0)
                return false;

            char lastChar = path[path.Length - 1];
            return lastChar == Path.DirectorySeparatorChar
                || lastChar == Path.AltDirectorySeparatorChar;
        }

        char GetDirectorySeparatorUsedInPath()
        {
            if (path.Contains(Path.AltDirectorySeparatorChar.ToString()))
                return Path.AltDirectorySeparatorChar;

            return Path.DirectorySeparatorChar;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKeyDown(KeyCode.K))
        {
            string myDocFolder = PathAddBackslash(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));
            ScreenCapture.CaptureScreenshot(myDocFolder + Time.time.ToString("f3")+".png");
            Debug.Log("screenshotscreenshot");
        }  
    }
}
