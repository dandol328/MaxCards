using System.Collections;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using ModdingUtils.Utils;
using UnboundLib.GameModes;

namespace MaxCards
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, "1.0.0")]
    public class MaxCards : BaseUnityPlugin
    {
        private const string ModId = "com.dandol328.rounds.maxcards";
        private const string ModName = "MaxCards";
        private const int DefaultMaxCards = 5;

        internal static ConfigEntry<int> MaxCardsConfig;

        private void Awake()
        {
            MaxCardsConfig = Config.Bind("General", "MaxCards", DefaultMaxCards,
                new ConfigDescription(
                    "Maximum number of cards a player can hold. When exceeded, the oldest cards are removed first.",
                    new AcceptableValueRange<int>(1, 100)));
        }

        private void Start()
        {
            GameModeManager.AddHook(GameModeHooks.HookPlayerPickEnd, EnforceLimit);
        }

        private static IEnumerator EnforceLimit(IGameModeHandler gm)
        {
            int max = MaxCardsConfig.Value;
            foreach (Player player in PlayerManager.instance.players.ToList())
            {
                int excess = player.data.currentCards.Count - max;
                if (excess <= 0) continue;
                // currentCards is ordered oldest -> newest
                var oldest = player.data.currentCards.Take(excess).ToArray();
                for (int i = 0; i < oldest.Length; i++)
                {
                    int index = player.data.currentCards.IndexOf(oldest[i]);
                    if (index >= 0) Cards.instance.RemoveCardFromPlayer(player, index);
                }
            }
            yield break;
        }
    }
}
