using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [Header("声音设置")]
    public AudioClip soundClip; 
    public AudioSource audioSource; 
    
    [Header("按钮设置")]
    public Button button; 
    
    [Header("音量设置")]
    [Range(0f, 1f)]
    public float volume = 1f;
    
    void Start()
    {
        
        if (button == null)
            button = GetComponent<Button>();
            
        
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
            
        
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
            
        
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
        
       
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogWarning("SoundButton: 未找到按钮组件！");
        }
    }
    
    void PlaySound()
    {
        if (soundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("SoundButton: 缺少声音片段或音频源！");
        }
    }
    
    
    void OnValidate()
    {
        if (audioSource != null)
            audioSource.volume = volume;
    }
}