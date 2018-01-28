using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImagePresent : MonoBehaviour
{
    [SerializeField] public List<Sprite> Images = new List<Sprite>();
    [SerializeField] public string NextScene;

    private int imageIdx;

    private void Start()
    {
        GetComponent<Image>().sprite = Images[0];
    }

    public void OnClick()
    {
        if (++imageIdx > Images.Count - 1)
        {
            SceneManager.LoadScene(NextScene);
            return;
        }

        GetComponent<Image>().sprite = Images[imageIdx];
    }
}
