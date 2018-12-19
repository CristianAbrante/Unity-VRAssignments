using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    private bool isRecording;
    private bool cameraAvaiable;
    private WebCamTexture backCamera;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

	void Start () {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0) {
            Debug.Log("No camara detected");
            cameraAvaiable = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++) {
            if (!devices[i].isFrontFacing) {
                backCamera = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }
        if (backCamera == null) {
            Debug.Log("Unable to find back camera.");
            return;
        }
        cameraAvaiable = true;
	}
	
	void Update () {
        if (!cameraAvaiable) {
            return;
        }
        float ratio = (float)backCamera.width / (float)backCamera.height;
        fit.aspectRatio = ratio;

        float scaleY = backCamera.videoVerticallyMirrored ? -1f : 1f;
        background.transform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCamera.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}

    public void onCameraClick() {
        if (!isRecording) {
            if (cameraAvaiable) {
                backCamera.Play();
                background.texture = backCamera;
                isRecording = true;
            }
        } else {
            if (cameraAvaiable) {
                backCamera.Stop();
                background.texture = defaultBackground;
                isRecording = false;
            }
        }
    }
}
