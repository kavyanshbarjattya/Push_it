using UnityEngine;
using UnityEngine.SceneManagement;

public class localplayer_restater : MonoBehaviour
{
    public void AgainPlaybtn()
    {
        SceneManager.LoadScene("local_player"); // if you press the 'playagain' button in 'localplayer' scene so this will run
    }
    public void Main_menu_Btn()
    {
        SceneManager.LoadScene("main_menu"); // if you press the 'go to menu' button in 'localplayer' scene so this will run
    }
}
