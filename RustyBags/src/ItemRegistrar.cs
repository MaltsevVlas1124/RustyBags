using ItemManager;

namespace RustyBags;

internal static class ItemRegistrar
{
    internal static void Register()
    {
        RegisterLeatherBag();
        RegisterBarrelBag();
        RegisterMinerBag();
        RegisterBearBag();
        RegisterDwarfBag();
        RegisterQuiver();
        RegisterMountainQuiver();
        RegisterCrossbowQuiver();
    }

    private static void RegisterLeatherBag()
    {
        Item leatherBag = new Item(Constants.BagsBundle, Constants.LeatherBagPrefab);
        leatherBag.Name.English("Simple Bag");
        leatherBag.Description.English("Worn and weathered, this humble pouch once carried the mead of a wandering skald. Its leather still whispers of long journeys and forgotten songs.");
        leatherBag.RequiredItems.Add("LeatherScraps", 20);
        leatherBag.RequiredItems.Add("DeerHide", 10);
        leatherBag.RequiredItems.Add("Resin", 15);
        leatherBag.RequiredUpgradeItems.Add("LeatherScraps", 10, 2);
        leatherBag.RequiredUpgradeItems.Add("DeerHide", 5, 2);
        leatherBag.RequiredUpgradeItems.Add("Resin", 8, 2);
        leatherBag.RequiredUpgradeItems.Add("BoneFragments", 10, 3);
        leatherBag.RequiredUpgradeItems.Add("DeerHide", 5, 3);
        leatherBag.RequiredUpgradeItems.Add("Copper", 5, 3);
        leatherBag.RequiredUpgradeItems.Add("BjornHide", 10, 4);
        leatherBag.RequiredUpgradeItems.Add("DeerHide", 5, 4);
        leatherBag.RequiredUpgradeItems.Add("Bronze", 5, 4);
        leatherBag.Crafting.Add(CraftingTable.Workbench, 1);
        BagSetup leatherSetup = new BagSetup(leatherBag, 5, 2);
        leatherSetup.AddSizePerQuality(6, 2, 2);
        leatherSetup.AddSizePerQuality(7, 2, 3);
        leatherSetup.AddSizePerQuality(8, 2, 4);
        leatherSetup.statusEffect.m_baseCarryWeight = 25f;
    }

    private static void RegisterBarrelBag()
    {
        Item barrelBag = new Item(Constants.BagsBundle, Constants.BarrelBagPrefab);
        barrelBag.Name.English("Barrel Bag");
        barrelBag.Description.English("Repurposed from an old swamp barrel, bound tight with iron hoops. Sturdy, spacious, and surprisingly watertight.");
        barrelBag.RequiredItems.Add("ElderBark", 10);
        barrelBag.RequiredItems.Add("Iron", 5);
        barrelBag.RequiredItems.Add("Guck", 5);
        barrelBag.RequiredItems.Add("LeatherScraps", 20);
        barrelBag.RequiredUpgradeItems.Add("ElderBark", 5, 2);
        barrelBag.RequiredUpgradeItems.Add("Iron", 2, 2);
        barrelBag.RequiredUpgradeItems.Add("Guck", 3, 2);
        barrelBag.RequiredUpgradeItems.Add("LeatherScraps", 10, 2);
        barrelBag.RequiredUpgradeItems.Add("WolfPelt", 10, 3);
        barrelBag.RequiredUpgradeItems.Add("Silver", 5, 3);
        barrelBag.RequiredUpgradeItems.Add("WolfClaw", 5, 3);
        barrelBag.RequiredUpgradeItems.Add("WolfHairBundle", 5, 3);
        barrelBag.RequiredUpgradeItems.Add("WolfPelt", 5, 4);
        barrelBag.RequiredUpgradeItems.Add("Silver", 2, 4);
        barrelBag.RequiredUpgradeItems.Add("WolfClaw", 3, 4);
        barrelBag.RequiredUpgradeItems.Add("WolfHairBundle", 2, 4);
        barrelBag.Crafting.Add(CraftingTable.Forge, 1);
        BagSetup barrelSetup = new BagSetup(barrelBag, 8, 2);
        barrelSetup.AddSizePerQuality(8, 3, 2);
        barrelSetup.AddSizePerQuality(8, 4, 3);
        barrelSetup.AddSizePerQuality(8, 5, 4);
        barrelSetup.statusEffect.m_baseCarryWeight = 50f;
    }

