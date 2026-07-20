# UMT_Cracked (Universal Minecraft Tool)
## ⚠️DISCLAIMER ANYONE⚠️
WHO HAS SAID TO HAVE MADE A CRACK OF THE PROGRAM IS LYING THIS IS THE ONLY OFFICAL AND WORKING VERSION THAT IS NOT FAKE AND OPEN SOURCE
SnooPeanuts4040 Or IcyModz420 Aka XeIcyScopez HAS NOT HAD ANY WORK IN THIS PROJECT IN ANYWAY SHAPE OR FORM
## I AM THE OFFICIAL DEVELOPER OF THIS PROJECT NO ONE ELSE HAS HELPED IN ANYWAY

## Overview

**UMT_Cracked** is a modified version of the Universal Minecraft Tool designed to allow access to the software without requiring a paid license.
The original application is not free to use, and this project was created to provide an alternative method for people who cannot afford the software or who simply want to test its functionality before purchasing.

This repository contains the required files and supporting components that allow the program to run without triggering license or account validation errors.

---
<h3>Live Discord And GitHub Status</h3>
<div class="container">
  <div class="Live_Discord_Status"><img src="http://keeleanfamily.com/Discord_User_Status?Username=Blitz&Status=Disturb&GitUsername=NewAgent2025&Page=UMT_Cracked" alt="Discord Status And GitHub" />
</div>

# Preview Of (UMT_Cracked)
  <center><div class="UMT_Tool_Cracked_Showcase"><img src="UMT_Cracked_Showcase.svg" alt="UMT_Tool_Cracked_Showcase" /></div></center>

## How It Works

### 1. Authentication Bypass

* The `sign-in.php` file simulates a **successful login request** to the software.
* It returns a response that makes the application believe:

  * The account exists
  * The login credentials are valid
  * The software license is active
* This prevents login errors even when using **non-existent email/username and password combinations**.

### 2. Session Validation

* The `timeCheck.php` script loads data from the `timeCheckRes` file.
* This ensures:

  * No session expiration warnings
  * No invalid session popups
  * When attempting to convert, edit, or use the program’s features, it would not load correctly and would crash.

Without this component, the application would display **errors during authentication**.

### 3. Extension & Server Data

* The `extensionDoc` file is a **ZIP archive** containing a GitHub link used for:

  * Data verification
  * Server-side reference checks
  * This also contains the files, including images and other data for worlds players and tag editing images.
  * This file is **not strictly required** for functionality, but is included for completeness.

### 4. Logout Handling

* The `sign-out.php` file enables:

  * Proper logout behavior
  * No crashes or stuck sessions when exiting the account

---

## Chunk Loading & Conversion Fix

If the software is launched without modification USING the custom ui/overlay then the:

* **Chunks will not load**
* **World conversion will fail**
* **Editor and pruning tools will not function**

This happens because the original program depends on:

`
Data from the official server or domain name is handled by updateActivityLog.php and timeCheck.php
`

which checks for the presence and validity of:

`
UMT_STREAM_ENDED and its AES encryption/decryption mechanisms, along with block processing and several additional components that were added to the system.
`

### So It Was Decided

To restore full functionality, so an additional program e.g software is required. When using the UI overlay in this custom program, the following factors are taken into account:

* A **compatibility layer** is added on top of the cracked software.
* This secondary layer:

  * Loads chunk data normally
  * Enables world conversion between platforms
  * Restores editor and pruning features
  * Mimics the behavior of the original licensed environment

From the application’s perspective, everything appears **fully legitimate and operational**.

---

## Version Handling

* The `version.php` file is **required for any future UMT_Cracked fixes**.
* It only exists so the software:

  * Reports the expected version number
  * Avoids update or mismatch warnings
---

## Working Types For UMT_Cracked

| World Conversion Type     | Version Requirement | Working        |
|--------------------------|--------------------|----------------|
| Xbox 360 → PS3           |  TU1 To TU68–TU75  | ✔️             |
| Xbox 360 → Wii U         |  TU1 To TU68–TU75  | ✔️             |
| PS3 → Xbox 360           |  TU1 To TU68–TU75  | ✔️             |
| Wii U → Xbox 360         |  TU1 To TU68–TU75  | ✔️             |
| (Encrypted) PS3 GAMEDATA |  TU1 To TU68–TU75  | ✔️             |
| Wii U → PS3              |  TU1 To TU68–TU75  | ✔️             |
| PS3 → Wii U              |  TU1 To TU68–TU75  | ✔️             |
| Xbox 360 → JAVA          | TU1 To Any Version | ✔️             |
| PS3 → JAVA               | TU1 To Any Version | ✔️             |
| Wii U → JAVA             | TU1 To Any Version | ✔️             |
| JAVA → Xbox 360          | PC Java To TU1-TU75 | ✔️             |
| JAVA → PS3               | PC Java To TU1-TU75 | ✔️             |
| JAVA → Wii U             | PC Java To TU1-TU75 | ✔️             |
| BEDROCK → Xbox 360       | BEDROCK To TU1-TU75 | ✔️             |
| BEDROCK → PS3            | BEDROCK To TU1-TU75 | ✔️             |
| BEDROCK → Wii U          | BEDROCK To TU1-TU75 | ✔️             |
| JAVA → BEDROCK           |PC Java To BEDROCK PE| ✔️             |
| BEDROCK → JAVA           |BEDROCK PE To PC Java| ✔️             |

### ⚠️TAKE NOTE:
> The mobs in mob spawners are removed during conversion to prevent save failures and potential world crashes.
> 
> Converting Console worlds to Java/Bedrock works without any issues. **June 23 2026 1:42 PM — Fully Fixed July 4th 2026 11:43 PM**
>
> Converting Java/Bedrock worlds to Console Edition currently works only for TU73–TU75 (TU68 not yet supported). All mobs, items, and blocks are preserved 1:1 with TU75. Anything from newer Java versions or modded content is removed (blocks replaced with air, mobs/items deleted). The sky limit is changed to 256 for compatibility. Works without issues.
>
>In comparison, the official UMT software removes mobs and some items during Console To Console conversions, while my version fully preserves this data. For Java To Console conversions, it removes almost every single mob (leaving only about 5-10), does the same with most items, changes some items to older versions, removes or messes up some blocks, and removes some mob heads from TU68-TU73 it also deletes some water blocks. In contrast, my version preserves this data for Java To Console worlds as well.
>
> For Java/Bedrock conversions and when downgrading to older versions, I am using Chunker. It is faster and easier to work with, so please keep this in mind.

