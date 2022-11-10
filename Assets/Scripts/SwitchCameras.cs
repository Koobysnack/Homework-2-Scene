using System.Collections;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private float transitionSpeed;
    private int curCamNum;

    private void Awake() {
        curCamNum = 0;
        enableCam(curCamNum);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            // move to next camera and enable
            curCamNum = curCamNum < cameras.Length - 1 ? curCamNum + 1 : 0;
            enableCam(curCamNum);
        }
    }

    private void enableCam(int camNum) {
        // enable new camera
        cameras[camNum].SetActive(true);

        // disable all other cameras
        for(int i = 0; i < cameras.Length; ++i)
            if(i != camNum)
                cameras[i].SetActive(false);
    }
}
