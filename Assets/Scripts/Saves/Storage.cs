using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saves
{
    public class Storage
    {
        /// <summary>
        /// Хранилище
        /// Создание файла для сохранений, перезапись существующих сохранений, а так же загрусзка существующих сохранений
        /// </summary>
        private string _filePath;
        private BinaryFormatter _formatter;

        public Storage()
        {
            var directory = Application.persistentDataPath + "/saves";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            _filePath = directory + "GameSave.save";
            InitializeBinaryFormatter();
        }

        private void InitializeBinaryFormatter()
        {
            _formatter = new BinaryFormatter();
        }

        //Возвращает сохраненные данные
        public object Load(object saveDataByDefault)
        {
            if (!File.Exists(_filePath))
            {
                if (saveDataByDefault != null)
                {
                    Save(saveDataByDefault);
                }
                return saveDataByDefault;
            }

            var file = File.Open(_filePath, FileMode.Open);
            var savedData = _formatter.Deserialize(file);
            file.Close();
            return savedData;
        }
        
        // Перезаписывает файл с сохранениями
        public void Save(object saveData)
        {
            var file = File.Create(_filePath);
            _formatter.Serialize(file, saveData);
            file.Close();
        }

        // Удаляет все сохранения
        public void ClearSaves()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}