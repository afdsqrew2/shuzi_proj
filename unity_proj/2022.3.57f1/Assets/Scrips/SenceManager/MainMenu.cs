using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene1()
    {
        // ��¼��ǰ����
        SceneHistoryManager.Instance.PushScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("��������λ���ִ�"); // ��������1
    }

    public void LoadScene2()
    {
        SceneHistoryManager.Instance.PushScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("����������߳���"); // ��������2
    }

    public void LoadScene3()
    {
        SceneHistoryManager.Instance.PushScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("�������桪���Ͻ�ѧ"); // ��������3
    }
}

