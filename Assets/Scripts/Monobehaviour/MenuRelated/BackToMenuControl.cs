using UnityEngine;

public class BackToMenuControl : MonoBehaviour
{
    public GameObject BackToMenuLabel;
    public ChangeScene ChangeScene;

    // Update is called once per frame
    private void Update()
    {
        if (BackToMenuLabel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ChangeScene.ChangeToScene("MainMenu");
                Time.timeScale = 1;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    BackToMenuLabel.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                BackToMenuLabel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}