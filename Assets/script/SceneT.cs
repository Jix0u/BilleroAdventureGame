using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneT : MonoBehaviour
{
    public string newScene;
    public Vector2 playerPos;
    public VectorV playerOld;
    public GameObject fadeP;

    private void Awake()
    {
        if (fadeP != null)
        {
            GameObject panel = Instantiate(fadeP, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerOld.initial = playerPos;
            StartCoroutine(FadeCo());
        }
    }

    private IEnumerator FadeCo()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(newScene);
        while (!op.isDone)
        {
            yield return null;
        }
        
    }
}
