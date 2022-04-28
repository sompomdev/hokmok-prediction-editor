using UnityEngine;
using System.Collections;

public partial class SMPGameLanguage
{
	
	private void SetLanguageToKhmer()
	{
		game_title								= "hk;mk";
        difficulty_status[0]                    = "gayNas;";
        difficulty_status[1]                    = "gaylµm";
        difficulty_status[2]                    = "Bi)ak";
        difficulty_status[3]                    = "Bi)akNas;";

        home_needHelp                           = "RtUvkarCMnYy?";

        menu_setting                            = "kMNt;";
        setting_soundFx                         = "sMelg";
        setting_soundMusic                      = "tRnþI";
        setting_fairy_ads                       = "bkSIsMNag";//"bkSIeGd";
		setting_login                           = "P¢ab;CamYyehVsbuk";
		setting_logout                          = "cakecjBIehVsbuk";
        setting_language_name                   = "Exµr";
        setting_language_title                  = "Pasa";
        setting_music_low                       = "exSay";
        setting_music_medium                    = "lµm";
        setting_music_high                      = "xøaMg";
        setting_notification                    = "rMlwk";
        setting_privacy                         = "siT§pÞal;xøÜn";
        setting_support                         = "RtUvkarCMnYy";
        setting_power_saving                    = "snSMsmuc©½y";
        setting_account                         = "KNnI";
        setting_bank                            = "FnaKar";
        setting_customerID                      = "elxGtifiCn";
        setting_on                              = "ebIk";
        setting_off                             = "biT";
		setting_restore							= "ykTMnijvij";
		dialog_restore_purchase_completed		= "ykTMnijvijedayeCaKC½y";
		dialog_restore_purchase_fail			= "braC½ykñúgkarykTMnijvij";
		dialog_restore_no_item					= "KµanTMnijcas;sRmab;Tajykvij";

		video_title                             = "emIlvIDIGUxøImYyedIm,IbþÚrykfIb";
		video_title_gold                        = "masmhasal";
		video_title_diamond                     = "t,Úg";
		video_title_HOM                         = "édmas";
		video_title_shadow_clone                = "RsemalkUnePøaH";
		video_title_thunder_attack				= "kmøaMgrnÞH";
		video_title_tap_damage					= "édrnÞH";
		video_title_critical_chance             = "kmøaMgmhima";
		video_title_attack_speed                = "sMEr​k​sRgÁam";
		video_bonus                             = "fIb";
		video_bonus_gold                        = "mas";
		diamonds                                = "t,Úg";
		video_close                             = "Gt;cg;";
		video_watch                             = "emIlvIDIGU";
		video_collect_gift                      = "RbmUlfIb";
		video_title_double_offline_gold         = "emIlvIedGUedIm,ITTYl)anmaseFVdg?";
		video_title_kill_boss                   = "pþac;CIvitem?";
		video_bonus_kill_boss_desc              = "eRbIyutþisil,_édRBH\nsmøab;em";
		video_bonus_second						= "vinaTI";
		video_one_shot							= "elIk";
		video_not_avaialble						= "vIedGUminTan;tMeNIrkarN_";

		inventory_tap_team                      = "RkumRbyuT§";
		inventory_tap_skill                     = "CMnaj";
		inventory_tap_supporter                 = "GñkkarBar";
		inventory_tap_pet                       = "kUnstV";
		inventory_tap_store                     = "hag";
		inventory_tap_inventory					= "smÖarH";
		inventory_tap_hero						= "virCn";

        inventory_bt_levelup                    = "kMritekIn";
        inventory_bt_buy                        = "Tij";
        inventory_bt_max                        = "MAX";
		inventory_txt_max                        = "Gtibrma";//អតិបរិមា
        inventory_bt_hire                       = "CYl\\LÚv";
        inventory_bt_unlock_skill               = "Tij";
        inventroy_bt_use_it_now                 = "cat;kar\\lUv";//"ចាត់ការឥលូវ";
        inventroy_bt_buy_it_now                 = "Tij\\lUv";//"ទិញឥឡុវ";
		inventory_bt_resurretion				= "rs;eLIgvij";
		inventory_bt_upgrade					= "begáIn";
		inventory_bt_regenerate					= "PJak;eLIg";
		inventory_bt_time						= "eBl";
		inventory_bt_already_bought				= "TijrYc";
		skill_second                            = "vinaTI";
		skill_unlock_at                         = "ebIkenA";
		skill_unlk_at							= "ebIk";
		skill_duration                          = "ryHeBl";
        skill_cool_down                         = "ryHeBlrgcaM";
        skill_active_skills                     = "CMnajskmµ";
		skill_on_boss_title						= "CMnajTl;em";
        skill_passive_skills                    = "CMnajGkmµ";
		skill_description[0]                    = "TTYl)ankmøaMgvay[xN]kñúgmYycuc";
		skill_description[1]                    = "begáItRsemalRbyuT§[N]kñúgmYyvinaTI";
		skill_description[2]                    = "begáInlT§PaBbeBa©jkmøaMgmhima[N]PaKry";
		skill_description[3]                    = "begáInkmøaMgsRmab;GñkkarBar[N]PaKry";
		skill_description[4]                    = "begáInkmøaMgvayBIkarcuc[N]PaKry";
		skill_description[5]                    = "TTYl)anmas[N]PaKryBIkarvaybisackñúgmYycuc";
		skill_description[6]                    = "tMeNIrkarsgswkCamYykgBl;stVciBa©wm";
        skill_description[7]                    = "tMeNIrkarExlsRmab;karBarkarvayRbhar";
        skill_description[8]                    = "tMeNIrkarGñkkarBaremXa";
        skill_description[9]                    = "fybisackñúgmYyvKÁcMnYn[-N]";
		skill_description[10]					= "begáInsmaCikRkúm";

		skill_require_at_least_2_heroes			= "tRmÚvy:agtic 2 virCn";
		skill_require_at_least_2_pets			= "tRmÚvy:agtic 2 kUnstV";
		skill_require_n_hero_more				= "tRmÚv [n] virCn eTot";
		skill_require_n_pet_more				= "tRmÚv [n] kUnstV eTot";

		support_damage_persecond                = "kmøaMgvaykñúgmYyvinaTI";

		perk_power_of_holding_alert             = "cucnigsgát;[üCab;edIm,Iévrh½s";
		perk_header								= "CMnYyBiess";
		perk_title[0]                           = "eGaymas´mk";
		perk_title[1]                           = "yutþisil,_édRBH";
		perk_title[2]                           = "kmøaMgsgát;";
		perk_title[3]                           = "eRbICMnYysareLIgvij";
		perk_descriptions[0]                    = "nwgTTUl)anmassrub[N]";//"នឹងទទូលមាស [N]";//
		perk_descriptions[1]                    = "elIkédeLIgelIsmøab;bIsac";//"េលីកៃដេឡីងេលីសំលាប់បិសាច";//"េលីកដៃេឡីងេលីសំលាប់បីសាច";//
		perk_descriptions[2]                    = "cucév #0 dgkñúg !@0 vinaTI";//"អាចចុចៃវ 30ដង/វិនាទី";//
		perk_descriptions[3]                    = "bMeBjmaNaeLIyvij";//"បំពេញមាណាឡើយវិញ"//
		store_header							= "hag";
		store_no_ads_optional                   = "biTkarpSBVpSayBIbkSIsMNag)an"; //បិទការផ្សព្វផ្សាយពីបក្សីអស្ចារ្យបាន
        store_no_ads_video_skippable            = "rMlgvIedGUBIbkSIsMNag)an"; //រំលងវីដេអូពីបក្សីអស្ចារ្យបាន
        store_more_diamons                      = "t,ÚgeBRCbEnßmeTot";//ត្បូងពេជ្របន្ថែមទៀត
		store_remove_ads                        = "KµankarpSBVpSayBaNiC©kmµ";
        store_no_ads                            = "KµankarpSBVpSay";//គ្មានការផ្សព្វផ្សាយ
        store_full_version                      = "RKb;muxgar";//គ្រប់មុខងារ
        store_price_not_availble                = "N/A";//មិនទាន់បានកំណត់តម្លៃទេ
		store_free_title						= "kabUbmas";
		store_free_description					= "TTYl)anhibbkSImaseTVdg";
		store_free_button_text					= "emIlvIedGU";
		store_free_price_text					= "FREE";

		shop_title                              = "hag";
		shop_description                        = "GñkGacTijt,ÜgenATIenH.";
		shop_bonus                              = "bEnßm";
		
		achm_title                              = "sMercEpnkar";
		achm_description                        = "TTYlt,ÚgBIkarseRmcEpnkarN_";
		achm_alert_title						= "seRmcEpnkar";
		achm_collect_now                        = "RbUmUlyk";
		achm_reward                             = "rgVan;";
		achm_complete                           = "bj©b;edayeCaKC½y";
		achm_item_title[0]                      = "smøab; [N] bisac";
		achm_item_title[1]                      = "RbUmUl)an [N] mas";
		achm_item_title[2]                      = "ebIk)an [N] GñkkarBar";
		achm_item_title[3]                      = "virCnQandl; [N] DPS";
		achm_item_title[4]                      = "smøab; [N] embisac";
		achm_item_title[5]                      = "cuc [N] dg";
		achm_item_title[6]                      = "GñkkarBarQandl; [N] kRmit";
		achm_item_title[7]                      = "bkSIsMNag [N] kadU";
		achm_item_title[8]                      = "eRbIkarvayRbharBIzansYK_ [N] dg";
		achm_item_title[9]                      = "Qandl; [N] tMbn;";
		achm_item_title[10]                     = "TTYl)an [N] kmøaMgmhima";
		achm_item_title[11]                     = "eRbI [N] CMnYyBiess";
		achm_item_title[12]                     = "P¢ab;CamYyehVsbuk";
		achm_item_title[13]                     = "smøab; [N] exµac";
		achm_item_title[14]                     = "smøab; [N] kUnbisac";
		achm_item_title[15]                     = "ebIk [N] virCn";
		achm_item_title[16] = "Use [N] Give me cash";
		achm_item_title[17] = "Use [N] Power of holding";
		achm_item_title[18] = "Use [N] Mana portion";

		teamselect_title                        = "RkumRbyuT§Qanmux";
		teamselect_subheader_title				= "RkumRbyuT§Qanmux";
		teamselect_description                  = "eRCIserIsGñkRbyuT§EdlCasMNb;citþrbs;GñkenATIenH";
		teamselect_active						= ")aneRCIsyk";
		teamselect_use_now						= "eRCIsyk";
		teamselect_lock							= "biT";
		teamselect_change						= "pøas;bþÚr";
		teamselect_all_team_dps					= "kmøaMgsrubkñúgmYyvinaTI";
		teamselect_empty_support_title			= "GñkKaMRT";
		teamselect_empty_support_desc			= "TijGñkKaMRTedIm,ICYyvirCnrbs;Gñk\nkñúgyutþnakarN_smøab;bisac.";
		teamselect_power_team_up				= "bkSCMnYy";
		teamselect_hero_type = "HERO";
		teamselect_support_type = "FELLOW";
		teamselect_change_your = "Change your";
		teamselect_active_on_select = "Active";
		teamselect_hero_on_select = "Hero";
		teamselect_support_on_select = "Fellow";
		teamselect_dmg = "DMG";
		teamselect_dps = "DPS";
		teamselect_skills = "Skills";
		teamselect_sttc_tap_counter = "Tap Counter";
		teamselect_sttc_boss_victory = "Boss Victories";
		teamselect_sttc_ghost_kill = "Ghost Kills";
		teamupselect_title = "Power team up select";

		SetKHHeroInfo();

		support_all_supporter_dps				= "kmøaMgsrubkñúgmYyvinaTI";
		support_skill_evolve                    = "bdivtþxøÜn";
		support_skill_icon_unlock               = "ebIk";
		support_active_title					= "GñkkarBarskmµ";
		support_flying_title					= "GñkkarBaremXa";
		support_passive_title					= "GñkkarBarGkmµ";
		support_skill_type_descriptions[0]      = "begáItRsemalRbyuT§[N]%";
		support_skill_type_descriptions[1]      = "begøInkmøaMgcuc[N]%";
		support_skill_type_descriptions[2]      = "begøInkmøaMgcuc[N]%énkmøaMgRbyuT§srubTaMgGs;";
		support_skill_type_descriptions[3]      = "begáInkmøaMgRbyuT§rYm[N]%";
		support_skill_type_descriptions[4]		= "kat;bnßykUnecAbisac[n]";
		support_skill_type_descriptions[5]      = "begøIn]_kasbej©jkmøaMgmhima[N]%";
		support_skill_type_descriptions[6]      = "begøInkmøaMgRbyuT§[ükmøaMgmhima[N]%";
		support_skill_type_descriptions[7]      = "begøIncMnYnmasFøak;[N]%";
		support_skill_type_descriptions[8]      = "begøIn]_kasqµamaselceLIg[N]%";
		support_skill_type_descriptions[9]      = "RtLb;xøÜnCasPaBedImnigbegøInfamBlCagmun";
		support_skill_type_descriptions[10]      = "begáInGRtaénfamBl bUk1";
        SetKHSupportInfo();

        dps_current                             = "kmøaMgsrub";
		dps_pet_damage                          = "kmøaMgstVciBa©wm";
        dps_shield                              = "kmøaMgkarBar";
        dps_tap                                 = "kmøaMgvay";
        dps_heroes                              = "kmøaMgGñkkarBar";
        dps_mana_desc                           = "(Mana Regeneration [N]/min)";
		dps_mana_pm_per_min						= "PM/min.";

        bgift_tap_damage                        = "[N]% kmøaMgvayBIkarcuc";
        bgift_attack_speed                      = "+[N]% kmøaMgsRmab;GñkkarBar";
        bgift_critical_chance                   = "+[N]% lT§PaBbeBa©jkmøaMgmhima";
        bgift_shadow_clown                      = "begáItRsemalRbyuT§ [N] kñúgmYyvinaTI";
        bgift_diamond                           = "+1 t,Úg";
		bgift_diamonds							= "+[N] t,Úg";
        bgift_gold                              = "+[N] mas";
        bgift_hand_of_midas                     = "+[N] masmYycuc";

        pls_bt_leave_battle                     = "Qb;RbkYtnigem";
        pls_bt_fight_boss                       = "RbkYtnigem";
        pls_failed_to_fight_boss                = "braC½ykñúgkarRbkYt";
        pls_stage_unlock                        = ")anrkeXIj";
		pls_battle								= "BATTLE!!";
		pls_revenge								= "REVENGE!!";
		pls_title_revenge						= "emsgswk";
		pls_title_boss							= "em";
		pls_title_big_boss						= "emFM";

		account_creation_text_des               = "virHbursrbs; GñkcaMepþImBITIenH. bMBak; ÉksN§an nigGavuF edIm,IeFVItMeNIrpSgeRBgCIritd¾Gs©arümYyenH.";
	    account_creation_text_reward            = "begáItKNn½ypÞúkTinñ½y nigTTYlfIb t,Úg100RKab;";
	    account_creation_sign_in_with_apple     = "P¢ab;CamYyeGpl";
	    account_creation_sign_in_with_facebook  = "Sign in with Facebook";// "P¢ab;CamYyehVsbuk";
	    account_creation_logout                 = "pþac;";
        account_creation_save                   = "rkSaTuk";
	    account_creation_text_name              = "eQµaH";
	    account_creation_text_name_place_holder = "dak;eQµaHtYrGgÁGñk";
	    account_creation_text_avatar            = "eGtUy:Us";
	    account_creation_text_avatar_des        = "eGtUy:UsnigeQµaHrbs;GñknwgbgðajkñúgCMruMGnLaj naeBlxagmux";

		stat_title								= "r)aykarN_";
		stat_tap_continue						= "cucedIm,Ibnþ";
		stat_button_watch						= "KuNCaBIr";
		stat_quest								= "Parkic©";
		stat_team_hit							= "vayrbs;Rkúm";
		stat_boss_hit							= "vayrbs;embisac";
		stat_combo_hit							= "vayBikarbnSM";
		stat_diamonds							= "t,Úg";
		stat_coin								= "kak;";
		stat_reward								= "rgVan;";
		stat_claim								= "RbmUl";

        please_check_your_internet_connection = "Please check your Internet connection.";
        downloading_required_assets = "Downloading required assets ... ";
		loading_required_assets = "Loading required assets ... ";
		checking_required_assets = "Checking required assets ... ";
		loading = "Loading ...";
		starting_game = "Starting game ...";


		dialog_no_internet_connection			= "KµanGIuneFIENt";
		dialog_native_ok						= "yl;RBm";
		dialog_native_cancel					= "e)aHbg;";

		confirm_exit							= "etIGñkcg;cakecjBIehÁmEmneT?";

		conflict_title							= "karrkSaTukCan;Kña";
		conflict_desc 							= "Tinñn½yrbs;Gñk)anrkSaTukçCan;KñaBIrkEnøg";
		conflict_local							= "Tinñn½yelIm:asIunGñk";
		conflict_server							= "Tinñn½yelIm:sIunem";
		conflict_level							= "kMrit";
		conflict_gold							= "mas";
		conflict_diamond						= "t,Úg";

		no_match								= "bþÚrvtßúEdlminRtUvKña";

		pet_active								= "eBleRbI";
		pet_passive								= "eBlmineRbI";
		pet_passive_bonus						= "eBlmineRbIbEnßm";
		pet_for_passive							= "TTYl";

		pet_skill_type[0]						= "kmøaMgRbyuT§srub";
		pet_skill_type[1]						= "kmøaMgGñkKaMRTsrub";
		pet_skill_type[2]						= "kmøaMgcuc";
		pet_skill_type[3]						= "massrub";
		pet_empty_title							= "stVciBa©wm";
		pet_empty_desc							= "køayCamitþsmøaj;kñúgtMeNIrpSg\neRBgrbs;Gñk.";
		pet_active_title						= "stVciBa©wmskmµ";
		pet_passive_title						= "stVciBa©wmGkmµ";
		pet_tap_capacity						= "smtßPaB";

		equipment_empty_title					= "vtßús½kþisiT§";
		equipment_empty_desc					= "vtßús½kþisiT§dMbUgrbs;Gñknwgmkdl;naCMnan;\neRkay. RbmUlvtßús½kþisiT§edIm,I\nbegáIn\\T§iBlnigPaBsIuvIélrbs;Gñk.";
		equipment_equip = "Equip";
		equipment_equipped = "EQUIPPED";

		tutorial_well_done						= "eFVI)anl¥";
		tutorial_element_supporter				= "pÁÚpÁgFatusRmab;xJúM ehIyxJúMnwgbEmøg CafamBledIm,ITb;Tl;nwgbIsac.";
		tutorial_tap_match3						= "xNHeBlb:HCamYyembisac GñkGaccucRbmUlFatuBIkarpÁÚrpÁg.";
		tutorial_match_descriptions[0]			= "pÁúM#Fatufµdav 3#RKab;";
		tutorial_match_descriptions[1]			= "pÁúM#fñaMsøwkeQI 4#snøwk";
		tutorial_match_descriptions[2]			= "pÁúM#Fatufµdav 5#RKab;";
		tutorial_match_descriptions[3]			= "pÁúM#FatuePøIg 3#Fatu";
		tutorial_match_descriptions[4]			= "pÁúM#FatuTwk 3#tMNk;";
		tutorial_match_descriptions[5]			= "pÁúM#FatudI 3#duM";
		tutorial_match_descriptions[6]			= "pÁúM#Fatuxül; 3#Fatu";

		send_gem								= "epJICUn";
		ask_gem									= "esñIsuM";
		facebook_ask_gem_title					= "Ask for gem";
		facebook_ask_gem_message				= "Can you send me a gem please?";
     	facebook_send_gem_title					= "Send a gem";
		facebook_send_gem_message				= "I gave you a gem!";
		inbox_your_inbox_title					= "sMeNIrmitþPkþi";
		inbox_your_inbox_desc					= "GñkGacepJInigTTYlt,ÚgCamYymitþPkþiehVsbukrbs;Gñk)anenATIenH.";
		inbox_accept							= "TTYlyk";
		inbox_check_all							= "RKIsTaMgGs;";
		inbox_give_gem_title					= "t,ÚgmYykMBugrg;caMGñk";
		inbox_give_gem_message					= "េអាយ gem មួយ";
		inbox_ask_gem_title						= "RtUvkarCMnYy";
		inbox_ask_gem_message					= "សុំ gem មួយ";

		rate_thank_in_advance					= "sUmGrKuNCamunsRmab;CMnYyrbs;Gñk";
		rate_the_app							= "vaytémøkmµviFI";
		rate_spread_the_word					= "EckrMElkCamYy";
		rate_send_feedback						= "epJIrmti";
		rate_email								= "sMbuRt";
		rate_feedback_descript_on_star1			= "páay 1? etImanbjðaGVIxøH EdlGñk)anTTYlBI ehÁmeyIg? KYrEtpþl;nUvBt_manénbjðaTaMgenHdl;BYkeyIg. sUmGrKuN.";
		rate_feedback_descript_on_star2			= "RtwmEtpáay 2? etIBYkeyIg)anbegáItkMhusqÁgGVIxøHelIehÁmrbs;eyIg? sUmCYypþl;nUveyabl;sRmab;BYkeyIgeFVIkarEksRmYl. sUmGrKuN.";
		rate_feedback_descript_on_star3			= "páay 3? KWminsUvGaRkk;bunµaneT k¾b:uEnþBUkeyIgGacEksRmYlbEnßmeTot)an RbsinebIGñkpþl;CaKMnitbEnßm. sUmGrKuN.";
		rate_feedback_descript_on_star4			= "páay 4? GrKuN BYkeyIgnigGacTTYl)anpáay 5 BIGñk RbsinebIGñkpþl;nUvPaBxVHxatdl;BYkeyIgeFVIkarEksRmYlbnþ. sUmGrKuN.";

		rate_feedback_descript_on_star5			= "GñknWgcUleTArvaytémøedaypÞal;enAelIeKhTMB½r. GrKuNsRmab;karKaMRT.";

		rate_text_feeling_on_star1				= "m©as;éføehIy";
		rate_text_feeling_on_star2				= "hW";
		rate_text_feeling_on_star3				= "l¥KYrsm";
		rate_text_feeling_on_star4				= "l¥Nas;";
		rate_text_feeling_on_star5				= "sUmGrKuN";
		rate_send								= "epJIr";
		rate_cancel								= "e)aHbg;";
		rate_your_feedback						= "Feedback on Hok Mok";//"karpþl;Camtieyabl;";
		rate_button_rate						= "vaytémø";
		rate_feedback_describe					= "BYkeyIgeFVIkarEksRmYlCaerogral;éf¶. dUcenHkarpþl;mtieyabl;rbs;GñkBitCamansar³sMxan;Nas;sRmab;BYkeyIg. RbsinebImankaresñIrsuM pþl;CaKMnit b¤bjðanana sUmCYyENnaM eyIgxJúMrIkraynwgeFVIkarEktRmUv. sUmGrKuN.";
#if UNITY_ANDROID
		sharemail_subject						= "Android Game: Hok Mok's garden. Check it out!";
#else
		sharemail_subject						= "iOS Game: Hok Mok's garden. Check it out!";
#endif
		shareemail_body							= "Hi,\nTry Hok Mok: the best android game for play, relax and reduce stress. Check it out on [link] .\nBye!";
		sharetwitter_subject					= "Play funny game together!";
		sharetwitter_getgame					= "Get the Game";
		feedback_with_message					= "Tap on Send to send your feedback below";

		fb_loading_back_to_game					= "Rtlb;eTAvij";
		acc_creation_title						= "begáItKNnI";
		acc_description							= "edIm,IrkSaTukTinñn½yrbs;Gñk.";
		acc_reward								= "TTYl 100";

		moregame_not_available					= "Rtlb;mkmþgeTot";
		moregame_button							= "ehÁmepSgeTot";
		txt_display_format						= "viTüasa®sþ"; //វិទ្យាសាស្ត្រ

		noti_1_body_1 							= "Finished eating? Go harvest Hok Mok.";
		noti_1_body_2 							= "Time for a break? Relax with Hok Mok";
		noti_1_body_3 							= "Retry Hok Mok before diner";
		noti_1_body_4 							= "Hok Mok is waiting.";

		noti_2_body_1 							= "Don't forget Hok Mok, your hero journey";
		noti_2_body_2 							= "Don't forget Hok Mok, your hero journey";
		noti_2_body_3 							= "Don't forget Hok Mok, your hero journey";

		noti_3_body_1 							= "Hero needs your help for journey";
		noti_3_body_2 							= "Hero needs your help for journey";
		noti_3_body_3 							= "Hero needs your help for journey";

		noti_offline_gold						= "Gold Acquired During Absence";

		leaderboard_title                       = "taragBinÞú";
        leaderboard_des                         = "rayCaeQµaHGñkelgRKb;TIkEnøg EdlmanTaMgcMNat;fñak;BinÞúRbcaMéf¶ RbcaMs)aþh_ nigx<s;bMput.";
	    leaderboard_action_menu1                = "em:agenH";
	    leaderboard_action_menu2                = "24em:agmun";
	    leaderboard_action_menu3                = "s)aþh_mun";
	    leaderboard_action_menu4                = "RKb;eBl";
	    leaderboard_text_rank                   = "lMdab;";
	    leaderboard_text_name                   = "eQµaH";
	    leaderboard_text_country                = "RbeTs";
	    leaderboard_text_level                  = "kMrit";
	    leaderboard_text_no_item                = "Tinñ½yminTan;mkdl;";

		quest_collect							= "RbUmUlyk";
		quest_reward							= "rgVan;";
		quest_skip								= "rMlg";
		quest_daily								= "Parkic©RbcaMéf¶";
		quest_mini								= "Parkic©tUc²";
		quest_daily_time_left					= "eBl";
		quest_mini_description					= "TTYlt,ÚgBIkarseRmcEpnkarN_";
		quest_disable							= "biT";

		repair_now = "Repair Now";
		weapon_break = "Weapon Break";

		quest_titles[1] = "Get your tripple power-up and use it!";

		title_share_facebook = "EckrMElk";
		title_share_twitter = "EckrMElk";

		rank_title[0] = "bronze";
		rank_title[1] = "silver";
		rank_title[2] = "gold";
		rank_title[3] = "platinium";

		fruit_type[0] = "Red";
		fruit_type[1] = "Sword";
		fruit_type[2] = "Health";
		fruit_type[3] = "Blue";
		fruit_type[4] = "Orange";
		fruit_type[5] = "Purple";

		boss_type[0] = "boss revenge";
		boss_type[1] = "boss";
		boss_type[2] = "big boss";
		
		stat_your_statistic = "sßitirbs;Gñk";
		stat_description = "sßitirbs;GñkTaMgGs;GacRtÚv)anrkeXIjenATIenH";
		stat_general_title = "sßitiTUeTA";
		stat_dps_title = "sßitikmøaMgRbyutþkñúgmYyvinaTI";
		stat_damage_title = "sßitikmøaMgvay";
		stat_legend_title = "sßitimhima";


		stat_level = "kMrit";//កំរិត
		stat_active_skills = "CMnajskmµ";//ជំនាញសកម្ម
		stat_best_DPS = "DIPIeGsl¥bMput";//ឌីភីអេសល្អបំផុត
		stat_base_tap_dps = "kmøaMgvayeKalBIkarcuc";//កម្លាំងវាយគោលពីការចុច
		stat_average_tap_dps = "kmøaMgvayBIkarcucCamFüm";//កម្លាំងវាយពីការចុចជាមធ្យម
		stat_total_support_dps = "DIPIeGsGñkkarBarsrub";//ឌីភីអេសអ្នកការពារសរុប
		stat_total_fly_support_dps = "DIPIeGsGñkkarBaremXasrub";//ឌីភីអេសអ្នកការពារមេឃាសរុប
		stat_total_hero_tap_damage = "kmøaMgvayBIkarcucsrub";//កម្លាំងវាយពីការចុចសរុប
		stat_total_hero_critical_damage = "kmøaMgmhimasrub";//កម្លាំងមហិមាសរុប
		stat_total_hero_critical_chnace = "lT§PaBbeBa©ajkmøaMgmhimasrub";//លទ្ធភាពបញ្ចោញកម្លាំងមហិមាសរុប
		stat_hero_ability_damage = "smtßPaBvirCnRbyutþsrub";//សមត្ថភាពវិរជនប្រយុត្តសរុប
		stat_total_supports_damage = "kmøaMgvayrbs;GñkkarBarsrub";//កម្លាំងវាយរបស់អ្នកការពារសរុប
		stat_total_flying_supports_damage = "kmøaMgvayrbs;GñkkarBaremXasrub";//កម្លាំងវាយរបស់អ្នកការពារមេឃាសរុប
		stat_total_pets_damage = "kmøaMgstVciBa©wmsrub";//កម្លាំងសត្វចិញ្ចឹមសរុប
		stat_total_skill_pet_support_damage = "CMnajstVciBa©wmsRmab;GñkkarBarsrub";//ជំនាញសត្វចិញ្ចឹមសម្រាប់អ្នកការពារសរុប
		stat_total_skill_pet_hero_damage = "CMnajstVciBa©wmsRmab;virCnsrub";//ជំនាញសត្វចិញ្ចឹមសម្រាប់វិរជនសរុប
		stat_mana_skill_cooldown = "CMnajbegáInm:aNa";//ជំនាញបង្កើនម៉ាណា
		stat_ghost_wave = "rlkexµac";//រលកខ្មោច
		stat_mana_capacity = "XøaMgmaNa";//ឃ្លាំងមាណា
		stat_mana_regeneration = "kMritekInvijénm:aNa";//កំរិតកើនវិញនៃម៉ាណា
		stat_critical_chance = "lT§PaBbeBa©ajkmøaMgmhima";//លទ្ធភាពបញ្ចោញកម្លាំងមហិមា
		stat_gato_cat_chance = "lT§PaBqµamasbgðajxøÜn";//លទ្ធភាពឆ្មាមាសបង្ហាញខ្លួន
		stat_total_taps = "kmøaMgvayBIkarcucsrub";//កម្លាំងវាយពីការចុចសរុប
		stat_highest_stage_reach = "vKÁx<s;bMput";//វគ្គខ្ពស់បំផុត
		stat_boss_victory = "emEdl)anQñH";//មេដែលបានឈ្នះ
		stat_big_boss_victory = "emFMEdl)anQñH";//មេធំដែលបានឈ្នះ
		stat_boss_failded = "emEdl)ancaj;";//មេដែលបានចាញ់
		stat_big_boss_failded = "emFMEdl)ancaj;";//មេធំដែលបានចាញ់
		stat_crown_collect = "mgáútRbmUl)an";//មង្កុតប្រមូលបាន
		stat_boss_fight_max_duration = "ryHeBlyUbMputvayem";//រយះពេលយូបំផុតវាយមេ
		stat_big_boss_fight_max_duration = "ryHeBlyUbMputvayemFM";//រយះពេលយូបំផុតវាយមេធំ
		stat_revenge_figh_max_duration = "ryHeBlyUbMputvayemsgswk";//រយះពេលយូបំផុតវាយមេសងសឹក
		stat_number_boss_kill_by = "cMnYnemsmøab;eday";//ចំនួនមេសម្លាប់ដោយ
		stat_number_big_boss_kill_by = "cMnYnemFMsmøab;eday";//ចំនួនមេធំសម្លាប់ដោយ
		stat_heroes_revive = "virCnrs;eLIgvij";//វិរជនរស់ឡើងវិញ
		stat_critical_hits = "kmøaMgvaymhima";//កម្លាំងវាយមហិមា
		stat_total_pet_levels = "kRmitstVciBa©wmsrub";//កម្រិតសត្វចិញ្ចឹមសរុប
		stat_all_pets_attack = "cMnYnvaystVciBa©wmsrub";//ចំនួនវាយសត្វចិញ្ចឹមសរុប
		stat_all_pets_big_attack = "cMnYnvayFMstVciBa©wm";//ចំនួនវាយធំសត្វចិញ្ចឹម
		stat_all_tap_pets_attack = "cMnYnvaystVciBa©wmeBlcuc";//ចំនួនវាយសត្វចិញ្ចឹមពេលចុច
		stat_total_skip_wave = "cMnYnrlkEdlrMlg";//ចំនួនរលកដែលរំលង
		stat_daily_quest_achived = "Parkic©RbcaMéf¶Edl)anRbmUl";//ភារកិច្ចប្រចាំថ្ងៃដែលបានប្រមូល
		stat_quest_achieved = "Parkic©Edl)anRbmUl";//ភារកិច្ចដែលបានប្រមូល
		stat_total_achievement = "EpnkarEdl)anseRmcsrub";//ផែនការដែលបានសម្រេចសរុប
		stat_flucky_bird_tapped = "cMnYncucelIstVsMNag";//ចំនួនចុចលើសត្វសំណាង
		stat_gato_cat_killed = "cMnYnqµamas)ansmøab;";//ចំនួនឆ្មាមាសបានសម្លាប់
		stat_total_gold_from_gato_cat ="cMnYnmasEdl)anBIqµamassrub";//ចំនួនមាសដែលបានពីឆ្មាមាសសរុប
		stat_hold_automatic_duration = "ryHeBleRbIkmøaMgsgát;vaysV½yRbvtþ";//រយះពេលប្រើកម្លាំងសង្កត់វាយស្វ័យប្រវត្ត
		stat_offline_gold_earnings = "cMnYnmasBIkarrkeBlsRmak";//ចំនួនមាសពីការរកពេលសម្រាក
		stat_watch_video = "emIlvIedGU";//មើលវីដេអូ
		stat_flucky_bird_gold_earning = "cMnYnmasEdl)anBIstVsMNag";//ចំនួនមាសដែលបានពីសត្វសំណាង
		stat_boss_gold_earning = "mas)anBIsmøab;em";//មាសបានពីសម្លាប់មេ
		stat_give_me_cash_gold_earning = "massrubBICMnYyBiesseGaymas´mk";//មាសសរុបពីជំនួយពិសេសអោយមាសខ្ញុំមក
		stat_gold_finger_gold_earning = "massrubBICMnYyBiessRmamédmas";//មាសសរុបពីជំនួយពិសេសម្រាមដៃមាស
		stat_doom_of_god_used = "cMnYnénkareRbICMnYyBiessyutþisil,_édRBH";//ចំនួននៃការប្រើជំនួយពិសេសយុត្តិសិល្ប៍ដៃព្រះ
		stat_gold_earned = "masrk)ansrub";//មាសរកបានសរុប
		stat_all_mana_gainded = "m:aNaTaMgGs;EdlTTYl)an";//ម៉ាណាទាំងអស់ដែលទទួលបាន
		stat_all_diamonds_collected = "t,ÚgEdlRbmUl)ansrub";//ត្បូងដែលប្រមូលបានសរុប
		stat_all_gold_collected = "masEdlRbmUl)ansrub";//មាសដែលប្រមូលបានសរុប
		stat_total_powerup_used = "cMnYnCMnajskmµ)aneRbIsrub";//ចំនួនជំនាញសកម្មបានប្រើសរុប
		stat_total_perks_used = "cMnYnCMnYyBiess)aneRbIsrub";//ចំនួនជំនួយពិសេសបានប្រើសរុប
		stat_play_time = "ryHeBlelgsrub";//រយះពេលលេងសរុប
		stat_day_since_install = "cMnYnéf¶Edl)antMeNIrkar";//ចំនួនថ្ងៃដែលបានតំណើរការ

		request_network_error = "GuIneFIentmintMeNIrkar";//អ៊ីនធើនេតមិនតំណើរការ
		request_client_error = "kMhusqÁgkarehA";//កំហុសឆ្គងការហៅ
		request_server_error = "esuIevImintMeNIrkar";//ស៊ើវើមិនតំណើរការ
		request_unknown_error = "bBaðaminGackMNt;sBaØaN [n]";//បញ្ហាមិនអាចកំណត់សញ្ញាណ
		request_sync_data_error = "There any issue on sync data, please retry!";

		inventory_bagpack = "BAGPACK";
		inventory_marketplace = "MARKETPLACE";
		inventory_filter_all = "all";
		inventory_retry = "RETRY";
		inventory_item_detail_hero_select = "Select a Character";
		inventory_equip_now = "Equip Now!";
		inventory_repair_now = "Repair Now!";
		inventory_sell_now = "Sell Now!";
		inventory_sell_item_unit = "xitems";
		inventory_full_bag_pack_msg = "Your bag pack is full!";
		inventory_unequip = "Unequip!";

		item_imp_inc_speed_support = "Increase speed support attack";
		item_imp_inc_hp_support = "Increase support hp";
		item_imp_inc_gold_drop = "Drop gold";
		item_imp_freeze_enemy = "Freeze enemy";
		item_imp_poison_enemy = "Poison enemy";
		item_imp_sheep_enemy = "Sheep enemy";
		item_imp_fire_enemy = "Increase damage for attack enemy";
		item_imp_inc_mana = "Increase the total mana available";
		item_imp_inc_mana_speed = "Increase speed regeneration of Mana";
		item_imp_size_hero = "Increase size of hero and increase strength";
		item_imp_hp_heal_got_hit = "Heal each time receiving a hit";
		item_imp_poison_attack = "Poison enemy when hitting";
		item_imp_freeze_attack = "Freeze enemy when hitting";
		item_imp_critical_hit_ratio = "Increase rate critical hit";
		item_imp_gold_enemy_drop = "Increase gold drop from enemy";
		item_imp_pet_active_time = "Increase pet active time";
		item_imp_hp_healing_on_battle = "Heal support or hero battle";
		item_imp_revive_support_on_battle = "Revive a support during a battle";
		item_imp_cure_freeze = "Cancel freeze";
		item_imp_cure_poison = "Cancel poison";
		item_imp_cure_sheep = "Cancel sheep";
		item_imp_power_capacity = "Increase the capacity of power up";
		item_imp_inc_hp = "Increase the total HP ";
		item_imp_fill_hp = "Refill HP battle only";
		item_imp_fill_mana = "Refill Mana";
		item_imp_inc_hp_refill_speed = "Increase speed regeneration of HP";
		item_imp_inc_dps = "Increase the damage of the global DPS";
		item_imp_inc_bag_slot = "Increase Bag Slot";
		item_imp_auto_tap = "Auto Tap";
		item_imp_holding_tap = "Holding Tap";

		SetKHProgressTitle ();
		SetKHProgressDes ();
	}

