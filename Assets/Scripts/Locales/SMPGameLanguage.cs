using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Language
{
	ENGLISH = 0,
	FRENCH,
    KHMER,
    SPANISH
}

public partial class SMPGameLanguage
{

	public SMPGameLanguage()
	{
		InitLanuage();
	}

    #region Using

	public string please_check_your_internet_connection;
	public string downloading_required_assets;
	public string loading_required_assets;
	public string checking_required_assets;
	public string loading;
	public string starting_game;
    public string[] difficulty_status = new string[4];
    public string home_needHelp;

    public string menu_setting;
    public string setting_soundFx;
    public string setting_soundMusic;
    public string setting_fairy_ads;
    public string setting_login;
    public string setting_logout;
    public string setting_language_name;
    public string setting_language_title;
    public string setting_music_medium;
    public string setting_music_low;
    public string setting_music_high;
    public string setting_notification;
    public string setting_power_saving;
    public string setting_privacy;
    public string setting_support;
    public string setting_account;
    public string setting_bank;
    public string setting_customerID;
    public string setting_on;
    public string setting_off;
	public string setting_restore;
	public string dialog_restore_purchase_completed;
	public string dialog_restore_purchase_fail;
	public string dialog_restore_no_item;

    public string video_title;
    public string video_title_gold;
    public string video_title_diamond;
    public string video_title_HOM;
	public string video_title_shadow_clone;
	public string video_title_thunder_attack;
	public string video_title_tap_damage;
	public string video_title_critical_chance;
	public string video_title_attack_speed;
    public string video_bonus;
    public string video_bonus_gold;
    public string diamonds;
    public string video_close;
    public string video_watch;
    public string video_collect_gift;
    public string video_title_double_offline_gold;
    public string video_title_kill_boss;
    public string video_bonus_kill_boss_desc;
	public string video_bonus_second;
	public string video_one_shot;
	public string video_not_avaialble;

    public string inventory_tap_team;
    public string inventory_tap_skill;
    public string inventory_tap_supporter;
    public string inventory_tap_pet;
    public string inventory_tap_store;
	public string inventory_tap_inventory;
	public string inventory_tap_hero;

    public string inventory_bt_levelup;
    public string inventory_bt_buy;
    public string inventory_bt_max;
	public string inventory_txt_max;
    public string inventory_bt_hire;
    public string inventory_bt_unlock_skill;
    public string inventroy_bt_use_it_now;
    public string inventroy_bt_buy_it_now { get; set; }
	public string inventory_bt_resurretion;
	public string inventory_bt_upgrade;
	public string inventory_bt_regenerate;
	public string inventory_bt_time { get; set; }
	public string inventory_bt_already_bought { get; set; }
	public string skill_second;
    public string skill_unlock_at;
	public string skill_unlk_at;
    public string skill_duration;
    public string skill_cool_down;
    public string skill_active_skills;
	public string skill_on_boss_title { get; set; }
    public string skill_passive_skills;
    public string[] skill_description = new string[] {"","","","","","","","","","", "" };
	public string skill_require_at_least_2_heroes;
	public string skill_require_at_least_2_pets;
	public string skill_require_n_hero_more;
	public string skill_require_n_pet_more;

	public string support_damage_persecond;

    public string perk_power_of_holding_alert;
	public string perk_header;
    public string[] perk_title = new string[5];
    public string[] perk_descriptions = new string[5];
	public string store_header;
	public string store_no_ads_optional;
    public string store_no_ads_video_skippable;
    public string store_more_diamons;
    public string store_remove_ads;
    public string store_no_ads;
    public string store_full_version;
    public string store_price_not_availble;
	public string store_free_title;
	public string store_free_description;
	public string store_free_button_text;
	public string store_free_price_text;

    public string shop_title;
    public string shop_description;
    public string shop_bonus;

    public string achm_title​ { get; set; }
	public string achm_alert_title;
    public string achm_description;
    public string achm_collect_now;
    public string achm_reward;
    public string achm_complete;
    public string[] achm_item_title = new string[20];

