using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

public class ScriptReader {
	private TextReader reader;
	private string _command;
	private List<string> _arguments;

	/// <summary>
	/// 取得した命令を示します。
	/// </summary>
	public string command {
		get { return _command; }
		private set { _command = value; }
	}

	/// <summary>
	/// 取得した引数リストを示します。
	/// </summary>
	public List<string> arguments {
		get { return _arguments; }
		private set { _arguments = value; }
	}

	public ScriptReader() {
        if(Ending.ura==false) {
            reader = new StringReader(((TextAsset)Resources.Load("Script")).text);
        } else {
            reader = new StringReader(((TextAsset)Resources.Load("Script2")).text);
        }
	}

	/// <summary>
	/// スクリプトファイルから命令を一つ読み込み、その内容をcommandおよびargumentsに格納します。
	/// </summary>
	/// <returns>スクリプトの末尾に到達した場合、falseを返します。</returns>
	public bool ReadScript() {
		const string pattern = @"(.+?)\((.*?)\)";

		string script = reader.ReadLine();
		if(script==null) {
			return false;
		}
		command = Regex.Replace(script, pattern, "$1");

		string arg = Regex.Replace(script, pattern, "$2");
		arg = Regex.Replace(arg, "\\\"([^,]*?)\\\"", "$1");
		arguments = arg.Split(',').ToList();


		return true;
	}

}
