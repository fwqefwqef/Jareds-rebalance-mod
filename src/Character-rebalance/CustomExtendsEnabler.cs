﻿/*using GameDataEditor;
using HarmonyLib;
using System;
using System.Reflection;



public class CustomExtendsEnabler
{

	[HarmonyPatch(typeof(Skill_Extended))]
	class DateToExtenedPatches
	{
		static AccessTools.FieldRef<Skill_Extended, string> _DesRef = AccessTools.FieldRefAccess<Skill_Extended, string>("_Des");

		[HarmonyPatch(nameof(Skill_Extended.DataToExtended), new Type[] { typeof(GDESkillExtendedData) })]
		[HarmonyPrefix]
		static bool DataToExtendedPrefix(GDESkillExtendedData _Data, ref Skill_Extended __result)
		{
			if (_Data.ClassName == null || _Data.ClassName == "" || _Data.ClassName.Trim() == "")
			{
				UnityEngine.Debug.LogWarning(_Data.Key + " : Skill_Exteneded ClassName probably shouldn't be empty");
				return true;
			}



			Type customExType = Assembly.GetExecutingAssembly().GetType(_Data.ClassName);

			if (ReferenceEquals(customExType, null))
			{
				return true;
			}

			__result = (Skill_Extended)Assembly.GetExecutingAssembly().CreateInstance(customExType.Name);

			__result.Data = _Data;
			_DesRef(__result) = _Data.Des;
			if (!ReferenceEquals(_Data.Image, null))
			{
				__result.SpriteImage = Misc.CreatSprite(_Data.Image);
			}
			return false;
		}



		[HarmonyPatch(nameof(Skill_Extended.DataToExtendedC))]
		[HarmonyPrefix]
		static bool DataToExtendedC(string ClassKey, ref Skill_Extended __result)
		{
			if (ClassKey == null || ClassKey == "" || ClassKey.Trim() == "")
			{
				UnityEngine.Debug.LogError("Skill_Exteneded ClassName probably shouldn't be empty");
				return true;
			}

			Type customExType = Assembly.GetExecutingAssembly().GetType(ClassKey);

			if (ReferenceEquals(customExType, null))
			{
				return true;
			}

			__result = (Skill_Extended)Assembly.GetExecutingAssembly().CreateInstance(customExType.Name);
			return false;
		}

	}

	[HarmonyPatch(typeof(Skill), nameof(Skill.ExtendedFind))]
	class ExtendedFindPatch
	{
		static bool Prefix(Skill __instance, ref Skill_Extended __result, string ExtendedName, bool NoError = true)
		{
			Type customExType = Assembly.GetExecutingAssembly().GetType(ExtendedName);

			if (ReferenceEquals(customExType, null))
			{
				return true;
			}

			foreach (Skill_Extended skill_Extended in __instance.AllExtendeds)
			{
				if (skill_Extended.Name == customExType.Name)
				{
					__result = skill_Extended;
					return false;
				}
			}
			__result = null;
			return false;

		}
	}

	[HarmonyPatch(typeof(Buff), nameof(Buff.DataToBuff))]
	class BuffClassPatch
	{
		static bool Prefix(ref Buff __result, GDEBuffData _BuffData, BattleChar Char, BattleChar Use, int LifeTime = -1, bool view = false)
		{

			if (_BuffData.ClassName == null || _BuffData.ClassName == "" || _BuffData.ClassName.Trim() == "")
			{
				return true;
			}


			Type customExType = Assembly.GetExecutingAssembly().GetType(_BuffData.ClassName);


			if (ReferenceEquals(customExType, null))
			{
				return true;
			}


			Buff buff = (Buff)Assembly.GetExecutingAssembly().CreateInstance(customExType.Name);

			buff.BuffData = _BuffData;
			buff.BChar = Char;
			StackBuff stackBuff = new StackBuff();
			if (Char != null)
			{
				buff.MyChar = Char.Info;
			}
			else
			{
				buff.BChar = Use;
				buff.MyChar = Use.Info;
			}
			if (buff.BuffData.LifeTime != 0f)
			{
				if (LifeTime != -1)
				{
					stackBuff.RemainTime = LifeTime;
					buff.LifeTime = (int)buff.BuffData.LifeTime;
				}
				else
				{
					stackBuff.RemainTime = (int)buff.BuffData.LifeTime;
					buff.LifeTime = (int)buff.BuffData.LifeTime;
				}
			}
			else
			{
				buff.TimeUseless = true;
			}
			buff.SkillCautionView = _BuffData.UseSkillDebuff;
			if (_BuffData.Barrier >= 1)
			{
				buff.BarrierHP = _BuffData.Barrier;
			}
			stackBuff.UseState = Use;
			buff.StackInfo.Add(stackBuff);
			buff.CantDisable = buff.BuffData.Cantdisable;
			buff.View = view;
			buff.Init();

			__result = buff;

			return false;
		}
	}

}


*/