    public string teamselect_title;
	public string teamselect_subheader_title;
    public string teamselect_description;
	public string teamselect_active;
	public string teamselect_use_now;
	public string teamselect_lock;
	public string teamselect_change;
	public string teamselect_all_team_dps;
	public string teamselect_empty_support_title;
	public string teamselect_empty_support_desc;
	public string teamselect_power_team_up { get; set; }
	public string teamselect_hero_type { get; set; }
	public string teamselect_support_type { get; set; }
	public string teamselect_change_your { get; set; }
	public string teamselect_active_on_select { get; set; }
	public string teamselect_hero_on_select { get; set; }
	public string teamselect_support_on_select { get; set; }
	public string teamselect_dmg { get; set; }
	public string teamselect_dps { get; set; }
	public string teamselect_skills { get; set; }
	public string teamselect_sttc_tap_counter { get; set; }
	public string teamselect_sttc_boss_victory { get; set; }
	public string teamselect_sttc_ghost_kill { get; set; }
	public string teamupselect_title { get; set; }

    public string[] hero_names = new string[9];
    public string[] hero_active_skill_names = new string[11];

	public string support_all_supporter_dps;
    public string support_skill_evolve;
    public string support_skill_icon_unlock;
	public string support_active_title;
	public string support_flying_title { get; set; }
	public string support_passive_title;
    public SupporterInfo[] supporters_info = new SupporterInfo[20];
    public string[] support_skill_type_descriptions = new string[11];

    public string dps_current;
    public string dps_pet_damage;
    public string dps_shield;
    public string dps_tap;
    public string dps_heroes;
    public string dps_mana_desc;
	public string dps_mana_pm_per_min;

    public string bgift_tap_damage;
    public string bgift_attack_speed;
    public string bgift_critical_chance;
    public string bgift_shadow_clown;
    public string bgift_diamond;
	public string bgift_diamonds;
    public string bgift_gold;
    public string bgift_hand_of_midas;

    public string pls_bt_leave_battle;
    public string pls_bt_fight_boss;
    public string pls_failed_to_fight_boss;
    public string pls_stage_unlock;

	public string pls_battle;
	public string pls_revenge;
	public string pls_title_revenge;
	public string pls_title_boss;
	public string pls_title_big_boss;

	public string account_creation_text_des {get; set;}
	public string account_creation_text_reward {get; set;}
	public string account_creation_sign_in_with_apple { get; set; }
	public string account_creation_sign_in_with_facebook { get; set; }
	public string account_creation_logout { get; set; }
	public string account_creation_save { get; set; }
	public string account_creation_text_name {get; set;}
	public string account_creation_text_name_place_holder {get; set;}
	public string account_creation_text_avatar {get; set;}
	public string account_creation_text_avatar_des {get; set;}

	public string stat_title { get; set; }
	public string stat_tap_continue { get; set; }
	public string stat_button_watch { get; set; }
	public string stat_quest { get; set; }
	public string stat_team_hit { get; set; }
	public string stat_boss_hit { get; set; }
	public string stat_combo_hit { get; set; }
	public string stat_diamonds { get; set; }
	public string stat_coin { get; set; }
	public string stat_reward { get; set; }
	public string stat_claim { get; set; }

	public string stat_your_statistic { get; set; }
	public string stat_description { get; set; }
	public string stat_general_title { get; set; }
	public string stat_dps_title { get; set; }
	public string stat_damage_title { get; set; }
	public string stat_legend_title { get; set; }

	public string stat_level;
	public string stat_active_skills;
	public string stat_best_DPS;
	public string stat_base_tap_dps;
	public string stat_average_tap_dps;
	public string stat_total_support_dps;
	public string stat_total_fly_support_dps;
	public string stat_total_hero_tap_damage;
	public string stat_total_hero_critical_damage;
	public string stat_total_hero_critical_chnace;
	public string stat_hero_ability_damage;
	public string stat_total_supports_damage;
	public string stat_total_flying_supports_damage;
	public string stat_total_pets_damage;
	public string stat_total_skill_pet_support_damage;
	public string stat_total_skill_pet_hero_damage;
	public string stat_mana_skill_cooldown;
	public string stat_ghost_wave;
	public string stat_mana_capacity;
	public string stat_mana_regeneration;
	public string stat_critical_chance;
	public string stat_gato_cat_chance;
	public string stat_total_taps;
	public string stat_highest_stage_reach;
	public string stat_boss_victory;
	public string stat_big_boss_victory;
	public string stat_boss_failded;
	public string stat_big_boss_failded;
	public string stat_crown_collect;
	public string stat_boss_fight_max_duration;
	public string stat_big_boss_fight_max_duration;
	public string stat_revenge_figh_max_duration;
	public string stat_number_boss_kill_by;
	public string stat_number_big_boss_kill_by;
	public string stat_heroes_revive;
	public string stat_critical_hits;
	public string stat_total_pet_levels;
	public string stat_all_pets_attack;
	public string stat_all_pets_big_attack;
	public string stat_all_tap_pets_attack;
	public string stat_total_skip_wave;
	public string stat_daily_quest_achived;
	public string stat_quest_achieved;
	public string stat_total_achievement;
	public string stat_flucky_bird_tapped;
	public string stat_gato_cat_killed;
	public string stat_total_gold_from_gato_cat;
	public string stat_hold_automatic_duration;
	public string stat_offline_gold_earnings;
	public string stat_watch_video;
	public string stat_flucky_bird_gold_earning;
	public string stat_boss_gold_earning;
	public string stat_give_me_cash_gold_earning;
	public string stat_gold_finger_gold_earning;
	public string stat_doom_of_god_used;
	public string stat_gold_earned;
	public string stat_all_mana_gainded;
	public string stat_all_diamonds_collected;
	public string stat_all_gold_collected;
	public string stat_total_powerup_used;
	public string stat_total_perks_used;
	public string stat_play_time;
	public string stat_day_since_install;

