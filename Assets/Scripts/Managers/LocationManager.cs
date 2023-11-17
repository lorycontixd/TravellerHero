using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    #region Singleton
    private static LocationManager _instance;
    public static LocationManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [Header("Settings")]
    public bool DebugMode;
    public float LocationUpdateEverySec;

    private LocationService locationService;


    private void Start()
    {
        locationService = new LocationService();
        locationService.Start();
    }

    public void Close()
    {
        locationService.Stop();
    }

    public LocationInfo GetLastData()
    {
        return locationService.lastData;
    }

    public LocationServiceStatus GetStatus()
    {
        return locationService.status;
    }
}
