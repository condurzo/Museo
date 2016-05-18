using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataLoader : MonoBehaviour {
	
	private static Dictionary<string, Dictionary<string,string>> mDictionary;	
	static DataLoader mInst;
	private TextAsset dataAsset;

	static public DataLoader instance
	{
		get
		{
			if (mInst == null)
			{
				mInst = Object.FindObjectOfType(typeof(DataLoader)) as DataLoader;

				if (mInst == null)
				{
					GameObject go = new GameObject("_DataLoader");
					DontDestroyOnLoad(go);
					mInst = go.AddComponent<DataLoader>();
				}
			}
			return mInst;
		}
	}
	
	void Awake () { 
		if (mInst == null) {
			mInst = this;
			string width = Screen.width.ToString();
			//dataAsset = Resources.Load("Data/"+width+"/data", typeof(TextAsset)) as TextAsset;
			dataAsset = Resources.Load("Data/800/data", typeof(TextAsset)) as TextAsset;
			if(dataAsset == null) dataAsset = Resources.Load("Data/800/data", typeof(TextAsset)) as TextAsset;
			LoadData();
		}else{
			Destroy(this.gameObject);
		}			
	}
	
	public void LoadData(){
		mDictionary = new Dictionary<string, Dictionary<string,string>>();
		ByteReaderCustom reader = new ByteReaderCustom(dataAsset);
		mDictionary = reader.ReadDictionary();
	}
	
	public Dictionary<string,string> Get (string key)
	{
		Dictionary<string,string> val;
		if(mDictionary.TryGetValue(key, out val)){
			val = mDictionary[key];
		}else{
			val = null;
		}	
		return val;
	}	
}
