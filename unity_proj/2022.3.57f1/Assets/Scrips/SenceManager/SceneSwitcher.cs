using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour
{
    // 单例实例
    public static SceneSwitcher Instance { get; private set; }

    // 场景历史栈
    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // 实现单例模式，确保只有一个SceneSwitcher存在
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 在场景切换时保持该对象不被销毁
        }
        else
        {
            Destroy(gameObject); // 销毁重复的SceneSwitcher
        }
    }

    /// <summary>
    /// 切换到指定场景，并记录当前场景到历史栈
    /// </summary>
    /// <param name="sceneName">目标场景名称</param>
    public void SwitchScene(string sceneName)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        sceneHistory.Push(currentScene); // 将当前场景压入历史栈
        SceneManager.LoadScene(sceneName); // 加载目标场景
    }

    /// <summary>
    /// 返回到上一个场景
    /// </summary>
    public void GoBack()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop(); // 弹出上一个场景
            SceneManager.LoadScene(previousScene); // 加载上一个场景
        }
        else
        {
            Debug.LogWarning("场景历史为空，无法返回。");
        }
    }

    /// <summary>
    /// 清空场景历史（可选）
    /// </summary>
    public void ResetHistory()
    {
        sceneHistory.Clear();
    }
}
