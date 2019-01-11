using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class KeywordScript : MonoBehaviour
{
    [SerializeField]

    private KeywordRecognizer m_Recognizer;
    private string[] m_Keywords = { "hola" };
    private bool isListening = false;
    public Button startListeningKeyword;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords );
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    public void startListening()
    {
        if (!isListening)
        {
            isListening = !isListening;
            m_Recognizer.Start();
            GetComponent<Image>().color = new Color(0.9f, 0.4f, 0.3f);
            GetComponentInChildren<Text>().text = "Listening...";
        }
        else
        {
            isListening = !isListening;
            m_Recognizer.Stop();
            m_Recognizer.Dispose();
            GetComponentInChildren<Text>().text = "Finish";
            startListeningKeyword.interactable = !startListeningKeyword.interactable;
        }
    }
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
    }
}