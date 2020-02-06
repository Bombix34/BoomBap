using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternTwo : ActionPattern
{
	public BossPatternTwo()
	{
		this.Actions.Add(new ActionPrepare());
		this.Actions.Add(new ActionPrepare());
		this.Actions.Add(new ActionParry(3));
	}
}
