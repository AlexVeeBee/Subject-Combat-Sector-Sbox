﻿using System;
using Sandbox;

[Library("scs_teampoints")]
[Hammer.EntityTool( "Team Points Tracker", "Subject Combat Sector", "The teams point tracker used for randomizing or upgrading" )]
public partial class TeamPoints : AnimEntity
{
	public enum TeamPointsTypeEnum
	{
		Unknown,
		Red,
		Blue,
		Green,
		Yellow
	}

	[Property( "TeamPointEnum" ), Description( "Which side will the points belong to" )]
	public TeamPointsTypeEnum TeamPointAssigned { get; set; } = TeamPointsTypeEnum.Unknown;

	[Net] protected int CurrentPoints { get; private set; }

	private int[] tierUpgradeCosts = new int[] { 8, 16, 24, 32, 40, 999 };
	public override void Spawn()
	{
		base.Spawn();
	}

	public void SetPoints(int setPoints)
	{
		CurrentPoints = setPoints;
	}

	public int GetTotalPoints()
	{
		return CurrentPoints;
	}

	public int GetUpgradeTierCost(int index)
	{
		return tierUpgradeCosts[index];
	}

	public bool AttemptRandomize()
	{
		if ( CurrentPoints < 1 )
			return false;

		return true;

	}

	public bool AttemptUpgrader(int index)
	{
		if ( CurrentPoints < tierUpgradeCosts[index] )
			return false;

		return true;
	}

	public void AddPoints( int addPoints )
	{
		CurrentPoints += addPoints;
	}

	public void SubtractPoints(int takePoints)
	{
		CurrentPoints -= takePoints;
	}

}