	public string request_network_error;
	public string request_client_error;
	public string request_server_error;
	public string request_unknown_error;
	public string request_sync_data_error;

	public string inventory_bagpack { get; set; }
	public string inventory_marketplace { get; set; }
	public string inventory_filter_all { get; set; }
	public string inventory_retry { get; set; }
	public string inventory_item_detail_hero_select { get; set; }
	public string inventory_equip_now { get; set; }
	public string inventory_repair_now { get; set; }
	public string inventory_sell_now { get; set; }
	public string inventory_sell_item_unit { get; set; }
	public string inventory_full_bag_pack_msg { get; set; }
	public string inventory_unequip { get; set; }

	public string item_imp_inc_speed_support;
	public string item_imp_inc_hp_support;
	public string item_imp_inc_gold_drop;
	public string item_imp_freeze_enemy;
	public string item_imp_poison_enemy;
	public string item_imp_sheep_enemy;
	public string item_imp_fire_enemy;
	public string item_imp_inc_mana;
	public string item_imp_inc_mana_speed;
	public string item_imp_size_hero;
	public string item_imp_hp_heal_got_hit;
	public string item_imp_poison_attack;
	public string item_imp_freeze_attack;
	public string item_imp_critical_hit_ratio;
	public string item_imp_gold_enemy_drop;
	public string item_imp_pet_active_time;
	public string item_imp_hp_healing_on_battle;
	public string item_imp_revive_support_on_battle;
	public string item_imp_cure_freeze;
	public string item_imp_cure_poison;
	public string item_imp_cure_sheep;
	public string item_imp_power_capacity;
	public string item_imp_inc_hp;
	public string item_imp_fill_hp;
	public string item_imp_fill_mana;
	public string item_imp_inc_hp_refill_speed;
	public string item_imp_inc_dps;
	public string item_imp_inc_bag_slot;
	public string item_imp_auto_tap;
	public string item_imp_holding_tap;

	#endregion

	public string game_title{get;set;}

	public string dialog_no_internet_connection;
	public string dialog_native_ok;
	public string dialog_native_cancel;

	public string rate_title;
	public string rate_message;
	public string rate_button_maybe_later;
	public string rate_button_sure;

	public string confirm_exit ;

	public string conflict_title;
	public string conflict_desc;
	public string conflict_local;
	public string conflict_server;
	public string conflict_level;
	public string conflict_gold;
	public string conflict_diamond;

	public string no_match;

	public string pet_active;
	public string pet_passive;
	public string pet_passive_bonus;
	public string pet_for_passive;
	public string[] pet_skill_type = new string[4];
	public string pet_empty_title;
	public string pet_empty_desc;
	public string pet_active_title;
	public string pet_passive_title;
	public string pet_tap_capacity;

	public string equipment_empty_title;
	public string equipment_empty_desc;
	public string equipment_equip;
	public string equipment_equipped;

	public string tutorial_well_done;
	public string tutorial_element_supporter;
	public string tutorial_tap_match3;
	public string[] tutorial_match_descriptions = new string[7];
	public string send_gem;
	public string ask_gem;
	public string facebook_ask_gem_title;
	public string facebook_ask_gem_message;
	public string facebook_send_gem_title;
	public string facebook_send_gem_message;
	public string inbox_your_inbox_title;
	public string inbox_your_inbox_desc;
	public string inbox_accept;
	public string inbox_check_all;
	public string inbox_give_gem_title;
	public string inbox_give_gem_message;
	public string inbox_ask_gem_title;
	public string inbox_ask_gem_message;

