using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace VinoUtility
{
public class GameManager : MonoSingleton<GameManager>
{
    public Action<int> onWinAction;
    public Action<int> onLoseAction;

    public Action<int> onLoadLevelAction;
    public List<LevelData> levelDatas;

    public EventHandler<int> onScoreChangeHandler;

    bool isPaused = false;

    #region Custom Region
    [Header("Custom Part")]
    public bool isFirstSave = true;

    public string firstSaveTip = "";

    #endregion

    void Init()
    {
        
    }
    private void Start() {
        Init();
        //LoadLevel();
        //LoadLevel(curLevel);
    }
    public int curLevel = 0;
    private int _curScore;

    public int curScore{
        get { return _curScore; }
        private set{
            _curScore = value;
            onScoreChangeHandler?.Invoke(this,_curScore);
        }
    }

    public void CheckCondition()
    {
       
    }
    
    public void Win()
    {
        Debug.Log("Win!");
        onWinAction?.Invoke(curLevel);
    }
    public void NextLevel()
    {
        curLevel++;
        LoadLevel(curLevel);
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return StartCoroutine(ScreenFader.Instance.FadeOut());
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return StartCoroutine(ScreenFader.Instance.FadeIn());
        yield return new WaitForSeconds(0.2f);
    }

    public void LoadLevel(int level)
    {
        if(levelDatas.Count <= level || level < 0)
           return;
        curLevel = level;
        StartCoroutine(LoadSceneAsync(levelDatas[level].sceneName));
        onLoadLevelAction?.Invoke(level);
    }

    public void Lose()
    {
        onLoseAction?.Invoke(curLevel);
    }

    public void SetPaused(bool pause)
    {
        isPaused = pause;
        Time.timeScale = isPaused? 0 : 1;
    }

    void Update()
    {
       KeyDownTest();
    }

    //Do Test
    void KeyDownTest()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.F3))
        {
            
        }
    }

}
}