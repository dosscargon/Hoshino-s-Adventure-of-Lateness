using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Data
{
	public string name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}
	public int time {
		get {
			return _time;
		}
		set {
			_time = value;
		}
	}

	[SerializeField]
	private string _name;
	[SerializeField]
	private int _time;

	public Data(string name, int time)
	{
		this.name = name;
		this.time = time;
	}
}