    private static void RegisterMinerBag()
    {
        Item minerBag = new Item(Constants.BagsBundle, Constants.MinerBagPrefab);
        minerBag.Name.English("Miner Bag");
        minerBag.Description.English("A treasure chest turned humble pack, still smelling faintly of gold dust and damp stone.");
        minerBag.RequiredItems.Add("ElderBark", 10);
        minerBag.RequiredItems.Add("Iron", 5);
        minerBag.RequiredItems.Add("Guck", 5);
        minerBag.RequiredItems.Add("LeatherScraps", 20);
        minerBag.RequiredUpgradeItems.Add("ElderBark", 5, 2);
        minerBag.RequiredUpgradeItems.Add("Iron", 2, 2);
        minerBag.RequiredUpgradeItems.Add("Guck", 3, 2);
        minerBag.RequiredUpgradeItems.Add("LeatherScraps", 10, 2);
        minerBag.RequiredUpgradeItems.Add("WolfPelt", 10, 3);
        minerBag.RequiredUpgradeItems.Add("Silver", 5, 3);
        minerBag.RequiredUpgradeItems.Add("WolfClaw", 5, 3);
        minerBag.RequiredUpgradeItems.Add("WolfHairBundle", 5, 3);
        minerBag.RequiredUpgradeItems.Add("WolfPelt", 5, 4);
        minerBag.RequiredUpgradeItems.Add("Silver", 2, 4);
        minerBag.RequiredUpgradeItems.Add("WolfClaw", 3, 4);
        minerBag.RequiredUpgradeItems.Add("WolfHairBundle", 2, 4);
        minerBag.Crafting.Add(CraftingTable.Forge, 1);
        BagSetup minerSetup = new BagSetup(minerBag, 6, 2, replaceShader: false, isOreBag: true);
        minerSetup.AddSizePerQuality(7, 3, 2);
        minerSetup.AddSizePerQuality(7, 4, 3);
        minerSetup.AddSizePerQuality(8, 4, 4);
        minerSetup.statusEffect.m_speedModifier = -0.1f;
        minerSetup.statusEffect.m_baseCarryWeight = 50f;
        minerSetup.statusEffect.m_inventoryWeightModifier = 0.5f;
    }

    private static void RegisterBearBag()
    {
        Item bearBag = new Item(Constants.BagsBundle, Constants.BearBagPrefab);
        bearBag.Name.English("Wretched Bag");
        bearBag.Description.English("Stitched from sinew and bones. Its frame creaks faintly, as though the beast still hungers for the life it lost.");
        bearBag.RequiredItems.Add("TrophyBjornUndead", 1);
        bearBag.RequiredItems.Add("UndeadBjornRibcage", 1);
        bearBag.RequiredItems.Add("LinenThread", 30);
        bearBag.RequiredItems.Add("LoxPelt", 10);
        bearBag.RequiredUpgradeItems.Add("BjornHide", 5, 2);
        bearBag.RequiredUpgradeItems.Add("LinenThread", 10, 2);
        bearBag.RequiredUpgradeItems.Add("Flax", 10, 2);
        bearBag.RequiredUpgradeItems.Add("LoxPelt", 5, 2);
        bearBag.RequiredUpgradeItems.Add("BjornHide", 10, 3);
        bearBag.RequiredUpgradeItems.Add("LinenThread", 20, 3);
        bearBag.RequiredUpgradeItems.Add("Flax", 20, 3);
        bearBag.RequiredUpgradeItems.Add("LoxPelt", 10, 3);
        bearBag.RequiredUpgradeItems.Add("BjornHide", 20, 4);
        bearBag.RequiredUpgradeItems.Add("LinenThread", 40, 4);
        bearBag.RequiredUpgradeItems.Add("Flax", 40, 4);
        bearBag.RequiredUpgradeItems.Add("LoxPelt", 20, 4);
        bearBag.Crafting.Add(CraftingTable.Workbench, 1);
        BagSetup bearSetup = new BagSetup(bearBag, 8, 5);
        bearSetup.AddSizePerQuality(8, 6, 2);
        bearSetup.AddSizePerQuality(8, 7, 3);
        bearSetup.AddSizePerQuality(8, 8, 4);
        bearSetup.statusEffect.m_baseCarryWeight = 75f;
        ModelReplacer bearReplacement = new ModelReplacer(bearBag.Prefab);
        bearReplacement.Add("attach/model/bear/default", new ModelReplacer.ReplacementInfo("TrophyBjornUndead", "attach/default"));
        bearReplacement.Add("attach/model/bear/model", new ModelReplacer.ReplacementInfo("UndeadBjornRibcage", "model"));
    }

