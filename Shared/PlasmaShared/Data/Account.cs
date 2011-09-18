﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace ZkData
{
	partial class Account: IPrincipal, IIdentity
	{
		public int AvailableXP { get { return GetXpForLevel(Level) - AccountUnlocks.Sum(x => (int?)(x.Unlock.XpCost*x.Count)) ?? 0; } }

		public double EloInvWeight { get { return GlobalConst.EloWeightMax + 1 - EloWeight; } }

		public double WeightEloMalus { get { return (GlobalConst.EloWeightMax - EloWeight)*GlobalConst.EloWeightMalusFactor; } }

        public double EffectiveElo { get { return Elo + WeightEloMalus; } }


	    public void CheckLevelUp()
		{
			if (XP > GetXpForLevel(Level + 1)) Level++;
		}


		public int GetDropshipCapacity()
		{
			return GlobalConst.DefaultDropshipCapacity +
			       (Planets.SelectMany(x => x.PlanetStructures).Where(x => !x.IsDestroyed).Sum(x => x.StructureType.EffectDropshipCapacity) ?? 0);
		}

		public int GetFreeJumpGatesCount(List<int> accessiblePlanets)
		{
			var jumpGateCapacity = Planets.SelectMany(x => x.PlanetStructures).Sum(x => x.StructureType.EffectWarpGateCapacity) ?? 0;
			var usedJumpGates = AccountPlanets.Where(x => !accessiblePlanets.Contains(x.PlanetID)).Sum(x => x.DropshipCount);
			return jumpGateCapacity - usedJumpGates;
		}

		public static int GetXpForLevel(int level)
		{
			if (level < 0) return 0;
			return level*80 + 20*level*level;
		}

		partial void OnCreated()
		{
			FirstLogin = DateTime.UtcNow;
			Elo = 1500;
			EloWeight = 1;
			DropshipCount = 1;
		}

		partial void OnNameChanging(string value)
		{
			if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(value))
			{
				List<string> aliases = null;
				if (!string.IsNullOrEmpty(Aliases)) aliases = new List<string>(Aliases.Split(','));
				else aliases = new List<string>();

				if (!aliases.Contains(Name)) aliases.Add(Name);
				Aliases = string.Join(",", aliases.ToArray());
			}
		}

		partial void OnXPChanged()
		{
			CheckLevelUp();
		}

		public string AuthenticationType { get { return "LobbyServer"; } }
		public bool IsAuthenticated { get { return true; } }

		public bool IsInRole(string role)
		{
			if (role == "LobbyAdmin") return IsLobbyAdministrator;
			if (role == "ZkAdmin") return IsZeroKAdmin;
			else return string.IsNullOrEmpty(role);
		}

		public IIdentity Identity { get { return this; } }
	}
}