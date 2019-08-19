using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; //to use Actions
using System.Linq; //to use ToArray
using UnityEngine.Windows.Speech; //To use voice recognition

public class VoiceTest : MonoBehaviour
{

    public GameObject prefabCube;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    private KeywordRecognizer keywordRecognizer;

    private void Start()
    {
        keywordActions.Add("Spawn cube", SpawnCube);

        keywordActions.Add("Spawn sphere", SpawnSphere);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized+= RecognizedPhrase;

        keywordRecognizer.Start();
    }

    void RecognizedPhrase(PhraseRecognizedEventArgs args)
    {
        keywordActions[args.text].Invoke();
    }

    void SpawnCube()
    {
        Instantiate(prefabCube, transform.position, transform.rotation);
    }

    void SpawnSphere()
    {
        Instantiate(prefabCube, transform.position, transform.rotation);
    }
}
