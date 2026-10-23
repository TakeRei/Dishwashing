using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartInput : MonoBehaviour
{
    /// <summary>
    /// ゲームスタートの際にエフェクト表示のスクリプトをアタッチするオブジェクト
    /// (DisplayEffectでもよかったけど、この時なぜかHandTrackingのスクリプトをとることにした)
    /// </summary>
    [SerializeField]
    public GameObject HandTraking;

    [SerializeField]
    public GameObject StartPlane01;

    [SerializeField]
    public GameObject StartButton01;

    [SerializeField]
    public GameObject StartPlane02;

    [SerializeField]
    public GameObject StartButton02;

    [SerializeField]
    public GameObject MagicMenu;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameExplan()
    {
        StartPlane01.SetActive(false);
        StartButton01.SetActive(false);
        StartPlane02.SetActive(true);
        StartButton02.SetActive(true);
        audioSource.PlayOneShot(ButtonSound);
    }

    public void StartGame()
    {
        StartPlane02.SetActive(false);
        StartButton02.SetActive(false);
        HandTraking.AddComponent<HandTracking>();
        MagicMenu.SetActive(true);
        CommonArea.isStartGame = true;
        audioSource.PlayOneShot(ButtonSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioSource.PlayOneShot(ButtonSound);
    }
}
