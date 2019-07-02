using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARController : MonoBehaviour
{
    public GameObject DetectedPlanePrefab;

    public GameObject Portal;
    public GameObject coloniaAnweisung;

    public Camera FirstPersonCamera;

    private static bool wasActive;

    private bool m_IsQuitting = false;

    // Start is called before the first frame update
    void Start()
    {
        if (wasActive == false)
        {
            coloniaAnweisung.SetActive(true);
            wasActive = true;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        _UpdateApplicationLifecycle();

        // Check if User touches the screen
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Raycast against the location the player touched to search for planes.
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            Portal.SetActive(true);
            coloniaAnweisung.SetActive(false);

            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            // Postion of the portal = hit position
            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation = hit.Pose.rotation;

            // Portal will face the camera
            Vector3 cameraPosition = FirstPersonCamera.transform.position;

            // Portal
            cameraPosition.y = hit.Pose.position.y;

            // Rotate the portal to face the camera
            Portal.transform.LookAt(cameraPosition, Portal.transform.up);

            Portal.transform.parent = anchor.transform;

        }
    }

    /// Check and update the application lifecycle.
    /// 
    private void _UpdateApplicationLifecycle()
    {
        // Exit the app when the 'back' button is pressed.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Only allow the screen to sleep when not tracking.
        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        if (m_IsQuitting)
        {
            return;
        }

        // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            _ShowAndroidToastMessage("Camera permission is needed to run this application.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            _ShowAndroidToastMessage(
                "ARCore encountered a problem connecting.  Please start the app again.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
    }

    /// Actually quit the application.
    private void _DoQuit()
    {
        Application.Quit();
    }

    /// Show an Android toast message.
  
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
