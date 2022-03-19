using System;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        #region Set Player name
        [SerializeField] private TMP_Text nameT;

        [SerializeField] private TMP_InputField inputField;
        public void SetName()
        {
            nameT.text = inputField.text.ToString();
        }

        #endregion

        [SerializeField] so_LevelManger levelManger;

        private void Start()
        {
            levelManger.SetCurrentLevel(0);
            print(levelManger.GetCurrentLevel());
        }

        public void OpenLevel()
        {
            SceneManager.LoadSceneAsync(levelManger.GetCurrentLevel());
        }



    }
}
