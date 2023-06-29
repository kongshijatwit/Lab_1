using UnityEngine;
using UnityEngine.UI;

public class HelloRandom : MonoBehaviour
{
    [SerializeField] private Text textPrefab;
    [SerializeField] private GameObject textContainer;
    private string[] helloLanguages = { "Hello World!" , "¡Hola Mundo!", "Salut tout le monde!", "Hallo Welt!" };
    

    void Start()
    {
        if (helloLanguages.Length < 1)
        {
            Debug.LogWarning("List is empty");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Text newText = Instantiate(textPrefab, textContainer.transform, false);
            newText.text = helloLanguages[Random.Range(0, helloLanguages.Length)];
            newText.transform.position = new Vector3(Random.Range(0f, 1060f), Random.Range(0f, 720f), newText.transform.position.z);
            //newText.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
