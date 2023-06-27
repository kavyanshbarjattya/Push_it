using UnityEngine;
using UnityEngine.SceneManagement;

public class localplayer_restater : MonoBehaviour
{
    public void AgainPlaybtn()
    {
        // if you press the 'playagain' button in 'localplayer' scene so this will run
        SceneManager.LoadScene("local_player");
    }
    public void Main_menu_Btn()
    {
        // if you press the 'go to menu' button in 'localplayer' scene so this will run
        SceneManager.LoadScene("main_menu");
    }
}
