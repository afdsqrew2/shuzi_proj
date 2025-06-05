using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene1()
    {
        // 记录当前场景
        SceneHistoryManager.Instance.PushScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("二级单工位—仓储"); // 二级界面1
    }

    public void LoadScene2()
    {
        SceneHistoryManager.Instance.PushScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("二级整体产线场景"); // 二级界面2
    }

    public void LoadScene3()
    {
        SceneHistoryManager.Instance.PushScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("二级界面—数孪教学"); // 二级界面3
    }
}

