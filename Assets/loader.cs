using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using ChartLoader.NET.Framework;
using ChartLoader.NET.Utils;
public class loader : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAssetRead;
    public  Chart Chart;
    void Start ()
	{
	  // if webGL, this will be something like "http://..."
	  string assetPath = Application.streamingAssetsPath;

	  bool isWebGl = assetPath.Contains("://") || 
	                   assetPath.Contains(":///");

	  try
	  {
	    if (isWebGl)
	    {
	      StartCoroutine(
	        SendRequest(
	          System.IO.Path.Combine(
	            assetPath, "/streamingAssets/myText.txt")));
	    }
	    else // desktop app
	    {
	      // do whatever you need is app is not WebGL
	    }
	  }
	  catch
	  {
	    // handle failure
	  }
	}

    // Update is called once per frame
    void Update ()
	{
	  // check to see if asset has been successfully read yet
	  if (isAssetRead)
	  {
	    // once asset is successfully read, 
	    // load the next screen (e.g. main menu or gameplay)
	    SceneManager.LoadScene("SampleScene");
	  }

	  // need to consider what happens if 
	  // asset fails to be read for some reason
	}

	private IEnumerator SendRequest(string url)
	{
	  using (UnityWebRequest request = UnityWebRequest.Get(url))
	  {
	    yield return request.SendWebRequest();

	        // entire file is returned via downloadHandler
	        ChartReader chartReader = new ChartReader();
        	Chart = chartReader.ReadChartFile(request.downloadHandler.text);
        	print(request.downloadHandler.text);
	        // or
	        //byte[] fileContents = request.downloadHandler.data;

	        // do whatever you need to do with the file contents
	  }
	}
}
