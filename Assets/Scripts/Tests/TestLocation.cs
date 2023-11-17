using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLocation : MonoBehaviour
{

    private IEnumerator TestLocationCo()
    {
        UnityEngine.Input.location.Start(500f, 500f) ;
        Debug.Log($"Location enabled by user: {UnityEngine.Input.location.isEnabledByUser}");

        // Wait until service initializes
        int maxWait = 15; // wait max seconds
        while (UnityEngine.Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            Debug.Log($"Waiting for location service to initialize: {maxWait}");
            yield return new WaitForSecondsRealtime(1);
            maxWait--;
        }
        // Editor has a bug which doesn't set the service status to Initializing. So extra wait in Editor.
#if UNITY_EDITOR
        int editorMaxWait = 15;
        while (UnityEngine.Input.location.status == LocationServiceStatus.Stopped && editorMaxWait > 0)
        {
            Debug.Log($"Extra Waiting for location service to initialize: {editorMaxWait}");
            yield return new WaitForSecondsRealtime(1);
            editorMaxWait--;
        }
#endif

        // Service didn't initialize in 15 seconds -> Exit
        if (maxWait < 1)
        {
            // TODO Failure
            Debug.LogFormat("Timed out");
            yield break;
        }

        // Connection has failed
        if (UnityEngine.Input.location.status != LocationServiceStatus.Running)
        {
            // TODO Failure
            Debug.LogFormat("Unable to determine device location. Failed with status {0}", UnityEngine.Input.location.status);
            yield break;
        }
        else
        {
            Debug.LogFormat("Location service live. status {0}", UnityEngine.Input.location.status);
            // Access granted and location value could be retrieved
            Debug.LogFormat("Location: "
                + UnityEngine.Input.location.lastData.latitude + " "
                + UnityEngine.Input.location.lastData.longitude + " "
                + UnityEngine.Input.location.lastData.altitude + " "
                + UnityEngine.Input.location.lastData.horizontalAccuracy + " "
                + UnityEngine.Input.location.lastData.timestamp);

            var _latitude = UnityEngine.Input.location.lastData.latitude;
            var _longitude = UnityEngine.Input.location.lastData.longitude;
            // TODO success do something with location
        }

        // Stop service if there is no need to query location updates continuously
        UnityEngine.Input.location.Stop();
    }

    private void Start()
    {
        StartCoroutine(TestLocationCo());
    }
}