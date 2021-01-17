using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour {

    public GameObject audioParent;
    AudioSource audioSource;

    public Text numberText;
    public Text soundInfoText;

    [System.Serializable]
    public class SoundData {
        public AudioClip sound;
        [Multiline]
        public string text;
        public int needStageNumber;
    }

    [SerializeField]
    public List<SoundData> sounds;

    int selectNumber = -1;

    // Use this for initialization
    void Start () {
        audioSource = audioParent.GetComponent<AudioSource>();
        ChangeSelectNumber(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSelectNumber(int dif) {
        do {
            selectNumber += dif;
            selectNumber += sounds.Count;
            selectNumber %= sounds.Count;
        } while (sounds[selectNumber].needStageNumber > Lanking.getInstance().clearStageNumber);

        numberText.text = (selectNumber + 1).ToString();
        soundInfoText.text = sounds[selectNumber].text;
    }

    public void PlayMusic() {
        audioSource.clip = sounds[selectNumber].sound;
        audioSource.Play();
    }
}