	public string rate_thank_in_advance;
	public string rate_the_app;
	public string rate_spread_the_word;
	public string rate_send_feedback;
	public string rate_email;
	public string rate_feedback_descript_on_star1;
	public string rate_feedback_descript_on_star2;
	public string rate_feedback_descript_on_star3;
	public string rate_feedback_descript_on_star4;
	public string rate_feedback_descript_on_star5;
	public string rate_text_feeling_on_star1;
	public string rate_text_feeling_on_star2;
	public string rate_text_feeling_on_star3;
	public string rate_text_feeling_on_star4;
	public string rate_text_feeling_on_star5;
	public string rate_send;
	public string rate_cancel;
	public string rate_your_feedback;

	public string rate_button_rate;
	public string rate_feedback_describe;
	public string sharemail_subject;
	public string shareemail_body;
	public string sharetwitter_subject;
	public string sharetwitter_getgame;
	public string feedback_with_message;

	public string fb_loading_back_to_game;

	public string acc_creation_title;
	public string acc_description;
	public string acc_reward;

	public string moregame_not_available;
	public string moregame_button;
	public string txt_display_format;

	public string noti_1_body_1;
	public string noti_1_body_2;
	public string noti_1_body_3;
	public string noti_1_body_4;

	public string noti_2_body_1;
	public string noti_2_body_2;
	public string noti_2_body_3;

	public string noti_3_body_1;
	public string noti_3_body_2;
	public string noti_3_body_3;

	public string noti_offline_gold;

	public string leaderboard_title {get; set;}
	public string leaderboard_des {get; set;}
	public string leaderboard_action_menu1 {get; set;}
	public string leaderboard_action_menu2 {get; set;}
	public string leaderboard_action_menu3 {get; set;}
	public string leaderboard_action_menu4 {get; set;}
	public string leaderboard_text_rank {get; set;}
	public string leaderboard_text_name {get; set;}
	public string leaderboard_text_country {get; set;}
	public string leaderboard_text_level {get; set;}
	public string leaderboard_text_no_item {get; set;}

	public string quest_collect { get; set; }
	public string quest_skip { get; set; }
	public string quest_daily { get; set; }
	public string quest_mini { get; set; }
	public string quest_reward { get; set; }
	public string quest_daily_time_left { get; set; }
	public string quest_mini_description { get; set; }
	public string quest_disable { get; set; }

	public string repair_now { get; set; }
	public string weapon_break { get; set; }

	public IDictionary<int, string> progress_titles = new Dictionary<int, string>();
	public IDictionary<int, string> progress_des = new Dictionary<int, string>();
	public IDictionary<int, string> quest_titles = new Dictionary<int, string>();

	public string title_share_facebook { get; set; }
	public string title_share_twitter { get; set; }

	public string[] rank_title = new string[4];
	public string[] fruit_type = new string[6];
	public string[] boss_type = new string[3];
	
	public void InitLanuage()
	{
		Debug.Log("Init locale");
        InitSupportInfo();
		//IninitStageName();
		if(true)
		{
			Language setLanguage = Language.ENGLISH;
			SetLangugae(setLanguage);
		}
		else
		{
			RefreshLanguageText();
		}
    }

	public void RefreshLanguageText ()
	{
		SetLanguageToEnglish();
        // switch (GameData.Instance().language)
        // {
        //     case Language.ENGLISH:
        //         {
        //             SetLanguageToEnglish();
        //             break;
        //         }
        //     case Language.FRENCH:
        //         {
        //             SetLanguageToFranch();
        //             break;
        //         }
        //     case Language.SPANISH:
        //         {
        //             SetLanguageToSpanish();
        //             break;
        //         }
        //     case Language.KHMER:
        //         {
        //             SetLanguageToKhmer();
        //             break;
        //         }
        // }
    }

	public void SetLangugae(Language lg)
	{
		RefreshLanguageText();
	}

	
    private void InitSupportInfo()
    {
        for (int i = 0; i < supporters_info.Length; i++)
        {
            supporters_info[i] = new SupporterInfo();
        }
    }

    public class SupporterInfo
    {
        public string name;
        public string[] skill_names = new string[9];
    }

	public string GetTutorialMatchDescriptions(int index)
	{
		if(index >= tutorial_match_descriptions.Length || index < 0)
		{
			return "Tutorial Match";
		}

		return tutorial_match_descriptions[index];
	}
}
