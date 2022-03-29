/*:
 * @plugindesc Mastermind - Minigame
 *
 * @author ImInneren
 *
 * @param Game_Runs_Switch
 * @desc Switch-Index, read "how-to-use".
 * @default 1
 *
 * @param Win_Yes_No_Switch
 * @desc Switch-Index, OFF: Lost, ON: Won
 * @default 2
 *
 * @help Mastermind - Minigame
 * Try to crack the random color code!
 * First choose a code with 4 spheres out of
 * 6 colors. Then test, if you hit the exact
 * code. If not, pins will help you!
 * Dark Pin: One Sphere have the right place
 * and color!
 * Bright Pin: One Sphere have the right color!
 * Now test your mind in "Mastermind" by
 * --> ImInneren <-- 
 */

var parameters = PluginManager.parameters('Mastermind_ImInneren');
var game_runs = Number(parameters['Game_Runs_Switch'] || 1);
var win_lost = Number(parameters['Win_Yes_No_Switch'] || 2);

var code = new Array("", "", "", "");
var position = 0;
var count_trys = 0;

var sphere_pos1;
var sphere_pos2;

var bet_spheres = new Array("mm_sphere_black", "mm_sphere_black", "mm_sphere_black", "mm_sphere_black");
var spheres_trys = [];
spheres_trys[1] = new Array();
spheres_trys[2] = new Array();
spheres_trys[3] = new Array();
spheres_trys[4] = new Array();
spheres_trys[5] = new Array();
spheres_trys[6] = new Array();
spheres_trys[7] = new Array();
spheres_trys[8] = new Array();
spheres_trys[9] = new Array();
spheres_trys[10] = new Array();

function rndm_spheres(){
	var ran = Math.random();
	var ret;

	if(ran < 0.166){
		ret = "mm_sphere_black";
	}else if(ran < 0.332){
		ret = "mm_sphere_blue";
	}else if(ran < 0.5){
		ret = "mm_sphere_green";
	}else if(ran < 0.666){
		ret = "mm_sphere_purple";
	}else if(ran < 0.832){
		ret = "mm_sphere_red";
	}else{
		ret = "mm_sphere_yellow";
	}
	
	return ret;
}

function sphere_pos_act(){
	var sphere_pos1 = position;
	var sphere_pos2 = 4 - position;

	$gameScreen.rotatePicture((position + 14), 1.5);

	while(sphere_pos1 > 0){
		$gameScreen.rotatePicture((position + 14 - sphere_pos1), 0);
		$gameScreen._pictures[position + 14 - sphere_pos1]._angle = 0;
		sphere_pos1--;
	}

	while(sphere_pos2 > 0){
		$gameScreen.rotatePicture((position + 14 + sphere_pos2), 0);
		$gameScreen._pictures[position + 14 + sphere_pos2]._angle = 0;
		sphere_pos2--;
	}
}

function color_check_up(){

	var color = bet_spheres[position];

	switch(color){

		case "mm_sphere_black":
			color = "mm_sphere_blue";
			break;
		case "mm_sphere_blue":
			color = "mm_sphere_green";
			break;
		case "mm_sphere_green":
			color = "mm_sphere_purple";
			break;
		case "mm_sphere_purple":
			color = "mm_sphere_red";
			break;
		case "mm_sphere_red":
			color = "mm_sphere_yellow";
			break;
		case "mm_sphere_yellow":
			color = "mm_sphere_black";
			break;
	}

	return color;
}

function color_check_down(){

	var color = bet_spheres[position];

	switch(color){

		case "mm_sphere_yellow":
			color = "mm_sphere_red";
			break;
		case "mm_sphere_red":
			color = "mm_sphere_purple";
			break;
		case "mm_sphere_purple":
			color = "mm_sphere_green";
			break;
		case "mm_sphere_green":
			color = "mm_sphere_blue";
			break;
		case "mm_sphere_blue":
			color = "mm_sphere_black";
			break;
		case "mm_sphere_black":
			color = "mm_sphere_yellow";
			break;
	}

	return color;
}