<details><summary>Click Here To See What UMT Changes/Removes</summary>
  
<strong>UMT Removes TU68-TU73</strong>

- Game Rules File Removes It For Console To Console Convertion

<strong>UMT Replaces TU73</strong>

- THERE IS NONE SAME FOR BLOCKS

<strong>UMT Removes TU73</strong>

- Mob Spawners
- All Mobs
- Kept Entities 1: Armor Stand 2: Dropped Item "THE REST Are Removed"
- minecraft:command_block 0
- minecraft:repeating_command_block 0
- minecraft:chain_command_block 0
- minecraft:command_block_minecart 0
- minecraft:water 0
- minecraft:lava 0

<strong>UMT Replaces TU68</strong>
  
- minecraft:dark_oak_stairs To minecraft:jungle_stairs Aka id:163

- <strong>BLOCKS REPLACED</strong>

- minecraft:dried_kelp_block 0 To minecraft:air
- minecraft:stripped_log_oak 0 To minecraft:air
- minecraft:stripped_log_spruce 0 To minecraft:air
- minecraft:stripped_log_birch 0 To minecraft:air
- minecraft:stripped_log_jungle 0 To minecraft:air
- minecraft:stripped_log_acacia 0 To minecraft:air
- minecraft:stripped_log_dark_oak 0 To minecraft:air
- minecraft:blue_ice 0 To minecraft:log 0 Aka id:17
- minecraft:spruce_trapdoor 0 To minecraft:air And minecraft:leaves 2 Aka id:18:2 And minecraft:leaves 3 Aka id:18:3 And minecraft:leaves 0 Aka id:18:0 And minecraft:leaves 1 Aka id:18:1
- minecraft:birch_trapdoor 0 To minecraft:leaves 0 Aka id:18:0 And minecraft:sponge 0 Aka id:19 And minecraft:sponge 1 Aka id:19:1
- minecraft:jungle_trapdoor 0 To minecraft:glass 0 Aka id:20
- minecraft:acacia_trapdoor 0 To minecraft:lapis_ore 0 Aka id:21
- minecraft:dark_oak_trapdoor 0 To minecraft:lapis_block 0 Aka id:22
- minecraft:prismarine_slab 0 To minecraft:air
- minecraft:prismarine_slab 1 To minecraft:air
- minecraft:prismarine_slab 2 To minecraft:air
- minecraft:prismarine_bricks_stairs 2 To minecraft:air
- minecraft:dark_prismarine_stairs 2 To minecraft:air
- minecraft:prismarine_stairs 2 To minecraft:air
- minecraft:pumpkin 0 To minecraft:air
- minecraft:deadbush 0 To minecraft:air
- minecraft:spruce_button 4 To minecraft:air
- minecraft:birch_button 4 To minecraft:air
- minecraft:jungle_button 4 To minecraft:air
- minecraft:acacia_button 4 To minecraft:air
- minecraft:dark_oak_button 4 To minecraft:air
- minecraft:spruce_pressure_plate 0 To minecraft:obsidian Aka id:49
- minecraft:birch_pressure_plate 0 To minecraft:tnt Aka id:46
- minecraft:jungle_pressure_plate 0 To minecraft:mossy_cobblestone Aka id:48
- minecraft:acacia_pressure_plate 0 To minecraft:brick_block Aka id:45
- minecraft:dark_oak_pressure_plate 0 To minecraft:bookshelf Aka id:47
- minecraft:turtle_egg 0 To minecraft:air
- minecraft:conduit 0 To minecraft:air
- minecraft:command_block 0 To minecraft:air
- minecraft:repeating_command_block 0 To minecraft:air
- minecraft:chain_command_block 0 To minecraft:air
- minecraft:command_block_minecart 0 To minecraft:air

<strong>UMT Removes TU68</strong>
- minecraft:prismarine_slab 0
- minecraft:prismarine_slab 1
- minecraft:prismarine_slab 2
- minecraft:prismarine_bricks_stairs 2
- minecraft:dark_prismarine_stairs 2
- minecraft:prismarine_stairs 2
- minecraft:blue_ice 0
- minecraft:spruce_trapdoor 0
- minecraft:birch_trapdoor 0
- minecraft:jungle_trapdoor 0
- minecraft:acacia_trapdoor 0
- minecraft:dark_oak_trapdoor 0
- minecraft:sandstone 2
- minecraft:dried_kelp_block 0
- minecraft:leaves2 8
- minecraft:leaves2 9
- minecraft:tallgrass 0
- minecraft:stripped_log_oak 0
- minecraft:stripped_log_spruce 0
- minecraft:stripped_log_birch 0
- minecraft:stripped_log_jungle 0
- minecraft:stripped_log_acacia 0
- minecraft:stripped_log_dark_oak 0
- minecraft:turtle_egg 0
- minecraft:conduit 0
- minecraft:coral_block 0
- minecraft:coral_block 1
- minecraft:coral_block 2
- minecraft:coral_block 3
- minecraft:coral_block 4
- minecraft:coral_block 5
- minecraft:coral_block 6
- minecraft:coral_block 7
- minecraft:coral_block 8
- minecraft:coral_block 9
- minecraft:coral_block 10
- minecraft:coral_block 11
- minecraft:coral_block 12
- minecraft:coral_fan_dead 0
- minecraft:coral_fan_dead 1
- minecraft:coral_fan_dead 2
- minecraft:coral_fan_dead 3
- minecraft:coral_fan_dead 4
- minecraft:piston 5
- minecraft:sticky_piston 5
- minecraft:spruce_button 4
- minecraft:birch_button 4
- minecraft:jungle_button 4
- minecraft:acacia_button 4
- minecraft:dark_oak_button 4
- minecraft:spruce_pressure_plate 0
- minecraft:birch_pressure_plate 0
- minecraft:jungle_pressure_plate 0
- minecraft:acacia_pressure_plate 0
- minecraft:dark_oak_pressure_plate 0
- minecraft:coral_fan 0
- minecraft:coral_fan 1
- minecraft:coral_fan 2
- minecraft:coral_fan 3
- minecraft:coral_fan 4
- minecraft:coral 0
- minecraft:coral 1
- minecraft:coral 2
- minecraft:coral 3
- minecraft:coral 4
- minecraft:sea_grass 0
- minecraft:kelp 0
- minecraft:sea_pickle 0
- minecraft:silver_shulker_box 1
- minecraft:pumpkin 0
- minecraft:command_block 0
- minecraft:repeating_command_block 0
- minecraft:chain_command_block 0
- minecraft:command_block_minecart 0
- minecraft:water 0
- minecraft:lava 0

