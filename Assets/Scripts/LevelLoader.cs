using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Helper;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader current;

    Animator animator;

    LevelData levelData;
    void Awake()
    {
        current = this;

        string levelDataString = PlayerPrefs.GetString("level_data", "");

        if (levelDataString == "")
        {
            levelData = new LevelData(CreateMix());
        }
        else
        {
            levelData = JsonUtility.FromJson<LevelData>(levelDataString);

            if (levelData.nextLevel >= levelData.currentMix[levelData.currentMix.Length - 2])
            {
                levelData = new LevelData(CreateMix());
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GoToMainMenu()
    {
        PlayerPrefs.DeleteKey("level_data");

        LoadLevel(0);
    }

    public void GoToPlay()
    {
        LoadLevel(levelData.nextLevel);

        levelData.nextLevel += 1;
        PlayerPrefs.SetString("level_data", JsonUtility.ToJson(levelData));
    }

    public void GoToCredits()
    {
        LoadLevel(1);
    }

    public void LoadNext()
    {
        if (PlayerPrefs.GetInt("current_lives", 0) != 0)
        {
            StartCoroutine(NextLevel());
        }
    }

    public void GoToExit()
    {
        Application.Quit();
    }

    void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevelCoroutine(sceneIndex));
    }

    IEnumerator LoadLevelCoroutine(int sceneIndex)
    {
        animator.SetTrigger("start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2.2f);

        LoadLevel(levelData.nextLevel);

        levelData.nextLevel += 1;
        PlayerPrefs.SetString("level_data", JsonUtility.ToJson(levelData));
    }

    int[] CreateMix()
    {
        int[] levelIndexes = new int[SceneManager.sceneCountInBuildSettings - 2];

        for (int i = 0; i < levelIndexes.Length; i++)
        {
            levelIndexes[i] = i + 2;
        }

        levelIndexes.Shuffle();

        return levelIndexes;
    }

    [System.Serializable]
    struct LevelData
    {
        public int[] currentMix;
        public int nextLevel;

        //
        // Summary:
        //     Test
        //
        // Parameters:
        //   mix:
        //     Test
        //
        // Returns:
        //     Test
        public LevelData(int[] mix)
        {
            currentMix = mix;
            nextLevel = currentMix[0];
        }
    }
}