function pic_trys(){
	var ret;
	switch(count_trys){
		case 1:
			ret = 20;
			break;
		case 2:
			ret = 24;
			break;
		case 3:
			ret = 28;
			break;
		case 4:
			ret = 32;
			break;
		case 5:
			ret = 36;
			break;
		case 6:
			ret = 40;
			break;
		case 7:
			ret = 44;
			break;
		case 8:
			ret = 48;
			break;
		case 9:
			ret = 52;
			break;
		case 10:
			ret = 56;
			break;
	}

	return ret;
}

var event_listener = function(){  	

	if(event.keyCode == 39){
		if(position == 4){
			position = 0;
		}else{
			position++;
		}
	}
		if(event.keyCode == 37){
		if(position == 0){
			position = 4;
		}else{
			position--;
		}
	}
 
	if(event.keyCode == 38){
		if(position != 4){
			bet_spheres[position] = color_check_up();
			$gameScreen._pictures[position + 14]._name = bet_spheres[position];
			}else{
			}
	}
		if(event.keyCode == 40){
		if(position != 4){
			bet_spheres[position] = color_check_down();
			$gameScreen._pictures[position + 14]._name = bet_spheres[position];
		}else{
		}
	}

	if(event.keyCode == 13){
		if(position == 4){

			var code_copy = new Array("", "", "", "");
			var bet_spheres_copy = new Array("", "", "", "");
			var bright_pin = 0;
			var dark_pin = 0;

			for(i = 0; i <= 3; i++){
				code_copy[i] = code[i];
				bet_spheres_copy[i] = bet_spheres[i];
			}
		
			spheres_trys[count_trys].push(bet_spheres[0]);
			spheres_trys[count_trys].push(bet_spheres[1]);
			spheres_trys[count_trys].push(bet_spheres[2]);
			spheres_trys[count_trys].push(bet_spheres[3]);
			$gameScreen.showPicture(pic_trys(), spheres_trys[count_trys][0], 1, 72, (91 + ((11 - count_trys) * 48)), 50, 50, 255, 0);
			$gameScreen.showPicture((pic_trys() + 1), spheres_trys[count_trys][1], 1, 120, (91 + ((11 - count_trys) * 48)), 50, 50, 255, 0);
			$gameScreen.showPicture((pic_trys() + 2), spheres_trys[count_trys][2], 1, 168, (91 + ((11 - count_trys) * 48)), 50, 50, 255, 0);
			$gameScreen.showPicture((pic_trys() + 3), spheres_trys[count_trys][3], 1, 212, (91 + ((11 - count_trys) * 48)), 50, 50, 255, 0);
		
			for(i = 0; i < 4; i++){
				if(bet_spheres_copy[i] == code_copy[i]){
					dark_pin++;
					code_copy[i] = "used";
					bet_spheres_copy[i] = "gone";
				}else{
				}
			}
		
			for(i = 0; i < 4; i++){
				if(bet_spheres_copy[i] == code_copy[0]){
					bright_pin++;
					code_copy[0] = "used";
				}else if(bet_spheres_copy[i] == code_copy[1]){
					bright_pin++;
					code_copy[1] = "used";
				}else if(bet_spheres_copy[i] == code_copy[2]){
					bright_pin++;
					code_copy[2] = "used";
				}else if(bet_spheres_copy[i] == code_copy[3]){
					bright_pin++;
					code_copy[3] = "used";
				}else{
				}
			}
			
			var copy1 = bright_pin;
			var copy2 = dark_pin;
				
			while(bright_pin >= 1){
				$gameScreen.showPicture((pic_trys() + 39 + dark_pin + bright_pin), "mm_pin_bright", 1, (350 - (bright_pin * 24)), (96 + ((11 - count_trys) * 48)), 100, 100, 255, 0);
				bright_pin--;
			}
			while(dark_pin >= 1){
				$gameScreen.showPicture((pic_trys() + 39 + dark_pin), "mm_pin_dark", 1, (350 - (dark_pin * 24) - (copy1 * 24)), (96 + ((11 - count_trys) * 48)), 100, 100, 255, 0);
				dark_pin--;
			}
			
			bright_pin = 0;
			dark_pin = 0;
			count_trys++;
		}else{
		}
		
		if(copy2 == 4){
			$gameSwitches.setValue(win_lost, true);
			$gameSwitches.setValue(game_runs, true);
			window.removeEventListener("keydown", event_listener);
			$gameScreen.movePicture(5, 0, 432, 625, 60, 60, 255, 0, 240);

			for(i = 1; i < 11; i++){
				spheres_trys[i].length = 0;
			}

		}else if(count_trys == 11 && copy2 != 4){
			$gameSwitches.setValue(win_lost, false);
			$gameSwitches.setValue(game_runs, true);
			window.removeEventListener("keydown", event_listener);
			$gameScreen.movePicture(5, 0, 432, 625, 60, 60, 255, 0, 240);

			for(i = 1; i < 11; i++){
				spheres_trys[i].length = 0;
			}
		}
	}

	sphere_pos_act();
}   

