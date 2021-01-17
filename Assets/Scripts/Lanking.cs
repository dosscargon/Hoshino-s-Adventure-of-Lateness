using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Lanking {
	const int VER = 101;

	public List<Data> lankList = new List<Data>();//現在のステージのランキング
	public List<List<Data>> internalLankList = new List<List<Data>>();//ランキングリストを集めたもの
	public string mode { get; set; }
	static Lanking instance = null;
	//Savedata savedata;

	string[] stages = new string[] {"A","B","C","EX_A", "EX_B", "EX_C" };

	public int clearStageNumber;

    public int playingStageNumber {
        get {
            return Array.IndexOf(stages, mode);
        }
    }

	static public Lanking getInstance() {
		if(instance==null) {
			instance = new Lanking();
		}
		return instance;
	}

    public void DeleteAll() {
        PlayerPrefs.DeleteAll();
        
        instance = new Lanking();
    }

	public Lanking() {
		bool dataError = false;

		clearStageNumber = PlayerPrefs.GetInt("clearStageNumber", 0);

		lankList.Clear();
		lankList.Add(new Data("セリーヌ", 120 * 60));
		lankList.Add(new Data("つぐるん", 130 * 60));
		lankList.Add(new Data("バンダナ", 140 * 60));
		lankList.Add(new Data("寿甘", 150 * 60));
		lankList.Add(new Data("れんじ", 160 * 60));

		LoadSavedata(PlayerPrefs.GetString("lanks"));


		if(internalLankList.Count<3) {
			dataError = true;
		}
		foreach(var lankList in internalLankList) {
			if(lankList.Count<5) {
				dataError = true;
			}
		}

		if (dataError)
		{
			
			for (int i = 0; i < stages.Length; i++)
			{
				internalLankList.Add(new List<Data>(lankList));
			}
		}

	}

	public void LoadLank(string list) {
		lankList = new List<Data>(internalLankList[Array.IndexOf(stages,list)]);
		//playingStageNumber = Array.IndexOf(stages, list);

	}

	public void SaveLank(string list) {
		internalLankList[Array.IndexOf(stages, list)] = new List<Data>(lankList);

		PlayerPrefs.SetString("lanks", MakeSavedata());
		PlayerPrefs.Save();
	}

	public void add(Data data) {
		lankList.Add(data);
		lankList.Sort((a, b)=>(a.time - b.time));
		lankList.Remove(lankList[5]);
	}


	public string MakeSavedata() {
		SerializableStringList individualLanks = new SerializableStringList();
		SerializableStringList individualDatas = new SerializableStringList();
		foreach (var lanklist in internalLankList)
		{
			individualDatas.item.Clear();
			foreach (var data in lanklist)
			{
				individualDatas.item.Add(JsonUtility.ToJson(data));
			}
			individualLanks.item.Add(JsonUtility.ToJson(individualDatas));
		}

		Debug.Log(JsonUtility.ToJson(individualLanks));
		return JsonUtility.ToJson(individualLanks);
	}

	public void LoadSavedata(string json) {
		SerializableStringList individualDatas;
		SerializableStringList individualLanks = JsonUtility.FromJson<SerializableStringList>(json);
		List<Data> lankList = new List<Data>();

		if(individualLanks==null) {
			individualLanks = new SerializableStringList();
		}
		internalLankList.Clear();

		foreach(var datas in individualLanks.item) {
			individualDatas = JsonUtility.FromJson<SerializableStringList>(datas);
			foreach(var data in individualDatas.item) {
				lankList.Add(JsonUtility.FromJson<Data>(data));
			}
			internalLankList.Add(new List<Data>(lankList));
			lankList.Clear();
		}
	}
	
	[Serializable]
	class SerializableStringList {
		public List<string> item;

		public SerializableStringList(List<string> instance) {
			item = instance;
		}
		public SerializableStringList() {
			item = new List<string>();
		}
	}

	public void updateCSN() {
		if(Array.IndexOf(stages,mode)>clearStageNumber) {
			clearStageNumber = Array.IndexOf(stages, mode);
		}
	}
	
	public void updateClearStageNumber() {
		if (clearStageNumber <= Array.IndexOf(stages, mode))  {
			clearStageNumber = Array.IndexOf(stages, mode) + 1;
		}
		PlayerPrefs.SetInt("clearStageNumber", clearStageNumber);
	}
}
