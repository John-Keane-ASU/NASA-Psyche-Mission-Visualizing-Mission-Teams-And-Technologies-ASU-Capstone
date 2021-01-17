using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code taken from https://www.youtube.com/watch?v=nodjrfARFA0
public class PanoramaCapture : MonoBehaviour
{
    public Camera targetCamera;
    public RenderTexture cubeMapLeft;
    public RenderTexture rt;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            capture();
    }
    public void capture()
    {
        targetCamera.RenderToCubemap(cubeMapLeft);
        cubeMapLeft.ConvertToEquirect(rt);
        Save(rt);
    }

    public void Save(RenderTexture t)
    {
        Texture2D tex = new Texture2D(t.width, t.height);

        RenderTexture.active = t;
        tex.ReadPixels(new Rect(0, 0, t.width, t.height),0,0);
        RenderTexture.active = null;
        byte[] bytes = tex.EncodeToJPG();
        string path = Application.dataPath + "/PanoramaTest" + ".jpg";
        System.IO.File.WriteAllBytes(path, bytes);
    }
}
