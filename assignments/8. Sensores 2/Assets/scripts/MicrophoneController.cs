using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneController : MonoBehaviour {
	public AudioSource source;
    public Button recButton;
    public Button playButton;

    private Color REC_COLOR_NORMAL = new Color(255, 194, 5);
    private Color REC_COLOR_ON_RECCORD = new Color(242, 60, 80);

    public void onRecClicked() {
        ColorBlock recColors = recButton.colors;
        if (!isRecording()) {
            recColors.normalColor = REC_COLOR_ON_RECCORD;
            recButton.colors = recColors;
            changeButtonText(recButton, "STOP REC");
            playButton.interactable = false;
            startReccord();
        } else {
            recColors.normalColor = REC_COLOR_NORMAL;
            recButton.colors = recColors;
            changeButtonText(recButton, "START REC");
            playButton.interactable = true;
            stopReccord();
        }
	}

    public void onPlayClicked() {
        source.Play();
    }

    private void startReccord() {
        source.clip = Microphone.Start(null, false, 10, 4410);
    }

    private void stopReccord() {
        if (isRecording()) {
            Microphone.End(null);
        }
    }

    private bool isRecording() {
		return Microphone.IsRecording(null);
	}

    private void changeButtonText(Button btn, string text) {
        btn.GetComponentInChildren<Text>().text = text;
    }
}
