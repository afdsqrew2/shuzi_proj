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
            Debug.LogWarning("没有上一场景记录");
            // 可选择加载默认场景或显示提示
        }
    }
}