	private void SetKHProgressTitle ()
	{
		progress_titles[0] = "First Tap!";
		progress_titles[1] = "Tap";
		progress_titles[2] = "Tap";
		progress_titles[5] = "Hire supports!";
		progress_titles[6] = "Collect gold!";
		progress_titles[7] = "Update hero!";
		progress_titles[8] = "Reach stage!";
		progress_titles[9] = "Kill ghosts!";
		progress_titles[10] = "Defeat bosses!";
		progress_titles[11] = "Defeat bosses!";
		progress_titles[12] = "Open chest";
		progress_titles[13] = "Watch the video!";
		progress_titles[14] = "Collect pets!";
		progress_titles[15] = "Collect gold!";
		progress_titles[16] = "Hire heroes!";
		progress_titles[17] = "Come back";
		progress_titles[18] = "Upgrade heroes";
		progress_titles[19] = "Upgrade pets";
		progress_titles[20] = "Upgrade pets";
		progress_titles[21] = "Upgrade heroes";
		progress_titles[23] = "Collect diamond";
		progress_titles[24] = "Make revive";
		progress_titles[25] = "Make revive";
		progress_titles[26] = "Pass boss fight";
		progress_titles[27] = "Combine powerup";
		progress_titles[28] = "On weekend";
		progress_titles[29] = "Use the shield";
		progress_titles[30] = "Play the game";
		progress_titles[31] = "Full support";
		progress_titles[32] = "Active support";
		progress_titles[33] = "Flying support";
		progress_titles[34] = "Full team";
		progress_titles[35] = "Full team!";
		progress_titles[36] = "World Loop!";
		progress_titles[37] = "World tour!";
		progress_titles[38] = "First powerup!";
		progress_titles[39] = "First mission!";
		progress_titles[40] = "Your [n] mission!";
		progress_titles[41] = "Collect diamonds!";
		progress_titles[42] = "Complete Stage";
		progress_titles[43] = "Beat levels";
		progress_titles[44] = "Clear boss";
		progress_titles[45] = "Critical tap";
		progress_titles[46] = "Level heroes";
		progress_titles[47] = "Level supports";
		progress_titles[48] = "Support skills";
		progress_titles[49] = "Upgrade power-up";
		progress_titles[50] = "Using mana";
		progress_titles[51] = "Combo hits";
		progress_titles[52] = "Swipe horizontal";
		progress_titles[53] = "Swipe vertical";
		progress_titles[54] = "Play time";
		progress_titles[56] = "Daily playing";
		progress_titles[57] = "Levels in total";
		progress_titles[58] = "Use perk!";
		progress_titles[59] = "Use perk!";
		progress_titles[60] = "Use Perk!";
		progress_titles[61] = "Use perk!";
		progress_titles[62] = "Train power-up!";
		progress_titles[63] = "Unlock power-up!";
		progress_titles[64] = "Obtain power-up!";
		progress_titles[65] = "Promote hero!";
		progress_titles[66] = "Promote hero!";
		progress_titles[67] = "Promote hero!";
		progress_titles[68] = "Promote hero!";
		progress_titles[69] = "Promote hero!";
		progress_titles[70] = "Promote hero!";
		progress_titles[71] = "Promote hero!";
		progress_titles[72] = "Promote hero!";
		progress_titles[73] = "Collect crowns!";
		progress_titles[74] = "Fail [n] times!";
		progress_titles[75] = "Obtain gifts!";
		progress_titles[76] = "First crown!";
		progress_titles[77] = "Update support!";
		progress_titles[78] = "Update pet!";
		progress_titles[79] = "Update pet!";
		progress_titles[80] = "Swipe runes";
		progress_titles[81] = "Play time";
		progress_titles[82] = "Play time";
		progress_titles[83] = "Facebook";
		progress_titles[84] = "Twitter";
		progress_titles[85] = "Use perk!";
		progress_titles[86] = "Use perk!";
		progress_titles[87] = "Use Perk!";
		progress_titles[88] = "Use perk!";
		progress_titles[89] = "Critical Hits";
		progress_titles[90] = "Update pets!";
		progress_titles[91] = "Use perks!";
		progress_titles[92] = "Use power-up!";
		progress_titles[93] = "Reduce round!";
		progress_titles[94] = "Reach DPS";
		progress_titles[95] = "Support evolve!";
		progress_titles[96] = "Reach rank";
		progress_titles[97] = "Reach rank";
		progress_titles[98] = "Magic runes";
		progress_titles[99] = "Combos hits";
		progress_titles[100] = "Play mastermind";
		progress_titles[101] = "Reach mastermind";
		progress_titles[102] = "Win mastermind";
		progress_titles[103] = "During the day";
		progress_titles[104] = "Make quests";
		progress_titles[105] = "[powerup_name]";
		progress_titles[106] = "Revive support";
		progress_titles[107] = "Revive hero";
		progress_titles[108] = "Level up";
		progress_titles[109] = "Level up";
		progress_titles[110] = "Level up";
		progress_titles[111] = "Reach evolve";
		progress_titles[112] = "Reach rank";
		progress_titles[113] = "Kill boss";
		progress_titles[114] = "Kill big boss";
		progress_titles[115] = "Unlock world";
		progress_titles[116] = "Revive all time";
	}
	private void SetKHProgressDes ()
	{
		progress_des[0] = "First Tap!";
		progress_des[1] = "Tap [n] times in [t] second!";
		progress_des[2] = "Tap [n] times!";
		progress_des[5] = "Hire [n] supports!";
		progress_des[6] = "Collect [n] gold!";
		progress_des[7] = "Update hero level to [n]!";
		progress_des[8] = "Reach stage [n]!";
		progress_des[9] = "Kill [n] ghosts!";
		progress_des[10] = "Defeat [n] bosses of battle!";
		progress_des[11] = "Defeat [n] bosses of revenge!";
		progress_des[12] = "Open chest [n] times";
		progress_des[13] = "Watch the video [n] times!";
		progress_des[14] = "Collect [n] pets!";
		progress_des[15] = "Collect [n] gold in [t] second!";
		progress_des[16] = "Hire [n] heroes!";
		progress_des[17] = "Come back [n] days consecutively";
		progress_des[18] = "Upgrade all heroes to level [n2]";
		progress_des[19] = "Upgrade all pets to level [n2]";
		progress_des[20] = "Upgrade [n] pets to level [n2]";
		progress_des[21] = "Upgrade [n] heroes to level [n2]";
		progress_des[23] = "Collect bird diamond [n] times";
		progress_des[24] = "Make [n] heroes revive";
		progress_des[25] = "Make [n] supports revive";
		progress_des[26] = "Pass [n] boss fight consecutivly";
		progress_des[27] = "Combine [n] powerup in the same time";
		progress_des[28] = "Play the game on weekend";
		progress_des[29] = "Use the shield [n] times";
		progress_des[30] = "Play the game [n] times";
		progress_des[31] = "Full support";
		progress_des[32] = "Full active support";
		progress_des[33] = "Full flying support";
		progress_des[34] = "Hire a full team of 8 heroes";
		progress_des[35] = "Full team!";
		progress_des[36] = "First Time world Loop!";
		progress_des[37] = "Make [n] world tour of hokmok!";
		progress_des[38] = "Obtain your first powerup!";
		progress_des[39] = "Complete your first mission!";
		progress_des[40] = "Complete your 10 mission!";
		progress_des[41] = "Collect [n] diamonds!";
		progress_des[42] = "Complete [n]th Stage";
		progress_des[43] = "Beat [n] levels";
		progress_des[44] = "Clear [n] boss monsters";
		progress_des[45] = "Tap [n] critical tap in [t] seconds";
		progress_des[46] = "Level heroes [n] times";
		progress_des[47] = "Level supports [n] times";
		progress_des[48] = "Unlock [n] support skills";
		progress_des[49] = "Upgrade power-up [n] times";
		progress_des[50] = "Start using mana";
		progress_des[51] = "Make [n] combo hits";
		progress_des[52] = "Swipe [n2] runes in one horizontal [n] times";
		progress_des[53] = "Swipe [n2] runes in one vertical [n] times";
		progress_des[54] = "[n] minutes total play time";
		progress_des[56] = "[n] minutes daily playing";
		progress_des[57] = "Complete [n] Levels in total";
		progress_des[58] = "Use perk Give me cash once!";
		progress_des[59] = "Use perk Doom once!";
		progress_des[60] = "Use Perk Power of Holding once";
		progress_des[61] = "Use perk Mana Potion once";
		progress_des[62] = "Train power-up of [n] heroes";
		progress_des[63] = "Unlock [n] heroe power-up!";
		progress_des[64] = "Obtain [n] power-up and use it!";
		progress_des[65] = "Promote your hero to the bronze!";
		progress_des[66] = "Promote your hero to the silver!";
		progress_des[67] = "Promote your hero to the gold!";
		progress_des[68] = "Promote your hero to the platinium!";
		progress_des[69] = "Promote [n] heroes to the bronze!";
		progress_des[70] = "Promote [n] heroes to the silver!";
		progress_des[71] = "Promote [n] heroes to the gold!";
		progress_des[72] = "Promote [n] heroes to the platinium!";
		progress_des[73] = "Collect [n] boss crowns!";
		progress_des[74] = "Fail [n] times!";
		progress_des[75] = "Obtain [n] bird gifts in 1 week!";
		progress_des[76] = "Collect first boss crown!";
		progress_des[77] = "Update a support to [n]!";
		progress_des[78] = "Update a pet!";
		progress_des[79] = "Update a pet [n] times!";
		progress_des[80] = "Swipe [n2] runes in one row [n] times";
		progress_des[81] = "[n] hour total play time";
		progress_des[82] = "[n] day total play time";
		progress_des[83] = "Share the game to Facebook";
		progress_des[84] = "Share the game to Twitter";
		progress_des[85] = "Use perk Give me cash [n] times";
		progress_des[86] = "Use perk Doom [n] times";
		progress_des[87] = "Use Perk Power of Holding [n] times";
		progress_des[88] = "Use perk Mana Potion [n] times";
		progress_des[89] = "Critical Hits [n] times";
		progress_des[90] = "Update [n] pets!";
		progress_des[91] = "Use [n2] times [n] perks!";
		progress_des[92] = "Use [n2] times [n] power-up!";
		progress_des[93] = "Reduce ghost round [n] times!";
		progress_des[94] = "Reach Threshold of [n] DPS";
		progress_des[95] = "[support_name] evolve [n] times!";
		progress_des[96] = "[hero_name] reach rank [rank_title]";
		progress_des[97] = "[support_name] reach rank [rank_title]";
		progress_des[98] = "Use [n] [fruit_type] magic runes";
		progress_des[99] = "Make [n] combos hits against a [boss_type]";
		progress_des[100] = "Play [n] mastermind";
		progress_des[101] = "Reach [n] mastermind color in a row ";
		progress_des[102] = "Win [n] mastermind";
		progress_des[103] = "Play [n] mastermind during the day";
		progress_des[104] = "Make [n] quests";
		progress_des[105] = "Use [powerup_name] [n] times";
		progress_des[106] = "Revive [n] times a support";
		progress_des[107] = "Revive [n] times a hero";
		progress_des[108] = "Level up your [hero_name] [n] times";
		progress_des[109] = "Level up your [support_name] [n] times";
		progress_des[110] = "Level up your [pet_name] [n] times";
		progress_des[111] = "All supports reach evolve [n]";
		progress_des[112] = "all heroes reach rank [rank_title]";
		progress_des[113] = "Kill [n] times boss";
		progress_des[114] = "Kill [n] times big boss";
		progress_des[115] = "Unlock \"[world_name]\"";
		progress_des[116] = "Revive all time [n] times";
	}

