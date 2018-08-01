using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	[SerializeField] AudioMixer audioMixer;
	[SerializeField] Dropdown resolutionDropdown;
	[SerializeField] Toggle fullScreenToggle;

	Resolution[] resolutions;

	void Start()
    {
		fullScreenToggle.isOn = Screen.fullScreen;
        SetResolutionDropdown();
    }

    private void SetResolutionDropdown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
		int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
			if (resolutions[i].width == Screen.width &&
				resolutions[i].height == Screen.height
			){
				currentResolutionIndex = i;
			}
        }
        resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
    }

	public void SetResolution(int resolutionIndex){
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

    public void SetVolume( float volume ){
		audioMixer.SetFloat("volume", volume);
	}

	public void SetQuality(int qualityIndex){
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
		Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, isFullScreen);
	}
}
