using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour
{
    [SerializeField]
    private Text m_Recognitions;

    private DictationRecognizer m_DictationRecognizer;
    private bool isListening = false;
    public Button startDictationButton;

    void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            print(text);

            if (m_Recognitions != null)
                m_Recognitions.text += text + "\n";
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };
    }

    public void startDictation()
    {
        if (!isListening)
        {
            isListening = !isListening;
            GetComponent<Image>().color = new Color(0.9f, 0.4f, 0.3f);
            GetComponentInChildren<Text>().text = "Listening...";
            m_DictationRecognizer.Start();
        }
        else
        {
            isListening = !isListening;
            m_DictationRecognizer.Stop();
            m_DictationRecognizer.Dispose();
            GetComponentInChildren<Text>().text = "Finish";
            startDictationButton.interactable = !startDictationButton.interactable;
        }
    }

    private void OnDestroy()
    {
        m_DictationRecognizer.Dispose();
    }
}