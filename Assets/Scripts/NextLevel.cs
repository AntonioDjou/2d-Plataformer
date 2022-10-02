using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
   void NextStage ()
    {
        SceneManager.LoadScene("Level2");
    }
}
