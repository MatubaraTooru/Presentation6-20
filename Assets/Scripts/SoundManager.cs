using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static public SoundManager _soundManager;

    [System.Serializable]
    public class SoundData
    {
        public string key;
        public AudioClip clip;
        public float volume;
    }

    [Header("再生するサウンドのデータ")]
    [SerializeField] SoundData[] _datas;
    [Header("再生する間隔")]
    [SerializeField] float _distance;

    // 最後に音を鳴らした時刻
    float _last;

    AudioSource[] _audioSources = new AudioSource[15];
    Dictionary<string, SoundData> _soundDic = new Dictionary<string, SoundData>();

    void Awake()
    {
        _soundManager = this;
        DontDestroyOnLoad(gameObject);


        for (int i = 0; i < _audioSources.Length; ++i)
            _audioSources[i] = gameObject.AddComponent<AudioSource>();

        foreach (SoundData sd in _datas)
            _soundDic.Add(sd.key, sd);
    }

    // 空いているAudioSourceを取得
    AudioSource GetAudioSource()
    {
        for (int i = 0; i < _audioSources.Length; ++i)
            if (!_audioSources[i].isPlaying)
                return _audioSources[i];
        return null;
    }

    // 再生
    public void Play(AudioClip clip, float volume)
    {
        AudioSource source = GetAudioSource();
        if (source == null)
        {
            Debug.LogWarning("空きがないので再生できません:" + clip.name);
            return;
        }
        source.volume = volume;
        source.clip = clip;
        source.Play();
    }

    // キーから再生
    public void Play(string key)
    {
        if (_soundDic.TryGetValue(key, out SoundData data))
        {
            if (Time.realtimeSinceStartup - _last < _distance) return;
            _last = Time.realtimeSinceStartup;
            Play(data.clip, data.volume);
        }
        else Debug.LogWarning("登録されていません:" + key);
    }

    // 鳴っている音を全部止める
    public void StopAll()
    {
        foreach (AudioSource source in _audioSources)
            source.Stop();
    }
}