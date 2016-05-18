using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleController : MonoBehaviour {
	
	public static PuzzleController instance;
	public static bool soundOn;
	
	public GameObject menuAnchor;
	public GameObject gameAnchor;
	public GameObject helpAnchor;
	public GameObject exitAnchor;
	public GameObject endAnchor;
	public GameObject levelWinAnchor;
	
	public bool menuOpened;
	public bool helpOpened;
	public bool gameOpened;
	public bool exitOpened;
	public bool endOpened;
	public bool levelWinOpened;
	
	public int cantPieces;
	public int width;
	public int height;
	public float pieceSize;
	public UIAtlas puzzleAtlas;
	public Vector2 freeSpace;	
	public Transform panelPivot;	
	public int scrambleSteps;	
	private UISprite freeSprite;
	private PuzzlePiece freePiece;
	private Vector2 freeId;
	public UILabel levelLabel;
	public Transform previewPivot;
	public Transform previewPivotStatic;
	public int cantLevels;
	
	public int imagePreviewOpenOffsetX;
	public int imagePreviewOpenOffsetY;
	public float imagePreviewOpenScaleX = 1;
	public float imagePreviewOpenScaleY = 1;
	
	public GameObject stagesSprite;
	
	private List<PuzzlePiece> piecesList;	
	private PuzzlePiece[,] piecesMatrix;
	
	private bool previewOpened;
	
	TweenColor buttonT;
	
	public GameObject linePrefab;
	
	public GameObject[] fireworksArray;
	private float fireworksTimer = float.MaxValue;
	private float fireworksInterval = 1;
	private bool fireworksShowing = false;
	
	bool xMovementRight;
	bool xMovementLeft;
	bool yMovementTop;
	bool yMovementBottom;
	Vector3 initialMPosition;
	Vector2 initialPPosition;
	PuzzlePiece pieceSelected;
	
	bool gameFinished;
	bool gameStarted;
	
	int piecesErased;
	
	float pieceSizeDefault;
	float pieceDifference;
	
	UISprite spritePreviewStatic;
	
	public GameObject stageIndicator;
	
	void Awake(){
		instance = this;
		Input.multiTouchEnabled = false;
	}
	
	void Start(){
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		TimerHandler.instance.StartTimerHandler();		
		PuzzleLoader.instance.LoadData();
		PuzzleLoader.instance.LoadLevelAtlas();
		cantPieces = int.Parse(PuzzleLoader.instance.Get("Amount"));
		width = int.Parse(PuzzleLoader.instance.Get("Col"));
		height = int.Parse(PuzzleLoader.instance.Get("Row"));
		pieceSize = int.Parse(PuzzleLoader.instance.Get("Size")) * PuzzleLoader.RESOLUTION_MULTIPLIER;
		scrambleSteps = int.Parse(PuzzleLoader.instance.Get("Iterations"));
		piecesList = new List<PuzzlePiece>();
		piecesMatrix = new PuzzlePiece[width,height];
		
		pieceSizeDefault = pieceSize;
		gameStarted = false;
		
		levelLabel.text = "" + PuzzleLoader.currentLevel;
		xMovementLeft = false;
		xMovementRight = false;
		yMovementTop = false;
		yMovementBottom = false;
		previewOpened = false;	
		gameFinished = false;
		piecesErased = 0;
		soundOn = true;
		iTween.Init(previewPivot.gameObject);
		
		StartScreen("Menu");
		PuzzleLoader.ResetRoot();
		SoundManager.PlayMusic("GameMusic");
	}
	
	void OnPlayClicked(){
		levelLabel.text = "" + PuzzleLoader.currentLevel;
		if(!gameStarted){
			gameStarted = true;
			StartScreen("Game");
			CreatePieces();
			ScrambleBoard();
			stageIndicator.transform.localPosition = new Vector3(0.98f, 13.6f, 0);
		}else{
			StartScreen("Game");
		}	
	}
	
	void OnHelpClicked(){
		StartScreen("Help");	
	}
	
	void OnExitAccepted(){
		Screen.orientation = ScreenOrientation.AutoRotation;
		Application.LoadLevel ("Juegos");
	}
	
	void OnExitCancelled(){
		StartScreen("Menu");
	}

	void OnExit(){
		StartScreen("Exit");
	}
	
	void StartScreen(string screen){
		switch(screen){
			case "Menu":
				menuOpened = true;
				gameOpened = false;
				helpOpened = false;
				exitOpened = false;
				endOpened = false;
				levelWinOpened = false;
				if(!menuAnchor.activeInHierarchy){
					menuAnchor.SetActive(true);
				}
				if(gameAnchor.activeInHierarchy){
					gameAnchor.SetActive(false);
				}
				if(helpAnchor.activeInHierarchy){
					helpAnchor.SetActive(false);
				}	
				if(exitAnchor.activeInHierarchy){
					exitAnchor.SetActive(false);
				}
				if(endAnchor.activeInHierarchy){
					endAnchor.SetActive(false);
				}
				if(levelWinAnchor.activeInHierarchy){
					levelWinAnchor.SetActive(false);	
				}
			break;
			case "Game":
				menuOpened = false;
				gameOpened = true;
				helpOpened = false;
				exitOpened = false;
				endOpened = false;
				levelWinOpened = false;
				if(menuAnchor.activeInHierarchy){
					menuAnchor.SetActive(false);
				}
				if(!gameAnchor.activeInHierarchy){
					gameAnchor.SetActive(true);
				}
				if(helpAnchor.activeInHierarchy){
					helpAnchor.SetActive(false);
				}
				if(exitAnchor.activeInHierarchy){
					exitAnchor.SetActive(false);
				}
				if(endAnchor.activeInHierarchy){
					endAnchor.SetActive(false);
				}
				if(levelWinAnchor.activeInHierarchy){
					levelWinAnchor.SetActive(false);	
				}
			break;
			case "Help":
				menuOpened = false;
				gameOpened = false;
				helpOpened = true;
				exitOpened = false;
				endOpened = false;
				levelWinOpened = false;
				if(menuAnchor.activeInHierarchy){
					menuAnchor.SetActive(false);
				}
				if(gameAnchor.activeInHierarchy){
					gameAnchor.SetActive(false);
				}
				if(!helpAnchor.activeInHierarchy){
					helpAnchor.SetActive(true);
				}
				if(exitAnchor.activeInHierarchy){
					exitAnchor.SetActive(false);
				}	
				if(endAnchor.activeInHierarchy){
					endAnchor.SetActive(false);
				}
				if(levelWinAnchor.activeInHierarchy){
					levelWinAnchor.SetActive(false);	
				}
			break;
			case "Exit":
				menuOpened = false;
				gameOpened = false;
				helpOpened = false;
				exitOpened = true;
				endOpened = false;
				levelWinOpened = false;
				if(menuAnchor.activeInHierarchy){
					menuAnchor.SetActive(false);
				}
				if(gameAnchor.activeInHierarchy){
					gameAnchor.SetActive(false);
				}
				if(helpAnchor.activeInHierarchy){
					helpAnchor.SetActive(false);
				}
				if(!exitAnchor.activeInHierarchy){
					exitAnchor.SetActive(true);
				}
				if(endAnchor.activeInHierarchy){
					endAnchor.SetActive(false);
				}
				if(levelWinAnchor.activeInHierarchy){
					levelWinAnchor.SetActive(false);	
				}
			break;
			case "End":
				menuOpened = false;
				gameOpened = false;
				helpOpened = false;
				exitOpened = false;
				endOpened = true;
				levelWinOpened = false;		
				if(menuAnchor.activeInHierarchy){
					menuAnchor.SetActive(false);
				}
				if(gameAnchor.activeInHierarchy){
					gameAnchor.SetActive(false);
				}
				if(helpAnchor.activeInHierarchy){
					helpAnchor.SetActive(false);
				}
				if(exitAnchor.activeInHierarchy){
					exitAnchor.SetActive(false);
				}
				if(!endAnchor.activeInHierarchy){
					endAnchor.SetActive(true);
				}
				if(levelWinAnchor.activeInHierarchy){
					levelWinAnchor.SetActive(false);	
				}
			break;
			case "LevelWin":
			menuOpened = false;
			gameOpened = false;
			helpOpened = false;
			exitOpened = false;
			endOpened = false;
			levelWinOpened = true;
			if(menuAnchor.activeInHierarchy){
				menuAnchor.SetActive(false);
			}
			if(gameAnchor.activeInHierarchy){
				gameAnchor.SetActive(false);
			}
			if(helpAnchor.activeInHierarchy){
				helpAnchor.SetActive(false);
			}	
			if(exitAnchor.activeInHierarchy){
				exitAnchor.SetActive(false);
			}
			if(endAnchor.activeInHierarchy){
				endAnchor.SetActive(false);
			}
			if(!levelWinAnchor.activeInHierarchy){
				levelWinAnchor.SetActive(true);	
			}
			break;
		}
		
		NGUITools.Broadcast("MakePixelPerfect");
		NGUITools.Broadcast("ResizeButton");
		NGUITools.Broadcast("ResizeLabel");
	}
	
	void RestartLevel(){
		PuzzleLoader.currentLevel += 1;				
		if(PuzzleLoader.currentLevel > cantLevels){
			StartScreen("End");
		}else{
			levelLabel.text = "" + PuzzleLoader.currentLevel;
			int cant = panelPivot.GetChildCount();
			for (int i = 0; i < cant; i++) {
				Destroy(panelPivot.GetChild(i).gameObject);			
			}
			DestroyImmediate(previewPivot.GetChild(0).gameObject);
			DestroyImmediate(previewPivotStatic.GetChild(0).gameObject);		
			PuzzleLoader.instance.LoadData();
			PuzzleLoader.instance.LoadLevelAtlas();
			cantPieces = int.Parse(PuzzleLoader.instance.Get("Amount"));
			width = int.Parse(PuzzleLoader.instance.Get("Col"));
			height = int.Parse(PuzzleLoader.instance.Get("Row"));
			pieceSize = int.Parse(PuzzleLoader.instance.Get("Size")) * PuzzleLoader.RESOLUTION_MULTIPLIER;
			scrambleSteps = int.Parse(PuzzleLoader.instance.Get("Iterations"));
			piecesList = new List<PuzzlePiece>();
			piecesMatrix = new PuzzlePiece[width,height];			
			previewOpened = false;	
			gameFinished = false;
			piecesErased = 0;		
			CreatePieces();		
			ScrambleBoard();
			iTween.MoveTo(previewPivot.gameObject, iTween.Hash("x", previewPivot.GetComponent<PositionItem>().GetPos().x, "y", previewPivot.GetComponent<PositionItem>().GetPos().y, "isLocal", true, "time", 0.2f));
		}
	}
	
	void ResetGame(){
		PuzzleLoader.currentLevel = 1;
		int cant = panelPivot.GetChildCount();
		for (int i = 0; i < cant; i++) {
			Destroy(panelPivot.GetChild(i).gameObject);			
		}
		if(previewPivot.childCount > 0){
			DestroyImmediate(previewPivot.GetChild(0).gameObject);
		}
		if(previewPivotStatic.childCount > 0){
			DestroyImmediate(previewPivotStatic.GetChild(0).gameObject);
		}
		PuzzleLoader.instance.LoadData();
		PuzzleLoader.instance.LoadLevelAtlas();
		cantPieces = int.Parse(PuzzleLoader.instance.Get("Amount"));
		width = int.Parse(PuzzleLoader.instance.Get("Col"));
		height = int.Parse(PuzzleLoader.instance.Get("Row"));
		pieceSize = int.Parse(PuzzleLoader.instance.Get("Size")) * PuzzleLoader.RESOLUTION_MULTIPLIER;
		scrambleSteps = int.Parse(PuzzleLoader.instance.Get("Iterations"));
		piecesList = new List<PuzzlePiece>();
		piecesMatrix = new PuzzlePiece[width,height];
		previewOpened = false;	
		gameFinished = false;
		gameStarted = false;
		piecesErased = 0;
		
		stagesSprite.transform.Find("Level1").gameObject.SetActive(false);
		stagesSprite.transform.Find("Level2").gameObject.SetActive(false);
		stagesSprite.transform.Find("Level3").gameObject.SetActive(false);
		endFireWorks();
		
		stageIndicator.transform.localPosition = new Vector3(0.98f, 13.6f, 0);
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(menuOpened){
				StartScreen("Exit");
			}else if(gameOpened && !gameFinished){
				StartScreen("Menu");
				ResetGame();
			}else if(helpOpened){
				ResetGame();
				StartScreen("Menu");	
			}else if(exitOpened){
				StartScreen("Menu");	
			}else if(endOpened){
				ResetGame();
				StartScreen("Menu");
			}
		}
		
		if(fireworksShowing)
		{
			if(fireworksTimer >= fireworksInterval)
			{
				fireworksTimer = 0;
				spawnFireworks();
			}
			else
			{
				fireworksTimer += Time.deltaTime;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.C)){
			CheckBoard();	
		}
		
		if(gameOpened){		
			if(xMovementRight){
				pieceSelected.gameObject.transform.localPosition = new Vector3(((Input.mousePosition.x - initialMPosition.x) + initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, (-initialPPosition.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				if(pieceSelected.transform.localPosition.x > ((freePiece.pos.x * pieceSize) + pieceSize) - pieceSizeDefault - pieceDifference){				
					pieceSelected.gameObject.transform.localPosition = new Vector3((initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, (-initialPPosition.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}else if(pieceSelected.transform.localPosition.x < (freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference){
					pieceSelected.gameObject.transform.localPosition = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}
			}else if(xMovementLeft){
				pieceSelected.gameObject.transform.localPosition = new Vector3(((Input.mousePosition.x - initialMPosition.x) + initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, (-initialPPosition.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				if(pieceSelected.transform.localPosition.x < ((freePiece.pos.x * pieceSize) - pieceSize) - pieceSizeDefault - pieceDifference){				
					pieceSelected.gameObject.transform.localPosition = new Vector3((initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, (-initialPPosition.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}else if(pieceSelected.transform.localPosition.x > (freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference){
					pieceSelected.gameObject.transform.localPosition = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}
			}else if(yMovementTop){
				pieceSelected.gameObject.transform.localPosition = new Vector3((initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, ((Input.mousePosition.y - initialMPosition.y) - (initialPPosition.y * pieceSize)) + pieceSizeDefault + pieceDifference, 0);
				if(pieceSelected.transform.localPosition.y > ((-freePiece.pos.y * pieceSize) + pieceSize) + pieceSizeDefault + pieceDifference){				
					pieceSelected.gameObject.transform.localPosition = new Vector3((initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, (-initialPPosition.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}else if(pieceSelected.transform.localPosition.y < (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference){
					pieceSelected.gameObject.transform.localPosition = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}
			}else if(yMovementBottom){
				pieceSelected.gameObject.transform.localPosition = new Vector3((initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, ((Input.mousePosition.y - initialMPosition.y) - (initialPPosition.y * pieceSize)) + pieceSizeDefault + pieceDifference, 0);
				if(pieceSelected.transform.localPosition.y < ((-freePiece.pos.y * pieceSize) - pieceSize) + pieceSizeDefault + pieceDifference){				
					pieceSelected.gameObject.transform.localPosition = new Vector3((initialPPosition.x * pieceSize) - pieceSizeDefault - pieceDifference, (-initialPPosition.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}else if(pieceSelected.transform.localPosition.y > (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference){
					pieceSelected.gameObject.transform.localPosition = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
				}	
			}
		}
	}
	
	public void DeselectPiece(){
		if(pieceSelected == null) return;
		Vector3 freePieceVector = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
		float distance = Vector2.Distance(pieceSelected.transform.localPosition, freePieceVector);
		Vector3 freeTarget;
		Vector3 pieceTarget;
		if(distance <= pieceSize / 2){
			pieceTarget = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
			freeTarget = new Vector3((pieceSelected.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-pieceSelected.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);			
			Vector2 aux;
			aux = freePiece.pos;
			freePiece.pos = pieceSelected.pos;
			pieceSelected.pos = aux;
			PuzzlePiece auxP;
			auxP = piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y];
			piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y] = piecesMatrix[(int)pieceSelected.pos.x, (int)pieceSelected.pos.y];
			piecesMatrix[(int)pieceSelected.pos.x, (int)pieceSelected.pos.y] = auxP;
			freeSprite.transform.localPosition = freeTarget;
			//pieceSelected.transform.localPosition = pieceTarget;
			Check(pieceSelected);
			SoundManager.PlaySound("MovePiece",1);
			//iTween.MoveTo(freeSprite.gameObject, iTween.Hash("position", freeTarget, "time", 0.1f, "islocal", true));
			iTween.MoveTo(pieceSelected.gameObject, iTween.Hash("position", pieceTarget, "time", 0.3f, "islocal", true, "easetype", iTween.EaseType.easeOutSine));
		}else{
			pieceTarget = new Vector3((pieceSelected.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-pieceSelected.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
			iTween.MoveTo(pieceSelected.gameObject, iTween.Hash("position", pieceTarget, "time", 0.3f, "islocal", true, "easetype", iTween.EaseType.easeOutSine));
			//freeSprite.transform.localPosition = freeTarget;
			//pieceSelected.transform.localPosition = pieceTarget;
		}
		xMovementLeft = false;
		xMovementRight = false;
		yMovementTop = false;
		yMovementBottom = false;
		pieceSelected = null;
	}
			
	public void SelectPiece(PuzzlePiece piece){
		if(gameFinished) return;
		if(piece.id == freeId){
			return;
		}else if(pieceSelected != null){
			return;	
		}
		
		if(piece.pos.x - 1 == freePiece.pos.x && piece.pos.y == freePiece.pos.y){
			xMovementRight = true;
		}else if(piece.pos.x + 1 == freePiece.pos.x && piece.pos.y == freePiece.pos.y){
			xMovementLeft = true;
		}else if(piece.pos.x == freePiece.pos.x && piece.pos.y - 1 == freePiece.pos.y){
			yMovementBottom = true;
		}else if(piece.pos.x == freePiece.pos.x && piece.pos.y + 1 == freePiece.pos.y){
			yMovementTop = true;
		}
		
		pieceSelected = piece;
		
		if(xMovementLeft || xMovementRight){
			initialMPosition = Input.mousePosition;
			initialPPosition = piece.pos;
		}else if(yMovementBottom || yMovementTop){
			initialMPosition = Input.mousePosition;
			initialPPosition = piece.pos;	
		}
	}	
			
	public void MovePiece(PuzzlePiece piece){
		if(piece.id == freeId){
			return;
		}
	
		bool moveDetected = false;
		Vector3 freeTarget;
		Vector3 pieceTarget;
		
		if(piece.pos.x - 1 == freePiece.pos.x && piece.pos.y == freePiece.pos.y){
			moveDetected = true;
		}else if(piece.pos.x + 1 == freePiece.pos.x && piece.pos.y == freePiece.pos.y){
			moveDetected = true;
		}else if(piece.pos.x == freePiece.pos.x && piece.pos.y - 1 == freePiece.pos.y){
			moveDetected = true;
		}else if(piece.pos.x == freePiece.pos.x && piece.pos.y + 1 == freePiece.pos.y){
			moveDetected = true;
		}
		
		if(moveDetected){			
			pieceTarget = new Vector3(freePiece.pos.x * pieceSize, -freePiece.pos.y * pieceSize, 0);
			freeTarget = new Vector3(piece.pos.x * pieceSize, -piece.pos.y * pieceSize, 0);			
			Vector2 aux;
			aux = freePiece.pos;
			freePiece.pos = piece.pos;
			piece.pos = aux;
			PuzzlePiece auxP;
			auxP = piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y];
			piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y] = piecesMatrix[(int)piece.pos.x, (int)piece.pos.y];
			piecesMatrix[(int)piece.pos.x, (int)piece.pos.y] = auxP;
			//iTween.MoveTo(freeSprite.gameObject, iTween.Hash("position", freeTarget, "time", 0.1f, "islocal", true));
			//iTween.MoveTo(piece.gameObject, iTween.Hash("position", pieceTarget, "time", 0.1f, "islocal", true, "oncomplete", "Check", "oncompletetarget", this.gameObject, "oncompleteparams", piece));
		}
	}
	
	void ScrambleBoard(){
		bool tryMove;
		int direction;
		pieceDifference = (pieceSizeDefault - pieceSize) / 2;
		Vector3 freeTarget, pieceTarget;
		
		for (int i = 0; i < scrambleSteps; i++) {
			tryMove = false;
			while(!tryMove){
				direction = Random.Range(0,4);
				PuzzlePiece piece = null;
				switch(direction){
				case 0:		
					//sprite.transform.localPosition = new Vector3((pieceSize * (i % width)) - pieceSize, (pieceSize * -h) + pieceSize , 0);
					if(freePiece.pos.y - 1 >= 0){
						piece = GetPiece(freePiece.pos.x, freePiece.pos.y - 1);	
						//freeTarget = new Vector3(piece.pos.x * pieceSize, -piece.pos.y * pieceSize, 0);
						/*//freeTarget = new Vector3(piece.pos.x / 2 * pieceSize - (pieceSize * 0.5f), - piece.pos.y * pieceSize + (pieceSize * 0.5f), 0);
						//pieceTarget = new Vector3(freePiece.pos.x / 2 * pieceSize - (pieceSize * 0.5f), -freePiece.pos.y * pieceSize + (pieceSize * 0.5f), 0);
						Vector2 aux;
						aux = freePiece.pos;
						freePiece.pos = piece.pos;
						piece.pos = aux;
						PuzzlePiece auxP;
						auxP = piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y];
						piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y] = piecesMatrix[(int)piece.pos.x, (int)piece.pos.y];
						piecesMatrix[(int)piece.pos.x, (int)piece.pos.y] = auxP;
						freeSprite.transform.localPosition = freeTarget;
						piece.transform.localPosition = pieceTarget;*/
						tryMove = true;
					}
					break;
				case 1:
					if(freePiece.pos.y + 1 < height){
						piece = GetPiece(freePiece.pos.x, freePiece.pos.y + 1);						
						tryMove = true;
					}
					break;
				case 2:
					if(freePiece.pos.x + 1 < width){
						piece = GetPiece(freePiece.pos.x + 1, freePiece.pos.y);						
						tryMove = true;
					}
					break;
				case 3:
					if(freePiece.pos.x - 1 >= 0){
						piece = GetPiece(freePiece.pos.x - 1, freePiece.pos.y);			
						tryMove = true;
					}
					break;
				}
				if(tryMove){
					freeTarget = new Vector3((piece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-piece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
					pieceTarget = new Vector3((freePiece.pos.x * pieceSize) - pieceSizeDefault - pieceDifference, (-freePiece.pos.y * pieceSize) + pieceSizeDefault + pieceDifference, 0);
					Vector2 aux;
					aux = freePiece.pos;
					freePiece.pos = piece.pos;
					piece.pos = aux;
					PuzzlePiece auxP;
					auxP = piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y];
					piecesMatrix[(int)freePiece.pos.x, (int)freePiece.pos.y] = piecesMatrix[(int)piece.pos.x, (int)piece.pos.y];
					piecesMatrix[(int)piece.pos.x, (int)piece.pos.y] = auxP;
					freeSprite.transform.localPosition = freeTarget;
					piece.transform.localPosition = pieceTarget;
				}
			}
		}	
	}
	
	PuzzlePiece GetPiece(float posX, float posY){
		return piecesMatrix[(int)posX, (int)posY];
	}
	
	void CreatePieces(){		
		int h = -1;
		for (int i = 0; i < cantPieces; i++) {			
			UISprite sprite = NGUITools.AddSprite(panelPivot.gameObject, puzzleAtlas, "Part"+(i+1));
			sprite.name = "Part"+(i+1);
			sprite.MakePixelPerfect();
			if(i % width == 0){
				h++;
			}
			pieceDifference = (pieceSizeDefault - pieceSize) / 2;
			sprite.depth = (i+1);
			sprite.pivot = UIWidget.Pivot.Center;
			sprite.transform.localPosition = new Vector3((pieceSize * (i % width)) - (pieceSizeDefault + pieceDifference), (pieceSize * -h) + (pieceSizeDefault + pieceDifference) , 0);
			sprite.gameObject.AddComponent(typeof(BoxCollider));
			sprite.GetComponent<BoxCollider>().center = new Vector3(0,0,0);
			PuzzlePiece tempPiece = sprite.gameObject.AddComponent(typeof(PuzzlePiece)) as PuzzlePiece;
			tempPiece.id = new Vector2((i % width), h);
			tempPiece.pos = new Vector2((i % width), h);
			piecesMatrix[(i % width), h] = tempPiece;
			piecesList.Add(tempPiece);
			if(i == cantPieces - 1){
				freeSpace = new Vector2(i % width, h);
				freeSprite = sprite;
				freeSprite.depth = 0;
				freeId = new Vector2(i % width, h);
				freePiece = tempPiece;
			}
			//"oncomplete", "PieceArrived", "oncompletetarget", this.gameObject,
			iTween.ScaleFrom(tempPiece.gameObject, iTween.Hash("scale", Vector3.zero, "time", 2.5f, "isLocal", true, "delay", i * .2f, "easetype", iTween.EaseType.easeOutElastic));
		}
		
		piecesList[piecesList.Count -1].GetComponent<UISprite>().alpha = 0;
		
		spritePreviewStatic = NGUITools.AddSprite(previewPivotStatic.gameObject, puzzleAtlas, "Source");
		spritePreviewStatic.MakePixelPerfect();
		spritePreviewStatic.depth = cantPieces;
		spritePreviewStatic.pivot = UIWidget.Pivot.Center;
		spritePreviewStatic.alpha = .75f;		
		spritePreviewStatic.transform.localPosition = new Vector3(0, 0, 0);
		previewPivotStatic.transform.localScale = new Vector3(0.4f, 0.4f, 1);
		iTween.ScaleFrom(previewPivotStatic.gameObject, iTween.Hash("scale", Vector3.zero, "time", 1f, "isLocal", true, "easetype", iTween.EaseType.easeOutExpo));
		UISprite spritePreview = NGUITools.AddSprite(previewPivot.gameObject, puzzleAtlas, "Source");
		spritePreview.MakePixelPerfect();
		spritePreview.depth = cantPieces + 1;
		spritePreview.pivot = UIWidget.Pivot.Center;
		spritePreview.cachedTransform.localPosition = new Vector3(0, 0, 0);		
		iTween.ScaleFrom(spritePreview.gameObject, iTween.Hash("scale", Vector3.zero, "time", 1f, "isLocal", true, "easetype", iTween.EaseType.easeOutExpo));
		BoxCollider boxC = spritePreview.gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
		boxC.center = new Vector3(0,0,0);
		UIButtonMessage buttonM = spritePreview.gameObject.AddComponent(typeof(UIButtonMessage)) as UIButtonMessage;
		buttonM.functionName = "OnPreviewClicked";
		buttonM.target = this.gameObject;
		buttonT = spritePreview.gameObject.AddComponent(typeof(TweenColor)) as TweenColor;
		buttonT.from = new Color(255,255,255, 1);
		buttonT.to = new Color(255,255,255, .5f);
		buttonT.duration = 0.5f;
		buttonT.enabled = false;
		previewPivot.transform.localScale = new Vector3(0.4f, 0.4f, 1);		
	}
	
	void OnPreviewClicked(){
		if(gameFinished) return;
		if(previewOpened){
			previewOpened = false;
			iTween.ScaleTo(previewPivot.gameObject, iTween.Hash("x", .4, "y", .4, "time", 0.5f));
			iTween.MoveTo(previewPivot.gameObject, iTween.Hash("x", previewPivot.GetComponent<PositionItem>().GetPos().x, "y", previewPivot.GetComponent<PositionItem>().GetPos().y, "isLocal", true, "time", 0.5f));
			buttonT.Toggle();
			TimerHandler.instance.StopTimer("ClosePreview");			
		}else{
			previewOpened = true;
			iTween.ScaleTo(previewPivot.gameObject, iTween.Hash("x", imagePreviewOpenScaleX , "y", imagePreviewOpenScaleY, "time", 0.5f));
			iTween.MoveTo(previewPivot.gameObject, iTween.Hash("x", panelPivot.GetComponent<PositionItem>().GetPos().x + imagePreviewOpenOffsetX, "y", panelPivot.GetComponent<PositionItem>().GetPos().y + imagePreviewOpenOffsetY, "isLocal", true, "time", 0.5f));
			buttonT.Toggle();
			TimerHandler.instance.AddTimer(2.0f, "ClosePreview", this.gameObject);
		}
		SoundManager.PlaySound("PreviewClick",1);
	}
	
	void ClosePreview(){
		previewOpened = false;
		iTween.ScaleTo(previewPivot.gameObject, iTween.Hash("x", .4, "y", .4, "time", 0.5f));
		iTween.MoveTo(previewPivot.gameObject, iTween.Hash("x", previewPivot.GetComponent<PositionItem>().GetPos().x, "y", previewPivot.GetComponent<PositionItem>().GetPos().y, "isLocal", true, "time", 0.5f));
		buttonT.Toggle();
	}
	
	PuzzlePiece GetPuzzlePiece(float x, float y){
		int posX = (int)x;
		int posY = (int)y;
		
		if(posX >= width || posX < 0 || posY >= height || posY < 0) return null;
		
		return piecesMatrix[posX, posY];
	}
	
	void CheckAdjacents(PuzzlePiece piece){
		PuzzlePiece tempPiece;
		
		GameObject go;
		
		tempPiece = GetPuzzlePiece(piece.pos.x + 1, piece.pos.y);
		if(tempPiece != null && tempPiece != freePiece){
			Debug.Log("Piece moved: " + piece + " Piece at Right: " + tempPiece);
			if(piece.id + new Vector2(1,0) == tempPiece.id){
				Debug.Log("Match at right");
				go = GameObject.Instantiate(linePrefab, Vector3.zero, Quaternion.identity) as GameObject;				
				go.layer = Layers.LAYER_2D;
				go.transform.parent = piece.transform;
				piece.rightLine = go;
				piece.RightAnimation();
			}
		}
		tempPiece = GetPuzzlePiece(piece.pos.x - 1, piece.pos.y);
		if(tempPiece != null && tempPiece != freePiece){
			Debug.Log("Piece moved: " + piece + " Piece at Left: " + tempPiece);
			if(piece.id - new Vector2(1,0) == tempPiece.id){
				Debug.Log("Match at left");	
				go = GameObject.Instantiate(linePrefab, Vector3.zero, Quaternion.identity) as GameObject;				
				go.layer = Layers.LAYER_2D;
				go.transform.parent = piece.transform;
				piece.leftLine = go;
				piece.LeftAnimation();
			}
		}
		tempPiece = GetPuzzlePiece(piece.pos.x, piece.pos.y + 1);
		if(tempPiece != null && tempPiece != freePiece){
			Debug.Log("Piece moved: " + piece + " Piece at Bottom: " + tempPiece);
			if(piece.id + new Vector2(0,1) == tempPiece.id){
				Debug.Log("Match at Bottom");
				go = GameObject.Instantiate(linePrefab, Vector3.zero, Quaternion.identity) as GameObject;				
				go.layer = Layers.LAYER_2D;
				go.transform.parent = piece.transform;
				piece.bottomLine = go;
				piece.BottomAnimation();
			}
		}
		tempPiece = GetPuzzlePiece(piece.pos.x, piece.pos.y - 1);
		if(tempPiece != null && tempPiece != freePiece){
			Debug.Log("Piece moved: " + piece + " Piece at Top: " + tempPiece);
			if(piece.id - new Vector2(0,1) == tempPiece.id){
				Debug.Log("Match at top");	
				go = GameObject.Instantiate(linePrefab, Vector3.zero, Quaternion.identity) as GameObject;				
				go.layer = Layers.LAYER_2D;
				go.transform.parent = piece.transform;
				piece.topLine = go;
				piece.TopAnimation();
			}
		}
	}
	
	void Check(PuzzlePiece piece){
		CheckAdjacents(piece);
		if(freePiece.pos == freePiece.id){
			CheckBoard();	
		}
	}
	
	void CheckBoard(){
		int goodPieces = 0;		
		for (int i = 0; i < piecesList.Count; i++) {
			//Debug.Log("Piece Id: " + piecesList[i].id + " Piece Pos: " + piecesList[i].pos); 
			if(piecesList[i].id == piecesList[i].pos){
				goodPieces++;
			}
		}	
		
		if(goodPieces == cantPieces){
			StartCoroutine(StartWinSequence());
			gameFinished = true;
		}
	}
	
	IEnumerator StartWinSequence(){
		int cant = panelPivot.GetChildCount();
		Vector3 offScreenPos = new Vector3(Screen.width / 2, Screen.height, 0);
		Transform stageSpriteTransform = stagesSprite.transform.FindChild("Level" + PuzzleLoader.currentLevel);
		stageSpriteTransform.gameObject.SetActive(true);
		iTween.ScaleFrom(stageSpriteTransform.gameObject, iTween.Hash("scale", Vector3.zero, "time", 2f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic));
		
		if(PuzzleLoader.currentLevel == 1)
		{
			iTween.MoveTo(stageIndicator, iTween.Hash("position", new Vector3(0.98f, -6.231386f, 0), "time", 1f, "isLocal", true));
		}
		else if(PuzzleLoader.currentLevel == 2)
		{
			iTween.MoveTo(stageIndicator, iTween.Hash("position", new Vector3(0.98f, -25.65319f, 0), "time", 1f, "isLocal", true));
		}
		else if(PuzzleLoader.currentLevel == 3)
		{
			iTween.ScaleTo(stageIndicator, iTween.Hash("scale", Vector3.zero, "time", 1f, "isLocal", true));
		}
		
		yield return new WaitForSeconds(2);
		iTween.ScaleTo(previewPivot.gameObject, iTween.Hash("scale", Vector3.zero, "isLocal", true, "time", 1, "delay", (cant+1) * 0.1f, "oncomplete", "PieceArrived", "oncompletetarget", this.gameObject));
		iTween.ScaleTo(previewPivotStatic.gameObject, iTween.Hash("scale", Vector3.zero, "isLocal", true, "time", 1, "delay", (cant) * 0.1f, "oncomplete", "PieceArrived", "oncompletetarget", this.gameObject));
		for (int i = 0; i < cant; i++) {
			iTween.MoveTo(panelPivot.GetChild(i).gameObject, iTween.Hash("y", panelPivot.GetChild(i).gameObject.transform.position.y - 1000, "time", 2, "isLocal", true, "delay", i * .1f, "oncomplete", "PieceArrived", "oncompletetarget", this.gameObject, "easetype", iTween.EaseType.easeInCirc));
		}
		
		if(PuzzleLoader.currentLevel == 3)
		{
			startFireworks();
		}
	}
	
	IEnumerator PieceArrived(){
		piecesErased += 1;
		
		if(piecesErased >= cantPieces + 2)
		{
			//StartScreen("LevelWin");
			yield return new WaitForSeconds(1);
			RestartLevel();	
		}
	}
	
	void OnRestartClicked(){
		ResetGame();
		StartScreen("Menu");
	}
	
	void OnGameHelpClicked(){
		if(!gameFinished){
			StartScreen("Help");
		}
	}
	
	void startFireworks()
	{
		fireworksShowing = true;
	}
	
	void endFireWorks()
	{
		fireworksShowing = false;
		fireworksTimer = 0;
	}
	
	void spawnFireworks()
	{
		int index = (int)Mathf.Round(Random.Range(0, 3));
		GameObject fireWork = (GameObject) GameObject.Instantiate(fireworksArray[index]);
		
		float xPos = Random.Range(-5, 5);
		float yPos = Random.Range(10, 12);
		fireWork.transform.position = new Vector3(xPos, yPos, 0);
		fireworksInterval = Random.Range(0.5f, 2f);
		SoundManager.PlaySound("Fireworks", 1);
		Destroy(fireWork, 8);
	}
}
