using UnityEngine;
using System.Collections;

public class Maze_Maze : MonoBehaviour 
{
	// Represents if the current maze will be randomly generated.
	public static bool spawnRandomMap = true;
	// The string representing the map to load.
	public static string stringToLoad;
	// Maze width.
	public static int MAZE_COLUMNS = 17;
	// Maze height.
	public static int MAZE_ROWS = 9;
	// Cell size.
	public const int CELL_SIZE = 1;
	// Tile size.
	public const int TILE_SIZE = 30;
	public GameObject wallPrefab;
	// Represents the Game.
	//private Game game;
	private Cell[] cells;
	private int cellSize;
	private int nbCols, nbRows;
	private bool initialized = false;
	
	// Use this for initialization
	void Start () {
		initMaze();
		createMaze();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//--------------------------------------------------------------
	/// Initialize the maze for creation.
	//--------------------------------------------------------------
	public void initMaze()
	{
		Debug.Log("initMaze"+"|"+MAZE_COLUMNS+"|"+MAZE_ROWS);
		nbCols = MAZE_COLUMNS;
		nbRows = MAZE_ROWS;
		cellSize = CELL_SIZE;
		cells = new Cell[(nbCols+2) * (nbRows+2)];
		for (int c = 0; c <= nbCols+1; c++)
		{
			for (int r = 0; r <= nbRows+1; r++)
			{
				Cell cell = new Cell(this, c, r);
				cells[r * (nbCols + 2) + c] = cell;
			}
		}
		initialized = true;
		//game.getObjectManager().resetSpawnLocations();
	}
	
	//--------------------------------------------------------------
	/// Creates and carves the maze.
	//--------------------------------------------------------------
	public void createMaze(bool carveMaze = true)
	{
		if (carveMaze)
		{
			this.setAllCellsToVirgin();
			for (int i = 0; i < 3; i++)
			{
				Cell cell = this.getRandomCell();
				if (cell.removeRandomWall())
					i--;
			}
			MazePather carver = new MazePather(this, getRandomCell());
			do {
				carver.carveMaze();
			} while (!carver.isFinished());
		}
		
		
		string m = "";
		for (int i = 1; i <= nbCols+1; i++)
		{
			for (int j = 1; j <= nbRows+1; j++)
			{
				Cell c = getCell(i, j);
				Wall wu = c.getTopWall();
				Wall wl = c.getLeftWall();
				if ((wl != null && (wl.isUp() || wl.isHard())) &&
				    (wu != null && (wu.isUp() || wu.isHard())))
				{
					m += "3";
				} else if ((wl != null && (wl.isUp() || wl.isHard())) &&
				           !(wu != null && (wu.isUp() || wu.isHard())))
				{
					m += "1";
				} else if (!(wl != null && (wl.isUp() || wl.isHard())) &&
				           (wu != null && (wu.isUp() || wu.isHard())))
				{
					m += "2";
				} else
				{
					m += "0";
				}
			}
		}
		
		buildMaze(m);
	}
	
	//--------------------------------------------------------------
	/// RPC event that builds the maze in the world.
	//--------------------------------------------------------------
	public void buildMaze(string m)
	{
		Debug.Log("buildMaze");
		for (int i = 1; i <= nbCols+1; i++)
		{
			for (int j = 1; j <= nbRows+1; j++)
			{
				GameObject go = null;
				switch(m.Substring(0, 1))
				{
				case "0":
					if (i <= nbCols && j <= nbRows)
					{
						getCell(i, j).getLeftWall().bringDown();
						//getCell(j, j).getTopWall().bringDown();
					}
					break;
				case "1":
					if (i <= nbCols && j <= nbRows)
					{
						getCell(i, j).getTopWall().bringDown();
					}
					go = (GameObject) Instantiate(wallPrefab, new Vector3((i*cellSize)-(((float)cellSize)/2), 0.0f, -j*cellSize), Quaternion.Euler(-90, 0, 0));
					go.transform.parent = gameObject.transform;
					if (go != null && (i == 1 || i == nbCols+1))
					{
						//go.GetComponent<WallComponent>().setAsHard();
					}
					//go.GetComponent<WallComponent>().setMazePosition(i, j);
					//go.GetComponent<WallComponent>().setWallType(WallComponent.WallType.left);
					
					
					break;
				case "2":
					if (i <= nbCols && j <= nbRows)
					{
						getCell(i, j).getLeftWall().bringDown();
					}
					go = (GameObject) Instantiate(wallPrefab, new Vector3(i*cellSize, 0.0f, -(j*cellSize)+(((float)cellSize)/2)), Quaternion.Euler(-90, 0, 90)); //top
					go.transform.parent = gameObject.transform;
					if (go != null && (j == 1 || j == nbRows+1))
					{
						//go.GetComponent<WallComponent>().setAsHard();
					}
					//go.GetComponent<WallComponent>().setMazePosition(i, j);
					//go.GetComponent<WallComponent>().setWallType(WallComponent.WallType.top);
					
					
					break;
				case "3":
					go = (GameObject) Instantiate(wallPrefab, new Vector3((i*cellSize)-(((float)cellSize)/2), 0.0f, -j*cellSize), Quaternion.Euler(-90, 0, 0)); //left
					go.transform.parent = gameObject.transform;
					if (go != null && (i == 1 || i == nbCols+1))
					{
						//go.GetComponent<WallComponent>().setAsHard();
					}
					//go.GetComponent<WallComponent>().setMazePosition(i, j);
					//go.GetComponent<WallComponent>().setWallType(WallComponent.WallType.left);
					
					go = (GameObject) Instantiate(wallPrefab, new Vector3(i*cellSize, 0.0f, -(j*cellSize)+(((float)cellSize)/2)), Quaternion.Euler(-90, 0, 90));
					go.transform.parent = gameObject.transform;
					if (go != null && (j == 1 || j == nbRows+1))
					{
						//go.GetComponent<WallComponent>().setAsHard();
					}
					//go.GetComponent<WallComponent>().setMazePosition(i, j);
					//go.GetComponent<WallComponent>().setWallType(WallComponent.WallType.top);
					break;
				}
				
				m = m.Substring(1);
			}
		}
	}
	
	//--------------------------------------------------------------
	/// Resets all cells to their default state.
	//--------------------------------------------------------------
	public void setAllCellsToVirgin()
	{
		for (int i = 1; i < Maze_Maze.MAZE_COLUMNS+1; i++)
		{
			for (int j = 1; j < Maze_Maze.MAZE_ROWS+1; j++)
			{
				Cell c = this.getCell(i, j);
				c.setState(0);
				c.setPathingValue(-1);
			}
		}
	}
	
	//--------------------------------------------------------------
	/// Returns a random cell foudn within the maze.
	//--------------------------------------------------------------
	public Cell getRandomCell()
	{
		int col = getRandomInt(1, nbCols+1);
		int row = getRandomInt(1, nbRows+1);
		return getCell(col, row);
	}
	
	//--------------------------------------------------------------
	/// Gets the cell foudn in the specified row and column.
	//--------------------------------------------------------------
	public Cell getCell(int col, int row)
	{
		return cells[row * (nbCols + 2) + col];
	}
	
	//--------------------------------------------------------------
	/// Returns the cell foudn in the specified index of the cells array.	
	//--------------------------------------------------------------
	public Cell getCellByIndex(int index)
	{
		return cells[index];
	}
	
	public int getNbRows() { return nbRows; }
	public int getNbCols() { return nbCols; }
	
	public int getRandomInt(int low, int high)
	{
		return (int)Random.Range (low, high);
	}
	
	public bool hasBeenInitialized()
	{
		return initialized;
	}
}
				