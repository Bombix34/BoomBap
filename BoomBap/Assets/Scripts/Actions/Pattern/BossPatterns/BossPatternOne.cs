using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternOne : ActionPattern
{
	public BossPatternOne()
	{
		this.Actions.Add(new ActionPrepare());
		this.Actions.Add(new ActionPrepare());
		this.Actions.Add(new ActionAttack(3));
	}
}
