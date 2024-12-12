
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine.SceneManagement;
using Wish;
using Sirenix.Serialization;
using BepInEx;
using HarmonyLib;
using Wish;
using BepInEx.Logging;
using I2.Loc;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;


namespace Polygamy;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class PolygamyPlugin : BaseUnityPlugin
{
    private const string pluginGuid = "vurawnica.sunhaven.polygamy";
    private const string pluginName = "Polygamy";
    private const string pluginVersion = "0.0.4";
    private Harmony m_harmony = new Harmony(pluginGuid);
    public static ManualLogSource logger;

    private void Awake()
    {
        // Plugin startup logic
        PolygamyPlugin.logger = this.Logger;
        logger.LogInfo((object)$"Plugin {pluginName} is loaded!");
        this.m_harmony.PatchAll();
    }

    [HarmonyPatch(typeof(NPCAI), "HandleWeddingRing")]
    class HarmonyPatch_NPCAI_HandleWeddingRing
    {
		private static bool Prefix(ref string __result, out bool response, NPCAI __instance, ref string ____npcName)
        {
            response = false;
            bool flag = false;
            string str = "";
            float value;
            if (__instance.IsMarriedToPlayer())
            {
                flag = true;
                switch (____npcName)
                {
                    case "Wornhardt":
                        str = "";
                        break;
                    case "Zaria":
                        str = ScriptLocalization.RNPC_Zaria_DeclineProposal_01;
                        break;
                    case "Donovan":
                        str = "";
                        break;
                    case "Karish":
                        str = ScriptLocalization.RNPC_Karish_DeclineProposal_01;
                        break;
                    case "Claude":
                        str = "";
                        break;
                    case "Jun":
                        str = "";
                        break;
                    case "Vivi":
                        str = ScriptLocalization.RNPC_Vivi_DeclineProposal_01;
                        break;
                    case "Lynn":
                        str = ScriptLocalization.RNPC_Lynn_DeclineProposal_01;
                        break;
                    case "Liam":
                        str = "";
                        break;
                    case "Anne":
                        str = ScriptLocalization.RNPC_Anne_DeclineProposal_01;
                        break;
                    case "Miyeon":
                        str = ScriptLocalization.RNPC_Miyeon_DeclineProposal_01;
                        break;
                    case "Kitty":
                        str = "";
                        break;
                    case "Lucius":
                        str = ScriptLocalization.RNPC_Lucius_DeclineProposal_01;
                        break;
                    case "Shang":
                        str = ScriptLocalization.RNPC_Shang_DeclineProposal_01;
                        break;
                    case "Wesley":
                        str = ScriptLocalization.RNPC_Wesley_DeclineProposal_01;
                        break;
                    case "Darius":
                        str = "";
                        break;
                    case "Xyla":
                        str = "";
                        break;
                    case "Catherine":
                        str = "";
                        break;
                    case "Lucia":
                        str = "";
                        break;
                    case "Iris":
                        str = "";
                        break;
                    case "Kai":
                        str = ScriptLocalization.RNPC_Kai_DeclineProposal_01;
                        break;
                    case "Vaan":
                        str = "";
                        break;
                    case "Nathaniel":
                        str = "";
                        break;
                }
            }
            else if (
                !__instance.IsDatingPlayer() ||
                !SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter(____npcName + " Cycle 14") ||
                !SingletonBehaviour<GameSave>.Instance.CurrentSave.characterData.Relationships.TryGetValue(____npcName, out value) ||
                value < 75f)
            {
                flag = true;
                switch (____npcName)
                {
                    case "Wornhardt":
                        str = "";
                        break;
                    case "Zaria":
                        str = ScriptLocalization.RNPC_Zaria_DeclineProposal_00;
                        break;
                    case "Donovan":
                        str = "";
                        break;
                    case "Karish":
                        str = ScriptLocalization.RNPC_Karish_DeclineProposal_00;
                        break;
                    case "Claude":
                        str = "";
                        break;
                    case "Jun":
                        str = "";
                        break;
                    case "Vivi":
                        str = ScriptLocalization.RNPC_Vivi_DeclineProposal_00;
                        break;
                    case "Lynn":
                        str = ScriptLocalization.RNPC_Lynn_DeclineProposal_00;
                        break;
                    case "Liam":
                        str = "";
                        break;
                    case "Anne":
                        str = ScriptLocalization.RNPC_Anne_DeclineProposal_00;
                        break;
                    case "Miyeon":
                        str = ScriptLocalization.RNPC_Miyeon_DeclineProposal_00;
                        break;
                    case "Kitty":
                        str = "";
                        break;
                    case "Lucius":
                        str = ScriptLocalization.RNPC_Lucius_DeclineProposal_00;
                        break;
                    case "Shang":
                        str = ScriptLocalization.RNPC_Shang_DeclineProposal_00;
                        break;
                    case "Wesley":
                        str = ScriptLocalization.RNPC_Wesley_DeclineProposal_00;
                        break;
                    case "Darius":
                        str = "";
                        break;
                    case "Xyla":
                        str = "";
                        break;
                    case "Catherine":
                        str = "";
                        break;
                    case "Lucia":
                        str = "";
                        break;
                    case "Iris":
                        str = "";
                        break;
                    case "Kai":
                        str = ScriptLocalization.RNPC_Kai_DeclineProposal_00;
                        break;
                    case "Vaan":
                        str = "";
                        break;
                    case "Nathaniel":
                        str = "";
                        break;
                }
            }
            foreach (string quest in Player.Instance.QuestList.questLog.Keys.ToList<string>())
            {
                if (quest.Contains("MarriageQuest"))
                {
                    Player.Instance.QuestList.AbandonQuest(quest);
                }
            }
            if (flag)
            {
                __result = str + "[]" + ScriptLocalization.RNPC_Generic_DeclineProposal;
            }
            if (SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("Married"))
            {
                Player.Instance.Inventory.RemoveItem(6107, 1);
            }
            response = true;
            SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("EngagedToRNPC", value: true);
            switch (____npcName)
            {
                case "Wornhardt":
                    Player.Instance.QuestList.StartQuest("WornhardtMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Wornhardt_AcceptProposal;
                    return false;
                case "Zaria":
                    Player.Instance.QuestList.StartQuest("ZariaMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Zaria_AcceptProposal;
                    return false;
                case "Donovan":
                    Player.Instance.QuestList.StartQuest("DonovanMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Donovan_AcceptProposal;
                    return false;
                case "Karish":
                    Player.Instance.QuestList.StartQuest("KarishMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Karish_AcceptProposal;
                    return false;
                case "Claude":
                    Player.Instance.QuestList.StartQuest("ClaudeMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Claude_AcceptProposal;
                    return false;
                case "Jun":
                    Player.Instance.QuestList.StartQuest("JunMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Jun_AcceptProposal;
                    return false;
                case "Vivi":
                    Player.Instance.QuestList.StartQuest("ViviMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Vivi_AcceptProposal;
                    return false;
                case "Lynn":
                    Player.Instance.QuestList.StartQuest("LynnMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Lynn_AcceptProposal;
                    return false;
                case "Liam":
                    Player.Instance.QuestList.StartQuest("LiamMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Liam_AcceptProposal;
                    return false;
                case "Anne":
                    Player.Instance.QuestList.StartQuest("AnneMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Anne_AcceptProposal;
                    return false;
                case "Miyeon":
                    Player.Instance.QuestList.StartQuest("MiyeonMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Miyeon_AcceptProposal;
                    return false;
                case "Kitty":
                    Player.Instance.QuestList.StartQuest("KittyMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Kitty_AcceptProposal;
                    return false;
                case "Lucius":
                    Player.Instance.QuestList.StartQuest("LuciusMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Lucius_AcceptProposal;
                    return false;
                case "Shang":
                    Player.Instance.QuestList.StartQuest("ShangMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Shang_AcceptProposal;
                    return false;
                case "Wesley":
                    Player.Instance.QuestList.StartQuest("WesleyMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Wesley_AcceptProposal;
                    return false;
                case "Darius":
                    Player.Instance.QuestList.StartQuest("DariusMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Darius_AcceptProposal;
                    return false;
                case "Xyla":
                    Player.Instance.QuestList.StartQuest("XylaMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Xyla_AcceptProposal;
                    return false;
                case "Catherine":
                    Player.Instance.QuestList.StartQuest("CatherineMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Catherine_AcceptProposal;
                    return false;
                case "Lucia":
                    Player.Instance.QuestList.StartQuest("LuciaMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Lucia_AcceptProposal;
                    return false;
                case "Iris":
                    Player.Instance.QuestList.StartQuest("IrisMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Iris_AcceptProposal;
                    return false;
                case "Kai":
                    Player.Instance.QuestList.StartQuest("KaiMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Kai_AcceptProposal;
                    return false;
                case "Vaan":
                    Player.Instance.QuestList.StartQuest("VaanMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Vaan_AcceptProposal;
                    return false;
                case "Nathaniel":
                    Player.Instance.QuestList.StartQuest("NathanielMarriageQuest", false);
                    __result = ScriptLocalization.RNPC_Nathaniel_AcceptProposal;
                    return false;
                default:
                    __result = ScriptLocalization.RNPC_Generic_AcceptProposal;
                    return false;

            }
        }
        private static string Postfix(string __result, out bool response, NPCAI __instance, ref string ____npcName)
        {
            response = false;
            bool flag = false;
            string text = "";
            float value;
            if (SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("MarriedTo" + ____npcName))
            {
                flag = true;
                switch (____npcName)
                {
                    case "Lynn":
                        text = "Hehe, you want to get married again?? That's cute sweetie, but I don't think it works that way.";
                        break;
                    case "Anne":
                        text = "I don't know if this is a little joke or not, but the gesture is really cute. And of course, I'd be happy to take a second ring!";
                        break;
                    case "Donovan":
                        text = "";
                        break;
                    case "Vaan":
                        text = "";
                        break;
                    case "Xyla":
                        text = "";
                        break;
                    case "Nathaniel":
                        text = "";
                        break;
                    case "Jun":
                        text = "";
                        break;
                    case "Liam":
                        text = "";
                        break;
                    case "Catherine":
                        text = "";
                        break;
                    case "Claude":
                        text = "";
                        break;
                    case "Kitty":
                        text = "";
                        break;
                    case "Wornhardt":
                        text = "";
                        break;
                    case "Darius":
                        text = "";
                        break;
                    case "Lucia":
                        text = "";
                        break;
                    case "Iris":
                        text = "";
                        break;
                    case "Miyeon":
                        text = "";
                        break;
                    case "Kai":
                        text = "";
                        break;
                    case "Shang":
                        text = "";
                        break;
                    case "Wesley":
                        text = "";
                        break;
                    case "Vivi":
                        text = "";
                        break;
                    case "Lucius":
                        text = "";
                        break;
                }
            }
            else if
                (
                !SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("Dating" + ____npcName) ||
                !SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter(____npcName + " Cycle 14") ||
                !SingletonBehaviour<GameSave>.Instance.CurrentSave.characterData.Relationships.TryGetValue(____npcName, out value) ||
                value < 75f
                )
            {
                flag = true;
                switch (____npcName)
                {
                    case "Lynn":
                        text = "Oh - wow! I'm so sorry XX, but I don't think I'm quite ready for that. We should get to know each other better first, right?";
                        break;
                    case "Anne":
                        text = "Who do I look like to you? I'm a merchant, not a farm wife. I love the ring, but it's going to take more effort on your part before I say yes.";
                        break;
                    case "Donovan":
                        text = "";
                        break;
                    case "Vaan":
                        text = "";
                        break;
                    case "Xyla":
                        text = "";
                        break;
                    case "Nathaniel":
                        text = "";
                        break;
                    case "Jun":
                        text = "";
                        break;
                    case "Liam":
                        text = "";
                        break;
                    case "Catherine":
                        text = "";
                        break;
                    case "Claude":
                        text = "";
                        break;
                    case "Kitty":
                        text = "";
                        break;
                    case "Wornhardt":
                        text = "";
                        break;
                    case "Darius":
                        text = "";
                        break;
                    case "Lucia":
                        text = "";
                        break;
                    case "Iris":
                        text = "";
                        break;
                    case "Miyeon":
                        text = "";
                        break;
                    case "Kai":
                        text = "";
                        break;
                    case "Shang":
                        text = "";
                        break;
                    case "Wesley":
                        text = "";
                        break;
                    case "Vivi":
                        text = "";
                        break;
                    case "Lucius":
                        text = "";
                        break;
                }
            }
            if (flag)
            {
                return text + "[]<i>(You must be dating and not already married to this character, achieved 15 full hearts, and progressed far enough in the dialogue to marry them)</i>";
            }
            if (SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("Married"))
            {
                Player.Instance.Inventory.RemoveItem(6107, 1);
            }
            response = true;
            SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("EngagedToRNPC", value: true);
            switch (____npcName)
            {
                case "Lynn":
                    Player.Instance.QuestList.StartQuest("LynnMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                case "Anne":
                    Player.Instance.QuestList.StartQuest("AnneMarriageQuest");
                    return "Heh, it's about time my investment paid off. What do you mean \"what investment?\" I'm talking about <i>you</i>, XX![]Of course I'll marry you! I'll pay for someone to arrange the ceremony, you just meet me at the event square tomorrow at 4:00 pm.";
                case "Donovan":
                    Player.Instance.QuestList.StartQuest("DonovanMarriageQuest");
                    return "Ah, I figured this was coming... Well I won't hold you in suspense.[]Let's do it, XX - let's get married!![]I'll have someone set up a nice little ceremony in your Human town. Just show up at 4:00 pm and I'll take care of the rest!";
                case "Vaan":
                    Player.Instance.QuestList.StartQuest("VaanMarriageQuest");
                    return "Finally! Yes of course we should be married, XX! It makes all the sense in the world.[]We should do it in Sun Haven. I'll see about contacting your Archmage to set up the ceremony. You just make sure you're on time! Let's call it 4:00 pm. I'll see you tomorrow!";
                case "Xyla":
                    Player.Instance.QuestList.StartQuest("XylaMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]I'll even set it up for you in your beloved Human town. Let's kick it off at 4:00 pm. Don't be late, sewer rat!";
                case "Nathaniel":
                    Player.Instance.QuestList.StartQuest("NathanielMarriageQuest");
                    return "Ah! Heh, it's about time![]Yes XX, I will absolutely marry you! Let me handle the ceremony, you just get yourself to the event square tomorrow at 4:00 pm. I can't wait!";
                case "Jun":
                    Player.Instance.QuestList.StartQuest("JunMarriageQuest");
                    return "XX! I've pictured this moment so many times... Yes, I will marry you![]Let's have the ceremony tomorrow at 4:00 pm. I'll get the event center all set up, you just need to be there. I'll see you then!";
                case "Liam":
                    Player.Instance.QuestList.StartQuest("LiamMarriageQuest");
                    return "Ah, wow, this is a lot.[]You know... I think I'm ready for this! Yes XX, let's get married!! I'll see about setting up a ceremony. You just meet me tomorrow at the event square. Let's say 4:00 pm!";
                case "Catherine":
                    Player.Instance.QuestList.StartQuest("CatherineMarriageQuest");
                    return "I've been dreaming of the moment! I thought I'd be prepared for it, but now I feel like I'm floating.[]Of course I'll marry you, XX!! I'll prepare the ceremony, you just meet me at the event square tomorrow at 4:00 pm.";
                case "Claude":
                    Player.Instance.QuestList.StartQuest("ClaudeMarriageQuest");
                    return "Marriage? With me? I never thought... Well, I guess it doesn't matter what I thought now.[]Yes, of course I will marry you, XX. I'll pay for somebody to set up the ceremony in the event square. Be there tomorrow at 4:00 pm. I really can't wait!";
                case "Kitty":
                    Player.Instance.QuestList.StartQuest("KittyMarriageQuest");
                    return "OH - oh my goodness gracious! XX, I will marry you! Kitty will marry XX, nya nya![]Don't worry, Kitty will get the ceremony set up. You just show up to the event square at 4:00 pm tomorrow! I can't wait!";
                case "Wornhardt":
                    Player.Instance.QuestList.StartQuest("WornhardtMarriageQuest");
                    return "... Really, do you mean this?[]XX, marrying you would make me the happiest man in town! Yes, let's do it! I'll handle the preparations, you just get yourself to the event square by 4:00 pm tomorrow.";
                case "Darius":
                    Player.Instance.QuestList.StartQuest("DariusMarriageQuest");
                    return "It's about time you asked, XX. I was growing impatient, but now you can take your proper place by the side of Withergate's future king.[]That is to say, I accept your proposal! I'll have some lackeys set up a ceremony tomorrow in your Human town. Be there at 4:00 pm, and don't keep me waiting.";
                case "Lucia":
                    Player.Instance.QuestList.StartQuest("LuciaMarriageQuest");
                    return "Oh my goodness!! XX!! Yes, yes <i>of course</i> I'll marry you![]I'll prepare the ceremony for us tomorrow. Try to be at the event square by 4:00 pm! I'm so excited, XX!";
                case "Iris":
                    Player.Instance.QuestList.StartQuest("IrisMarriageQuest");
                    return "You're proposing?? Oh - I'm sorry, I was just so unprepared for this.[]...The answer is yes, obviously! I know you'll want it in Sun Haven, so I'll talk to your Archmage to set it up. Just be there tomorrow at 4:00 pm. Ah, this is so exciting!";
                case "Miyeon":
                    Player.Instance.QuestList.StartQuest("MiyeonMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                case "Kai":
                    Player.Instance.QuestList.StartQuest("KaiMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                case "Shang":
                    Player.Instance.QuestList.StartQuest("ShangMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                case "Wesley":
                    Player.Instance.QuestList.StartQuest("WesleyMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                case "Vivi":
                    Player.Instance.QuestList.StartQuest("ViviMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                case "Lucius":
                    Player.Instance.QuestList.StartQuest("LuciusMarriageQuest");
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
                default:
                    return "Oh! Heh, I really shouldn't be surprised. Actually, what's really surprising is... I don't think it's a bad idea. Sure, let's do it, XX![]We should do it at 4pm tomorrow at the event center! I'll take care of everything else, you just show up!";
            }
        }
    }

    [HarmonyPatch(typeof(NPCAI), "HandleMemoryLossPotion")]
    class HarmonyPatch_NPCAI_HandleMemoryLossPotion
    {
        private static bool Prefix(ref string __result, out bool response, NPCAI __instance, ref string ____npcName)
        {
            response = true;

            List<string> spouses = new List<string>();
            int count = 0;
            foreach (var npcai in SingletonBehaviour<NPCManager>.Instance._npcs.Values.Where(npcai => SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("MarriedTo" + npcai.OriginalName)))
            {
                spouses.Add(npcai.OriginalName);
                count += 1;
            }
            if (count <= 1)
            {
                return true;
            }

            bool flag = __instance.IsMarriedToPlayer();
            __instance.PlatonicPlayer();
            string new_main;

            if (GameSave.CurrentCharacter.Relationships.ContainsKey(____npcName))
            {
                GameSave.CurrentCharacter.Relationships[____npcName] = Mathf.Max(0f, GameSave.CurrentCharacter.Relationships[____npcName]);
            }
            string progressStringCharacter = SingletonBehaviour<GameSave>.Instance.GetProgressStringCharacter("MarriedWith");

            if (progressStringCharacter.Equals(____npcName))
            {
                if (spouses[0] == ____npcName)
                {
                    new_main = spouses[1];
                }
                else
                {
                    new_main = spouses[0];
                }
                SingletonBehaviour<GameSave>.Instance.SetProgressStringCharacter("MarriedWith", new_main);
                SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("MarriedTo" + progressStringCharacter, false);
                SingletonBehaviour<GameSave>.Instance.SetProgressBoolWorld(____npcName + "MarriedWalkPath", false, true);
                NPCAI realNPC = SingletonBehaviour<NPCManager>.Instance.GetRealNPC(____npcName);
                realNPC.GeneratePath();
                SingletonBehaviour<NPCManager>.Instance.StartNPCPath(realNPC);
            }
            __instance.GenerateCycle(false);

            if (flag)
            {
                switch (____npcName)
                {
                    case "Wornhardt":
                        __result = ScriptLocalization.RNPC_Wornhardt_MLP_Married;
                        return false;
                    case "Zaria":
                        __result = ScriptLocalization.RNPC_Zaria_MLP_Married;
                        return false;
                    case "Donovan":
                        __result = ScriptLocalization.RNPC_Donovan_MLP_Married;
                        return false;
                    case "Karish":
                        __result = ScriptLocalization.RNPC_Karish_MLP_Married;
                        return false;
                    case "Claude":
                        __result = ScriptLocalization.RNPC_Claude_MLP_Married;
                        return false;
                    case "Jun":
                        __result = ScriptLocalization.RNPC_Jun_MLP_Married;
                        return false;
                    case "Vivi":
                        __result = ScriptLocalization.RNPC_Vivi_MLP_Married;
                        return false;
                    case "Lynn":
                        __result = ScriptLocalization.RNPC_Lynn_MLP_Married;
                        return false;
                    case "Liam":
                        __result = ScriptLocalization.RNPC_Liam_MLP_Married;
                        return false;
                    case "Anne":
                        __result = ScriptLocalization.RNPC_Anne_MLP_Married;
                        return false;
                    case "Miyeon":
                        __result = ScriptLocalization.RNPC_Miyeon_MLP_Married;
                        return false;
                    case "Kitty":
                        __result = ScriptLocalization.RNPC_Kitty_MLP_Married;
                        return false;
                    case "Lucius":
                        __result = ScriptLocalization.RNPC_Lucius_MLP_Married;
                        return false;
                    case "Shang":
                        __result = ScriptLocalization.RNPC_Shang_MLP_Married;
                        return false;
                    case "Wesley":
                        __result = ScriptLocalization.RNPC_Wesley_MLP_Married;
                        return false;
                    case "Darius":
                        __result = ScriptLocalization.RNPC_Darius_MLP_Married;
                        return false;
                    case "Xyla":
                        __result = ScriptLocalization.RNPC_Xyla_MLP_Married;
                        return false;
                    case "Catherine":
                        __result = ScriptLocalization.RNPC_Catherine_MLP_Married;
                        return false;
                    case "Lucia":
                        __result = ScriptLocalization.RNPC_Lucia_MLP_Married;
                        return false;
                    case "Iris":
                        __result = ScriptLocalization.RNPC_Iris_MLP_Married;
                        return false;
                    case "Kai":
                        __result = ScriptLocalization.RNPC_Kai_MLP_Married;
                        return false;
                    case "Vaan":
                        __result = ScriptLocalization.RNPC_Vaan_MLP_Married;
                        return false;
                    case "Nathaniel":
                        __result = ScriptLocalization.RNPC_Nathaniel_MLP_Married;
                        return false;
                    default:
                        __result = ScriptLocalization.RNPC_Anne_MLP_Married;
                        return false;
                }
            }
            switch (____npcName)
            {
                case "Wornhardt":
                    __result = ScriptLocalization.RNPC_Wornhardt_MLP;
                    return false;
                case "Zaria":
                    __result = ScriptLocalization.RNPC_Zaria_MLP;
                    return false;
                case "Donovan":
                    __result = ScriptLocalization.RNPC_Donovan_MLP;
                    return false;
                case "Karish":
                    __result = ScriptLocalization.RNPC_Karish_MLP;
                    return false;
                case "Claude":
                    __result = ScriptLocalization.RNPC_Claude_MLP;
                    return false;
                case "Jun":
                    __result = ScriptLocalization.RNPC_Jun_MLP;
                    return false;
                case "Vivi":
                    __result = ScriptLocalization.RNPC_Vivi_MLP;
                    return false;
                case "Lynn":
                    __result = ScriptLocalization.RNPC_Lynn_MLP;
                    return false;
                case "Liam":
                    __result = ScriptLocalization.RNPC_Liam_MLP;
                    return false;
                case "Anne":
                    __result = ScriptLocalization.RNPC_Anne_MLP;
                    return false;
                case "Miyeon":
                    __result = ScriptLocalization.RNPC_Miyeon_MLP;
                    return false;
                case "Kitty":
                    __result = ScriptLocalization.RNPC_Kitty_MLP;
                    return false;
                case "Lucius":
                    __result = ScriptLocalization.RNPC_Lucius_MLP;
                    return false;
                case "Shang":
                    __result = ScriptLocalization.RNPC_Shang_MLP;
                    return false;
                case "Wesley":
                    __result = ScriptLocalization.RNPC_Wesley_MLP;
                    return false;
                case "Darius":
                    __result = ScriptLocalization.RNPC_Darius_MLP;
                    return false;
                case "Xyla":
                    __result = ScriptLocalization.RNPC_Xyla_MLP;
                    return false;
                case "Catherine":
                    __result = ScriptLocalization.RNPC_Catherine_MLP;
                    return false;
                case "Lucia":
                    __result = ScriptLocalization.RNPC_Lucia_MLP;
                    return false;
                case "Iris":
                    __result = ScriptLocalization.RNPC_Iris_MLP;
                    return false;
                case "Kai":
                    __result = ScriptLocalization.RNPC_Kai_MLP;
                    return false;
                case "Vaan":
                    __result = ScriptLocalization.RNPC_Vaan_MLP;
                    return false;
                case "Nathaniel":
                    __result = ScriptLocalization.RNPC_Nathaniel_MLP;
                    return false;
                default:
                    __result = ScriptLocalization.RNPC_Anne_MLP;
                    return false;
            }
        }
    }

    [HarmonyPatch(typeof(NPCAI), "MarryPlayer")]
    class HarmonyPatch_Player_MarryPlayer
    {
        private static bool Prefix(NPCAI __instance, ref string ____npcName)
        {
            List<string> spouses = new List<string>();
            int count = 0;
            string new_main;

            foreach (var npcai in SingletonBehaviour<NPCManager>.Instance._npcs.Values.Where(npcai => SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("MarriedTo" + npcai.OriginalName)))
            {
                spouses.Add(npcai.OriginalName);
                count += 1;
            }
            if (count <= 1)
            {
                return true;
            }

            if (spouses[0] == ____npcName)
            {
                new_main = spouses[1];
            }
            else
            {
                new_main = spouses[0];
            }
            string current_spouse = SingletonBehaviour<GameSave>.Instance.GetProgressStringCharacter("MarriedWith");

            SingletonBehaviour<GameSave>.Instance.SetProgressBoolWorld(current_spouse + "MarriedWalkPath", false, true);
            NPCAI realNPC = SingletonBehaviour<NPCManager>.Instance.GetRealNPC(current_spouse);
            realNPC.GeneratePath();
            SingletonBehaviour<NPCManager>.Instance.StartNPCPath(realNPC);

            SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("MarriedTo" + ____npcName, true);
            SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("Married", true);
            SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("Dating" + ____npcName, false);
            SingletonBehaviour<GameSave>.Instance.SetProgressStringCharacter("MarriedWith", ____npcName);
            if (SingletonBehaviour<GameSave>.Instance.GetProgressBoolWorld("Tier3House"))
            {
                SingletonBehaviour<GameSave>.Instance.SetProgressBoolWorld(____npcName + "MarriedWalkPath", true, true);
                realNPC = SingletonBehaviour<NPCManager>.Instance.GetRealNPC(____npcName);
                realNPC.GeneratePath();
                SingletonBehaviour<NPCManager>.Instance.StartNPCPath(realNPC);
            }
            Utilities.UnlockAcheivement(100);
            __instance.GenerateCycle(false);
            return false;
        }
    }

    [HarmonyPatch(typeof(Player), "RequestSleep")]
    class HarmonyPatch_Player_RequestSleep
    {
        private static bool Prefix(bool isMarriageBed = false, MarriageOvernightCutscene marriageOvernightCutscene = null, bool isCutsceneComplete = false)
        {
            if (isMarriageBed && !isCutsceneComplete)
            {
                string sleep = "Early";
                if (SingletonBehaviour<DayCycle>.Instance.Time.Hour >= 18 || SingletonBehaviour<DayCycle>.Instance.Time.Hour < 6)
                {
                    sleep = "Sleep";
                }

                LocalizedDialogueTree localizedDialogueTree0 = new LocalizedDialogueTree
                {
                    npc = null
                };


                string name0 = "Bed";
                DialogueNode dialogueNode0 = new DialogueNode();
                dialogueNode0.dialogueText = new List<string>
                {
                    "What do you want to do?"
                };

                Dictionary<int, Response> dictionary0 = new Dictionary<int, Response>();

                Response response01 = new Response();
                response01.responseText = (() => "Sleep");
                response01.action = delegate ()
                {
                    localizedDialogueTree0.Talk(sleep, true, null);
                };
                dictionary0.Add(0, response01);

                Response response02 = new Response();
                response02.responseText = (() => "Change main spouse");
                response02.action = delegate ()
                {
                    localizedDialogueTree0.Talk("ChangeMainSpouse1", true, null);
                };
                dictionary0.Add(1, response02);
                dialogueNode0.responses = dictionary0;

                Response response03 = new Response();
                response03.responseText = (() => "Nothing");
                response03.action = delegate ()
                {
                    DialogueController.Instance.CancelDialogue();
                };
                dictionary0.Add(2, response03);
                dialogueNode0.responses = dictionary0;
                localizedDialogueTree0.AddNode(name0, dialogueNode0);


                string name1 = "Sleep";
                DialogueNode dialogueNode1 = new DialogueNode();
                dialogueNode1.dialogueText = new List<string>
                {
                    ScriptLocalization.SleepRequestSpouse
                };
                Dictionary<int, Response> dictionary1 = new Dictionary<int, Response>();

                Response response04 = new Response();
                response04.responseText = (() => ScriptLocalization.Yes);
                response04.action = delegate ()
                {
                    marriageOvernightCutscene.Begin();
                    DialogueController.Instance.CancelDialogue();
                };
                dictionary1.Add(0, response04);

                Response response05 = new Response();
                response05.responseText = (() => ScriptLocalization.No);
                response05.action = delegate ()
                {
                    DialogueController.Instance.CancelDialogue();
                };
                dictionary1.Add(1, response05);

                dialogueNode1.responses = dictionary1;
                localizedDialogueTree0.AddNode(name1, dialogueNode1);


                string name2 = "Early";
                DialogueNode dialogueNode2 = new DialogueNode();
                dialogueNode2.dialogueText = new List<string>
                {
                    ScriptLocalization.TooEarlyToSleep
                };
                localizedDialogueTree0.AddNode(name2, dialogueNode2);


                string name3 = "ChangeMainSpouse";

                List<string> spouses = new List<string>();
                Dictionary<int, Response> dictionary2 = new Dictionary<int, Response>();
                int i = 0;
                int page = 1;
                string page_name;

                foreach (var npcai in SingletonBehaviour<NPCManager>.Instance._npcs.Values.Where(npcai => SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("MarriedTo" + npcai.OriginalName)))
                {
                    spouses.Add(npcai.OriginalName);
                }
                foreach (var name in spouses)
                {
                    if (i == 3)
                    {
                        DialogueNode dialogueNode3 = new DialogueNode();
                        dialogueNode3.dialogueText = new List<string>
                            {
                                "Who will be the main spouse?"
                            };
                        page_name = name3 + page;
                        page += 1;
                        string next_page_name = name3 + page;

                        Response next_page = new Response();
                        next_page.responseText = (() => "Next");
                        next_page.action = delegate ()
                        {
                            localizedDialogueTree0.Talk(next_page_name, true, null);
                        };
                        dictionary2.Add(i, next_page);
                        dialogueNode3.responses = dictionary2;
                        localizedDialogueTree0.AddNode(page_name, dialogueNode3);


                        i = 0;
                        dictionary2 = new Dictionary<int, Response>();
                    }

                    Response response = new Response();
                    response.responseText = (() => name);
                    response.action = delegate ()
                    {
                        string current_spouse = SingletonBehaviour<GameSave>.Instance.GetProgressStringCharacter("MarriedWith");

                        SingletonBehaviour<GameSave>.Instance.SetProgressBoolWorld(current_spouse + "MarriedWalkPath", false, true);
                        NPCAI realNPC = SingletonBehaviour<NPCManager>.Instance.GetRealNPC(current_spouse);
                        realNPC.GeneratePath();
                        SingletonBehaviour<NPCManager>.Instance.StartNPCPath(realNPC);

                        SingletonBehaviour<GameSave>.Instance.SetProgressStringCharacter("MarriedWith", name);
                        localizedDialogueTree0.Talk("Reenter", true, null);
                    };
                    dictionary2.Add(i, response);
                    i += 1;

                }

                DialogueNode dialogueNode4 = new DialogueNode();
                dialogueNode4.dialogueText = new List<string>
                {
                    "Who will be the main spouse?"
                };
                page_name = name3 + page;

                Response nevermind = new Response();
                nevermind.responseText = (() => "Nevermind");
                nevermind.action = delegate ()
                {
                    DialogueController.Instance.CancelDialogue();
                };
                dictionary2.Add(i, nevermind);
                dialogueNode4.responses = dictionary2;
                localizedDialogueTree0.AddNode(page_name, dialogueNode4);

                string name4 = "Reenter";
                DialogueNode dialogueNode5 = new DialogueNode();
                dialogueNode5.dialogueText = new List<string>
                {
                    "Re-enter the house to apply changes."
                };
                localizedDialogueTree0.AddNode(name4, dialogueNode5);

                localizedDialogueTree0.Talk("Bed", true, null);
                return true;
            }
            else
            {
                return true;
            }
        }
    }

    [HarmonyPatch(typeof(LocalizedDialogueTree), "BernardHandleDivorce")]
    class HarmonyPatch_Player_BernardHandleDivorce
    {
        private static LocalizedDialogueTree HandleConfirm(LocalizedDialogueTree localizedDialogueTree0, string name, string new_main)
        {
            string name1 = "ConfirmDivorce";
            DialogueNode dialogueNode2 = new DialogueNode();
            dialogueNode2.dialogueText = new List<string>
            {
                $"Are you sure you want to divorce {name}?"
            };
            Dictionary<int, Response> dictionary1 = new Dictionary<int, Response>();

            Response response01 = new Response();
            response01.responseText = (() => ScriptLocalization.Yes);
            response01.action = delegate ()
            {
                Utilities.UnlockAcheivement(131);
                if (SingletonBehaviour<GameSave>.Instance.GetProgressStringCharacter("MarriedWith") == name)
                {
                    SingletonBehaviour<GameSave>.Instance.SetProgressStringCharacter("MarriedWith", new_main);
                }
                SingletonBehaviour<GameSave>.Instance.SetProgressBoolCharacter("MarriedTo" + name, false);

                NPCAI realNPC = SingletonBehaviour<NPCManager>.Instance.GetRealNPC(name);
                realNPC.GeneratePath();
                SingletonBehaviour<NPCManager>.Instance.StartNPCPath(realNPC);
                GameSave.CurrentCharacter.Relationships[name] = 40f;
                SingletonBehaviour<NPCManager>.Instance.GetRealNPC(name).GenerateCycle(false);
            };
            dictionary1.Add(0, response01);

            Response response05 = new Response();
            response05.responseText = (() => ScriptLocalization.No);
            response05.action = delegate ()
            {
                DialogueController.Instance.CancelDialogue();
            };
            dictionary1.Add(1, response05);

            dialogueNode2.responses = dictionary1;
            localizedDialogueTree0.AddNode(name1, dialogueNode2);
            return localizedDialogueTree0;
        }

        private static bool Prefix()
        {
            LocalizedDialogueTree localizedDialogueTree0 = new LocalizedDialogueTree
            {
                npc = null
            };

            string name0 = "Divorce";

            List<string> spouses = new List<string>();
            Dictionary<int, Response> dictionary0 = new Dictionary<int, Response>();
            int i = 0;
            int page = 1;
            string page_name;
            int count = 0;
            string new_main;

            foreach (var npcai in SingletonBehaviour<NPCManager>.Instance._npcs.Values.Where(npcai => SingletonBehaviour<GameSave>.Instance.GetProgressBoolCharacter("MarriedTo" + npcai.OriginalName)))
            {
                spouses.Add(npcai.OriginalName);
                count += 1;
            }
            if (count <= 1)
            {
                return true;
            }
            foreach (var name in spouses)
            {
                if (i == 3)
                {
                    DialogueNode dialogueNode0 = new DialogueNode();
                    dialogueNode0.dialogueText = new List<string>
                    {
                        "Who do you want to divorce?"
                    };
                    page_name = name0 + page;
                    page += 1;
                    string next_page_name = name0 + page;

                    Response next_page = new Response();
                    next_page.responseText = (() => "Next");
                    next_page.action = delegate ()
                    {
                        localizedDialogueTree0.Talk(next_page_name, true, null);
                    };
                    dictionary0.Add(i, next_page);
                    dialogueNode0.responses = dictionary0;
                    localizedDialogueTree0.AddNode(page_name, dialogueNode0);


                    i = 0;
                    dictionary0 = new Dictionary<int, Response>();
                }

                Response response = new Response();
                response.responseText = (() => name);
                response.action = delegate ()
                {
                    if (spouses[0] == name)
                    {
                        new_main = spouses[1];
                    } else
                    {
                        new_main = spouses[0];
                    }
                    
                    localizedDialogueTree0 = HandleConfirm(localizedDialogueTree0, name, new_main);
                    localizedDialogueTree0.Talk("ConfirmDivorce", true, null);
                };
                dictionary0.Add(i, response);
                i += 1;

            }

            DialogueNode dialogueNode1 = new DialogueNode();
            dialogueNode1.dialogueText = new List<string>
            {
                "Who do you want to divorce?"
            };
            page_name = name0 + page;

            Response nevermind = new Response();
            nevermind.responseText = (() => "Nevermind");
            nevermind.action = delegate ()
            {
                DialogueController.Instance.CancelDialogue();
            };
            dictionary0.Add(i, nevermind);
            dialogueNode1.responses = dictionary0;
            localizedDialogueTree0.AddNode(page_name, dialogueNode1);

            localizedDialogueTree0.Talk("Divorce1", true, null);

            return false;
        }
    }
}