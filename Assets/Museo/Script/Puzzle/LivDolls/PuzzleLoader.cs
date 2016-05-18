using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleLoader : MonoBehaviour {
	
	public TextAsset[] levels;
	private static Dictionary<string, string> mDictionary;
	public static float RESOLUTION_MULTIPLIER;
	
	private static UIAtlas mainAtlas;
	private static UIAtlas partAtlas;
	private static UIFont mainFont;
	private static UIFont secondaryFont;
	
	public static bool isHD;
	public static bool isUHD;
	public static bool isSD;
	private static float height;
	
	public UILabel label;
	public bool debugMode;
	
	static PuzzleLoader mInst;
	
	public static int currentLevel;
	
	static public PuzzleLoader instance
	{
		get
		{
			if (mInst == null)
			{
				mInst = Object.FindObjectOfType(typeof(PuzzleLoader)) as PuzzleLoader;

				if (mInst == null)
				{
					GameObject go = new GameObject("_PuzzleLoader");
					DontDestroyOnLoad(go);
					mInst = go.AddComponent<PuzzleLoader>();
				}
			}
			return mInst;
		}
	}
	
	void Awake () { 
		if (mInst == null) {
			mInst = this;
			currentLevel = 1;
			LoadAtlas();
		}else{
			Destroy(this.gameObject);
		}
			
	}
	
	public void LoadAtlas(){
		mainAtlas = Resources.Load("Atlas/LivDolls/Main Atlas", typeof(UIAtlas)) as UIAtlas;
		partAtlas = Resources.Load("Atlas/LivDolls/Parts Atlas", typeof(UIAtlas)) as UIAtlas;
		mainFont = Resources.Load("Fonts/LivDolls/Main Font", typeof(UIFont)) as UIFont;
		secondaryFont = Resources.Load("Fonts/LivDolls/Secondary Font", typeof(UIFont)) as UIFont;
				
		CheckAtlasToLoad();	
		ResizeEverything();
	}
	
	public static void SwitchToSD(){
		partAtlas.pixelSize = 0.6f;
		mainAtlas.pixelSize = 0.6f;
		UIFont goFont = Resources.Load("Fonts/LivDolls/FontHD", typeof(UIFont)) as UIFont;
		mainFont.replacement = goFont;	
		goFont = Resources.Load("Fonts/LivDolls/FontHD2", typeof(UIFont)) as UIFont;
		secondaryFont.replacement = goFont;
		isSD = true;
		isHD = false;
		isUHD = false;
		height = 320;		
	}
	
	public static void SwitchToHD(){
		partAtlas.pixelSize = 0.89f;
		mainAtlas.pixelSize = 0.89f;			
		UIFont goFont = Resources.Load("Fonts/LivDolls/FontHD", typeof(UIFont)) as UIFont;
		mainFont.replacement = goFont;	
		goFont = Resources.Load("Fonts/LivDolls/FontHD2", typeof(UIFont)) as UIFont;
		secondaryFont.replacement = goFont;
		isHD = true;
		isSD = false;
		isUHD = false;
		height = 480;
	}
	
	public static void SwitchToUHD(){
		partAtlas.pixelSize = 1;
		mainAtlas.pixelSize = 1;			
		UIFont goFont = Resources.Load("Fonts/LivDolls/FontHD", typeof(UIFont)) as UIFont;
		mainFont.replacement = goFont;	
		goFont = Resources.Load("Fonts/LivDolls/FontHD2", typeof(UIFont)) as UIFont;
		secondaryFont.replacement = goFont;
		isUHD = true;
		isSD = false;
		isHD = false;
		height = 540;
	}
	
	private static void CheckAtlasToLoad(){
		if(Screen.height == 320){
			SwitchToSD();	
		}else if(Screen.height == 480){	
			SwitchToHD();
		}else if(Screen.height == 540){
			SwitchToUHD();	
		}else{
			SwitchToHD();	
		}
		
		RESOLUTION_MULTIPLIER = mainAtlas.pixelSize;
	}
	
	public static void ResetRoot(){
		NGUITools.Broadcast("ResetRoot", height);	
	}
	
	private void ResizeEverything(){
		if(debugMode){
			label.text = "Height: " + height + " PixRtio: " + mainAtlas.pixelSize;
		}		
		NGUITools.Broadcast("MakePixelPerfect");
		NGUITools.Broadcast("ResizeButton");
		NGUITools.Broadcast("ResizeLabel");
		//NGUITools.Broadcast("ResetRoot", height);
	}
	
	public void LoadLevelAtlas(){
	    UIAtlas goAtlas = Resources.Load("Atlas/LivDolls/Level"+currentLevel+"HD", typeof(UIAtlas)) as UIAtlas;
		float pS = partAtlas.pixelSize;
		partAtlas.replacement = goAtlas;
		partAtlas.pixelSize = pS;
	}
	
	public void LoadData(){
		mDictionary = new Dictionary<string, string>();
		ByteReader reader = new ByteReader(levels[currentLevel-1]);
		mDictionary = reader.ReadDictionary();
	}
	
	public string Get (string key)
	{
		string val;
		return (mDictionary.TryGetValue(key, out val)) ? val : key;
	}
	
	
	
}
