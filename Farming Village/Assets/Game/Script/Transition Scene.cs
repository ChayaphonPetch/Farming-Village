using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public Animator transition;  // Corrected the typo
    public float transitionTime = 1f;
    public Vector2 transitionPosition;
    public string levelToLoad;  // Added levelToLoad as a public field

    public Vector3 playerPosition;
    public Vector3 playerPositionHouse = new Vector3(-6.41f, 5.84f, 0f);
    public Vector3 playerPositionNPC1 = new Vector3(45.81f, 7.37f, 0f);
    public Vector3 playerPositionNPC2 = new Vector3(56.8f, -8.67f, 0f);
    public Vector3 playerPositionNPC3 = new Vector3(70.78f, -6.59f, 0f);
    public Vector3 playerPositionShop = new Vector3(66.05f, 7.01f, 0f);


void OnTriggerEnter2D(Collider2D other)  // Updated for 2D
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Work");
            DataPersistenceManager.Instance.SaveGame();
            LoadNextScene();
        }
    }

    public void SaveData(ref GameData data)
    {
         data.playerPosition = this.transitionPosition;
     }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScreenAsync(levelToLoad));
    }


    IEnumerator LoadScreenAsync(string levelToLoad)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelToLoad);
    }
}