    private static void RegisterDwarfBag()
    {
        Item dwarfBag = new Item(Constants.BagsBundle, Constants.DwarfBagPrefab);
        dwarfBag.Name.English("Dverger Bag");
        dwarfBag.Description.English("It hums faintly with the heat of forge-fires and the scent of old ale.");
        dwarfBag.RequiredItems.Add("Copper", 15);
        dwarfBag.RequiredItems.Add("Eitr", 10);
        dwarfBag.RequiredItems.Add("YggdrasilWood", 15);
        dwarfBag.RequiredItems.Add("JuteBlue", 5);
        dwarfBag.RequiredUpgradeItems.Add("Copper", 2, 2);
        dwarfBag.RequiredUpgradeItems.Add("Eitr", 5, 2);
        dwarfBag.RequiredUpgradeItems.Add("YggdrasilWood", 10, 2);
        dwarfBag.RequiredUpgradeItems.Add("JuteBlue", 3, 2);
        dwarfBag.RequiredUpgradeItems.Add("FlametalNew", 2, 3);
        dwarfBag.RequiredUpgradeItems.Add("AskHide", 5, 3);
        dwarfBag.RequiredUpgradeItems.Add("CharredBone", 10, 3);
        dwarfBag.RequiredUpgradeItems.Add("YggdrasilWood", 3, 3);
        dwarfBag.RequiredUpgradeItems.Add("FlametalNew", 4, 4);
        dwarfBag.RequiredUpgradeItems.Add("AskHide", 10, 4);
        dwarfBag.RequiredUpgradeItems.Add("CharredBone", 20, 4);
        dwarfBag.RequiredUpgradeItems.Add("YggdrasilWood", 6, 4);
        dwarfBag.Crafting.Add(CraftingTable.BlackForge, 1);
        BagSetup dwarfSetup = new BagSetup(dwarfBag, 8, 8);
        dwarfSetup.AddSizePerQuality(8, 9, 2);
        dwarfSetup.AddSizePerQuality(8, 10, 3);
        dwarfSetup.AddSizePerQuality(8, 11, 4);
        dwarfSetup.statusEffect.m_baseCarryWeight = 100f;
        ModelReplacer dwarfReplacement = new ModelReplacer(dwarfBag.Prefab);
        dwarfReplacement.Add("attach/model/chest/stonechest", new ModelReplacer.ReplacementInfo("TreasureChest_dvergrtown", "New/stonechest"));
        dwarfReplacement.Add("attach/model/chest/stonechesttop_closed", new ModelReplacer.ReplacementInfo("TreasureChest_dvergrtown", "New/stonechesttop_closed"));
    }

    private static void RegisterQuiver()
    {
        Item quiver = new Item(Constants.BagsBundle, Constants.QuiverPrefab);
        quiver.Name.English("Simple Quiver");
        quiver.Description.English("It bears the scent of the wild. Each arrow drawn carries the spirit of the chase.");
        quiver.RequiredItems.Add("LeatherScraps", 20);
        quiver.RequiredItems.Add("BoneFragments", 10);
        quiver.RequiredItems.Add("DeerHide", 5);
        quiver.RequiredUpgradeItems.Add("TrollHide", 10, 2);
        quiver.RequiredUpgradeItems.Add("BoneFragments", 5, 2);
        quiver.RequiredUpgradeItems.Add("Iron", 10, 3);
        quiver.RequiredUpgradeItems.Add("BjornHide", 5, 3);
        quiver.RequiredUpgradeItems.Add("Silver", 10, 4);
        quiver.RequiredUpgradeItems.Add("WolfPelt", 5, 4);
        quiver.Crafting.Add(CraftingTable.Workbench, 1);
        BagSetup quiverSetup = new BagSetup(quiver, 4, 1, true);
        quiverSetup.AddSizePerQuality(5, 1, 2);
        quiverSetup.AddSizePerQuality(6, 1, 3);
        quiverSetup.AddSizePerQuality(7, 1, 4);
        quiverSetup.statusEffect.m_skillLevel = Skills.SkillType.Bows;
        quiverSetup.statusEffect.m_skillLevelModifier = 10f;
        quiverSetup.statusEffect.m_speedModifier = 0f;
        ModelReplacer replacement = new ModelReplacer(quiver.Prefab);
        replacement.Add("attach/Quiver/model", new ModelReplacer.ReplacementInfo("DeerHide", "model"));
    }

