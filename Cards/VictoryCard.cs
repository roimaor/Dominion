using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
	public abstract class VictoryCard : Card
	{
		private int vps;

		public VictoryCard(string name, int cost, Player cardOwner, int vps) : base(name,cost, cardOwner)
		{
			this.Vps = vps;
		}

		public int Vps { get { return vps; } set { vps = value; } }

		public override void playCard()
		{
			specialEffect();
		}

		abstract public int vpsWorth();
	}
}
