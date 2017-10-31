$(function () {

    var svg_script = function () {
        var hoverColorStroke = 'rgba(100, 100, 100, 0.3)';
        var hoverColorFill = 'rgba(100, 100, 100, 0.3)';
        var params = {
            "vc_mud_guards": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_mud_guards",
                "c_rep": "vc_mud_guards",
                "erc": "vc_mud_guards",
                "desc": "vc_mud_guards",
                "label": 'vc_mud_guards'
            },
            "vc_left_mud_guard": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_mud_guard",
                "c_rep": "vc_left_mud_guard",
                "erc": "vc_left_mud_guard",
                "desc": "vc_left_mud_guard",
                "label": 'vc_left_mud_guard'
            },
            "vc_right_mud_guard": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_mud_guard",
                "c_rep": "vc_right_mud_guard",
                "erc": "vc_right_mud_guard",
                "desc": "vc_right_mud_guard",
                "label": 'vc_right_mud_guard'
            },
            "vc_grill": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_grill",
                "c_rep": "vc_grill",
                "erc": "vc_grill",
                "desc": "vc_grill",
                "label": 'vc_grill'
            },
            "vc_bonnet": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_bonnet",
                "c_rep": "vc_bonnet",
                "erc": "vc_bonnet",
                "desc": "vc_bonnet",
                "label": 'vc_bonnet'
            },
            "vc_right_fender": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_fender",
                "c_rep": "vc_right_fender",
                "erc": "vc_right_fender",
                "desc": "vc_right_fender",
                "label": 'vc_right_fender'
            },
            "vc_left_fender": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_fender",
                "c_rep": "vc_left_fender",
                "erc": "vc_left_fender",
                "desc": "vc_left_fender",
                "label": 'vc_left_fender'
            },
            "vc_front_bumper": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_front_bumper",
                "c_rep": "vc_front_bumper",
                "erc": "vc_front_bumper",
                "desc": "vc_front_bumper",
                "label": 'vc_front_bumper'
            },
            "vc_head_lights": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_head_lights",
                "c_rep": "vc_head_lights",
                "erc": "vc_head_lights",
                "desc": "vc_head_lights",
                "label": 'vc_head_lights'
            },
            "vc_lfdoor": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_lfdoor",
                "c_rep": "vc_lfdoor",
                "erc": "vc_lfdoor",
                "desc": "vc_lfdoor",
                "label": 'vc_lfdoor'
            },
            "vc_rfdoor": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rfdoor",
                "c_rep": "vc_rfdoor",
                "erc": "vc_rfdoor",
                "desc": "vc_rfdoor",
                "label": 'vc_rfdoor'
            },
            "vc_left_rocker_panel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rocker_panel",
                "c_rep": "vc_left_rocker_panel",
                "erc": "vc_left_rocker_panel",
                "desc": "vc_left_rocker_panel",
                "label": 'vc_left_rocker_panel'
            },
            "vc_right_mirror": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_mirror",
                "c_rep": "vc_right_mirror",
                "erc": "vc_right_mirror",
                "desc": "vc_right_mirror",
                "label": 'vc_right_mirror'
            },
            "vc_left_mirror": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_mirror",
                "c_rep": "vc_left_mirror",
                "erc": "vc_left_mirror",
                "desc": "vc_left_mirror",
                "label": 'vc_left_mirror'
            },
            "vc_lrdoor": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_lrdoor",
                "c_rep": "vc_lrdoor",
                "erc": "vc_lrdoor",
                "desc": "vc_lrdoor",
                "label": 'vc_lrdoor'
            },
            "vc_rrdoor": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rrdoor",
                "c_rep": "vc_rrdoor",
                "erc": "vc_rrdoor",
                "desc": "vc_rrdoor",
                "label": 'vc_rrdoor'
            },
            "vc_rear_window": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rear_window",
                "c_rep": "vc_rear_window",
                "erc": "vc_rear_window",
                "desc": "vc_rear_window",
                "label": 'vc_rear_window'
            },
            "vc_roof": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_roof",
                "c_rep": "vc_roof",
                "erc": "vc_roof",
                "desc": "vc_roof",
                "label": 'vc_roof'
            },
            "vc_vc_sun_roof": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_vc_sun_roof",
                "c_rep": "vc_vc_sun_roof",
                "erc": "vc_vc_sun_roof",
                "desc": "vc_vc_sun_roof",
                "label": 'vc_vc_sun_roof'
            },
            "vc_fog_lights": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_fog_lights",
                "c_rep": "vc_fog_lights",
                "erc": "vc_fog_lights",
                "desc": "vc_fog_lights",
                "label": 'vc_fog_lights'
            },
            "vc_left_quarter": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_quarter",
                "c_rep": "vc_left_quarter",
                "erc": "vc_left_quarter",
                "desc": "vc_left_quarter",
                "label": 'vc_left_quarter'
            },
            "vc_right_quarter": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_quarter",
                "c_rep": "vc_right_quarter",
                "erc": "vc_right_quarter",
                "desc": "vc_right_quarter",
                "label": 'vc_right_quarter'
            },
            "vc_trunk": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_trunk",
                "c_rep": "vc_trunk",
                "erc": "vc_trunk",
                "desc": "vc_trunk",
                "label": 'vc_trunk'
            },
            "vc_rare_bumper": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rare_bumper",
                "c_rep": "vc_rare_bumper",
                "erc": "vc_rare_bumper",
                "desc": "vc_rare_bumper",
                "label": 'vc_rare_bumper'
            },
            "vc_petrol_cap": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_petrol_cap",
                "c_rep": "vc_petrol_cap",
                "erc": "vc_petrol_cap",
                "desc": "vc_petrol_cap",
                "label": 'vc_petrol_cap'
            },
            "vc_wind_screen": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_wind_screen",
                "c_rep": "vc_wind_screen",
                "erc": "vc_wind_screen",
                "desc": "vc_wind_screen",
                "label": 'vc_wind_screen'
            },
            "vc_wipers": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_wipers",
                "c_rep": "vc_wipers",
                "erc": "vc_wipers",
                "desc": "vc_wipers",
                "label": 'vc_wipers'
            },
            "vc_backscreen": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_backscreen",
                "c_rep": "vc_backscreen",
                "erc": "vc_backscreen",
                "desc": "vc_backscreen",
                "label": 'vc_backscreen'
            },
            "vc_antenna": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_antenna",
                "c_rep": "vc_antenna",
                "erc": "vc_antenna",
                "desc": "vc_antenna",
                "label": 'vc_antenna'
            },
            "vc_tailer_hitch": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_tailer_hitch",
                "c_rep": "vc_tailer_hitch",
                "erc": "vc_tailer_hitch",
                "desc": "vc_tailer_hitch",
                "label": 'vc_tailer_hitch'
            },
            "vc_tail_lights": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_tail_lights",
                "c_rep": "vc_tail_lights",
                "erc": "vc_tail_lights",
                "desc": "vc_tail_lights",
                "label": 'vc_tail_lights'
            },
            "vc_right_rocker_panel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rocker_panel",
                "c_rep": "vc_right_rocker_panel",
                "erc": "vc_right_rocker_panel",
                "desc": "vc_right_rocker_panel",
                "label": 'vc_right_rocker_panel'
            },
            "vc_radiator_core_support": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_radiator_core_support",
                "c_rep": "vc_radiator_core_support",
                "erc": "vc_radiator_core_support",
                "desc": "vc_radiator_core_support",
                "label": 'Raiator Core Support'
            },
            "vc_right_rear_rail": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_rail",
                "c_rep": "vc_right_rear_rail",
                "erc": "vc_right_rear_rail",
                "desc": "vc_right_rear_rail",
                "label": 'Right Rear Rail'
            },
            "vc_left_front_rail": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_rail",
                "c_rep": "vc_left_front_rail",
                "erc": "vc_left_front_rail",
                "desc": "vc_left_front_railame",
                "label": 'Left Front vc_left_front_rail'
            },
            "vc_left_apron": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_apron",
                "c_rep": "vc_left_apron",
                "erc": "vc_left_apronframe",
                "desc": "vc_left_aproner_frame",
                "label": 'Left vc_left_apron'
            },
            "vc_left_strut_tower_apron": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_strut_tower_apron",
                "c_rep": "vc_left_strut_tower_apron",
                "erc": "vc_left_strut_tower_apron",
                "desc": "vc_left_strut_tower_apron",
                "label": 'Left Strut Tower vc_left_strut_tower_apron'
            },
            "vc_cowl_panel_firewall": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_cowl_panel_firewall",
                "c_rep": "vc_cowl_panel_firewall",
                "erc": "vc_cowl_panel_firewall",
                "desc": "vc_cowl_panel_firewall",
                "label": 'Cowl Panel vc_cowl_panel_firewall'
            },
            "vc_left_a_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_a_pillar",
                "c_rep": "vc_left_a_pillar",
                "erc": "vc_left_a_pillarme",
                "desc": "vc_left_a_pillarframe",
                "label": 'Left A vc_left_a_pillar'
            },
            "vc_left_b_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_b_pillar",
                "c_rep": "vc_left_b_pillar",
                "erc": "vc_left_b_pillarme",
                "desc": "vc_left_b_pillarframe",
                "label": 'Left B vc_left_b_pillar'
            },
            "vc_left_c_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_c_pillar",
                "c_rep": "vc_left_c_pillar",
                "erc": "vc_left_c_pillarme",
                "desc": "vc_left_c_pillarframe",
                "label": 'Left C vc_left_c_pillar'
            },
            "vc_left_d_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_d_pillar",
                "c_rep": "vc_left_d_pillar",
                "erc": "vc_left_d_pillarme",
                "desc": "vc_left_d_pillarframe",
                "label": 'Left D vc_left_d_pillar'
            },
            "vc_right_a_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_a_pillar",
                "c_rep": "vc_right_a_pillar",
                "erc": "vc_right_a_pillare",
                "desc": "vc_right_a_pillarrame",
                "label": 'Right A vc_right_a_pillar'
            },
            "vc_right_b_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_b_pillar",
                "c_rep": "vc_right_b_pillar",
                "erc": "vc_right_b_pillare",
                "desc": "vc_right_b_pillarrame",
                "label": 'Right B vc_right_b_pillar'
            },
            "vc_right_c_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_c_pillar",
                "c_rep": "vc_right_c_pillar",
                "erc": "vc_right_c_pillare",
                "desc": "vc_right_c_pillarrame",
                "label": 'Right C vc_right_c_pillar'
            },
            "vc_right_d_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_d_pillar",
                "c_rep": "vc_right_d_pillar",
                "erc": "vc_right_d_pillare",
                "desc": "vc_right_d_pillarrame",
                "label": 'Right D vc_right_d_pillar'
            },
            "vc_left_rear_rail": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_rail",
                "c_rep": "vc_left_rear_rail",
                "erc": "vc_left_rear_raile",
                "desc": "vc_left_rear_railrame",
                "label": 'Left Rear vc_left_rear_rail'
            },
            "vc_left_rear_lock_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_lock_pillar",
                "c_rep": "vc_left_rear_lock_pillar",
                "erc": "vc_left_rear_lock_pillar",
                "desc": "vc_left_rear_lock_pillar",
                "label": 'Lefr Rear Lock vc_left_rear_lock_pillar'
            },
            "vc_right_rear_lock_pillar": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_lock_pillar",
                "c_rep": "vc_right_rear_lock_pillar",
                "erc": "vc_right_rear_lock_pillar",
                "desc": "vc_right_rear_lock_pillar",
                "label": 'Right Rear Lock vc_right_rear_lock_pillar'
            },
            "vc_right_front_rail": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_rail",
                "c_rep": "vc_right_front_rail",
                "erc": "vc_right_front_rail",
                "desc": "vc_right_front_railme",
                "label": 'Right Front vc_right_front_rail'
            },
            "vc_right_apron": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_apron",
                "c_rep": "vc_right_apron",
                "erc": "vc_right_apronrame",
                "desc": "vc_right_apronr_frame",
                "label": 'Right vc_right_apron'
            },
            "vc_right_strut_tower_apron": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_strut_tower_apron",
                "c_rep": "vc_right_strut_tower_apron",
                "erc": "vc_right_strut_tower_apron",
                "desc": "vc_right_strut_tower_apron",
                "label": 'Right Strut Tower vc_right_strut_tower_apron'
            },
            "vc_floor_pans": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_floor_pans",
                "c_rep": "vc_floor_pans",
                "erc": "vc_floor_pansframe",
                "desc": "vc_floor_panser_frame",
                "label": 'Floor vc_floor_pans'
            },
            "vc_left_rear_wheel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_wheel",
                "c_rep": "vc_left_rear_wheel",
                "erc": "vc_left_rear_wheel",
                "desc": "vc_left_rear_wheelame",
                "label": 'vc_left_rear_wheel'
            },
            "vc_right_rear_wheel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_wheel",
                "c_rep": "vc_right_rear_wheel",
                "erc": "vc_right_rear_wheel",
                "desc": "vc_right_rear_wheelme",
                "label": 'vc_right_rear_wheel'
            },
            "vc_exhaust": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_exhaust",
                "c_rep": "vc_exhaust",
                "erc": "vc_exhauster_frame",
                "desc": "vc_exhaustmeter_frame",
                "label": 'vc_exhaust'
            },
            "vc_rear_axle": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rear_axle",
                "c_rep": "vc_rear_axle",
                "erc": "vc_rear_axle_frame",
                "desc": "vc_rear_axleter_frame",
                "label": 'vc_rear_axle'
            },
            "vc_rear_shocks": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rear_shocks",
                "c_rep": "vc_rear_shocks",
                "erc": "vc_rear_shocksrame",
                "desc": "vc_rear_shocksr_frame",
                "label": 'vc_rear_shocks'
            },
            "vc_emissions": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_emissions",
                "c_rep": "vc_emissions",
                "erc": "vc_emissions_frame",
                "desc": "vc_emissionster_frame",
                "label": 'vc_emissions'
            },
            "vc_left_front_wheel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_wheel",
                "c_rep": "vc_left_front_wheel",
                "erc": "vc_left_front_wheel",
                "desc": "vc_left_front_wheelme",
                "label": 'vc_left_front_wheel'
            },
            "vc_right_front_wheel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_wheel",
                "c_rep": "vc_right_front_wheel",
                "erc": "vc_right_front_wheel",
                "desc": "vc_right_front_wheele",
                "label": 'vc_right_front_wheel'
            },
            "vc_transmission": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_transmission",
                "c_rep": "vc_transmission",
                "erc": "vc_transmissioname",
                "desc": "vc_transmission_frame",
                "label": 'vc_transmission'
            },
            "vc_engine": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_engine",
                "c_rep": "vc_engine",
                "erc": "vc_engineter_frame",
                "desc": "vc_engineimeter_frame",
                "label": 'vc_engine'
            },
            "vc_front_shocks": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_front_shocks",
                "c_rep": "vc_front_shocks",
                "erc": "vc_front_shocksame",
                "desc": "vc_front_shocks_frame",
                "label": 'vc_front_shocks'
            },
            "vc_left_front_door_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_door_mechanics",
                "c_rep": "vc_left_front_door_mechanics",
                "erc": "vc_left_front_door_mechanics",
                "desc": "vc_left_front_door_mechanics",
                "label": 'vc_left_front_door_mechanics'
            },
            "vc_left_front_win_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_win_mechanics",
                "c_rep": "vc_left_front_win_mechanics",
                "erc": "vc_left_front_win_mechanics",
                "desc": "vc_left_front_win_mechanics",
                "label": 'vc_left_front_win_mechanics'
            },
            "vc_left_rear_win_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_win_mechanics",
                "c_rep": "vc_left_rear_win_mechanics",
                "erc": "vc_left_rear_win_mechanics",
                "desc": "vc_left_rear_win_mechanics",
                "label": 'vc_left_rear_win_mechanics'
            },
            "vc_left_rear_door_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_door_mechanics",
                "c_rep": "vc_left_rear_door_mechanics",
                "erc": "vc_left_rear_door_mechanics",
                "desc": "vc_left_rear_door_mechanics",
                "label": 'vc_left_rear_door_mechanics'
            },
            "vc_rear_brakes": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rear_brakes",
                "c_rep": "vc_rear_brakes",
                "erc": "vc_rear_brakesrame",
                "desc": "vc_rear_brakesr_frame",
                "label": 'vc_rear_brakes'
            },
            "vc_electrics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_electrics",
                "c_rep": "vc_electrics",
                "erc": "vc_electrics_frame",
                "desc": "vc_electricster_frame",
                "label": 'vc_electrics'
            },
            "vc_climate_control": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_climate_control",
                "c_rep": "vc_climate_control",
                "erc": "vc_climate_control",
                "desc": "vc_climate_controlame",
                "label": 'vc_climate_control'
            },
            "vc_power_steering": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_power_steering",
                "c_rep": "vc_power_steering",
                "erc": "vc_power_steeringe",
                "desc": "vc_power_steeringrame",
                "label": 'vc_power_steering'
            },
            "vc_clutch": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_clutch",
                "c_rep": "vc_clutch",
                "erc": "vc_clutchter_frame",
                "desc": "vc_clutchimeter_frame",
                "label": 'vc_clutch'
            },
            "vc_front_brakes": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_front_brakes",
                "c_rep": "vc_front_brakes",
                "erc": "vc_front_brakesame",
                "desc": "vc_front_brakes_frame",
                "label": 'vc_front_brakes'
            },
            "vc_battery": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_battery",
                "c_rep": "vc_battery",
                "erc": "vc_batteryer_frame",
                "desc": "vc_batterymeter_frame",
                "label": 'vc_battery'
            },
            "vc_right_front_win_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_win_mechanics",
                "c_rep": "vc_right_front_win_mechanics",
                "erc": "vc_right_front_win_mechanics",
                "desc": "vc_right_front_win_mechanics",
                "label": 'vc_right_front_win_mechanics'
            },
            "vc_right_rear_win_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_win_mechanics",
                "c_rep": "vc_right_rear_win_mechanics",
                "erc": "vc_right_rear_win_mechanics",
                "desc": "vc_right_rear_win_mechanics",
                "label": 'vc_right_rear_win_mechanics'
            },
            "vc_right_front_door_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_door_mechanics",
                "c_rep": "vc_right_front_door_mechanics",
                "erc": "vc_right_front_door_mechanics",
                "desc": "vc_right_front_door_mechanics",
                "label": 'vc_right_front_door_mechanics'
            },
            "vc_right_rear_door_mechanics": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_door_mechanics",
                "c_rep": "vc_right_rear_door_mechanics",
                "erc": "vc_right_rear_door_mechanics",
                "desc": "vc_right_rear_door_mechanics",
                "label": 'vc_right_rear_door_mechanics'
            },
            "vc_front_axle": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_front_axle",
                "c_rep": "vc_front_axle",
                "erc": "vc_front_axleframe",
                "desc": "vc_front_axleer_frame",
                "label": 'vc_front_axle'
            },
            "vc_val_left_front_wheel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_val_left_front_wheel",
                "c_rep": "vc_val_left_front_wheel",
                "erc": "vc_val_left_front_wheel",
                "desc": "vc_val_left_front_wheel",
                "label": 'vc_val_left_front_wheel'
            },
            "vc_warning_lights": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_warning_lights",
                "c_rep": "vc_warning_lights",
                "erc": "vc_warning_lightse",
                "desc": "vc_warning_lightsrame",
                "label": 'vc_warning_lights'
            },
            "vc_tools": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_tools",
                "c_rep": "vc_tools",
                "erc": "vc_toolseter_frame",
                "desc": "vc_toolsrimeter_frame",
                "label": 'vc_tools'
            },
            "vc_spare_tyre": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_spare_tyre",
                "c_rep": "vc_spare_tyre",
                "erc": "vc_spare_tyreframe",
                "desc": "vc_spare_tyreer_frame",
                "label": 'vc_spare_tyre'
            },
            "vc_fuel_tank": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_fuel_tank",
                "c_rep": "vc_fuel_tank",
                "erc": "vc_fuel_tank",
                "desc": "vc_fuel_tank",
                "label": 'vc_fuel_tank'
            },
            "vc_perimeter_frame" : {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_perimeter_frame",
                "c_rep": "vc_perimeter_frame",
                "erc": "vc_perimeter_frame",
                "desc": "vc_perimeter_frame",
                "label": 'vc_fuel_tank'
            },
            "vc_interior_parts": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_interior_parts",
                "c_rep": "vc_interior_parts",
                "erc": "vc_interior_parts",
                "desc": "vc_interior_parts",
                "label": 'vc_interior_parts'
            },
            "vc_rear_mirror": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_rear_mirror",
                "c_rep": "vc_rear_mirror",
                "erc": "vc_rear_mirror",
                "desc": "vc_rear_mirror",
                "label": 'vc_rear_mirror'
            },
            "vc_gauges": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_gauges",
                "c_rep": "vc_gauges",
                "erc": "vc_gauges",
                "desc": "vc_gauges",
                "label": 'vc_gauges'
            },
            "vc_left_front_door_panel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_door_panel",
                "c_rep": "vc_left_front_door_panel",
                "erc": "vc_left_front_door_panel",
                "desc": "vc_left_front_door_panel",
                "label": 'vc_left_front_door_panel'
            },
            "vc_left_rear_door_panel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_door_panel",
                "c_rep": "vc_left_rear_door_panel",
                "erc": "vc_left_rear_door_panel",
                "desc": "vc_left_rear_door_panel",
                "label": 'vc_left_rear_door_panel'
            },
            "vc_headliner": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_headliner",
                "c_rep": "vc_headliner",
                "erc": "vc_headliner",
                "desc": "vc_headliner",
                "label": 'vc_headliner'
            },
            "vc_dash": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_dash",
                "c_rep": "vc_dashll",
                "erc": "vc_dash",
                "desc": "vc_dash",
                "label": 'vc_dash'
            },
            "vc_right_front_door_panel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_door_panel",
                "c_rep": "vc_right_front_door_panel",
                "erc": "vc_right_front_door_panel",
                "desc": "vc_right_front_door_panel",
                "label": 'vc_right_front_door_panel'
            },
            "vc_console": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_console",
                "c_rep": "vc_console",
                "erc": "vc_console",
                "desc": "vc_console",
                "label": 'vc_console'
            },
            "vc_lamp": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_lamp",
                "c_rep": "vc_lampll",
                "erc": "vc_lamp",
                "desc": "vc_lamp",
                "label": 'vc_lamp'
            },
            "vc_right_rear_door_panel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_door_panel",
                "c_rep": "vc_right_rear_door_panel",
                "erc": "vc_right_rear_door_panel",
                "desc": "vc_right_rear_door_panel",
                "label": 'vc_right_rear_door_panel'
            },
            "vc_glovebox": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_glovebox",
                "c_rep": "vc_glovebox",
                "erc": "vc_glovebox",
                "desc": "vc_glovebox",
                "label": 'vc_glovebox'
            },
            "vc_shift_knob": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_shift_knob",
                "c_rep": "vc_shift_knob",
                "erc": "vc_shift_knob",
                "desc": "vc_shift_knob",
                "label": 'vc_shift_knob'
            },
            "vc_left_front_carpet": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_carpet",
                "c_rep": "vc_left_front_carpet",
                "erc": "vc_left_front_carpet",
                "desc": "vc_left_front_carpet",
                "label": 'vc_left_front_carpet'
            },
            "vc_right_front_carpet": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_carpet",
                "c_rep": "vc_right_front_carpet",
                "erc": "vc_right_front_carpet",
                "desc": "vc_right_front_carpet",
                "label": 'vc_right_front_carpet'
            },
            "vc_steering_wheel": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_steering_wheel",
                "c_rep": "vc_steering_wheel",
                "erc": "vc_steering_wheel",
                "desc": "vc_steering_wheel",
                "label": 'vc_steering_wheel'
            },
            "vc_airbag": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_airbag",
                "c_rep": "vc_airbag",
                "erc": "vc_airbag",
                "desc": "vc_airbag",
                "label": 'vc_airbag'
            },
            "vc_right_front_seat": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_front_seat",
                "c_rep": "vc_right_front_seat",
                "erc": "vc_right_front_seat",
                "desc": "vc_right_front_seat",
                "label": 'vc_right_front_seat'
            },
            "vc_left_front_seat": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_front_seat",
                "c_rep": "vc_left_front_seat",
                "erc": "vc_left_front_seat",
                "desc": "vc_left_front_seat",
                "label": 'vc_left_front_seat'
            },
            "vc_left_rear_seat": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_seat",
                "c_rep": "vc_left_rear_seat",
                "erc": "vc_left_rear_seat",
                "desc": "vc_left_rear_seat",
                "label": 'vc_left_rear_seat'
            },
            "vc_right_rear_seat": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_seat",
                "c_rep": "vc_right_rear_seat",
                "erc": "vc_right_rear_seat",
                "desc": "vc_right_rear_seat",
                "label": 'vc_right_rear_seat'
            },
            "vc_audio": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_audio",
                "c_rep": "vc_audiol",
                "erc": "vc_audio",
                "desc": "vc_audio",
                "label": 'vc_audio'
            },
            "vc_2nd_row_console": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_2nd_row_console",
                "c_rep": "vc_2nd_row_console",
                "erc": "vc_2nd_row_console",
                "desc": "vc_2nd_row_console",
                "label": 'vc_2nd_row_console'
            },
            "vc_left_rear_carpet": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_left_rear_carpet",
                "c_rep": "vc_left_rear_carpet",
                "erc": "vc_left_rear_carpet",
                "desc": "vc_left_rear_carpet",
                "label": 'vc_left_rear_carpet'
            },
            "vc_right_rear_carpet": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_right_rear_carpet",
                "c_rep": "vc_right_rear_carpet",
                "erc": "vc_right_rear_carpet",
                "desc": "vc_right_rear_carpet",
                "label": 'vc_right_rear_carpet'
            },
            "vc_third_row_seat": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_third_row_seat",
                "c_rep": "vc_third_row_seat",
                "erc": "vc_third_row_seat",
                "desc": "vc_third_row_seat",
                "label": 'vc_third_row_seat'
            },
            "vc_odor": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_odor",
                "c_rep": "vc_odorll",
                "erc": "vc_odor",
                "desc": "vc_odor",
                "label": 'vc_odor'
            },
            "vc_manuals": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_manuals",
                "c_rep": "vc_manuals",
                "erc": "vc_manuals",
                "desc": "vc_manuals",
                "label": 'vc_manuals'
            },
            "vc_features": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_features",
                "c_rep": "vc_features",
                "erc": "vc_features",
                "desc": "vc_features",
                "label": 'vc_features'
            },
            "vc_fourth_row_seat": {
                "rating": "5.0",
                "severity": "5.0",
                "cor": "vc_fourth_row_seat",
                "c_rep": "vc_fourth_row_seat",
                "erc": "vc_fourth_row_seat",
                "desc": "vc_fourth_row_seat",
                "label": 'vc_fourth_row_seat'
            }
        };
        var check_attributes = function (object, attribute) {
            return (typeof(object.attr(attribute)) !== typeof undefined);
        };
        var copy_original_params = function () {
            $('.hover-able').each(function (index, value) {
                var obj = $(this);
                var obj_id;
                if (check_attributes(obj, 'stroke')) {
                    obj.attr('data-ori-stroke', obj.attr('stroke'))
                }
                if (check_attributes(obj, 'fill')) {
                    obj.attr('data-ori-fill', obj.attr('fill'));
                }
            });

           
            $('.svg-container').each(function () {
                $('tspan', this).attr('fill', "#4E4E4E");
            })
        };
        var svg_container_hover = function () {
            $('.svg-container').hover(mouse_enter, mouse_leave);
        };
        var mouse_enter = function () {
            var obj = $(this);
            var objScnd = $('.hover-able', this);
            set_part_details(obj);
            
            if (obj.is('.hover-able')) {
                $(this).attr({'stroke': hoverColorStroke, 'fill': hoverColorFill});
            }
            objScnd.attr({'stroke': hoverColorStroke, 'fill': hoverColorFill});
            if (obj.data('img') != "") {
                $('.part-detail > .part-img > img').attr('src', $("#hdnUrl").val()+ obj.data('img'));
            }
            else {
                $('.part-detail > .part-img > img').attr('src', '/assets/images/no_img.png');
            }
           
            assign_color(obj);
        };
        var mouse_leave = function () {
            var obj = $(this);
            unset_part_details();
            assign_color(obj);
            $('.part-detail > .part-img > img').attr('src', '/assets/images/no_img.png');
            assign_initial_color(obj);
        };
        var update_part_params = function () {
            $('#done').click(function () {
                var part_id_val = $('.part_id').val();
                var obj = $('#' + part_id_val);
                params[part_id_val]['rating'] = $('c_rate').val();
                params[part_id_val]['severity'] = $('#severity').val();
                params[part_id_val]['cor'] = $('#cor').val();
                params[part_id_val]['c_rep'] = $('#c_rep').val();
                params[part_id_val]['erc'] = $('#erc').val();
                params[part_id_val]['desc'] = $('#desc').val();
                $('#part_id').val('');
                $('#part-preview').html('');
                $(this).closest('#field-box-container').fadeOut('400');
                //update_avg();
                assign_color(obj);
            });
        };
        var assign_initial_color = function (object) {
            var obj_id = object.attr('id');
            var strokeColor = 'initial';
            var fillColor = 'initial';
            if (object.is('.hover-able')) {
                if (check_attributes(object, 'fill')) {
                    $('#' + obj_id).attr('fill', fillColor == 'initial' ? $('#' + obj_id).attr('data-ori-fill') : fillColor);
                }
            }

            $('#' + obj_id).find('.hover-able').not("tspan").each(function (index, value) {
                objScnd = $(this);

                if (check_attributes(objScnd, 'fill')) {
                    objScnd.attr('fill', fillColor == 'initial' ? objScnd.attr('data-ori-fill') : fillColor);
                }
            });
        };
        var assign_color = function (object) {
            var obj_id = object.attr('id');
            var objScnd;
            var strokeColor = '#f37b2e';
            var fillColor = '#f37b2e';
            //var field_value = parseFloat($('#' + obj_id).data('sv'));
            //if (field_value <= 2.0) {
            //    strokeColor = '#ffff00';
            //    fillColor = '#ffff00';
            //}
            //else if (field_value > 2.0 && field_value <= 4.0) {
            //    strokeColor = '#ffd40c';
            //    fillColor = '#ffd40c';
            //}
            //else if (field_value > 4.0 && field_value <= 6.0) {
            //    strokeColor = '#ff8c00';
            //    fillColor = '#ff8c00';
            //}
            //else if (field_value > 6.0 && field_value <= 8.0) {
            //    strokeColor = '#ff4500';
            //    fillColor = '#ff4500';
            //}
            //else if (field_value > 8.0 && field_value < 10.0) {
            //    strokeColor = '#ff0000';
            //    fillColor = '#ff0000';
            //}
            //else if (field_value == 10.0) {
            //    strokeColor = 'initial';
            //    fillColor = 'initial';
            //}

            if (object.is('.hover-able')) {
                // if (check_attributes(object, 'stroke')) {
                //     $('#' + obj_id).attr('stroke', strokeColor == 'initial' ? $('#' + obj_id).attr('data-ori-stroke') : strokeColor);
                // }
                if (check_attributes(object, 'fill')) {
                    $('#' + obj_id).attr('fill', fillColor == 'initial' ? $('#' + obj_id).attr('data-ori-fill') : fillColor);
                }
            }

            $('#' + obj_id).find('.hover-able').not("text").each(function (index, value) {
                objScnd = $(this);
                // if (check_attributes(objScnd, 'stroke')) {
                //     objScnd.attr('stroke', strokeColor == 'initial' ? objScnd.attr('data-ori-stroke') : strokeColor);
                // }
                if (check_attributes(objScnd, 'fill')) {
                    objScnd.attr('fill', fillColor == 'initial' ? objScnd.attr('data-ori-fill') : fillColor);
                }
            });
        };
        var svg_tab_click = function () {
            $('.svg-tab-btn').on('click', function () {
                var data_target = $(this).attr('data-target');
                $('.svg-tab-btn.active').removeClass('active');
                $(this).addClass('active');
                $('.svg-tab.active').removeClass('active');
                $(data_target).addClass('active');
                $(data_target + '_head').addClass('active');
            });
        };
        var set_part_details = function (object) {
            var obj_id = object.attr('id');
            var part_params = params[obj_id];
            var part_detail_obj = $('.part_detail');
            $('.part_title .value', part_detail_obj).html(object.data('partname'));
            if (object.data('cr') != "" && object.data('cr') != "Please Select") {
                $('.part_condition .value', part_detail_obj).html(object.data('cr'));
            }
            else {
                $('.part_condition .value', part_detail_obj).html("N/A");
            }
            $('.part_severity .value', part_detail_obj).html(object.data('sv'));
            $('.part_desc .value', part_detail_obj).html(object.data('des'));
            $('.part_cor .value', part_detail_obj).html(object.data('cor'));
            $('.part_c_rep .value', part_detail_obj).html(object.data('corp'));
            $('.part_ecr .value', part_detail_obj).html(object.data('esr'));
        };
        var unset_part_details = function () {
            var part_detail_obj = $('.part_detail');
            $('.part_title .value', part_detail_obj).html('N/A');
            $('.part_condition .value', part_detail_obj).html('N/A');
            $('.part_severity .value', part_detail_obj).html('N/A');
            $('.part_desc .value', part_detail_obj).html('N/A');
            $('.part_cor .value', part_detail_obj).html('N/A');
            $('.part_c_rep .value', part_detail_obj).html('N/A');
            $('.part_ecr .value', part_detail_obj).html('N/A');
        };
        var chart_init = function () {
            generateCircle('#progress-circle-ex', $('#progress-circle-ex').data('rating-value'));
            generateCircle('#progress-circle-in', $('#progress-circle-in').data('rating-value'));
            generateCircle('#progress-circle-mec', $('#progress-circle-mec').data('rating-value'));
            generateCircle('#progress-circle-fr', $('#progress-circle-fr').data('rating-value'));
        };
        var generateCircle = function(selector, rating_value) {
            $(selector).circleProgress({
                value: rating_value / 5,
                size: 75,
                startAngle: Math.PI * 1.5,
                fill: {
                    gradient: ["red", "orange"]
                }
            }).on('circle-animation-progress', function (event, progress) {
                $(this).find('strong').html((rating_value * progress).toFixed(1) + '<i></i>');
            });
        };
        return function () {
            copy_original_params();
            svg_container_hover();
            update_part_params();
            svg_tab_click();
            chart_init();
        }
    };
    var init = svg_script();
    init();
    $('body').on('click', '.img-focusable', function () {
        $('.img-pop img').attr('src', $(this).attr('src'));
        $('.img-pop-container').fadeIn(100);
    });

    $('.img-pop-container').on('click', function () {
        $(this).fadeOut(100);
    });
    $('.fa.fa-qrcode').closest('.btn').on('click', function () {
        $('.qr-pop-up').fadeIn(200);
        event.stopPropagation();
    });

    $(document).on('click', function () {
        if ($('.qr-pop-up').is(':visible')) {
            $('.qr-pop-up').fadeOut(200)
        }
    });
});