    private static void RegisterMountainQuiver()
    {
        Item mountainQuiver = new Item(Constants.BagsBundle, Constants.MountainQuiverPrefab);
        mountainQuiver.Name.English("Fur Quiver");
        mountainQuiver.Description.English("It bears the scent of the wild. Each arrow drawn carries the spirit of the chase.");
        mountainQuiver.RequiredItems.Add("WolfPelt", 20);
        mountainQuiver.RequiredItems.Add("Silver", 20);
        mountainQuiver.RequiredItems.Add("BjornHide", 5);
        mountainQuiver.RequiredUpgradeItems.Add("Iron", 5, 2);
        mountainQuiver.RequiredUpgradeItems.Add("LinenThread", 15, 2);
        mountainQuiver.RequiredUpgradeItems.Add("Eitr", 5, 3);
        mountainQuiver.RequiredUpgradeItems.Add("Carapace", 5, 3);
        mountainQuiver.RequiredUpgradeItems.Add("FlametalNew", 5, 4);
        mountainQuiver.RequiredUpgradeItems.Add("CharredBone", 15, 4);
        mountainQuiver.Crafting.Add(CraftingTable.Forge, 1);
        BagSetup mountainQuiverSetup = new BagSetup(mountainQuiver, 8, 1, true);
        mountainQuiverSetup.AddSizePerQuality(8, 2, 2);
        mountainQuiverSetup.AddSizePerQuality(8, 3, 3);
        mountainQuiverSetup.AddSizePerQuality(8, 4, 4);
        mountainQuiverSetup.statusEffect.m_skillLevel = Skills.SkillType.Bows;
        mountainQuiverSetup.statusEffect.m_skillLevelModifier = 10f;
        mountainQuiverSetup.statusEffect.m_speedModifier = 0f;
        mountainQuiverSetup.statusEffect.m_inventoryWeightModifier = 0.5f;
    }

    private static void RegisterCrossbowQuiver()
    {
        Item crossbowQuiver = new Item(Constants.BagsBundle, Constants.CrossbowQuiverPrefab);
        crossbowQuiver.Name.English("Crossbow Quiver");
        crossbowQuiver.Description.English("Bound in oiled leather and reinforced with brass rings — a quiver fit for a dwarf who favors precision over luck.");
        crossbowQuiver.RequiredItems.Add("WolfPelt", 20);
        crossbowQuiver.RequiredItems.Add("Silver", 20);
        crossbowQuiver.RequiredItems.Add("BjornHide", 5);
        crossbowQuiver.RequiredUpgradeItems.Add("Iron", 5, 2);
        crossbowQuiver.RequiredUpgradeItems.Add("LinenThread", 15, 2);
        crossbowQuiver.RequiredUpgradeItems.Add("Eitr", 5, 3);
        crossbowQuiver.RequiredUpgradeItems.Add("Carapace", 5, 3);
        crossbowQuiver.RequiredUpgradeItems.Add("FlametalNew", 5, 4);
        crossbowQuiver.RequiredUpgradeItems.Add("CharredBone", 15, 4);
        crossbowQuiver.Crafting.Add(CraftingTable.Forge, 1);
        BagSetup crossbowSetup = new BagSetup(crossbowQuiver, 8, 1, true);
        crossbowSetup.AddSizePerQuality(8, 2, 2);
        crossbowSetup.AddSizePerQuality(8, 3, 3);
        crossbowSetup.AddSizePerQuality(8, 4, 4);
        crossbowSetup.statusEffect.m_skillLevel = Skills.SkillType.Crossbows;
        crossbowSetup.statusEffect.m_skillLevelModifier = 10f;
        crossbowSetup.statusEffect.m_speedModifier = 0f;
        ModelReplacer replacement = new ModelReplacer(crossbowQuiver.Prefab);
        replacement.Add("attach/Quiver/default", new ModelReplacer.ReplacementInfo("TrophyGoblinShaman", "attach/default"));
    }
}
