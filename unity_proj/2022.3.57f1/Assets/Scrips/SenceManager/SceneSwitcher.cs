using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour
{
    // ����ʵ��
    public static SceneSwitcher Instance { get; private set; }

    // ������ʷջ
    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // ʵ�ֵ���ģʽ��ȷ��ֻ��һ��SceneSwitcher����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �ڳ����л�ʱ���ָö��󲻱�����
        }
        else
        {
            Destroy(gameObject); // �����ظ���SceneSwitcher
        }
    }

    /// <summary>
    /// �л���ָ������������¼��ǰ��������ʷջ
    /// </summary>
    /// <param name="sceneName">Ŀ�곡������</param>
    public void SwitchScene(string sceneName)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        sceneHistory.Push(currentScene); // ����ǰ����ѹ����ʷջ
        SceneManager.LoadScene(sceneName); // ����Ŀ�곡��
    }

    /// <summary>
    /// ���ص���һ������
    /// </summary>
    public void GoBack()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop(); // ������һ������
            SceneManager.LoadScene(previousScene); // ������һ������
        }
        else
        {
            Debug.LogWarning("������ʷΪ�գ��޷����ء�");
        }
    }

    /// <summary>
    /// ��ճ�����ʷ����ѡ��
    /// </summary>
    public void ResetHistory()
    {
        sceneHistory.Clear();
    }
}
