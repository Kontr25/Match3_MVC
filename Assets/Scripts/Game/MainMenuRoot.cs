using MainMenu;
using Saves.MenuSaveManager;
using UnityEngine;

namespace Game
{
    public class MainMenuRoot: MonoBehaviour
    {
        // Вьюшки
        [SerializeField] private MainMenuViewAbstract _mainMenuView;
        [SerializeField] private MenuSaveManagerViewAbstract _saveManagerView;
        
        // Контрллеры
        private MainMenuControllerAbstract _mainMenuController;
        private MenuSaveManagerControllerAbstract _saveManagerController;
        private void Start()
        {
            // Инициализация контроллеров
            _mainMenuController = new MainMenuController(new MainMenuModel(), _mainMenuView);
            _saveManagerController = new MenuSaveManagerController(new MenuSaveManagerModel(), _saveManagerView);
            
            // Загрузка сохранений
            _saveManagerController.LoadData();
        }

        // Освобождение ресурсов контроллеров
        private void OnDestroy()
        {
            _mainMenuController.Dispose();
            _saveManagerController.Dispose();
        }
    }
}