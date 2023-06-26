using UnityEngine;
using UnityEngine.SceneManagement;

public class match_restarter : MonoBehaviour
{
    private car_move car_move;
    private car_ai car_ai;
    private void Start()
    {
        car_move= GetComponent<car_move>();
        car_ai= GetComponent<car_ai>(); 
    }
    public void MainMenu()
    {
        car_move.is_looking = true; //this will start 'AI Chasing' function again as we stopped it in car_move script
        SceneManager.LoadScene("main_menu");
    }
    public void AgainPlay()
    {
        car_move.is_looking = true;
        SceneManager.LoadScene("AI_Game");
    }
}
