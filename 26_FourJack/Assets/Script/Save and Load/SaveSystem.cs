using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystemRD
{
    public enum SaveFilles
    {

    }

    public static class SaveSystem
    {

        private static readonly string saveFolder = Application.dataPath + "/Save/";


        public static void Init()
        {
            // Checks if the save folder exists. If it doesn't, it makes a save folder
            if (!Directory.Exists(saveFolder))
            {
                // Makes save folder
                Directory.CreateDirectory(saveFolder);
            }
        }

        public static void Save(SaveFilles fillName, string data)
        {

            ///        SaveObjeck saveObjeck = new SaveObjeck
            ///        {
            ///           teast = 2,
            ///        };
            ///        string json = JsonUtility.ToJson(save);

            File.WriteAllText(getPath(fillName), data);
        }

        public static string Load(SaveFilles fillName)
        {
            string filePath = getPath(fillName);
            if (File.Exists(filePath))
            {
                string saveString = File.ReadAllText(filePath);
                return saveString;
            }
            else
            {
                Debug.Log("Can NOT find file: " + filePath);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fillName"></param>
        /// <returns>returns the class </returns>
        public static T Load<T>(SaveFilles fillName) where T : class
        {
            string fillPath = Load(fillName);
            T saveObjeck = default;

            if (fillPath != null)
            {
                saveObjeck = JsonUtility.FromJson<T>(fillPath);
            }

            return saveObjeck;
        }

        private static string getPath(SaveFilles fillName)
        {
            return Path.Combine(saveFolder, "Save_" + fillName + ".txt");
        }
    }
}



