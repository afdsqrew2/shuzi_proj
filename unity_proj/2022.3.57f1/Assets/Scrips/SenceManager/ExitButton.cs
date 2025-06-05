using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnExitButtonPressed()
    {
        // 如果是构建的应用程序，退出
        Application.Quit();
    }
}