<strong>UMT JAVA TO CONSOLE AND CONSOLE TO JAVA REMOVED ITEMS TU68-TU73</strong>
- minecraft:mob_spawner 0
- minecraft:spawn_egg 0
- minecraft:wither 0
- minecraft:giant 0
- minecraft:ender_dragon 0
- minecraft:rabbit 0
- minecraft:illusioner 0
- minecraft:water 0
- minecraft:skull 0
- minecraft:snow_layer 0
- minecraft:snow_layer 1
- minecraft:snow_layer 2
- minecraft:snow_layer 3
- minecraft:snow_layer 4
- minecraft:snow_layer 5
- minecraft:snow_layer 6
- minecraft:snow_layer 7
- minecraft:log 12
- minecraft:log 13
- minecraft:log 14
- minecraft:log 15
- minecraft:log2 12
- minecraft:log2 13
- minecraft:lit_redstone_lamp 0
- minecraft:debug_fourj_item 0
- minecraft:skull 3
- minecraft:powered_repeater 0
- minecraft:unpowered_repeater 0
- minecraft:spectral_arrow 0
- minecraft:command_block_minecart 0
- minecraft:fire_charge 1
- minecraft:carrots 0
- minecraft:potatoes 0
- minecraft:beetroots 0
- minecraft:powered_comparator 0
- minecraft:unpowered_comparator 0
- minecraft:cocoa 0
- minecraft:melon_stem 0
- minecraft:pumpkin_stem 0
- minecraft:double_wooden_slab 3
- minecraft:double_wooden_slab 0
- minecraft:double_wooden_slab 1
- minecraft:vex 0
- minecraft:double_wooden_slab 2
- minecraft:dolphin 0
- minecraft:double_stone_slab 6
- minecraft:unlit_redstone_torch 0
- minecraft:lit_redstone_ore 0
- minecraft:wall_sign 0
- minecraft:standing_sign 0
- minecraft:lit_furnace 0
- minecraft:double_stone_slab 5
- minecraft:redstone_wire 0
- minecraft:piston_head 0
- minecraft:double_stone_slab 4
- minecraft:lava 0
- minecraft:double_wooden_slab 4
- minecraft:double_wooden_slab 5
- minecraft:double_stone_slab 7
- minecraft:dirt 1
- minecraft:double_stone_slab 0
- minecraft:double_stone_slab 1
- minecraft:double_stone_slab 2
- minecraft:double_stone_slab 3
- minecraft:command_block 0
- minecraft:repeating_command_block 0
- minecraft:chain_command_block 0
- minecraft:lingering_potion 0
- minecraft:strong_poison 0
- minecraft:strong_regeneration 0
- minecraft:strong_strength 0
- minecraft:strong_turtle_master 0
- minecraft:bucket 0
- minecraft:lava_bucket 0
- minecraft:water_bucket 0
- minecraft:milk_bucket 0
- minecraft:fish_bucket 0
- minecraft:salmon_bucket 0
- minecraft:puffer_bucket 0
- minecraft:tropical_bucket 0
- minecraft:snowball 0
- minecraft:paper 0
- minecraft:book 0
- minecraft:writable_book 0
- minecraft:ender_pearl 0
- minecraft:ender_eye 0
- minecraft:nether_star 0
- minecraft:creeper 0
- minecraft:skeleton 0
- minecraft:wither_skeleton 0
- minecraft:stray 0
- minecraft:spider 0
- minecraft:cave_spider 0
- minecraft:zombie 0
- minecraft:wool 15
- minecraft:wool 11
- minecraft:wool 3
- minecraft:wool 9
- minecraft:wool 13
- minecraft:wool 5
- minecraft:wool 6
- minecraft:wool 2
- minecraft:wool 10
- minecraft:wool 14
- minecraft:wool 12
- minecraft:wool 1
- minecraft:wool 4
- minecraft:wool 0
- minecraft:wool 8
- minecraft:wool 7
- minecraft:carpet 15
- minecraft:carpet 11
- minecraft:carpet 3
- minecraft:carpet 9
- minecraft:carpet 13
- minecraft:carpet 5
- minecraft:carpet 6
- minecraft:carpet 2
- minecraft:carpet 10
- minecraft:carpet 14
- minecraft:carpet 12
- minecraft:long_poison 0
- minecraft:long_regeneration 0
- minecraft:long_strength 0
- minecraft:long_weakness 0
- minecraft:long_turtle_master 0
- minecraft:long_slow_falling 0
- minecraft:potion 0
- minecraft:strong_leaping 0
- minecraft:strong_swiftness 0
- minecraft:strong_healing 0
- minecraft:strong_harming 0
- minecraft:splash_potion 0
- minecraft:lime_glazed_terracotta 2
- minecraft:pink_glazed_terracotta 2
- minecraft:magenta_glazed_terracotta 2
- minecraft:purple_glazed_terracotta 2
- minecraft:red_glazed_terracotta 2
- minecraft:brown_glazed_terracotta 2
- minecraft:orange_glazed_terracotta 2
- minecraft:yellow_glazed_terracotta 2
- minecraft:white_glazed_terracotta 2
- minecraft:silver_glazed_terracotta 2
- minecraft:gray_glazed_terracotta 2
- minecraft:banner 1
- minecraft:banner 14
- minecraft:banner 11
- minecraft:banner 10
- minecraft:banner 12
- minecraft:banner 6
- minecraft:banner 4
- minecraft:banner 5
- minecraft:banner 13
- minecraft:banner 9
- minecraft:banner 15
- minecraft:banner 8
- minecraft:banner 7
- minecraft:banner 0
- minecraft:banner 2
- minecraft:banner 3
- minecraft:rotten_flesh 0
- minecraft:spider_eye 0
- minecraft:potato 0
- minecraft:baked_potato 0
- minecraft:poisonous_potato 0
- minecraft:carrot 0
- minecraft:golden_carrot 0
- minecraft:pumpkin_pie 0
- minecraft:beetroot 0
- minecraft:chorus_fruit 0
- minecraft:dried_kelp 0
- minecraft:compass 0
- minecraft:leather_helmet 0
- minecraft:leather_chestplate 0
- minecraft:leather_leggings 0
- minecraft:leather_boots 0
- minecraft:wooden_sword 0
- minecraft:wooden_shovel 0
- minecraft:wooden_pickaxe 0
- minecraft:wooden_axe 0
- minecraft:wooden_hoe 0
- minecraft:map 0
- minecraft:chainmail_helmet 0
- minecraft:chainmail_chestplate 0
- minecraft:chainmail_leggings 0
- minecraft:chainmail_boots 0
- minecraft:stone_sword 0
- minecraft:lime_shulker_box 1
- minecraft:pink_shulker_box 1
- minecraft:magenta_shulker_box 1
- minecraft:purple_shulker_box 1
- minecraft:red_shulker_box 1
- minecraft:brown_shulker_box 1
- minecraft:orange_shulker_box 1
- minecraft:yellow_shulker_box 1
- minecraft:white_shulker_box 1
- minecraft:silver_shulker_box 1
- minecraft:gray_shulker_box 1
- minecraft:bed 15
- minecraft:bed 11
- minecraft:bed 3
- minecraft:bed 9
- minecraft:bed 13
- minecraft:bed 5
- minecraft:bed 6
- minecraft:bed 2
- minecraft:bed 10
- minecraft:bed 14
- minecraft:bed 12
- minecraft:bed 1
- minecraft:bed 4
- minecraft:bed 0
- minecraft:bed 8
- minecraft:bed 7
- minecraft:fish 0
- minecraft:salmon 0
- minecraft:pufferfish 0
- minecraft:tropicalfish 0
- minecraft:parrot 0
- minecraft:wolf 0
- minecraft:ocelot 0
- minecraft:polar_bear 0
- minecraft:horse 0
- minecraft:donkey 0
- minecraft:mule 0
- minecraft:skeleton_horse 0
- minecraft:zombie_horse 0
- minecraft:llama 0
- minecraft:turtle 0
- minecraft:phantom 0
- minecraft:record_13 0
- minecraft:record_cat 0
- minecraft:record_blocks 0
- minecraft:record_chirp 0
- minecraft:record_far 0
- minecraft:record_mall 0
- minecraft:record_mellohi 0
- minecraft:record_stal 0
- minecraft:record_strad 0
- minecraft:record_ward 0
- minecraft:enchanted_book 0
- minecraft:experience_bottle 0
- minecraft:dragon_breath 0
- minecraft:ghast_tear 0
- minecraft:fermented_spider_eye 0
- minecraft:blaze_powder 0
- minecraft:magma_cream 0
- minecraft:speckled_melon 0
- minecraft:rabbit_foot 0
- minecraft:phantom_membrane 0
- minecraft:glass_bottle 0
- minecraft:awkward 0
- minecraft:night_vision 0
- minecraft:invisibility 0
- minecraft:leaping 0
- minecraft:fire_resistance 0
- minecraft:stained_glass_pane 6
- minecraft:stained_glass_pane 2
- minecraft:stained_glass_pane 10
- minecraft:stained_glass_pane 14
- minecraft:stained_glass_pane 12
- minecraft:stained_glass_pane 1
- minecraft:stained_glass_pane 4
- minecraft:stained_glass_pane 0
- minecraft:stained_glass_pane 8
- minecraft:stained_glass_pane 7
- minecraft:red_mushroom_block 11
- minecraft:brown_mushroom_block 11
- minecraft:brown_mushroom_block 0
- minecraft:brown_mushroom_block 10
- minecraft:sea_pickle 0
- minecraft:kelp 0
- minecraft:sea_grass 0
- minecraft:coral 0
- minecraft:coral 1
- minecraft:coral 2
- minecraft:coral 3
- minecraft:coral 4
- minecraft:coral_fan 0
- minecraft:coral_fan 1
- minecraft:coral_fan 2
- minecraft:coral_fan 3
- minecraft:coral_fan 4
- minecraft:carpet 1
- minecraft:carpet 4
- minecraft:carpet 0
- minecraft:carpet 8
- minecraft:carpet 7
- minecraft:stained_glass 15
- minecraft:stained_glass 11
- minecraft:stained_glass 3
- minecraft:stained_glass 9
- minecraft:stained_glass 13
- minecraft:stained_glass 5
- minecraft:stained_glass 6
- minecraft:stained_glass 2
- minecraft:stained_glass 10
- minecraft:stained_glass 14
- minecraft:stained_glass 12
- minecraft:stained_glass 1
- minecraft:stained_glass 4
- minecraft:stained_glass 0
- minecraft:stained_glass 8
- minecraft:stained_glass 7
- minecraft:stained_glass_pane 15
- minecraft:stained_glass_pane 11
- minecraft:stained_glass_pane 3
- minecraft:stained_glass_pane 9
- minecraft:stained_glass_pane 13
- minecraft:stained_glass_pane 5
- minecraft:diamond_leggings 0
- minecraft:diamond_boots 0
- minecraft:diamond_sword 0
- minecraft:diamond_shovel 0
- minecraft:diamond_pickaxe 0
- minecraft:diamond_axe 0
- minecraft:diamond_hoe 0
- minecraft:clock 0
- minecraft:shears 0
- minecraft:fishing_rod 0
- minecraft:carrot_on_a_stick 0
- minecraft:lead 0
- minecraft:totem_of_undying 0
- minecraft:diamond_horse_armor 0
- minecraft:golden_horse_armor 0
- minecraft:iron_horse_armor 0
- minecraft:leather_horse_armor 0
- minecraft:armor_stand 0
- minecraft:turtle_helmet 0
- minecraft:trident 0
- minecraft:tipped_arrow 0
- minecraft:swiftness 0
- minecraft:slowness 0
- minecraft:zombie_villager 0
- minecraft:husk 0
- minecraft:drowned 0
- minecraft:slime 0
- minecraft:witch 0
- minecraft:silverfish 0
- minecraft:ghast 0
- minecraft:zombie_pigman 0
- minecraft:blaze 0
- minecraft:magma_cube 0
- minecraft:enderman 0
- minecraft:endermite 0
- minecraft:shulker 0
- minecraft:guardian 0
- minecraft:elder_guardian 0
- minecraft:evocation_illager 0
- minecraft:vindication_illager 0
- minecraft:villager 0
- minecraft:bat 0
- minecraft:pig 0
- minecraft:sheep 0
- minecraft:cow 0
- minecraft:mooshroom 0
- minecraft:chicken 0
- minecraft:squid 0
- minecraft:boat 0
- minecraft:spruce_boat 0
- minecraft:birch_boat 0
- minecraft:jungle_boat 0
- minecraft:acacia_boat 0
- minecraft:dark_oak_boat 0
- minecraft:dispenser 0
- minecraft:noteblock 0
- minecraft:piston 5
- minecraft:sticky_piston 5
- minecraft:tnt 0
- minecraft:lever 4
- minecraft:stone_button 4
- minecraft:wooden_button 4
- minecraft:spruce_button 4
- minecraft:birch_button 4
- minecraft:jungle_button 4
- minecraft:acacia_button 4
- minecraft:dark_oak_button 4
- minecraft:stone_pressure_plate 0
- minecraft:wooden_pressure_plate 0
- minecraft:spruce_pressure_plate 0
- minecraft:birch_pressure_plate 0
- minecraft:jungle_pressure_plate 0
- minecraft:acacia_pressure_plate 0
- minecraft:dark_oak_pressure_plate 0
- minecraft:redstone 0
- minecraft:beetroot_seeds 0
- minecraft:wheat 0
- minecraft:reeds 0
- minecraft:egg 0
- minecraft:sugar 0
- minecraft:slime_ball 0
- minecraft:blaze_rod 0
- minecraft:gold_nugget 0
- minecraft:iron_nugget 0
- minecraft:shulker_shell 0
- minecraft:nether_wart 0
- minecraft:chorus_fruit_popped 0
- minecraft:turtle_shell_piece 0
- minecraft:dye 0
- minecraft:dye 4
- minecraft:dye 12
- minecraft:dye 6
- minecraft:dye 2
- minecraft:dye 10
- minecraft:dye 9
- minecraft:dye 13
- minecraft:dye 5
- minecraft:dye 1
- minecraft:dye 3
- minecraft:dye 14
- minecraft:dye 11
- minecraft:dye 15
- minecraft:turtle_master 0
- minecraft:slow_falling 0
- minecraft:water_breathing 0
- minecraft:healing 0
- minecraft:harming 0
- minecraft:poison 0
- minecraft:regeneration 0
- minecraft:strength 0
- minecraft:weakness 0
- minecraft:luck 0
- minecraft:long_night_vision 0
- minecraft:long_invisibility 0
- minecraft:long_leaping 0
- minecraft:long_fire_resistance 0
- minecraft:long_swiftness 0
- minecraft:long_slowness 0
- minecraft:long_water_breathing 0
- minecraft:coal 0
- minecraft:coal 1
- minecraft:diamond 0
- minecraft:emerald 0
- minecraft:iron_ingot 0
- minecraft:gold_ingot 0
- minecraft:quartz 0
- minecraft:brick 0
- minecraft:netherbrick 0
- minecraft:stick 0
- minecraft:bowl 0
- minecraft:bone 0
- minecraft:string 0
- minecraft:feather 0
- minecraft:flint 0
- minecraft:leather 0
- minecraft:rabbit_hide 0
- minecraft:gunpowder 0
- minecraft:clay_ball 0
- minecraft:glowstone_dust 0
- minecraft:prismarine_crystals 0
- minecraft:prismarine_shard 0
- minecraft:nautilus 0
- minecraft:nautilus_core 0
- minecraft:wheat_seeds 0
- minecraft:melon_seeds 0
- minecraft:pumpkin_seeds 0
- minecraft:coral_fan_dead 0
- minecraft:coral_fan_dead 1
- minecraft:coral_fan_dead 2
- minecraft:coral_fan_dead 3
- minecraft:coral_fan_dead 4
- minecraft:coral_block 0
- minecraft:coral_block 1
- minecraft:coral_block 2
- minecraft:coral_block 3
- minecraft:coral_block 4
- minecraft:coral_block 8
- minecraft:coral_block 9
- minecraft:coral_block 10
- minecraft:coral_block 11
- minecraft:coral_block 12
- minecraft:rail 0
- minecraft:golden_rail 0
- minecraft:detector_rail 0
- minecraft:activator_rail 0
- minecraft:ladder 2
- minecraft:minecart 0
- minecraft:furnace_minecart 0
- minecraft:hopper_minecart 0
- minecraft:tnt_minecart 0
- minecraft:elytra 0
- minecraft:saddle 0
- minecraft:dye 7
- minecraft:dye 8
- minecraft:apple 0
- minecraft:golden_apple 0
- minecraft:golden_apple 1
- minecraft:mushroom_stew 0
- minecraft:rabbit_stew 0
- minecraft:beetroot_soup 0
- minecraft:bread 0
- minecraft:cookie 0
- minecraft:cooked_fish 0
- minecraft:cooked_fish 1
- minecraft:fish 1
- minecraft:fish 2
- minecraft:fish 3
- minecraft:cooked_porkchop 0
- minecraft:porkchop 0
- minecraft:cooked_beef 0
- minecraft:beef 0
- minecraft:cooked_chicken 0
- minecraft:cooked_mutton 0
- minecraft:mutton 0
- minecraft:cooked_rabbit 0
- minecraft:redstone_block 0
- minecraft:redstone_torch 5
- minecraft:repeater 0
- minecraft:redstone_lamp 0
- minecraft:tripwire_hook 2
- minecraft:daylight_detector 0
- minecraft:dropper 0
- minecraft:hopper 0
- minecraft:comparator 0
- minecraft:trapped_chest 2
- minecraft:heavy_weighted_pressure_plate 0
- minecraft:light_weighted_pressure_plate 0
- minecraft:observer 3
- minecraft:cake 0
- minecraft:chest 2
- minecraft:ender_chest 2
- minecraft:crafting_table 0
- minecraft:furnace 2
- minecraft:brewing_stand 0
- minecraft:enchanting_table 0
- minecraft:beacon 0
- minecraft:conduit 0
- minecraft:black_shulker_box 1
- minecraft:blue_shulker_box 1
- minecraft:light_blue_shulker_box 1
- minecraft:cyan_shulker_box 1
- minecraft:green_shulker_box 1
- minecraft:end_portal_frame 2
- minecraft:end_crystal 0
- minecraft:jukebox 0
- minecraft:anvil 2
- minecraft:cauldron 0
- minecraft:turtle_egg 0
- minecraft:stone_shovel 0
- minecraft:stone_pickaxe 0
- minecraft:stone_axe 0
- minecraft:stone_hoe 0
- minecraft:bow 0
- minecraft:iron_helmet 0
- minecraft:iron_chestplate 0
- minecraft:iron_leggings 0
- minecraft:iron_boots 0
- minecraft:iron_sword 0
- minecraft:iron_shovel 0
- minecraft:iron_pickaxe 0
- minecraft:iron_axe 0
- minecraft:iron_hoe 0
- minecraft:arrow 0
- minecraft:golden_helmet 0
- minecraft:golden_chestplate 0
- minecraft:golden_leggings 0
- minecraft:golden_boots 0
- minecraft:golden_sword 0
- minecraft:golden_shovel 0
- minecraft:golden_pickaxe 0
- minecraft:golden_axe 0
- minecraft:golden_hoe 0
- minecraft:flint_and_steel 0
- minecraft:diamond_helmet 0
- minecraft:diamond_chestplate 0
- minecraft:record_11 0
- minecraft:record_wait 0
- minecraft:fireworks 0
- minecraft:stripped_log_oak 0
- minecraft:stripped_log_spruce 0
- minecraft:stripped_log_birch 0
- minecraft:stripped_log_jungle 0
- minecraft:stripped_log_acacia 0
- minecraft:stripped_log_dark_oak 0
- minecraft:leaves2 8
- minecraft:leaves2 9
- minecraft:waterlily 0
- minecraft:torch 5
- minecraft:tallgrass 0
- minecraft:tallgrass 1
- minecraft:tallgrass 2
- minecraft:deadbush 0
- minecraft:yellow_flower 0
- minecraft:red_flower 0
- minecraft:red_flower 1
- minecraft:red_flower 2
- minecraft:red_flower 3
- minecraft:red_flower 4
- minecraft:red_flower 5
- minecraft:red_flower 6
- minecraft:red_flower 7
- minecraft:red_flower 8
- minecraft:double_plant 0
- minecraft:double_plant 1
- minecraft:double_plant 2
- minecraft:double_plant 3
- minecraft:double_plant 4
- minecraft:double_plant 5
- minecraft:grass_path 0
- minecraft:sandstone 2
- minecraft:sandstone 1
- minecraft:sand 1
- minecraft:red_sandstone 2
- minecraft:red_sandstone 1
- minecraft:stone 1
- minecraft:stone 2
- minecraft:stone 5
- minecraft:stone 6
- minecraft:stone 3
- minecraft:stone 4
- minecraft:stonebrick 1
- minecraft:stonebrick 2
- minecraft:stonebrick 3
- minecraft:monster_egg 0
- minecraft:monster_egg 1
- minecraft:monster_egg 2
- minecraft:monster_egg 3
- minecraft:monster_egg 4
- minecraft:monster_egg 5
- minecraft:dirt 2
- minecraft:nether_brick 0
- minecraft:red_nether_brick 0
- minecraft:end_bricks 0
- minecraft:quartz_block 1
- minecraft:quartz_block 2
- minecraft:trapdoor 0
- minecraft:concrete 12
- minecraft:concrete 1
- minecraft:concrete 4
- minecraft:concrete 0
- minecraft:concrete 8
- minecraft:concrete 7
- minecraft:concrete_powder 15
- minecraft:concrete_powder 11
- minecraft:concrete_powder 3
- minecraft:concrete_powder 9
- minecraft:concrete_powder 13
- minecraft:concrete_powder 5
- minecraft:concrete_powder 6
- minecraft:concrete_powder 2
- minecraft:concrete_powder 10
- minecraft:concrete_powder 14
- minecraft:concrete_powder 12
- minecraft:concrete_powder 1
- minecraft:concrete_powder 4
- minecraft:concrete_powder 0
- minecraft:concrete_powder 8
- minecraft:concrete_powder 7
- minecraft:black_glazed_terracotta 2
- minecraft:blue_glazed_terracotta 2
- minecraft:light_blue_glazed_terracotta 2
- minecraft:cyan_glazed_terracotta 2
- minecraft:green_glazed_terracotta 2
- minecraft:brick_block 0
- minecraft:magma 0
- minecraft:prismarine 1
- minecraft:prismarine 2
- minecraft:fence 0
- minecraft:dark_oak_fence 0
- minecraft:stonebrick 0
- minecraft:skull 1
- minecraft:skull 2
- minecraft:skull 4
- minecraft:skull 5
- minecraft:prismarine_slab 1
- minecraft:prismarine_slab 2
- minecraft:oak_stairs 2
- minecraft:spruce_stairs 2
- minecraft:birch_stairs 2
- minecraft:jungle_stairs 2
- minecraft:acacia_stairs 2
- minecraft:dark_oak_stairs 2
- minecraft:stone_stairs 2
- minecraft:brick_stairs 2
- minecraft:stone_brick_stairs 2
- minecraft:nether_brick_stairs 2
- minecraft:sandstone_stairs 2
- minecraft:red_sandstone_stairs 2
- minecraft:quartz_stairs 2
- minecraft:purpur_stairs 2
- minecraft:prismarine_stairs 2
- minecraft:prismarine_bricks_stairs 2
- minecraft:dark_prismarine_stairs 2
- minecraft:hardened_clay 0
- minecraft:stained_hardened_clay 15
- minecraft:stained_hardened_clay 11
- minecraft:stained_hardened_clay 3
- minecraft:stained_hardened_clay 9
- minecraft:stained_hardened_clay 13
- minecraft:fence_gate 2
- minecraft:spruce_fence_gate 2
- minecraft:birch_fence_gate 2
- minecraft:jungle_fence_gate 2
- minecraft:acacia_fence_gate 2
- minecraft:dark_oak_fence_gate 2
- minecraft:wooden_door 0
- minecraft:stone_slab 0
- minecraft:stone_slab 1
- minecraft:stone_slab2 0
- minecraft:wooden_slab 0
- minecraft:wooden_slab 1
- minecraft:wooden_slab 2
- minecraft:wooden_slab 3
- minecraft:wooden_slab 4
- minecraft:wooden_slab 5
- minecraft:stone_slab 3
- minecraft:stone_slab 4
- minecraft:stone_slab 5
- minecraft:stone_slab 6
- minecraft:stone_slab 7
- minecraft:stained_hardened_clay 5
- minecraft:stained_hardened_clay 6
- minecraft:stained_hardened_clay 2
- minecraft:stained_hardened_clay 10
- minecraft:stained_hardened_clay 14
- minecraft:stained_hardened_clay 12
- minecraft:stained_hardened_clay 1
- minecraft:stained_hardened_clay 4
- minecraft:stained_hardened_clay 0
- minecraft:stained_hardened_clay 8
- minecraft:stained_hardened_clay 7
- minecraft:sponge 1
- minecraft:melon_block 0
- minecraft:lit_pumpkin 0
- minecraft:sapling 0
- minecraft:sapling 1
- minecraft:sapling 2
- minecraft:sapling 3
- minecraft:sapling 4
- minecraft:sapling 5
- minecraft:leaves 8
- minecraft:leaves 9
- minecraft:leaves 10
- minecraft:leaves 11
- minecraft:web 0
- minecraft:sign 0
- minecraft:end_rod 1
- minecraft:cobblestone_wall 1
- minecraft:concrete 15
- minecraft:concrete 11
- minecraft:concrete 3
- minecraft:concrete 9
- minecraft:concrete 13
- minecraft:concrete 5
- minecraft:concrete 6
- minecraft:concrete 2
- minecraft:concrete 10
- minecraft:concrete 14
- minecraft:stripped_log_oak 0
- minecraft:stripped_log_spruce 0
- minecraft:stripped_log_birch 0
- minecraft:stripped_log_jungle 0
- minecraft:stripped_log_acacia 0
- minecraft:stripped_log_dark_oak 0
- minecraft:leaves2 8
- minecraft:leaves2 9
- minecraft:waterlily 0
- minecraft:torch 5
- minecraft:tallgrass 0
- minecraft:tallgrass 1
- minecraft:tallgrass 2
- minecraft:deadbush 0
- minecraft:yellow_flower 0
- minecraft:red_flower 0
- minecraft:red_flower 1
- minecraft:red_flower 2
- minecraft:red_flower 3
- minecraft:red_flower 4
- minecraft:red_flower 5
- minecraft:red_flower 6
- minecraft:red_flower 7
- minecraft:red_flower 8
- minecraft:double_plant 0
- minecraft:double_plant 1
- minecraft:double_plant 2
- minecraft:double_plant 3
- minecraft:double_plant 4
- minecraft:double_plant 5
- minecraft:grass_path 0
- minecraft:sandstone 2
- minecraft:sandstone 1
- minecraft:sand 1
- minecraft:red_sandstone 2
- minecraft:red_sandstone 1
- minecraft:stone 1
- minecraft:stone 2
- minecraft:stone 5
- minecraft:stone 6
- minecraft:stone 3
- minecraft:stone 4
- minecraft:stonebrick 1
- minecraft:stonebrick 2
- minecraft:stonebrick 3
- minecraft:monster_egg 0
- minecraft:monster_egg 1
- minecraft:monster_egg 2
- minecraft:monster_egg 3
- minecraft:monster_egg 4
- minecraft:monster_egg 5
- minecraft:dirt 1
- minecraft:dirt 2
- minecraft:nether_brick 0
- minecraft:red_nether_brick 0
- minecraft:end_bricks 0
- minecraft:quartz_block 1
- minecraft:quartz_block 2
- minecraft:trapdoor 0
- minecraft:concrete 12
- minecraft:concrete 1
- minecraft:concrete 4
- minecraft:concrete 0
- minecraft:concrete 8
- minecraft:concrete 7
- minecraft:concrete_powder 15
- minecraft:concrete_powder 11
- minecraft:concrete_powder 3
- minecraft:concrete_powder 9
- minecraft:concrete_powder 13
- minecraft:concrete_powder 5
- minecraft:concrete_powder 6
- minecraft:concrete_powder 2
- minecraft:concrete_powder 10
- minecraft:concrete_powder 14
- minecraft:concrete_powder 12
- minecraft:concrete_powder 1
- minecraft:concrete_powder 4
- minecraft:concrete_powder 0
- minecraft:concrete_powder 8
- minecraft:concrete_powder 7
- minecraft:black_glazed_terracotta 2
- minecraft:blue_glazed_terracotta 2
- minecraft:light_blue_glazed_terracotta 2
- minecraft:cyan_glazed_terracotta 2
- minecraft:green_glazed_terracotta 2
- minecraft:brick_block 0
- minecraft:magma 0
- minecraft:prismarine 1
- minecraft:prismarine 2
- minecraft:slime 0
- minecraft:fence 0
- minecraft:dark_oak_fence 0
- minecraft:stonebrick 0
- minecraft:skull 0
- minecraft:skull 1
- minecraft:skull 2
- minecraft:skull 3
- minecraft:skull 4
- minecraft:skull 5
- minecraft:prismarine_slab 1
- minecraft:prismarine_slab 2
- minecraft:oak_stairs 2
- minecraft:spruce_stairs 2
- minecraft:birch_stairs 2
- minecraft:jungle_stairs 2
- minecraft:acacia_stairs 2
- minecraft:dark_oak_stairs 2
- minecraft:stone_stairs 2
- minecraft:brick_stairs 2
- minecraft:stone_brick_stairs 2
- minecraft:nether_brick_stairs 2
- minecraft:sandstone_stairs 2
- minecraft:red_sandstone_stairs 2
- minecraft:quartz_stairs 2
- minecraft:purpur_stairs 2
- minecraft:prismarine_stairs 2
- minecraft:prismarine_bricks_stairs 2
- minecraft:dark_prismarine_stairs 2
- minecraft:hardened_clay 0
- minecraft:stained_hardened_clay 15
- minecraft:stained_hardened_clay 11
- minecraft:stained_hardened_clay 3
- minecraft:stained_hardened_clay 9
- minecraft:stained_hardened_clay 13
- minecraft:fence_gate 2
- minecraft:spruce_fence_gate 2
- minecraft:birch_fence_gate 2
- minecraft:jungle_fence_gate 2
- minecraft:acacia_fence_gate 2
- minecraft:dark_oak_fence_gate 2
- minecraft:wooden_door 0
- minecraft:stone_slab 0
- minecraft:stone_slab 1
- minecraft:stone_slab2 0
- minecraft:wooden_slab 0
- minecraft:wooden_slab 1
- minecraft:wooden_slab 2
- minecraft:wooden_slab 3
- minecraft:wooden_slab 4
- minecraft:wooden_slab 5
- minecraft:stone_slab 3
- minecraft:stone_slab 4
- minecraft:stone_slab 5
- minecraft:stone_slab 6
- minecraft:stone_slab 7
- minecraft:stained_hardened_clay 5
- minecraft:stained_hardened_clay 6
- minecraft:stained_hardened_clay 2
- minecraft:stained_hardened_clay 10
- minecraft:stained_hardened_clay 14
- minecraft:stained_hardened_clay 12
- minecraft:stained_hardened_clay 1
- minecraft:stained_hardened_clay 4
- minecraft:stained_hardened_clay 0
- minecraft:stained_hardened_clay 8
- minecraft:stained_hardened_clay 7
- minecraft:sponge 1
- minecraft:melon_block 0
- minecraft:lit_pumpkin 0
- minecraft:sapling 0
- minecraft:sapling 1
- minecraft:sapling 2
- minecraft:sapling 3
- minecraft:sapling 4
- minecraft:sapling 5
- minecraft:leaves 8
- minecraft:leaves 9
- minecraft:leaves 10
- minecraft:leaves 11
- minecraft:snow_layer 0
- minecraft:web 0
- minecraft:sign 0
- minecraft:end_rod 1
- minecraft:cobblestone_wall 1
- minecraft:concrete 15
- minecraft:concrete 11
- minecraft:concrete 3
- minecraft:concrete 9
- minecraft:concrete 13
- minecraft:concrete 5
- minecraft:concrete 6
- minecraft:concrete 2
- minecraft:concrete 10
- minecraft:concrete 14
</details>

