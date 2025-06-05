using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHistoryManager : MonoBehaviour
{
    public static SceneHistoryManager Instance;

    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ��
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

    // ��������ʱ���ã���¼��ʷ
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �ɸ�����Ҫ�ڴ˴�������������
    }

    // ѹ�뵱ǰ��������ʷջ
    public void PushScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            sceneHistory.Push(sceneName);
        }
    }

    // ������һ����������
    public string PopScene()
    {
        if (sceneHistory.Count > 0)
        {
            return sceneHistory.Pop();
        }
        return null;
    }

    // ��ȡ��һ���������Ƶ����Ƴ�
    public string PeekScene()
    {
        if (sceneHistory.Count > 0)
        {
            return sceneHistory.Peek();
        }
        return null;
    }
}