    private void SetKHHeroInfo()
    {
        hero_names[0]                           = "hnura";
        hero_names[1]                           = "eksr";
        hero_names[2]                           = "m:Ur:a";
        hero_names[3]                           = "raCnI";
        hero_names[4]                           = "visalbuRt";
        hero_names[5]                           = "FIta";
        hero_names[6]                           = "nrsigð";
        hero_names[7]                           = "sk;RkGb;";
        hero_names[8]                           = "m:Ufar:U";

		hero_active_skill_names[0]              = "kmøaMgrnÞH";
		hero_active_skill_names[1]              = "RsemalkUnePøaH";
		hero_active_skill_names[2]              = "kmøaMgmhima";
		hero_active_skill_names[3]              = "sMEr​k​sRgÁam";
		hero_active_skill_names[4]              = "édrnÞH";
		hero_active_skill_names[5]              = "édmas";
		hero_active_skill_names[6]              = "kgBl;bkSI";
        hero_active_skill_names[7]              = "ExlRBH";
        hero_active_skill_names[8]              = "GñkkarBaremXa";
        hero_active_skill_names[9]              = "pøÚvkat;";
		hero_active_skill_names[10]				= "bkSCMnYy";
	}

    private void SetKHSupportInfo()
    {
        supporters_info[0].name                 = "esna";
		supporters_info[0].skill_names[0]       = "vtþmanr)aMgcEmøk";
		supporters_info[0].skill_names[1]       = "snÞúHlMEBgC½y";
		supporters_info[0].skill_names[2]       = "Es,ks<an;";
		supporters_info[0].skill_names[3]       = "famBlBiess";
		supporters_info[0].skill_names[4]       = "kmøaMgBiess";
		supporters_info[0].skill_names[5]       = "k,altan;";
		supporters_info[0].skill_names[6]       = ")alIehARTBü";
		supporters_info[0].skill_names[7]       = "kmøaMgénkMhwg";

        supporters_info[1].name                 = "vr:aNa";
		supporters_info[1].skill_names[0]       = "RBYjcitþFm_";
		supporters_info[1].skill_names[1]       = "degðImexµac";
		supporters_info[1].skill_names[2]       = "RBYj\\temtþa";
		supporters_info[1].skill_names[3]       = "kmøaMgsamKÁI";
		supporters_info[1].skill_names[4]       = "RBYjTwkePøog";
		supporters_info[1].skill_names[5]       = "GnÞgRBlwg";
		supporters_info[1].skill_names[6]       = "exµaceXIjxøac";
		supporters_info[1].skill_names[7]       = "snÞúHRBYjePøIg";

        supporters_info[2].name                 = "ecAcWm";
		supporters_info[2].skill_names[0]       = "kmøaMgykS";
		supporters_info[2].skill_names[1]       = "kmøaMgbgçM";
		supporters_info[2].skill_names[2]       = "k,ÜnedIm,IQñH";
		supporters_info[2].skill_names[3]       = "ePøIgKMnuM";
		supporters_info[2].skill_names[4]       = "famBlBiess";
		supporters_info[2].skill_names[5]       = "RBlwgkMNac";
		supporters_info[2].skill_names[6]       = "CMnYyGrUbI";
		supporters_info[2].skill_names[7]       = "\\T§iBlcitþesµaH";

        supporters_info[3].name                 = "kakI";
		supporters_info[3].skill_names[0]       = ")atédRBH";
		supporters_info[3].skill_names[1]       = "snÞúHmáúdC½y";
		supporters_info[3].skill_names[2]       = "snþMcitþ";
		supporters_info[3].skill_names[3]       = "qnÞ³GñkcM)aMg";
		supporters_info[3].skill_names[4]       = "famBlBiess";
		supporters_info[3].skill_names[5]       = "rlkkñúgcitþ";
		supporters_info[3].skill_names[6]       = "KMnuMkñúgsRgÁam";
		supporters_info[3].skill_names[7]       = "KMnitplitRTBü";

        supporters_info[4].name                 = "raCbuRt";
		supporters_info[4].skill_names[0]       = "kmøaMgykS";
		supporters_info[4].skill_names[1]       = "kmøaMgbgçM";
		supporters_info[4].skill_names[2]       = "k,ÜnedIm,IQñH";
		supporters_info[4].skill_names[3]       = "ePøIgKMnuM";
		supporters_info[4].skill_names[4]       = "RBlwgkMNac";
		supporters_info[4].skill_names[5]       = "famBlBiess";
		supporters_info[4].skill_names[6]       = "CMnYyGrUbI";
		supporters_info[4].skill_names[7]       = "\\T§iBlcitþesµaH";

        supporters_info[5].name                 = "kULa";
		supporters_info[5].skill_names[0]       = "kmøaMgBIFmµCati";
		supporters_info[5].skill_names[1]       = "rnÞHeCIg";
		supporters_info[5].skill_names[2]       = "kMeraleKaC​l;";
		supporters_info[5].skill_names[3]       = "cMhayBul";
		supporters_info[5].skill_names[4]       = "kNþab;édehaH";
		supporters_info[5].skill_names[5]       = "famBlBiess";
		supporters_info[5].skill_names[6]       = "\\T§iBlrnÞH";
		supporters_info[5].skill_names[7]       = "kmøaMgmhima";

        supporters_info[6].name                 = "qda";
		supporters_info[6].skill_names[0]       = "kmøaMgGFidæan";
		supporters_info[6].skill_names[1]       = "kmøaMgxÞ½r";
		supporters_info[6].skill_names[2]       = "bdivtþbIsac";
		supporters_info[6].skill_names[3]       = "GnÞgpøÚvcitþ";
		supporters_info[6].skill_names[4]       = "xøaMgdUcPñMePøIg";
		supporters_info[6].skill_names[5]       = "x©IkmøaMgexµac";
		supporters_info[6].skill_names[6]       = "famBlBiess";
		supporters_info[6].skill_names[7]       = "Rbmaj;RBlwg";

        supporters_info[7].name                 = "m:aLa";
		supporters_info[7].skill_names[0]       = "smøab;Kµanemtþa";
		supporters_info[7].skill_names[1]       = "BüúHcitþemtþa";
		supporters_info[7].skill_names[2]       = "smøab;minerIsmux";
		supporters_info[7].skill_names[3]       = "mnþesñh_RBYjeTB";
		supporters_info[7].skill_names[4]       = "nisS½yGavuFTBV";
		supporters_info[7].skill_names[5]       = "GMNacyutþiFm_";
		supporters_info[7].skill_names[6]       = "CMnYbBUefAePøaH";

        supporters_info[8].name                 = "buTum";
		supporters_info[8].skill_names[0]       = "RkjaMbIsac";
		supporters_info[8].skill_names[1]       = "BIgBagBis";
		supporters_info[8].skill_names[2]       = "eramstVeTB";
		supporters_info[8].skill_names[3]       = "tMnk;TwkERbrUb";
		supporters_info[8].skill_names[4]       = "exµacedIrrkmas";
		supporters_info[8].skill_names[5]       = "mhakmøaMg";
		supporters_info[8].skill_names[6]       = "exµaceXIjxøac";
		supporters_info[8].skill_names[7]       = "x©IkmøaMgxül;";

        supporters_info[9].name                 = "nagrMsaysk;";
		supporters_info[9].skill_names[0]       = "kMhwgFmµCati";
		supporters_info[9].skill_names[1]       = "sil,_snþM";
		supporters_info[9].skill_names[2]       = "kMhwgexµacRtI";
		supporters_info[9].skill_names[3]       = "exµaceXIjxøac";
		supporters_info[9].skill_names[4]       = "exµacvegVgTis";
		supporters_info[9].skill_names[5]       = "exµacRsUbvijJan";
		supporters_info[9].skill_names[6]       = "exµaclak;mas";

        supporters_info[10].name                = "kam:Uv";
		supporters_info[10].skill_names[0]      = "kmøaMgxÞb;";
		supporters_info[10].skill_names[1]      = "jjYrTaRBlwg";
		supporters_info[10].skill_names[2]      = "jjYrmhaTMgn;";
		supporters_info[10].skill_names[3]      = "GavuFeRskQam";
		supporters_info[10].skill_names[4]      = "jjYreTvta";
		supporters_info[10].skill_names[5]      = "BUefAGKÁI";
		supporters_info[10].skill_names[6]      = "kMhwgsgswk";

        supporters_info[11].name                = "GgÁlImar";
		supporters_info[11].skill_names[0]      = "edjsmøab;";
		supporters_info[11].skill_names[1]      = "bkSIeTB";
		supporters_info[11].skill_names[2]      = "RmamédGmt³";
		supporters_info[11].skill_names[3]      = "kUnkaMbitmas";
		supporters_info[11].skill_names[4]      = "daveRsabmas";
		supporters_info[11].skill_names[5]      = "taMgcitþCaRBH";
		supporters_info[11].skill_names[6]      = "RBHQñHrhUt";

		supporters_info[12].name = "mcäa";
		supporters_info[12].skill_names[0] = "vtþmanr)aMgcEmøk";
		supporters_info[12].skill_names[1] = "snÞúHlMEBgC½y";
		supporters_info[12].skill_names[2] = "Es,ks<an;";
		supporters_info[12].skill_names[3] = "famBlBiess";
		supporters_info[12].skill_names[4] = "kmøaMgBiess";
		supporters_info[12].skill_names[5] = "k,altan;";
		supporters_info[12].skill_names[6] = ")alIehARTBü";
		supporters_info[12].skill_names[7] = "kmøaMgénkMhwg";
		
		supporters_info[13].name = "nagpan;";
		supporters_info[13].skill_names[0] = "kmøaMgykS";
		supporters_info[13].skill_names[1] = "kmøaMgbgçM";
		supporters_info[13].skill_names[2] = "k,ÜnedIm,IQñH";
		supporters_info[13].skill_names[3] = "ePøIgKMnuM";
		supporters_info[13].skill_names[4] = "famBlBiess";
		supporters_info[13].skill_names[5] = "RBlwgkMNac";
		supporters_info[13].skill_names[6] = "CMnYyGrUbI";
		supporters_info[13].skill_names[7] = "\\T§iBlcitþesµaH";
		
		supporters_info[14].name = "FIta";
		supporters_info[14].skill_names[0] = "kmøaMgykS";
		supporters_info[14].skill_names[1] = "kmøaMgbgçM";
		supporters_info[14].skill_names[2] = "k,ÜnedIm,IQñH";
		supporters_info[14].skill_names[3] = "ePøIgKMnuM";
		supporters_info[14].skill_names[4] = "RBlwgkMNac";
		supporters_info[14].skill_names[5] = "famBlBiess";
		supporters_info[14].skill_names[6] = "CMnYyGrUbI";
		supporters_info[14].skill_names[7] = "\\T§iBlcitþesµaH";
		
		supporters_info[15].name = "C½y";
		supporters_info[15].skill_names[0] = "kmøaMgGFidæan";
		supporters_info[15].skill_names[1] = "kmøaMgxÞ½r";
		supporters_info[15].skill_names[2] = "bdivtþbIsac";
		supporters_info[15].skill_names[3] = "GnÞgpøÚvcitþ";
		supporters_info[15].skill_names[4] = "xøaMgdUcPñMePøIg";
		supporters_info[15].skill_names[5] = "x©IkmøaMgexµac";
		supporters_info[15].skill_names[6] = "famBlBiess";
		supporters_info[15].skill_names[7] = "Rbmaj;RBlwg";

		supporters_info[16].name = "GgÁ eTB";
		supporters_info[16].skill_names[0] = "RBYjcitþFm_";
		supporters_info[16].skill_names[1] = "degðImexµac";
		supporters_info[16].skill_names[2] = "RBYj\\temtþa";
		supporters_info[16].skill_names[3] = "kmøaMgsamKÁI";
		supporters_info[16].skill_names[4] = "RBYjTwkePøog";
		supporters_info[16].skill_names[5] = "GnÞgRBlwg";
		supporters_info[16].skill_names[6] = "exµaceXIjxøac";
		supporters_info[16].skill_names[7] = "snÞúHRBYjePøIg";
		
		supporters_info[17].name = "efr:a m:ar:a";
		supporters_info[17].skill_names[0] = ")atédRBH";
		supporters_info[17].skill_names[1] = "snÞúHmáúdC½y";
		supporters_info[17].skill_names[2] = "snþMcitþ";
		supporters_info[17].skill_names[3] = "qnÞ³GñkcM)aMg";
		supporters_info[17].skill_names[4] = "famBlBiess";
		supporters_info[17].skill_names[5] = "rlkkñúgcitþ";
		supporters_info[17].skill_names[6] = "KMnuMkñúgsRgÁam";
		supporters_info[17].skill_names[7] = "KMnitplitRTBü";
		
		supporters_info[18].name = "efr:a m:Ur:a";
		supporters_info[18].skill_names[0] = "kmøaMgBIFmµCati";
		supporters_info[18].skill_names[1] = "rnÞHeCIg";
		supporters_info[18].skill_names[2] = "kMeraleKaC​l;";
		supporters_info[18].skill_names[3] = "cMhayBul";
		supporters_info[18].skill_names[4] = "kNþab;édehaH";
		supporters_info[18].skill_names[5] = "famBlBiess";
		supporters_info[18].skill_names[6] = "\\T§iBlrnÞH";
		supporters_info[18].skill_names[7] = "kmøaMgmhima";
		
		supporters_info[19].name = "GgÁ Bisidæ";
		supporters_info[19].skill_names[0] = "smøab;Kµanemtþa";
		supporters_info[19].skill_names[1] = "BüúHcitþemtþa";
		supporters_info[19].skill_names[2] = "smøab;minerIsmux";
		supporters_info[19].skill_names[3] = "mnþesñh_RBYjeTB";
		supporters_info[19].skill_names[4] = "nisS½yGavuFTBV";
		supporters_info[19].skill_names[5] = "GMNacyutþiFm_";
		supporters_info[19].skill_names[6] = "CMnYbBUefAePøaH";
	}
}
