using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private float _volumeValue;
    [SerializeField] private Slider _volumeValueSlider;
    [SerializeField] private Sprite _muteSoundImage;
    [SerializeField] private Sprite _unmuteSoundImage;
    [SerializeField] private Image _soundImage;
    [SerializeField] private AudioSource _soundSource;

    private void Start()
    {
        MuteSound();
        UpdateVolumeValue();
    }

    public void UpdateVolumeValue()
    {
        _soundSource.volume = _volumeValueSlider.value;

        if (_volumeValueSlider.value == 0)
        {
            MuteSound();
        }
        else
        {
            UnmuteSound();
        }
    }

    public void ToggleSound()
    {
        if (_volumeValueSlider.value == 0)
        {
            _volumeValueSlider.value = 0.25f;
            _soundSource.volume = 0.25f;
            UnmuteSound();
        }
        else
        {
            _volumeValueSlider.value = 0f;
            _soundSource.volume = 0f;
            MuteSound();
        }
    }

    private void MuteSound()
    {
        _soundImage.sprite = _muteSoundImage;
    }
    private void UnmuteSound()
    {
        _soundImage.sprite = _unmuteSoundImage;
    }
}