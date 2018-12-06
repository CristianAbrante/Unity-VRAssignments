//
// API.AI Unity SDK Sample
// =================================================
//
// Copyright (C) 2015 by Speaktoit, Inc. (https://www.speaktoit.com)
// https://www.api.ai
//
// ***********************************************************************************************************************
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
//
// ***********************************************************************************************************************

using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Reflection;
using ApiAiSDK;
using ApiAiSDK.Model;
using ApiAiSDK.Unity;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ApiAiModule : MonoBehaviour
{

    public Text answerTextField;
    public Text inputTextField;
    private ApiAiUnity apiAiUnity;
    private AudioSource aud;

    private readonly String candleActionText = "candle";
    private readonly String barrelsActionText = "barrels";

    private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
    { 
        NullValueHandling = NullValueHandling.Ignore,
    };

    private readonly Queue<Action> ExecuteOnMainThread = new Queue<Action>();

    // Use this for initialization
    void Start()
    {
        ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) =>
        {
            return true;
        };
            
        const string ACCESS_TOKEN = "3d546d5451bc4c498b77dfc361f1256e";

        var config = new AIConfiguration(ACCESS_TOKEN, SupportedLanguage.Spanish);

        apiAiUnity = new ApiAiUnity();
        apiAiUnity.Initialize(config);
    }
    
    public void SendText()
    {
        var text = inputTextField.text;

        Debug.Log(text);

        AIResponse response = apiAiUnity.TextRequest(text);

        if (response != null)
        {
            Debug.Log("Resolved query: " + response.Result.ResolvedQuery);
            var outText = JsonConvert.SerializeObject(response, jsonSettings);

            var pattern = @"speech"":""(.+?)""";
            var match = Regex.Match(outText, pattern);

            Debug.Log("Result: " + match.Groups[1]);

            answerTextField.text = match.Groups[1].ToString();

            tryToDoAction(match.Groups[1].ToString());
        } else
        {
            Debug.LogError("Response is null");
        }

    }

    private void tryToDoAction(String text) {
        if(text.Contains(candleActionText)) 
            GameController.lightToogle();

        else if(text.Contains(barrelsActionText))
            GameController.changeObjectsColor();
    }
}
