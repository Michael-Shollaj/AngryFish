using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Pig[] _enemies;

    // Start is called before the first frame update
    void OnEnable()
    {
        _enemies = FindObjectsOfType<Pig>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Pig pig in _enemies)
        {
            if(pig != null)
            return;
        }
        Debug.Log("You killed all sea enemies");

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
