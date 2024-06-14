using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Saves.MenuSaveManager
{
    public class MenuSaveManagerView: MenuSaveManagerViewAbstract
    {
        public override event Action OnClearSaves;

        [SerializeField] private TMP_Text[] _playerNameTexts;
        [SerializeField] private TMP_Text[] _playerRecordTexts;
        [SerializeField] private Button _clearSavesButton;
        
        public override string[] RandomNames => _randomNames;
        public override int FirstPlaceCount => _playerNameTexts.Length;

        public override void UpdateRecordWindow(List<string> playerNames, List<int> playerRecords)
        {
            for (int i = 0; i < _playerNameTexts.Length; i++)
            {
                _playerNameTexts[i].text = playerNames[i];
                _playerRecordTexts[i].text = playerRecords[i].ToString();
            }
        }

        public override void ClearSaves()
        {
            OnClearSaves?.Invoke();
        }

        public override void Subscribe()
        {
            _clearSavesButton.onClick.AddListener(ClearSaves);
        }

        public override void Unsubscribe()
        {
            _clearSavesButton.onClick.RemoveListener(ClearSaves);
        }
    }
}