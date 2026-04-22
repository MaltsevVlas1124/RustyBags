using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using ItemManager;
using RustyBags.Managers;
using RustyBags.Utilities;
using ServerSync;
using UnityEngine;
using Toggle = RustyBags.Managers.Toggle;

namespace RustyBags
{
    [BepInDependency("vapok.mods.adventurebackpacks", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("randyknapp.mods.epicloot", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("Azumatt.AzuCraftyBoxes", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("ZenDragon.ZenConstruction", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("Azumatt.AzuExtendedPlayerInventory", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class RustyBagsPlugin : BaseUnityPlugin
    {
        internal const string ModName = "RustyBags";
        internal const string ModVersion = "1.3.4";
        internal const string Author = "RustyMods";
        private const string ModGUID = Author + "." + ModName;
        public const string ConfigFileName = ModGUID + ".cfg";
        public static readonly string ConfigFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;
        internal static string ConnectionError = "";
        public readonly Harmony _harmony = new(ModGUID);
        public static readonly ManualLogSource RustyBagsLogger = BepInEx.Logging.Logger.CreateLogSource(ModName);
        public static readonly ConfigSync ConfigSync = new(ModGUID) { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion };

        public static RustyBagsPlugin instance = null!;
        public static readonly Dir BagDir = new (Paths.ConfigPath, "RustyBags");
        public static GameObject root = null!;


        public static bool isEpicLootLoaded;
        public void Awake()
        {
            instance = this;
            root = new GameObject("RustyBags.Prefab.Root");
            DontDestroyOnLoad(root);
            root.SetActive(false);

            isEpicLootLoaded = Chainloader.PluginInfos.ContainsKey("randyknapp.mods.epicloot");
            
            Item.DefaultConfigurability = Configurability.Recipe;
            
            ItemRegistrar.Register();
            Configs.Setup();
            Keys.Write();
            Localizer.Load();
            SetupEPI();
            BagCraft.Init();
            EpicLoot_Compat.Load();
            Assembly assembly = Assembly.GetExecutingAssembly();
            _harmony.PatchAll(assembly);
        }

        public void SetupEPI()
        {
            if (!AzuExtendedPlayerInventory.API.IsLoaded()) return;
            ConfigEntry<Toggle> addBagSlotConfig = Configs.config("2 - Extended Player Inventory", "Add Bag Slot", Toggle.On, "If on, will add bag slot to EPI");
            
            OnBagSlotConfigChange();
            addBagSlotConfig.SettingChanged += (_, _) =>
            {
                OnBagSlotConfigChange();
            };
            ConfigEntry<Toggle> addQuiverSlotConfig = Configs.config("2 - Extended Player Inventory", "Add Quiver Slot", Toggle.On,
                "If on, will add quiver slot to EPI");
            
            OnQuiverSlotConfigChange();
            addQuiverSlotConfig.SettingChanged += (_, _) =>
            {
                OnQuiverSlotConfigChange();
            };
            return;

            void OnQuiverSlotConfigChange()
            {
                AzuExtendedPlayerInventory.API.RemoveSlot(Keys.Quiver);
                if (addQuiverSlotConfig.Value is Toggle.On)
                {
                    AzuExtendedPlayerInventory.API.AddSlot(Keys.Quiver, player => player.GetEquippedQuiver(),
                        item =>
                        {
                            if (item is not Quiver) return false;
                            if (Configs.MultipleBags) return true;
                            return !(Player.m_localPlayer?.HasBag() ?? false);
                        });
                }
            }

            void OnBagSlotConfigChange()
            {
                AzuExtendedPlayerInventory.API.RemoveSlot(Keys.Bag);
                if (addBagSlotConfig.Value is Toggle.On)
                {
                    AzuExtendedPlayerInventory.API.AddSlot(Keys.Bag, player => player.GetBag(),
                        item =>
                        {
                            if (item is not Bag) return false;
                            if (item is Quiver) return false;
                            if (Configs.MultipleBags) return true;
                            return !(Player.m_localPlayer?.HasBag() ?? false);
                        });
                }
            }
        }
        
        private void OnDestroy()
        {
            Config.Save();
        }
    }
}