---

<h3>Creator Blocked Me</h3>
<img width="579" height="269" alt="UMT_Creator_Blocked_Me" src="https://github.com/user-attachments/assets/5f1aca4c-3ceb-4b6a-bff5-1e4e8207f0ca" />

<details>
<summary><h3>Click Here For: Possible Sources & Confirmed Components Used In Official UMT</h3></summary>

**Chunker (Extremely Likely After More Research)**
- Tool for upgrading/downgrading Minecraft worlds and converting between editions.  
- Java: 26.2 → 1.8.8
- Bedrock: 1.26.30 → 1.12.0
- Supports Java ↔ Bedrock + Bedrock downgrading and upgrading
- [Chunker Open Source](https://github.com/HiveGamesOSS/Chunker)

> There is no official proof Mat used Chunker, but it would make sense logically instead of rebuilding these systems repeatedly.

**leveldb-mcpe-latest-build (Confirmed)**  
- [Leveldb-MCPE-Latest-Build](https://github.com/Amulet-Team/leveldb-mcpe)
- Used for handling Bedrock world data (LevelDB format)
- Confirmed via UMT source code
<img width="677" height="46" alt="image" src="https://github.com/user-attachments/assets/d1754c13-770a-46f4-aca0-14a88dd266e6" />

**XMemcompress (Confirmed)**
- [XMemcompress](https://github.com/gibbed/XCompression)
- Used For Compiling And Decompiling Xbox 360 Files
<img width="248" height="42" alt="image" src="https://github.com/user-attachments/assets/56b9e9e2-31b5-45e5-9c78-0ff2ef75f886" />
<img width="241" height="67" alt="image" src="https://github.com/user-attachments/assets/6768aacf-811d-4ed8-a78e-470ef6e89b57" />
<img width="506" height="217" alt="image" src="https://github.com/user-attachments/assets/95549d4e-1747-4b4f-9177-d44698831bda" />
</details>

## Purpose of This Project

This project was created to:

* Help users who **cannot afford** the original software
* Allow people to **test features before buying**
* Provide an **educational example** of how request validation systems function

---

## Disclaimer

This repository is provided for **educational and research purposes only**.

* No ownership of the original software is claimed.
* Users are responsible for how they use the contents of this repository.
* Supporting the original developers by purchasing legitimate software is always recommended if you are able to do so.