var aliasPluginCommand = Game_Interpreter.prototype.pluginCommand;

Game_Interpreter.prototype.pluginCommand = function(command, args){

	aliasPluginCommand.call(this, command, args);

	if(command == 'mm_init'){

		$gameSwitches.setValue(win_lost, false);
		$gameSwitches.setValue(game_runs, false);
		count_trys = 1;
		position = 0;

		for(i = 0; i <= 3; i++){
			code[i] = rndm_spheres();
			bet_spheres[i] = "mm_sphere_black";
		}
	
		$gameScreen.showPicture(5, "mm_hidebar", 0, 432, 456, 100, 100, 255, 0);
		$gameScreen.showPicture(1, code[0], 1, 480, 504, 100, 100, 255, 0);
		$gameScreen.showPicture(2, code[1], 1, 576, 504, 100, 100, 255, 0);
		$gameScreen.showPicture(3, code[2], 1, 672, 504, 100, 100, 255, 0);
		$gameScreen.showPicture(4, code[3], 1, 768, 504, 100, 100, 255, 0);

		$gameScreen.showPicture(6, "mm_arrow", 1, 456, 240, 100, 100, 255, 0);
		$gameScreen.showPicture(7, "mm_arrow", 1, 528, 240, 100, 100, 255, 0);
		$gameScreen.showPicture(8, "mm_arrow", 1, 600, 240, 100, 100, 255, 0);
		$gameScreen.showPicture(9, "mm_arrow", 1, 672, 240, 100, 100, 255, 0);
	
		$gameScreen.showPicture(10, "mm_arrow", 1, 456, 384, 100, 100, 255, 0);
		$gameScreen._pictures[10]._angle = 180;
		$gameScreen.showPicture(11, "mm_arrow", 1, 528, 384, 100, 100, 255, 0);
		$gameScreen._pictures[11]._angle = 180;
		$gameScreen.showPicture(12, "mm_arrow", 1, 600, 384, 100, 100, 255, 0);
		$gameScreen._pictures[12]._angle = 180;
		$gameScreen.showPicture(13, "mm_arrow", 1, 672, 384, 100, 100, 255, 0);
		$gameScreen._pictures[13]._angle = 180;

		$gameScreen.showPicture(18, "mm_button", 1, 768, 312, 100, 100, 255, 0);

		$gameScreen.showPicture(14, "mm_sphere_black", 1, 456, 312, 100, 100, 255, 0);
		$gameScreen.showPicture(15, "mm_sphere_black", 1, 528, 312, 100, 100, 255, 0);
		$gameScreen.showPicture(16, "mm_sphere_black", 1, 600, 312, 100, 100, 255, 0);
		$gameScreen.showPicture(17, "mm_sphere_black", 1, 672, 312, 100, 100, 255, 0);
		sphere_pos_act();
	}
	if(command == 'mm_start'){
		window.addEventListener("keydown", event_listener);
	}

    if(command == 'mm_clear'){
    	$gameScreen.clearPictures();
    }
}