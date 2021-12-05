/*===============================================================
Product:    Samr Studio Templates
Developer:  Eric Mitchell
Company:    Samr Studio
Date:       04/12/2021 20:33
================================================================*/
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SamrStudio
{
    public class ButtonsHandler : MonoBehaviour
    {
        [SerializeField]
        private Button continueButton;
        [SerializeField]
        private Button newGameButton;
        [SerializeField]
        private Button loadGameButton;
        [SerializeField]
        private Button settingsButton;
        [SerializeField]
        private Button creditsButton;
        [SerializeField]
        private Button exitButton;
        [SerializeField]
        private float tweenDuration = 0.2f;


        public void OnContinueClicked()
        {
            Debug.Log("Continue");

            continueButton.transform.DOShakeScale(tweenDuration);
        }

        public void OnNewGameClicked()
        {
            Debug.Log("New Game");

            newGameButton.transform.DOShakeScale(tweenDuration);
        }

        public void OnLoadGameClicked()
        {
            Debug.Log("Load Game");

            loadGameButton.transform.DOShakeScale(tweenDuration);
        }

        public void OnSettingsClicked()
        {
            Debug.Log("Settings");

            settingsButton.transform.DOShakeScale(tweenDuration);
        }

        public void OnCreditsClicked()
        {
            Debug.Log("Credits");

            creditsButton.transform.DOShakeScale(tweenDuration);
        }

        public void OnExitClicked()
        {
            Debug.Log("Exit");

            exitButton.transform.DOShakeScale(tweenDuration);

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}