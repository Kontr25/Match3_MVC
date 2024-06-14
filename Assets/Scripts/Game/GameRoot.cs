using System;
using Interfaces;
using Saves.GameSaveManager;
using ScoreManager;
using ScriptableObjects;
using Slot;
using Tile;
using TileSlotManager;
using UnityEngine;

namespace Game
{
    public class GameRoot : MonoBehaviour, IDisposable, ISubscribable
    {
        [SerializeField] private GameData _gameData; //ScriptableObject с настройками игры
        
        // Вьюшки
        [SerializeField] private TileSpawnerViewAbstract _tileSpawnerView;
        [SerializeField] private TileManagerViewAbstract _tileManagerView;
        [SerializeField] private SlotSpawnerViewAbstract _slotSpawnerView;
        [SerializeField] private SlotManagerViewAbstract _slotManagerView;
        [SerializeField] private TileSlotManagerViewAbstract _tileSlotManagerView;
        [SerializeField] private GameSaveManagerView _saveManagerView;
        [SerializeField] private ScoreManagerViewAbstract _scoreManagerView;
        
        // Контроллеры
        private TileSpawnerControllerAbstract _tileSpawnerController;
        private TileManagerControllerAbstract _tileManagerController;
        private SlotSpawnerControllerAbstract _slotSpawnerController;
        private SlotManagerControllerAbstract _slotManagerController;
        private TileSlotManagerControllerAbstract _tileSlotManagerController;
        private GameSaveManagerControllerAbstract _saveManagerController;
        private ScoreManagerControllerAbstract _scoreManagerController;

        private void Start()
        {
            // Инициализация контроллеров
            _saveManagerController = new GameSaveManagerController(new GameSaveManagerModel(), _saveManagerView);
            _tileSpawnerController = new TileSpawnerController(new TileSpawnerModel(), _tileSpawnerView);
            _tileManagerController = new TileManagerController(new TileManagerModel(), _tileManagerView, 
                _tileSpawnerController, _gameData.GridRowsCount, _gameData.GridColumnsCount);
            
            _slotSpawnerController = new SlotSpawnerController(new SlotSpawnerModel(), _slotSpawnerView, _gameData.GridColumnsCount);
            _slotManagerController = new SlotManagerController(new SlotManagerModel(_gameData.GridRowsCount, _gameData.GridColumnsCount),
                _slotManagerView, _slotSpawnerController, _gameData.GridRowsCount, _gameData.GridColumnsCount);

            _scoreManagerController = new ScoreManagerController(
                new ScoreManagerModel(_gameData.StartingPlayerScore, _gameData.ScorePerTile, _gameData.ScoreLostPerMove),
                _scoreManagerView);

            TileSlotManagerModel tileSlotManagerModel = new TileSlotManagerModel();
            _tileSlotManagerController = new TileSlotManagerController(tileSlotManagerModel, _tileSlotManagerView, 
                _tileManagerController, _slotManagerController, _gameData.GridRowsCount, _gameData.GridColumnsCount);
            
            // Установка всех тайлов в слоты
            _tileSlotManagerController.SetAllTileInSlot();
            
            // Подписка на события
            Subscribe();
        }

        // Метод, который вызываетя при завершении игры и пытается сохранить новый рекорд
        private void GameOver(int score)
        {
            _saveManagerController.TrySaveNewRecord(score);
        }

        // Освобождение ресурсов и отписка от событий
        private void OnDestroy()
        {
            Dispose();
            Unsubscribe();
        }

        // Освобождение ресурсов контроллеров
        public void Dispose()
        {
            _tileManagerController.Dispose();
            _tileSlotManagerController.Dispose();
            _saveManagerController.Dispose();
            _scoreManagerController.Dispose();
        }

        // Подписка на события
        public void Subscribe()
        {
            _tileSlotManagerController.OnDestructionComplete += _scoreManagerController.HandleTileDestruction;
            _scoreManagerController.OnGameOver += GameOver;
        }

        // Отписка от событий
        public void Unsubscribe()
        {
            _tileSlotManagerController.OnDestructionComplete -= _scoreManagerController.HandleTileDestruction;
            _scoreManagerController.OnGameOver -= GameOver;
        }
    }
}