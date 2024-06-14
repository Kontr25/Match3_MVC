using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuModel: MainMenuModelAbstract
    {
        public override void StartGame()
        {
            SceneManager.LoadScene(1);
        }
        
        public override void Quit()
        {
            Application.Quit();
        }
    }
}