using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCameraButton : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;

    private UIDocument doc;
    private VisualElement root;
    private VisualElement frame;
    private Button button;
    private int curCamNum;

    private void OnEnable() {
        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        frame = root.Q<VisualElement>("Frame");
        button = frame.Q<Button>("Button");

        curCamNum = -1;
        enableCam();

        button.RegisterCallback<ClickEvent>(ev => enableCam());
    }

    private void enableCam() {
        // enable new camera
        curCamNum = curCamNum < cameras.Length - 1 ? curCamNum + 1 : 0;
        cameras[curCamNum].SetActive(true);

        // disable all other cameras
        for(int i = 0; i < cameras.Length; ++i)
            if(i != curCamNum)
                cameras[i].SetActive(false);
    }
}
