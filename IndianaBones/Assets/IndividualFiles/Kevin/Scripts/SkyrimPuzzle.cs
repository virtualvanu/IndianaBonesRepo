﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyrimPuzzle : Puzzle 
{
	public List<bool> finishedParts = new List<bool>();

	public override void PuzzleTrigger(TriggerdObjects currentObject)
	{
		if(finishedParts[currentObject.puzzlePart] == true)
		{
			finishedParts[currentObject.puzzlePart] = false;
		}
		else
		{
			finishedParts[currentObject.puzzlePart] = true;
			PuzzleCheck();
		}
	}

	public void PuzzleCheck()
	{
		returnBool = true;
		foreach (bool b in finishedParts)
		{
			if(b == false)
			{
				returnBool = false;
			}
		}
		puzzleManager.triggers -= 1;
		puzzleManager.done = returnBool;
	}
}
