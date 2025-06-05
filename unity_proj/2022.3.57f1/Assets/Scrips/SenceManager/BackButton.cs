using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        string previousScene = SceneHistoryManager.Instance.PopScene();
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("û����һ������¼");
            // ��ѡ�����Ĭ�ϳ�������ʾ��ʾ
        }
    }
}
