using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public string sceneName;
    public Animator transitionAnimation;
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;
    [SerializeField] private Button loadButton;
    public bool disableLoad = false;

    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        if(disableLoad)
            PlayerPrefs.DeleteKey("CanLoad");
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (PlayerPrefs.HasKey("CanLoad") || PlayerPrefs.GetInt("CanLoad") == 1)
            loadButton.interactable = true;
        else
            loadButton.interactable = false;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void PlayButton()
    {
        PlayerPrefs.SetInt("CanLoad", 1);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnimation.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }
    public void ResetButton()
    {
        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;
        volumeTextValue.text = defaultVolume.ToString("0.0");
        VolumeApply();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
}
