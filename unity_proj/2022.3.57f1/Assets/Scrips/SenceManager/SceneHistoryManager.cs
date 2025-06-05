using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHistoryManager : MonoBehaviour
{
    public static SceneHistoryManager Instance;

    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // 确保只有一个实例
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 场景加载时调用，记录历史
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 可根据需要在此处进行其他操作
    }

    // 压入当前场景到历史栈
    public void PushScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            sceneHistory.Push(sceneName);
        }
    }

    // 弹出上一个场景名称
    public string PopScene()
    {
        if (sceneHistory.Count > 0)
        {
            return sceneHistory.Pop();
        }
        return null;
    }

    // 获取上一个场景名称但不移除
    public string PeekScene()
    {
        if (sceneHistory.Count > 0)
        {
            return sceneHistory.Peek();
        }
        return null;
    }
}

