using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Enemy[] enemies;
    bool levelComplete = false;
    float gameTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelComplete)
        {
            bool allEnemiesDead = true;
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                    allEnemiesDead = false;
            }
            levelComplete = allEnemiesDead;
        }
        else
        {
            gameTimer += Time.deltaTime;
            if (gameTimer > 2f)
            {
                Globals.currentLevel++;
                if (Globals.currentLevel >= Globals.LevelNames.Length)
                    Globals.currentLevel = 0;
                SceneManager.LoadScene(Globals.LevelNames[Globals.currentLevel]);
            }
        }
    }
}
